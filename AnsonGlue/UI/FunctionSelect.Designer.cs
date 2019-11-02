namespace AnsonGlue.UI
{
    partial class CFunctionSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_gBoxAnalogSignal = new System.Windows.Forms.GroupBox();
            this.m_rBtnVisonOk = new AnsonGlue.Repaint.CRoundButton();
            this.m_rGlueOk = new AnsonGlue.Repaint.CRoundButton();
            this.m_gBoxRestart = new System.Windows.Forms.GroupBox();
            this.m_rBtnRestartServer = new AnsonGlue.Repaint.CRoundButton();
            this.m_gBoxAnalogSignal.SuspendLayout();
            this.m_gBoxRestart.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_gBoxAnalogSignal
            // 
            this.m_gBoxAnalogSignal.Controls.Add(this.m_rBtnVisonOk);
            this.m_gBoxAnalogSignal.Controls.Add(this.m_rGlueOk);
            this.m_gBoxAnalogSignal.Location = new System.Drawing.Point(12, 14);
            this.m_gBoxAnalogSignal.Name = "m_gBoxAnalogSignal";
            this.m_gBoxAnalogSignal.Size = new System.Drawing.Size(476, 121);
            this.m_gBoxAnalogSignal.TabIndex = 1;
            this.m_gBoxAnalogSignal.TabStop = false;
            this.m_gBoxAnalogSignal.Text = "手动模拟信号";
            // 
            // m_rBtnVisonOk
            // 
            this.m_rBtnVisonOk.DisableBackColor = System.Drawing.Color.Red;
            this.m_rBtnVisonOk.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnVisonOk.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnVisonOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnVisonOk.FlatAppearance.BorderSize = 0;
            this.m_rBtnVisonOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnVisonOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnVisonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnVisonOk.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnVisonOk.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnVisonOk.Location = new System.Drawing.Point(42, 55);
            this.m_rBtnVisonOk.Name = "m_rBtnVisonOk";
            this.m_rBtnVisonOk.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnVisonOk.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnVisonOk.Radius = 20;
            this.m_rBtnVisonOk.Size = new System.Drawing.Size(170, 43);
            this.m_rBtnVisonOk.TabIndex = 2;
            this.m_rBtnVisonOk.Text = "视觉处理完成";
            this.m_rBtnVisonOk.UseVisualStyleBackColor = true;
            // 
            // m_rGlueOk
            // 
            this.m_rGlueOk.DisableBackColor = System.Drawing.Color.Red;
            this.m_rGlueOk.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rGlueOk.EnterForeColor = System.Drawing.Color.Black;
            this.m_rGlueOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rGlueOk.FlatAppearance.BorderSize = 0;
            this.m_rGlueOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rGlueOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rGlueOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rGlueOk.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rGlueOk.HoverForeColor = System.Drawing.Color.Black;
            this.m_rGlueOk.Location = new System.Drawing.Point(263, 55);
            this.m_rGlueOk.Name = "m_rGlueOk";
            this.m_rGlueOk.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rGlueOk.PressForeColor = System.Drawing.Color.Black;
            this.m_rGlueOk.Radius = 20;
            this.m_rGlueOk.Size = new System.Drawing.Size(170, 43);
            this.m_rGlueOk.TabIndex = 1;
            this.m_rGlueOk.Text = "点胶完成";
            this.m_rGlueOk.UseVisualStyleBackColor = true;
            // 
            // m_gBoxRestart
            // 
            this.m_gBoxRestart.Controls.Add(this.m_rBtnRestartServer);
            this.m_gBoxRestart.Location = new System.Drawing.Point(12, 141);
            this.m_gBoxRestart.Name = "m_gBoxRestart";
            this.m_gBoxRestart.Size = new System.Drawing.Size(476, 107);
            this.m_gBoxRestart.TabIndex = 2;
            this.m_gBoxRestart.TabStop = false;
            this.m_gBoxRestart.Text = "重新连接/启动";
            // 
            // m_rBtnRestartServer
            // 
            this.m_rBtnRestartServer.DisableBackColor = System.Drawing.Color.Red;
            this.m_rBtnRestartServer.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnRestartServer.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnRestartServer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnRestartServer.FlatAppearance.BorderSize = 0;
            this.m_rBtnRestartServer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnRestartServer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnRestartServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnRestartServer.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnRestartServer.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnRestartServer.Location = new System.Drawing.Point(42, 49);
            this.m_rBtnRestartServer.Name = "m_rBtnRestartServer";
            this.m_rBtnRestartServer.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnRestartServer.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnRestartServer.Radius = 20;
            this.m_rBtnRestartServer.Size = new System.Drawing.Size(170, 43);
            this.m_rBtnRestartServer.TabIndex = 0;
            this.m_rBtnRestartServer.Text = "视觉";
            this.m_rBtnRestartServer.UseVisualStyleBackColor = true;
            this.m_rBtnRestartServer.Click += new System.EventHandler(this.m_rBtnRestartServer_Click);
            // 
            // CFunctionSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 260);
            this.Controls.Add(this.m_gBoxRestart);
            this.Controls.Add(this.m_gBoxAnalogSignal);
            this.Font = new System.Drawing.Font("Open Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "CFunctionSelect";
            this.Text = "CameraImage";
            this.Load += new System.EventHandler(this.CFunctionSelect_Load);
            this.m_gBoxAnalogSignal.ResumeLayout(false);
            this.m_gBoxRestart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox m_gBoxAnalogSignal;
        private Repaint.CRoundButton m_rGlueOk;
        private Repaint.CRoundButton m_rBtnVisonOk;
        private System.Windows.Forms.GroupBox m_gBoxRestart;
        private Repaint.CRoundButton m_rBtnRestartServer;
    }
}