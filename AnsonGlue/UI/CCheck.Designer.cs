namespace AnsonGlue.UI
{
    partial class CCheck
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_rBtnOpenIo = new AnsonGlue.Repaint.CRoundButton();
            this.label2 = new System.Windows.Forms.Label();
            this.m_rBtnOpenMotionSetting = new AnsonGlue.Repaint.CRoundButton();
            this.label3 = new System.Windows.Forms.Label();
            this.m_rBtnPluginDebug = new AnsonGlue.Repaint.CRoundButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "IO调试窗口:";
            // 
            // m_rBtnOpenIo
            // 
            this.m_rBtnOpenIo.DisableBackColor = System.Drawing.Color.Red;
            this.m_rBtnOpenIo.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnOpenIo.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnOpenIo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnOpenIo.FlatAppearance.BorderSize = 0;
            this.m_rBtnOpenIo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnOpenIo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnOpenIo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnOpenIo.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnOpenIo.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnOpenIo.Location = new System.Drawing.Point(266, 28);
            this.m_rBtnOpenIo.Name = "m_rBtnOpenIo";
            this.m_rBtnOpenIo.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnOpenIo.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnOpenIo.Radius = 20;
            this.m_rBtnOpenIo.Size = new System.Drawing.Size(136, 38);
            this.m_rBtnOpenIo.TabIndex = 1;
            this.m_rBtnOpenIo.Text = "打开";
            this.m_rBtnOpenIo.UseVisualStyleBackColor = true;
            this.m_rBtnOpenIo.Click += new System.EventHandler(this.m_rBtnOpenIo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "运动板卡参数设置：";
            // 
            // m_rBtnOpenMotionSetting
            // 
            this.m_rBtnOpenMotionSetting.DisableBackColor = System.Drawing.Color.Red;
            this.m_rBtnOpenMotionSetting.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnOpenMotionSetting.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnOpenMotionSetting.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnOpenMotionSetting.FlatAppearance.BorderSize = 0;
            this.m_rBtnOpenMotionSetting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnOpenMotionSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnOpenMotionSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnOpenMotionSetting.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnOpenMotionSetting.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnOpenMotionSetting.Location = new System.Drawing.Point(266, 86);
            this.m_rBtnOpenMotionSetting.Name = "m_rBtnOpenMotionSetting";
            this.m_rBtnOpenMotionSetting.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnOpenMotionSetting.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnOpenMotionSetting.Radius = 20;
            this.m_rBtnOpenMotionSetting.Size = new System.Drawing.Size(136, 38);
            this.m_rBtnOpenMotionSetting.TabIndex = 3;
            this.m_rBtnOpenMotionSetting.Text = "打开";
            this.m_rBtnOpenMotionSetting.UseVisualStyleBackColor = true;
            this.m_rBtnOpenMotionSetting.Click += new System.EventHandler(this.m_rBtnOpenMachine_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 33);
            this.label3.TabIndex = 4;
            this.label3.Text = "挂件调试窗口:";
            // 
            // m_rBtnPluginDebug
            // 
            this.m_rBtnPluginDebug.DisableBackColor = System.Drawing.Color.Red;
            this.m_rBtnPluginDebug.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnPluginDebug.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnPluginDebug.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnPluginDebug.FlatAppearance.BorderSize = 0;
            this.m_rBtnPluginDebug.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnPluginDebug.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnPluginDebug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnPluginDebug.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnPluginDebug.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnPluginDebug.Location = new System.Drawing.Point(266, 144);
            this.m_rBtnPluginDebug.Name = "m_rBtnPluginDebug";
            this.m_rBtnPluginDebug.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnPluginDebug.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnPluginDebug.Radius = 20;
            this.m_rBtnPluginDebug.Size = new System.Drawing.Size(136, 38);
            this.m_rBtnPluginDebug.TabIndex = 5;
            this.m_rBtnPluginDebug.Text = "打开";
            this.m_rBtnPluginDebug.UseVisualStyleBackColor = true;
            this.m_rBtnPluginDebug.Click += new System.EventHandler(this.m_rBtnPluginDebug_Click);
            // 
            // CCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 260);
            this.Controls.Add(this.m_rBtnPluginDebug);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_rBtnOpenMotionSetting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_rBtnOpenIo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Open Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximumSize = new System.Drawing.Size(500, 260);
            this.MinimumSize = new System.Drawing.Size(500, 260);
            this.Name = "CCheck";
            this.Text = "Check";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Repaint.CRoundButton m_rBtnOpenIo;
        private System.Windows.Forms.Label label2;
        private Repaint.CRoundButton m_rBtnOpenMotionSetting;
        private System.Windows.Forms.Label label3;
        private Repaint.CRoundButton m_rBtnPluginDebug;
    }
}