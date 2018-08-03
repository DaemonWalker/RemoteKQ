using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RemoteKQ
{
    /// <summary>
    /// 数据集
    /// </summary>
    [DataContract]
    public class Data
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
        /// 不打卡的日期
        /// </summary>
        [DataMember]
        public List<DateTime> NoCheckDateList { get; set; }

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
            NoCheckDateList = new List<DateTime>();
        }
        public bool IsCheckDay()
        {
            if (this.NoCheckDateList.Contains(DateTime.Now.Date))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void RemoveOldDays()
        {
            var now = DateTime.Now;
            for (int i = this.NoCheckDateList.Count - 1; i >= 0; i--)
            {
                if ((NoCheckDateList[i] - now).TotalDays <= -1)
                {
                    this.NoCheckDateList.RemoveAt(i);
                }
            }
        }
    }
}
