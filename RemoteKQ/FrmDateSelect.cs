using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteKQ
{
    public partial class FrmDateSelect : Form
    {
        #region 数据变量
        /// <summary>
        /// 第一个日期显示位置
        /// </summary>
        private Point StartPos = new Point(16, 46);

        /// <summary>
        /// 日期显示大小
        /// </summary>
        private Size BtnSize = new Size(34, 34);

        /// <summary>
        /// 日历默认大小
        /// </summary>
        private Font DefaultFont = new Font("宋体", 12);

        /// <summary>
        /// 日历按钮间隔
        /// </summary>
        private int Wide = 48;

        /// <summary>
        /// 当前查看日期
        /// </summary>
        private DateTime CheckMonth = DateTime.Now;

        /// <summary>
        /// 按钮控件集合
        /// </summary>
        private List<CheckBox> BtnList = new List<CheckBox>();
        #endregion
        #region 方法
        public FrmDateSelect()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示日历
        /// </summary>
        private void SetCalendar()
        {
            labDate.Text = this.CheckMonth.ToString("yyyy年MM月");
            for (int i = this.BtnList.Count - 1; i >= 0; i--)
            {
                this.BtnList[i].Dispose();
            }
            BtnList.Clear();

            var date = new DateTime(this.CheckMonth.Year, this.CheckMonth.Month, 1);
            var totalDay = (date.AddMonths(1) - date).TotalDays;
            var start = date.DayOfWeek.GetHashCode() - 1;
            var weekDay = date.DayOfWeek.GetHashCode();

            for (int i = 1; i <= totalDay; i++)
            {
                //大概就是这么算位置的
                var row = ((i + start) / 7) % 5;
                var column = (i + start) % 7;

                var btn = new CheckBox();
                btn.Text = i.ToString();
                btn.Appearance = Appearance.Button;
                btn.AutoSize = false;
                btn.Font = this.DefaultFont;
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.Size = this.BtnSize;
                btn.Location = new Point(this.StartPos.X + column * this.Wide, this.StartPos.Y + row * this.Wide);

                //如果是周六周日默认不在计划之内
                if (weekDay != 0 && weekDay != 6)
                {
                    btn.Checked = true;
                }
                this.panel2.Controls.Add(btn);
                weekDay = (weekDay + 1) % 7;
                BtnList.Add(btn);
            }
        }

        #endregion
        #region 事件
        /// <summary>
        /// 载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDateSelect_Load(object sender, EventArgs e)
        {
            SetCalendar();
        }

        /// <summary>
        /// 上个月按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            this.CheckMonth = this.CheckMonth.AddMonths(-1);
            SetCalendar();
        }

        /// <summary>
        /// 下个月按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            this.CheckMonth = this.CheckMonth.AddMonths(1);
            SetCalendar();
        }

        /// <summary>
        /// 打卡计划添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPlan_Click(object sender, EventArgs e)
        {
            var parent = (this.Owner as FrmMain);
            var noCheckDateList = parent.Data.NoCheckDateList;
            foreach (var btn in this.BtnList)
            {
                if (btn.Checked == false)
                {
                    var date = new DateTime(this.CheckMonth.Year, this.CheckMonth.Month, Convert.ToInt32(btn.Text));
                    if (noCheckDateList.Contains(date) == false)
                    {
                        noCheckDateList.Add(date);
                    }
                }
            }
            parent.iconDeskTop.ShowBalloonTip(3000, "提示", "添加打卡计划成功", ToolTipIcon.Info);
        }
        #endregion
    }
}
