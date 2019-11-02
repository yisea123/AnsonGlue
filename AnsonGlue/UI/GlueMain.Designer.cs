using AnsonGlue.Repaint;

namespace AnsonGlue.UI
{
    sealed partial class CGlue
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CGlue));
            this.m_bHome = new System.Windows.Forms.Button();
            this.m_bProduceDate = new System.Windows.Forms.Button();
            this.m_bWarning = new System.Windows.Forms.Button();
            this.m_bSetting = new System.Windows.Forms.Button();
            this.m_bVision = new System.Windows.Forms.Button();
            this.m_bStart = new System.Windows.Forms.Button();
            this.m_bLogin = new System.Windows.Forms.Button();
            this.m_bStop = new System.Windows.Forms.Button();
            this.m_bSuspend = new System.Windows.Forms.Button();
            this.m_pLeft = new AnsonGlue.Repaint.CRoundPanel(this.components);
            this.m_pRightDown = new AnsonGlue.Repaint.CRoundPanel(this.components);
            this.m_pRightUp = new AnsonGlue.Repaint.CRoundPanel(this.components);
            this.m_rBtnMachineNum = new AnsonGlue.Repaint.CRoundButton();
            this.m_rBtnAlarmStatus = new AnsonGlue.Repaint.CRoundButton();
            this.m_rBtnAlarmTime = new AnsonGlue.Repaint.CRoundButton();
            this.m_rBtnUph = new AnsonGlue.Repaint.CRoundButton();
            this.m_pOpenExcelDir = new System.Windows.Forms.Panel();
            this.m_pOpenImageDir = new System.Windows.Forms.Panel();
            this.m_rBtnCoordinate = new AnsonGlue.Repaint.CRoundButton();
            this.SuspendLayout();
            // 
            // m_bHome
            // 
            this.m_bHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_bHome.FlatAppearance.BorderSize = 0;
            this.m_bHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_bHome.Image = global::AnsonGlue.Properties.Resources.Home;
            this.m_bHome.Location = new System.Drawing.Point(22, 12);
            this.m_bHome.Name = "m_bHome";
            this.m_bHome.Size = new System.Drawing.Size(83, 83);
            this.m_bHome.TabIndex = 3;
            this.m_bHome.UseVisualStyleBackColor = true;
            this.m_bHome.Click += new System.EventHandler(this.m_bHome_Click);
            // 
            // m_bProduceDate
            // 
            this.m_bProduceDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_bProduceDate.FlatAppearance.BorderSize = 0;
            this.m_bProduceDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_bProduceDate.Image = global::AnsonGlue.Properties.Resources.ProduceData;
            this.m_bProduceDate.Location = new System.Drawing.Point(430, 12);
            this.m_bProduceDate.Name = "m_bProduceDate";
            this.m_bProduceDate.Size = new System.Drawing.Size(83, 83);
            this.m_bProduceDate.TabIndex = 16;
            this.m_bProduceDate.UseVisualStyleBackColor = true;
            this.m_bProduceDate.Click += new System.EventHandler(this.m_bProduceDate_Click);
            // 
            // m_bWarning
            // 
            this.m_bWarning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_bWarning.FlatAppearance.BorderSize = 0;
            this.m_bWarning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_bWarning.Image = global::AnsonGlue.Properties.Resources.Warnning;
            this.m_bWarning.Location = new System.Drawing.Point(328, 12);
            this.m_bWarning.Name = "m_bWarning";
            this.m_bWarning.Size = new System.Drawing.Size(83, 83);
            this.m_bWarning.TabIndex = 17;
            this.m_bWarning.UseVisualStyleBackColor = true;
            this.m_bWarning.Click += new System.EventHandler(this.m_bWarning_Click);
            // 
            // m_bSetting
            // 
            this.m_bSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_bSetting.FlatAppearance.BorderSize = 0;
            this.m_bSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_bSetting.Image = global::AnsonGlue.Properties.Resources.Setting;
            this.m_bSetting.Location = new System.Drawing.Point(124, 12);
            this.m_bSetting.Name = "m_bSetting";
            this.m_bSetting.Size = new System.Drawing.Size(83, 83);
            this.m_bSetting.TabIndex = 18;
            this.m_bSetting.UseVisualStyleBackColor = true;
            this.m_bSetting.Click += new System.EventHandler(this.m_bSetting_Click);
            // 
            // m_bVision
            // 
            this.m_bVision.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_bVision.FlatAppearance.BorderSize = 0;
            this.m_bVision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_bVision.Image = global::AnsonGlue.Properties.Resources.Vision;
            this.m_bVision.Location = new System.Drawing.Point(226, 12);
            this.m_bVision.Name = "m_bVision";
            this.m_bVision.Size = new System.Drawing.Size(83, 83);
            this.m_bVision.TabIndex = 19;
            this.m_bVision.UseVisualStyleBackColor = true;
            this.m_bVision.Click += new System.EventHandler(this.m_bVision_Click);
            // 
            // m_bStart
            // 
            this.m_bStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_bStart.FlatAppearance.BorderSize = 0;
            this.m_bStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_bStart.Image = global::AnsonGlue.Properties.Resources.Start;
            this.m_bStart.Location = new System.Drawing.Point(772, 12);
            this.m_bStart.Name = "m_bStart";
            this.m_bStart.Size = new System.Drawing.Size(80, 80);
            this.m_bStart.TabIndex = 20;
            this.m_bStart.UseVisualStyleBackColor = true;
            this.m_bStart.Click += new System.EventHandler(this.m_bStart_Click);
            // 
            // m_bLogin
            // 
            this.m_bLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_bLogin.FlatAppearance.BorderSize = 0;
            this.m_bLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_bLogin.Image = global::AnsonGlue.Properties.Resources.Login;
            this.m_bLogin.Location = new System.Drawing.Point(1287, 12);
            this.m_bLogin.Name = "m_bLogin";
            this.m_bLogin.Size = new System.Drawing.Size(80, 80);
            this.m_bLogin.TabIndex = 21;
            this.m_bLogin.UseVisualStyleBackColor = true;
            this.m_bLogin.Click += new System.EventHandler(this.m_bLogin_Click);
            // 
            // m_bStop
            // 
            this.m_bStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_bStop.FlatAppearance.BorderSize = 0;
            this.m_bStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_bStop.Image = global::AnsonGlue.Properties.Resources.Stop;
            this.m_bStop.Location = new System.Drawing.Point(978, 12);
            this.m_bStop.Name = "m_bStop";
            this.m_bStop.Size = new System.Drawing.Size(80, 80);
            this.m_bStop.TabIndex = 24;
            this.m_bStop.UseVisualStyleBackColor = true;
            this.m_bStop.Click += new System.EventHandler(this.m_bStop_Click);
            // 
            // m_bSuspend
            // 
            this.m_bSuspend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_bSuspend.FlatAppearance.BorderSize = 0;
            this.m_bSuspend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_bSuspend.Image = global::AnsonGlue.Properties.Resources.Suspend;
            this.m_bSuspend.Location = new System.Drawing.Point(875, 12);
            this.m_bSuspend.Name = "m_bSuspend";
            this.m_bSuspend.Size = new System.Drawing.Size(80, 80);
            this.m_bSuspend.TabIndex = 25;
            this.m_bSuspend.UseVisualStyleBackColor = true;
            this.m_bSuspend.Click += new System.EventHandler(this.m_bSuspend_Click);
            // 
            // m_pLeft
            // 
            this.m_pLeft.BackColor = System.Drawing.SystemColors.Control;
            this.m_pLeft.Location = new System.Drawing.Point(22, 202);
            this.m_pLeft.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.m_pLeft.Name = "m_pLeft";
            this.m_pLeft.SetRoundRadius = 40;
            this.m_pLeft.Size = new System.Drawing.Size(830, 670);
            this.m_pLeft.TabIndex = 29;
            // 
            // m_pRightDown
            // 
            this.m_pRightDown.BackColor = System.Drawing.SystemColors.Control;
            this.m_pRightDown.Location = new System.Drawing.Point(875, 612);
            this.m_pRightDown.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.m_pRightDown.Name = "m_pRightDown";
            this.m_pRightDown.SetRoundRadius = 40;
            this.m_pRightDown.Size = new System.Drawing.Size(500, 260);
            this.m_pRightDown.TabIndex = 28;
            // 
            // m_pRightUp
            // 
            this.m_pRightUp.BackColor = System.Drawing.SystemColors.Control;
            this.m_pRightUp.Location = new System.Drawing.Point(874, 105);
            this.m_pRightUp.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.m_pRightUp.Name = "m_pRightUp";
            this.m_pRightUp.SetRoundRadius = 40;
            this.m_pRightUp.Size = new System.Drawing.Size(492, 495);
            this.m_pRightUp.TabIndex = 26;
            // 
            // m_rBtnMachineNum
            // 
            this.m_rBtnMachineNum.DisableBackColor = System.Drawing.Color.Empty;
            this.m_rBtnMachineNum.EnterBackColor = System.Drawing.Color.Pink;
            this.m_rBtnMachineNum.EnterForeColor = System.Drawing.Color.White;
            this.m_rBtnMachineNum.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnMachineNum.FlatAppearance.BorderSize = 0;
            this.m_rBtnMachineNum.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnMachineNum.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnMachineNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnMachineNum.HoverBackColor = System.Drawing.Color.LightBlue;
            this.m_rBtnMachineNum.HoverForeColor = System.Drawing.Color.White;
            this.m_rBtnMachineNum.Location = new System.Drawing.Point(541, 12);
            this.m_rBtnMachineNum.Name = "m_rBtnMachineNum";
            this.m_rBtnMachineNum.PressBackColor = System.Drawing.Color.Pink;
            this.m_rBtnMachineNum.PressForeColor = System.Drawing.Color.White;
            this.m_rBtnMachineNum.Radius = 18;
            this.m_rBtnMachineNum.Size = new System.Drawing.Size(205, 83);
            this.m_rBtnMachineNum.TabIndex = 30;
            this.m_rBtnMachineNum.Text = "Tool-001";
            this.m_rBtnMachineNum.UseVisualStyleBackColor = true;
            // 
            // m_rBtnAlarmStatus
            // 
            this.m_rBtnAlarmStatus.DisableBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnAlarmStatus.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnAlarmStatus.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnAlarmStatus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnAlarmStatus.FlatAppearance.BorderSize = 0;
            this.m_rBtnAlarmStatus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnAlarmStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnAlarmStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnAlarmStatus.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnAlarmStatus.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnAlarmStatus.Location = new System.Drawing.Point(37, 107);
            this.m_rBtnAlarmStatus.Name = "m_rBtnAlarmStatus";
            this.m_rBtnAlarmStatus.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnAlarmStatus.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnAlarmStatus.Radius = 20;
            this.m_rBtnAlarmStatus.Size = new System.Drawing.Size(133, 73);
            this.m_rBtnAlarmStatus.TabIndex = 31;
            this.m_rBtnAlarmStatus.Text = "No Alarm";
            this.m_rBtnAlarmStatus.UseVisualStyleBackColor = true;
            // 
            // m_rBtnAlarmTime
            // 
            this.m_rBtnAlarmTime.DisableBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnAlarmTime.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnAlarmTime.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnAlarmTime.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnAlarmTime.FlatAppearance.BorderSize = 0;
            this.m_rBtnAlarmTime.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnAlarmTime.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnAlarmTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnAlarmTime.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnAlarmTime.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnAlarmTime.Location = new System.Drawing.Point(185, 107);
            this.m_rBtnAlarmTime.Name = "m_rBtnAlarmTime";
            this.m_rBtnAlarmTime.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnAlarmTime.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnAlarmTime.Radius = 20;
            this.m_rBtnAlarmTime.Size = new System.Drawing.Size(294, 73);
            this.m_rBtnAlarmTime.TabIndex = 32;
            this.m_rBtnAlarmTime.Text = "AlarmTime    00:10:27";
            this.m_rBtnAlarmTime.UseVisualStyleBackColor = true;
            // 
            // m_rBtnUph
            // 
            this.m_rBtnUph.DisableBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnUph.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(191)))));
            this.m_rBtnUph.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnUph.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnUph.FlatAppearance.BorderSize = 0;
            this.m_rBtnUph.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnUph.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnUph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnUph.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(191)))));
            this.m_rBtnUph.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnUph.Location = new System.Drawing.Point(499, 107);
            this.m_rBtnUph.Name = "m_rBtnUph";
            this.m_rBtnUph.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(191)))));
            this.m_rBtnUph.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnUph.Radius = 20;
            this.m_rBtnUph.Size = new System.Drawing.Size(111, 73);
            this.m_rBtnUph.TabIndex = 33;
            this.m_rBtnUph.Text = "UPH:270";
            this.m_rBtnUph.UseVisualStyleBackColor = true;
            // 
            // m_pOpenExcelDir
            // 
            this.m_pOpenExcelDir.BackColor = System.Drawing.SystemColors.Window;
            this.m_pOpenExcelDir.BackgroundImage = global::AnsonGlue.Properties.Resources.OpenExcelDir;
            this.m_pOpenExcelDir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_pOpenExcelDir.Location = new System.Drawing.Point(1081, 3);
            this.m_pOpenExcelDir.Name = "m_pOpenExcelDir";
            this.m_pOpenExcelDir.Size = new System.Drawing.Size(97, 92);
            this.m_pOpenExcelDir.TabIndex = 35;
            this.m_pOpenExcelDir.Click += new System.EventHandler(this.m_pOpenExcelDir_Click);
            // 
            // m_pOpenImageDir
            // 
            this.m_pOpenImageDir.BackgroundImage = global::AnsonGlue.Properties.Resources.OpenImageDir;
            this.m_pOpenImageDir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_pOpenImageDir.Location = new System.Drawing.Point(1184, 3);
            this.m_pOpenImageDir.Name = "m_pOpenImageDir";
            this.m_pOpenImageDir.Size = new System.Drawing.Size(97, 92);
            this.m_pOpenImageDir.TabIndex = 36;
            this.m_pOpenImageDir.Click += new System.EventHandler(this.m_pOpenImageDir_Click);
            // 
            // m_rBtnCoordinate
            // 
            this.m_rBtnCoordinate.DisableBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnCoordinate.EnterBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnCoordinate.EnterForeColor = System.Drawing.Color.Empty;
            this.m_rBtnCoordinate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnCoordinate.FlatAppearance.BorderSize = 0;
            this.m_rBtnCoordinate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnCoordinate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnCoordinate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnCoordinate.HoverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnCoordinate.HoverForeColor = System.Drawing.Color.Empty;
            this.m_rBtnCoordinate.Image = global::AnsonGlue.Properties.Resources.Coordinate;
            this.m_rBtnCoordinate.Location = new System.Drawing.Point(706, 107);
            this.m_rBtnCoordinate.Name = "m_rBtnCoordinate";
            this.m_rBtnCoordinate.PressBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnCoordinate.PressForeColor = System.Drawing.Color.Empty;
            this.m_rBtnCoordinate.Radius = 20;
            this.m_rBtnCoordinate.Size = new System.Drawing.Size(97, 79);
            this.m_rBtnCoordinate.TabIndex = 37;
            this.m_rBtnCoordinate.UseVisualStyleBackColor = true;
            this.m_rBtnCoordinate.Click += new System.EventHandler(this.m_rBtnCoordinate_Click);
            // 
            // CGlue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1382, 893);
            this.Controls.Add(this.m_rBtnCoordinate);
            this.Controls.Add(this.m_pOpenImageDir);
            this.Controls.Add(this.m_pOpenExcelDir);
            this.Controls.Add(this.m_rBtnUph);
            this.Controls.Add(this.m_rBtnAlarmTime);
            this.Controls.Add(this.m_rBtnAlarmStatus);
            this.Controls.Add(this.m_rBtnMachineNum);
            this.Controls.Add(this.m_pLeft);
            this.Controls.Add(this.m_pRightDown);
            this.Controls.Add(this.m_pRightUp);
            this.Controls.Add(this.m_bSuspend);
            this.Controls.Add(this.m_bStop);
            this.Controls.Add(this.m_bLogin);
            this.Controls.Add(this.m_bStart);
            this.Controls.Add(this.m_bVision);
            this.Controls.Add(this.m_bSetting);
            this.Controls.Add(this.m_bWarning);
            this.Controls.Add(this.m_bProduceDate);
            this.Controls.Add(this.m_bHome);
            this.Font = new System.Drawing.Font("Open Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximumSize = new System.Drawing.Size(1400, 940);
            this.MinimumSize = new System.Drawing.Size(1400, 940);
            this.Name = "CGlue";
            this.Text = "Glue";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CGlue_FormClosed);
            this.Load += new System.EventHandler(this.Glue_Load);
            this.Move += new System.EventHandler(this.CGlue_Move);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_bHome;
        private System.Windows.Forms.Button m_bProduceDate;
        private System.Windows.Forms.Button m_bWarning;
        private System.Windows.Forms.Button m_bSetting;
        private System.Windows.Forms.Button m_bVision;
        private System.Windows.Forms.Button m_bStart;
        private System.Windows.Forms.Button m_bLogin;
        private System.Windows.Forms.Button m_bStop;
        private System.Windows.Forms.Button m_bSuspend;
        private CRoundPanel m_pRightUp;
        private CRoundPanel m_pRightDown;
        private CRoundPanel m_pLeft;
        private global::AnsonGlue.Repaint.CRoundButton m_rBtnMachineNum;
        private AnsonGlue.Repaint.CRoundButton m_rBtnAlarmStatus;
        private AnsonGlue.Repaint.CRoundButton m_rBtnAlarmTime;
        private AnsonGlue.Repaint.CRoundButton m_rBtnUph;
        private System.Windows.Forms.Panel m_pOpenExcelDir;
        private System.Windows.Forms.Panel m_pOpenImageDir;
        private CRoundButton m_rBtnCoordinate;
        
    }
}

