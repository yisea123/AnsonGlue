namespace AnsonGlue.UI
{
    partial class CPluginDebug
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPluginDebug));
            this.m_pBalance = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_tBoxWeightDisplay = new System.Windows.Forms.TextBox();
            this.m_rBtnZeroBalance = new AnsonGlue.Repaint.CRoundButton();
            this.m_rBtnRestartBalance = new AnsonGlue.Repaint.CRoundButton();
            this.m_rBtnTouchBalance = new AnsonGlue.Repaint.CRoundButton();
            this.m_pScanner = new System.Windows.Forms.GroupBox();
            this.m_rBtnTouchScanner = new AnsonGlue.Repaint.CRoundButton();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.m_pBalance.SuspendLayout();
            this.m_pScanner.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_pBalance
            // 
            this.m_pBalance.Controls.Add(this.label1);
            this.m_pBalance.Controls.Add(this.m_tBoxWeightDisplay);
            this.m_pBalance.Controls.Add(this.m_rBtnZeroBalance);
            this.m_pBalance.Controls.Add(this.m_rBtnRestartBalance);
            this.m_pBalance.Controls.Add(this.m_rBtnTouchBalance);
            this.m_pBalance.Location = new System.Drawing.Point(26, 36);
            this.m_pBalance.Name = "m_pBalance";
            this.m_pBalance.Size = new System.Drawing.Size(356, 156);
            this.m_pBalance.TabIndex = 0;
            this.m_pBalance.TabStop = false;
            this.m_pBalance.Text = "电子秤";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "重量：";
            // 
            // m_tBoxWeightDisplay
            // 
            this.m_tBoxWeightDisplay.Location = new System.Drawing.Point(121, 98);
            this.m_tBoxWeightDisplay.Name = "m_tBoxWeightDisplay";
            this.m_tBoxWeightDisplay.Size = new System.Drawing.Size(201, 28);
            this.m_tBoxWeightDisplay.TabIndex = 3;
            // 
            // m_rBtnZeroBalance
            // 
            this.m_rBtnZeroBalance.DisableBackColor = System.Drawing.Color.Red;
            this.m_rBtnZeroBalance.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnZeroBalance.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnZeroBalance.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnZeroBalance.FlatAppearance.BorderSize = 0;
            this.m_rBtnZeroBalance.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnZeroBalance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnZeroBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnZeroBalance.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnZeroBalance.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnZeroBalance.Location = new System.Drawing.Point(242, 41);
            this.m_rBtnZeroBalance.Name = "m_rBtnZeroBalance";
            this.m_rBtnZeroBalance.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnZeroBalance.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnZeroBalance.Radius = 20;
            this.m_rBtnZeroBalance.Size = new System.Drawing.Size(80, 33);
            this.m_rBtnZeroBalance.TabIndex = 2;
            this.m_rBtnZeroBalance.Text = "清零";
            this.m_rBtnZeroBalance.UseVisualStyleBackColor = true;
            this.m_rBtnZeroBalance.Click += new System.EventHandler(this.m_rBtnZeroBalance_Click);
            // 
            // m_rBtnRestartBalance
            // 
            this.m_rBtnRestartBalance.DisableBackColor = System.Drawing.Color.Red;
            this.m_rBtnRestartBalance.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnRestartBalance.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnRestartBalance.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnRestartBalance.FlatAppearance.BorderSize = 0;
            this.m_rBtnRestartBalance.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnRestartBalance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnRestartBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnRestartBalance.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnRestartBalance.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnRestartBalance.Location = new System.Drawing.Point(139, 41);
            this.m_rBtnRestartBalance.Name = "m_rBtnRestartBalance";
            this.m_rBtnRestartBalance.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnRestartBalance.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnRestartBalance.Radius = 20;
            this.m_rBtnRestartBalance.Size = new System.Drawing.Size(80, 33);
            this.m_rBtnRestartBalance.TabIndex = 1;
            this.m_rBtnRestartBalance.Text = "重启";
            this.m_rBtnRestartBalance.UseVisualStyleBackColor = true;
            this.m_rBtnRestartBalance.Click += new System.EventHandler(this.m_rBtnRestartBalance_Click);
            // 
            // m_rBtnTouchBalance
            // 
            this.m_rBtnTouchBalance.DisableBackColor = System.Drawing.Color.Red;
            this.m_rBtnTouchBalance.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnTouchBalance.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnTouchBalance.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnTouchBalance.FlatAppearance.BorderSize = 0;
            this.m_rBtnTouchBalance.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnTouchBalance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnTouchBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnTouchBalance.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnTouchBalance.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnTouchBalance.Location = new System.Drawing.Point(36, 41);
            this.m_rBtnTouchBalance.Name = "m_rBtnTouchBalance";
            this.m_rBtnTouchBalance.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnTouchBalance.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnTouchBalance.Radius = 20;
            this.m_rBtnTouchBalance.Size = new System.Drawing.Size(80, 33);
            this.m_rBtnTouchBalance.TabIndex = 0;
            this.m_rBtnTouchBalance.Text = "读数";
            this.m_rBtnTouchBalance.UseVisualStyleBackColor = true;
            this.m_rBtnTouchBalance.Click += new System.EventHandler(this.m_rBtnTouchBalance_Click);
            // 
            // m_pScanner
            // 
            this.m_pScanner.Controls.Add(this.m_rBtnTouchScanner);
            this.m_pScanner.Controls.Add(this.label2);
            this.m_pScanner.Controls.Add(this.textBox1);
            this.m_pScanner.Location = new System.Drawing.Point(26, 239);
            this.m_pScanner.Name = "m_pScanner";
            this.m_pScanner.Size = new System.Drawing.Size(356, 138);
            this.m_pScanner.TabIndex = 1;
            this.m_pScanner.TabStop = false;
            this.m_pScanner.Text = "扫码枪";
            // 
            // m_rBtnTouchScanner
            // 
            this.m_rBtnTouchScanner.DisableBackColor = System.Drawing.Color.Red;
            this.m_rBtnTouchScanner.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnTouchScanner.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnTouchScanner.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnTouchScanner.FlatAppearance.BorderSize = 0;
            this.m_rBtnTouchScanner.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnTouchScanner.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnTouchScanner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnTouchScanner.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnTouchScanner.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnTouchScanner.Location = new System.Drawing.Point(139, 27);
            this.m_rBtnTouchScanner.Name = "m_rBtnTouchScanner";
            this.m_rBtnTouchScanner.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnTouchScanner.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnTouchScanner.Radius = 20;
            this.m_rBtnTouchScanner.Size = new System.Drawing.Size(80, 33);
            this.m_rBtnTouchScanner.TabIndex = 2;
            this.m_rBtnTouchScanner.Text = "读数";
            this.m_rBtnTouchScanner.UseVisualStyleBackColor = true;
            this.m_rBtnTouchScanner.Click += new System.EventHandler(this.m_rBtnTouchScanner_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "数据：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(121, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(201, 28);
            this.textBox1.TabIndex = 0;
            // 
            // CPluginDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 670);
            this.Controls.Add(this.m_pScanner);
            this.Controls.Add(this.m_pBalance);
            this.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CPluginDebug";
            this.Text = "PluginDebug";
            this.m_pBalance.ResumeLayout(false);
            this.m_pBalance.PerformLayout();
            this.m_pScanner.ResumeLayout(false);
            this.m_pScanner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox m_pBalance;
        private Repaint.CRoundButton m_rBtnZeroBalance;
        private Repaint.CRoundButton m_rBtnRestartBalance;
        private Repaint.CRoundButton m_rBtnTouchBalance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_tBoxWeightDisplay;
        private System.Windows.Forms.GroupBox m_pScanner;
        private Repaint.CRoundButton m_rBtnTouchScanner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;

    }
}