using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace RemoteKQ
{
    public partial class FrmMain : Form
    {
        #region 全局变量
        /// <summary>
        /// 数据集
        /// </summary>
        private Data Data;

        /// <summary>
        /// 存档目录
        /// </summary>
        private string dirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NeusoftKQ");

        /// <summary>
        /// 存档文件
        /// </summary>
        private string filePath = Path.Combine(new string[] { Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NeusoftKQ", "save.json" });

        /// <summary>
        /// cookie集合
        /// </summary>
        private CookieContainer cookieContainer = new CookieContainer();
        #endregion

        #region 方法
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 工具方法 GET
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string WebGet(string url)
        {
            string result = string.Empty;
            var request = WebRequest.Create(url) as HttpWebRequest;

            //请求HEADER
            request.UserAgent = this.Data.UserAgent;
            request.CookieContainer = this.cookieContainer;

            //获取返回字符串
            using (var sw = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8))
            {
                return sw.ReadToEnd();
            }
        }

        /// <summary>
        /// 工具方法POST
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        private string WebPost(string url, string postData)
        {
            //MessageBox.Show(postData);
            var bytes = Encoding.UTF8.GetBytes(postData);

            var request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = @"application/x-www-form-urlencoded";
            request.CookieContainer = this.cookieContainer;
            request.UserAgent = this.Data.UserAgent;

            request.ContentLength = bytes.Length;
            var stream = request.GetRequestStream();
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();

            var res = request.GetResponse() as HttpWebResponse;
            using (var sr = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                return sr.ReadToEnd();
            }
        }


        /// <summary>
        /// 保存数据方法
        /// </summary>
        private void SaveData()
        {
            this.Data.UserName = this.txtUserID.Text;
            if (Directory.Exists(dirPath) == false)
            {
                Directory.CreateDirectory(dirPath);
            }

            this.Data.Cookies = new List<Cookie>();
            this.Data.Cookies.AddRange(GetCookies());
            File.WriteAllText(filePath, JsonConvert.SerializeObject(this.Data));
        }

        /// <summary>
        /// 载入数据
        /// </summary>
        private void LoadData()
        {
            if (File.Exists(this.filePath) == false)
            {
                InitData();
                return;
            }

            var json = File.ReadAllText(this.filePath);
            try
            {
                this.Data = JsonConvert.DeserializeObject<Data>(json);
                foreach (var cookie in this.Data.Cookies)
                {
                    this.cookieContainer.Add(cookie);
                }
                this.txtSelectedLocation.Text = this.Data.LocationStr;
                this.txtUserID.Text = this.Data.UserName;
                this.timeMorning.Value = this.Data.MorningTime;
                this.timeEvening.Value = this.Data.EveningTime;
                this.txtRandMin.Value = this.Data.RandMin;
                this.txtUserAgent.Text = this.Data.UserAgent;

                json = this.WebGet($"https://sacasnap.neusoft.com/co/mobile/user/obtain?userId={this.Data.UserName}");
                if (JToken.Parse(json)["code"].ToString() != "0")
                {
                    MessageBox.Show("登录已失效，请重新登录");
                    GetCaptcha();
                }
                else
                {
                    GetKQTimeTable();
                }
            }
            catch
            {
                InitData();
            }
        }

        /// <summary>
        /// 获取登录信息列表
        /// </summary>
        private void GetKQTimeTable()
        {
            var orderList = this.WebGet(@"https://sacasnap.neusoft.com/co/mobile/microapp/list");
            var objs = JArray.Parse(JToken.Parse(JArray.Parse(JToken.Parse(orderList)["result"].ToString())[0].ToString())["appList"].ToString())
                .Where(p => p["name"].ToString() == "外勤打卡");

            if (objs == null || objs.Count() == 0)
            {
                ShowMsgMeesageBox("你无须打卡");
            }

            var url = objs.First()["redirectUri"].ToString();
            var msg = this.WebGet(url);
            var json = this.WebPost(@"https://wxservice.neusoft.com/snap/outAttendance?m=getOutAttendance", string.Empty);

            var dataTable = new DataTable();
            dataTable.Columns.Add("recordDate");
            dataTable.Columns.Add("location");

            foreach (var item in JArray.Parse(json))
            {
                var row = dataTable.NewRow();
                row[0] = item["recordDate"];
                row[1] = item["location"];
                dataTable.Rows.Add(row);
            }

            this.dgvInfo.DataSource = dataTable;
        }

        /// <summary>
        /// 打卡事件
        /// </summary>
        private void CheckIN()
        {
            var orderList = this.WebGet(@"https://sacasnap.neusoft.com/co/mobile/microapp/list");
            var objs = JArray.Parse(JToken.Parse(JArray.Parse(JToken.Parse(orderList)["result"].ToString())[0].ToString())["appList"].ToString())
                .Where(p => p["name"].ToString() == "外勤打卡");

            //判断是否有打卡菜单
            if (objs == null || objs.Count() == 0)
            {
                ShowMsgMeesageBox("你无须打卡");
            }

            var url = objs.First()["redirectUri"].ToString();
            var msg = this.WebGet(url);

            var data = @"{""photo"":"""",""place"":""" + this.Data.LocationStr + @"""}";
            data = "d=" + HttpUtility.UrlEncode(data);

            var json = this.WebPost("https://wxservice.neusoft.com/snap/outAttendance?m=outAttendanceApply", data);

            if (JToken.Parse(json)["code"].ToString() != "0")
            {
                ShowErrorMeesageBox("打卡失败");
                return;
            }
            else
            {
                this.iconDeskTop.ShowBalloonTip(3000, "自动打卡", "打卡成功", ToolTipIcon.Info);
            }
            GetKQTimeTable();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            this.Data = new Data();
            GetCaptcha();
        }

        private void ShowMsgMeesageBox(string content, string title = "消息")
        {
            MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowErrorMeesageBox(string content, string title = "警告")
        {
            MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region 事件
        /// <summary>
        /// load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.ShowInTaskbar = false;
            LoadData();
        }

        /// <summary>
        /// 跳转到百度经纬度查询页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkPos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = @"http://api.map.baidu.com/lbsapi/getpoint/index.html";
            System.Diagnostics.Process.Start(url);
        }

        /// <summary>
        /// 获取位置按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetPosInfo_Click(object sender, EventArgs e)
        {
            //将经纬度转换为百度经纬度
            var json = this.WebGet($@"http://api.map.baidu.com/geoconv/v1/?coords={txtPos.Text}&from=5&to=6&ak=mgSV5AK7dHpBoOdpp1CSn57WnGRLGTN7");
            var pos = JArray.Parse(JToken.Parse(json)["result"].ToString())[0];
            var posX = pos["x"].ToString();
            var posY = pos["y"].ToString();

            //根据百度经纬度获取周围地址
            json = this.WebGet($@"https://api.map.baidu.com/?qt=rgc&x={posX}&y={posY}&dis_poi=500&poi_num=12&latest_admin=1&ie=utf-8&oue=1&fromproduct=jsapi&res=api&callback=BMap._rd._cbk31507&ak=mgSV5AK7dHpBoOdpp1CSn57WnGRLGTN7");
            json = json.Substring(json.IndexOf("{"));
            json = json.Substring(0, json.LastIndexOf("}") + 1);

            var rs = JToken.Parse(JToken.Parse(json)["content"].ToString());
            var addressComponents = JToken.Parse(rs["address_detail"].ToString());
            this.Data.Procity = addressComponents["province"].ToString() + addressComponents["city"].ToString();

            //将获取到的地址显示到下拉框
            var titles = JArray.Parse(rs["surround_poi"].ToString()).Select(p => p["name"].ToString()).ToList();
            drpLocation.DataSource = titles;
        }

        /// <summary>
        /// 选定位置按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectLocation_Click(object sender, EventArgs e)
        {
            //选择文本框赋值
            txtSelectedLocation.Text = this.Data.Procity + drpLocation.Text;
            this.Data.LocationStr = this.Data.Procity + drpLocation.Text;
        }

        /// <summary>
        /// 登录按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //将文本进行URL编码
            var pwd = HttpUtility.UrlEncode(txtPwd.Text);
            var checkCode = HttpUtility.UrlEncode(this.Data.CheckCode);
            var userID = HttpUtility.UrlEncode(this.txtUserID.Text);
            var captcha = HttpUtility.UrlEncode(this.txtCaptcha.Text);
            var devID = HttpUtility.UrlEncode(this.Data.DevID);

            var data = $@"devId={devID}&password={pwd}&checkCodeId={checkCode}&username={userID}&checkCode={captcha}";
            var json = this.WebPost(@"https://sacasnap.neusoft.com/co/mobile/login", data);
            var obj = JToken.Parse(json);
            if (obj["code"].ToString() != "0")
            {
                ShowErrorMeesageBox(obj["msg"].ToString());
                return;
            }
            else
            {
                ShowMsgMeesageBox("登陆成功");
            }
            var cookie = GetCookies().First();
            this.cookieContainer.Add(new Cookie(cookie.Name, cookie.Value, "/", "wxservice.neusoft.com"));
        }

        /// <summary>
        /// 获取CookieContainer内的所有Cookie
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Cookie> GetCookies()
        {
            Hashtable k = (Hashtable)this.cookieContainer.GetType().GetField("m_domainTable", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(this.cookieContainer);
            foreach (DictionaryEntry element in k)
            {
                SortedList l = (SortedList)element.Value.GetType().GetField("m_list", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(element.Value);
                foreach (var e in l)
                {
                    var cl = (CookieCollection)((DictionaryEntry)e).Value;
                    foreach (Cookie fc in cl)
                    {
                        yield return fc;
                    }
                }
            }
        }

        /// <summary>
        /// 获取登录验证码
        /// </summary>
        private void GetCaptcha()
        {
            var wc = new WebClient();
            var bytes = wc.DownloadData($@"https://sacasnap.neusoft.com/co/Captcha.jpg?checkCodeId={this.Data.CheckCode}");
            var ms = new MemoryStream();
            ms.Write(bytes, 0, bytes.Length);
            picCaptcha.Image = Image.FromStream(ms);
        }

        /// <summary>
        /// 重新获取验证码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picCaptcha_Click(object sender, EventArgs e)
        {
            //如果登录人不同重新生成相关数据
            if (this.Data.UserName != this.txtUserID.Text)
            {
                InitData();
            }
            else
            {
                GetCaptcha();
            }
        }

        /// <summary>
        /// 登录按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            CheckIN();
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        /// <summary>
        /// 获取打卡列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckInfo_Click(object sender, EventArgs e)
        {
            GetKQTimeTable();
        }
        /// <summary>
        /// 自动打卡点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAuto_Click(object sender, EventArgs e)
        {
            btnAuto.Enabled = false;
            btnAuto.Text = "自动打卡中...";
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        var now = (int)DateTime.Now.TimeOfDay.TotalSeconds;
                        if (now == (int)this.timeMorning.Value.TimeOfDay.TotalSeconds ||
                            now == (int)this.timeEvening.Value.TimeOfDay.TotalSeconds)
                        {
                            var rand = new Random();
                            if (this.Data.RandMin < 1)
                            {
                                this.Data.RandMin = 1;
                            }
                            var sleepTime = rand.Next(this.Data.RandMin - 1) * 60 + rand.Next(60);

                            Thread.Sleep(sleepTime * 1000);

                            CheckIN();
                        }
                        Thread.Sleep(900);
                    }
                    catch
                    {
                    }
                }
            });
        }

        /// <summary>
        /// 更改早晨打卡时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeMorning_ValueChanged(object sender, EventArgs e)
        {
            this.Data.MorningTime = this.timeMorning.Value;
        }

        /// <summary>
        /// 更改晚上打卡时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeEvening_ValueChanged(object sender, EventArgs e)
        {
            this.Data.EveningTime = this.timeEvening.Value;
        }

        /// <summary>
        /// 更改随机时间范围
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRandMin_ValueChanged(object sender, EventArgs e)
        {
            this.Data.RandMin = Convert.ToInt32(this.txtRandMin.Value);
        }

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowForm_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        /// <summary>
        /// 隐藏窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHideForm_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// 关闭窗口保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SaveData();
        }

        /// <summary>
        /// 置顶窗口点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTopForm_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        /// <summary>
        /// 取消置顶点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelTopForm_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
        }

        /// <summary>
        /// 修改UserAgent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserAgent_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtUserAgent.Text))
            {
                this.Data.UserAgent = @"Mozilla/5.0 (Linux; Android 5.1.1; HUAWEI P7-L07 Build/HuaweiP7-L07) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/39.0.0.0 Mobile Safari/537.36";
                this.txtUserAgent.Text = this.Data.UserAgent;
            }
            else
            {
                this.Data.UserAgent = this.txtUserAgent.Text;
            }
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }

    /// <summary>
    /// 数据集
    /// </summary>
    [DataContract]
    internal class Data
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// 登陆省份
        /// </summary>
        [DataMember]
        public string Procity { get; set; }

        /// <summary>
        /// 早晨打卡时间
        /// </summary>
        [DataMember]
        public DateTime MorningTime { get; set; }

        /// <summary>
        /// 晚上打卡时间
        /// </summary>
        [DataMember]
        public DateTime EveningTime { get; set; }

        /// <summary>
        /// 随机时间
        /// </summary>
        [DataMember]
        public int RandMin { get; set; }

        /// <summary>
        /// 地址字符串
        /// </summary>
        [DataMember]
        public string LocationStr { get; set; }

        /// <summary>
        /// cookie集合
        /// </summary>
        [DataMember]
        public List<Cookie> Cookies { get; set; }

        /// <summary>
        /// 唯一识别码
        /// </summary>
        [DataMember]
        public string CheckCode { get; set; }

        /// <summary>
        /// 机器识别码
        /// </summary>
        [DataMember]
        public string DevID { get; set; }

        /// <summary>
        /// 浏览器标识
        /// </summary>
        [DataMember]
        public string UserAgent { get; set; }

        /// <summary>
        /// 初始化数据生成
        /// </summary>
        public Data()
        {
            Cookies = new List<Cookie>();
            CheckCode = Guid.NewGuid().ToString();
            DevID = Guid.NewGuid().ToString().Replace("-", "");
            UserAgent = @"Mozilla/5.0 (Linux; Android 5.1.1; HUAWEI P7-L07 Build/HuaweiP7-L07) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/39.0.0.0 Mobile Safari/537.36";
            MorningTime = DateTime.Now;
            EveningTime = DateTime.Now;
        }
    }
}
