namespace AnsonGlue.UI
{
    partial class CParaSetting
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
            this.m_rBtnMotionSetting = new AnsonGlue.Repaint.CRoundButton();
            this.m_rBtnCmtSetting = new AnsonGlue.Repaint.CRoundButton();
            this.SuspendLayout();
            // 
            // m_rBtnMotionSetting
            // 
            this.m_rBtnMotionSetting.DisableBackColor = System.Drawing.Color.Red;
            this.m_rBtnMotionSetting.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnMotionSetting.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnMotionSetting.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnMotionSetting.FlatAppearance.BorderSize = 0;
            this.m_rBtnMotionSetting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnMotionSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnMotionSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnMotionSetting.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnMotionSetting.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnMotionSetting.Location = new System.Drawing.Point(51, 104);
            this.m_rBtnMotionSetting.Name = "m_rBtnMotionSetting";
            this.m_rBtnMotionSetting.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnMotionSetting.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnMotionSetting.Radius = 20;
            this.m_rBtnMotionSetting.Size = new System.Drawing.Size(166, 40);
            this.m_rBtnMotionSetting.TabIndex = 0;
            this.m_rBtnMotionSetting.Text = "运动控制参数";
            this.m_rBtnMotionSetting.UseVisualStyleBackColor = true;
            this.m_rBtnMotionSetting.Click += new System.EventHandler(this.m_rBtnMotionSetting_Click);
            // 
            // m_rBtnCmtSetting
            // 
            this.m_rBtnCmtSetting.DisableBackColor = System.Drawing.Color.Red;
            this.m_rBtnCmtSetting.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnCmtSetting.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnCmtSetting.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnCmtSetting.FlatAppearance.BorderSize = 0;
            this.m_rBtnCmtSetting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnCmtSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnCmtSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnCmtSetting.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnCmtSetting.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnCmtSetting.Location = new System.Drawing.Point(51, 41);
            this.m_rBtnCmtSetting.Name = "m_rBtnCmtSetting";
            this.m_rBtnCmtSetting.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnCmtSetting.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnCmtSetting.Radius = 20;
            this.m_rBtnCmtSetting.Size = new System.Drawing.Size(166, 40);
            this.m_rBtnCmtSetting.TabIndex = 1;
            this.m_rBtnCmtSetting.Text = "通讯方式设置";
            this.m_rBtnCmtSetting.UseVisualStyleBackColor = true;
            this.m_rBtnCmtSetting.Click += new System.EventHandler(this.m_rBtnCmtSetting_Click);
            // 
            // CParaSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 260);
            this.Controls.Add(this.m_rBtnCmtSetting);
            this.Controls.Add(this.m_rBtnMotionSetting);
            this.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CParaSetting";
            this.Text = "ParaSetting";
            this.ResumeLayout(false);

        }

        #endregion

        private Repaint.CRoundButton m_rBtnMotionSetting;
        private Repaint.CRoundButton m_rBtnCmtSetting;
    }
}