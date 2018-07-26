﻿namespace RemoteKQ
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.txtCaptcha = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.picCaptcha = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSelectedLocation = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRandMin = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timeEvening = new System.Windows.Forms.DateTimePicker();
            this.timeMorning = new System.Windows.Forms.DateTimePicker();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSelectLocation = new System.Windows.Forms.Button();
            this.drpLocation = new System.Windows.Forms.ComboBox();
            this.btnGetPosInfo = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPos = new System.Windows.Forms.TextBox();
            this.linkPos = new System.Windows.Forms.LinkLabel();
            this.dgvInfo = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCheckInfo = new System.Windows.Forms.Button();
            this.iconDeskTop = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnShowForm = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHideForm = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAuto = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptcha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRandMin)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnAuto);
            this.panel1.Controls.Add(this.btnCheckInfo);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnCheckIn);
            this.panel1.Controls.Add(this.txtCaptcha);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.picCaptcha);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtSelectedLocation);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtRandMin);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.timeEvening);
            this.panel1.Controls.Add(this.timeMorning);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.txtPwd);
            this.panel1.Controls.Add(this.txtUserID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 415);
            this.panel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("宋体", 12F);
            this.btnSave.Location = new System.Drawing.Point(34, 357);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 45);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "保存信息";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Font = new System.Drawing.Font("宋体", 12F);
            this.btnCheckIn.Location = new System.Drawing.Point(78, 307);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(88, 33);
            this.btnCheckIn.TabIndex = 18;
            this.btnCheckIn.Text = "打卡一次";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // txtCaptcha
            // 
            this.txtCaptcha.Font = new System.Drawing.Font("宋体", 12F);
            this.txtCaptcha.Location = new System.Drawing.Point(78, 85);
            this.txtCaptcha.Name = "txtCaptcha";
            this.txtCaptcha.Size = new System.Drawing.Size(70, 26);
            this.txtCaptcha.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F);
            this.label10.Location = new System.Drawing.Point(16, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "验证码";
            // 
            // picCaptcha
            // 
            this.picCaptcha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCaptcha.Location = new System.Drawing.Point(154, 85);
            this.picCaptcha.Name = "picCaptcha";
            this.picCaptcha.Size = new System.Drawing.Size(102, 59);
            this.picCaptcha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCaptcha.TabIndex = 15;
            this.picCaptcha.TabStop = false;
            this.picCaptcha.Click += new System.EventHandler(this.picCaptcha_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F);
            this.label9.Location = new System.Drawing.Point(31, 281);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "地点";
            // 
            // txtSelectedLocation
            // 
            this.txtSelectedLocation.Font = new System.Drawing.Font("宋体", 12F);
            this.txtSelectedLocation.Location = new System.Drawing.Point(80, 276);
            this.txtSelectedLocation.Name = "txtSelectedLocation";
            this.txtSelectedLocation.ReadOnly = true;
            this.txtSelectedLocation.Size = new System.Drawing.Size(176, 26);
            this.txtSelectedLocation.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F);
            this.label6.Location = new System.Drawing.Point(31, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "范围";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(214, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "分钟";
            // 
            // txtRandMin
            // 
            this.txtRandMin.Font = new System.Drawing.Font("宋体", 12F);
            this.txtRandMin.Location = new System.Drawing.Point(80, 243);
            this.txtRandMin.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.txtRandMin.Name = "txtRandMin";
            this.txtRandMin.Size = new System.Drawing.Size(128, 26);
            this.txtRandMin.TabIndex = 9;
            this.txtRandMin.ValueChanged += new System.EventHandler(this.txtRandMin_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(31, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "晚上";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(31, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "早晨";
            // 
            // timeEvening
            // 
            this.timeEvening.CalendarFont = new System.Drawing.Font("宋体", 12F);
            this.timeEvening.Font = new System.Drawing.Font("宋体", 12F);
            this.timeEvening.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeEvening.Location = new System.Drawing.Point(80, 210);
            this.timeEvening.Name = "timeEvening";
            this.timeEvening.Size = new System.Drawing.Size(175, 26);
            this.timeEvening.TabIndex = 6;
            this.timeEvening.ValueChanged += new System.EventHandler(this.timeEvening_ValueChanged);
            // 
            // timeMorning
            // 
            this.timeMorning.CalendarFont = new System.Drawing.Font("宋体", 12F);
            this.timeMorning.Font = new System.Drawing.Font("宋体", 12F);
            this.timeMorning.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeMorning.Location = new System.Drawing.Point(79, 177);
            this.timeMorning.Name = "timeMorning";
            this.timeMorning.Size = new System.Drawing.Size(175, 26);
            this.timeMorning.TabIndex = 5;
            this.timeMorning.ValueChanged += new System.EventHandler(this.timeMorning_ValueChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("宋体", 12F);
            this.btnLogin.Location = new System.Drawing.Point(78, 116);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(70, 28);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.Font = new System.Drawing.Font("宋体", 12F);
            this.txtPwd.Location = new System.Drawing.Point(78, 54);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(176, 26);
            this.txtPwd.TabIndex = 3;
            // 
            // txtUserID
            // 
            this.txtUserID.Font = new System.Drawing.Font("宋体", 12F);
            this.txtUserID.Location = new System.Drawing.Point(78, 23);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(176, 26);
            this.txtUserID.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(32, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(32, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "账号";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvInfo);
            this.panel2.Controls.Add(this.btnSelectLocation);
            this.panel2.Controls.Add(this.drpLocation);
            this.panel2.Controls.Add(this.btnGetPosInfo);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtPos);
            this.panel2.Controls.Add(this.linkPos);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(278, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(522, 415);
            this.panel2.TabIndex = 1;
            // 
            // btnSelectLocation
            // 
            this.btnSelectLocation.Font = new System.Drawing.Font("宋体", 12F);
            this.btnSelectLocation.Location = new System.Drawing.Point(308, 76);
            this.btnSelectLocation.Name = "btnSelectLocation";
            this.btnSelectLocation.Size = new System.Drawing.Size(101, 23);
            this.btnSelectLocation.TabIndex = 7;
            this.btnSelectLocation.Text = "选定位置";
            this.btnSelectLocation.UseVisualStyleBackColor = true;
            this.btnSelectLocation.Click += new System.EventHandler(this.btnSelectLocation_Click);
            // 
            // drpLocation
            // 
            this.drpLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpLocation.Font = new System.Drawing.Font("宋体", 12F);
            this.drpLocation.FormattingEnabled = true;
            this.drpLocation.Location = new System.Drawing.Point(26, 75);
            this.drpLocation.Name = "drpLocation";
            this.drpLocation.Size = new System.Drawing.Size(267, 24);
            this.drpLocation.TabIndex = 6;
            // 
            // btnGetPosInfo
            // 
            this.btnGetPosInfo.Font = new System.Drawing.Font("宋体", 12F);
            this.btnGetPosInfo.Location = new System.Drawing.Point(308, 46);
            this.btnGetPosInfo.Name = "btnGetPosInfo";
            this.btnGetPosInfo.Size = new System.Drawing.Size(101, 23);
            this.btnGetPosInfo.TabIndex = 5;
            this.btnGetPosInfo.Text = "获取位置";
            this.btnGetPosInfo.UseVisualStyleBackColor = true;
            this.btnGetPosInfo.Click += new System.EventHandler(this.btnGetPosInfo_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F);
            this.label8.Location = new System.Drawing.Point(23, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "获得的坐标";
            // 
            // txtPos
            // 
            this.txtPos.Font = new System.Drawing.Font("宋体", 12F);
            this.txtPos.Location = new System.Drawing.Point(117, 44);
            this.txtPos.Name = "txtPos";
            this.txtPos.Size = new System.Drawing.Size(176, 26);
            this.txtPos.TabIndex = 3;
            this.txtPos.Text = "113.554727,22.20178";
            // 
            // linkPos
            // 
            this.linkPos.AutoSize = true;
            this.linkPos.Font = new System.Drawing.Font("宋体", 12F);
            this.linkPos.Location = new System.Drawing.Point(23, 23);
            this.linkPos.Name = "linkPos";
            this.linkPos.Size = new System.Drawing.Size(104, 16);
            this.linkPos.TabIndex = 0;
            this.linkPos.TabStop = true;
            this.linkPos.Text = "点击获得坐标";
            this.linkPos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPos_LinkClicked);
            // 
            // dgvInfo
            // 
            this.dgvInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvInfo.Location = new System.Drawing.Point(0, 142);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvInfo.RowTemplate.Height = 23;
            this.dgvInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInfo.Size = new System.Drawing.Size(520, 271);
            this.dgvInfo.TabIndex = 8;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "recordDate";
            this.Column1.HeaderText = "打卡时间";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "location";
            this.Column2.HeaderText = "打卡位置";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // btnCheckInfo
            // 
            this.btnCheckInfo.Font = new System.Drawing.Font("宋体", 12F);
            this.btnCheckInfo.Location = new System.Drawing.Point(172, 307);
            this.btnCheckInfo.Name = "btnCheckInfo";
            this.btnCheckInfo.Size = new System.Drawing.Size(82, 33);
            this.btnCheckInfo.TabIndex = 20;
            this.btnCheckInfo.Text = "查看记录";
            this.btnCheckInfo.UseVisualStyleBackColor = true;
            this.btnCheckInfo.Click += new System.EventHandler(this.btnCheckInfo_Click);
            // 
            // iconDeskTop
            // 
            this.iconDeskTop.ContextMenuStrip = this.contextMenuStrip1;
            this.iconDeskTop.Icon = ((System.Drawing.Icon)(resources.GetObject("iconDeskTop.Icon")));
            this.iconDeskTop.Text = "自动打卡机";
            this.iconDeskTop.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowForm,
            this.btnHideForm,
            this.btnExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 70);
            // 
            // btnShowForm
            // 
            this.btnShowForm.Name = "btnShowForm";
            this.btnShowForm.Size = new System.Drawing.Size(124, 22);
            this.btnShowForm.Text = "显示窗口";
            this.btnShowForm.Click += new System.EventHandler(this.btnShowForm_Click);
            // 
            // btnHideForm
            // 
            this.btnHideForm.Name = "btnHideForm";
            this.btnHideForm.Size = new System.Drawing.Size(124, 22);
            this.btnHideForm.Text = "隐藏窗口";
            this.btnHideForm.Click += new System.EventHandler(this.btnHideForm_Click);
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(124, 22);
            this.btnExit.Text = "退出";
            // 
            // btnAuto
            // 
            this.btnAuto.Font = new System.Drawing.Font("宋体", 12F);
            this.btnAuto.Location = new System.Drawing.Point(154, 357);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(102, 45);
            this.btnAuto.TabIndex = 21;
            this.btnAuto.Text = "自动打卡";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 415);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMain";
            this.Text = "自动打卡机";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptcha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRandMin)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown txtRandMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker timeEvening;
        private System.Windows.Forms.DateTimePicker timeMorning;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel linkPos;
        private System.Windows.Forms.TextBox txtPos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSelectedLocation;
        private System.Windows.Forms.Button btnSelectLocation;
        private System.Windows.Forms.ComboBox drpLocation;
        private System.Windows.Forms.Button btnGetPosInfo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox picCaptcha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCaptcha;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnCheckInfo;
        private System.Windows.Forms.NotifyIcon iconDeskTop;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnShowForm;
        private System.Windows.Forms.ToolStripMenuItem btnHideForm;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
    }
}
