namespace AnsonGlue.UI
{
    partial class CVisionSetting
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
            this.label2 = new System.Windows.Forms.Label();
            this.m_rBtnCamera = new AnsonGlue.Repaint.CRoundButton();
            this.m_rBtnValveCali = new AnsonGlue.Repaint.CRoundButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "相机:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "阀:";
            // 
            // m_rBtnCamera
            // 
            this.m_rBtnCamera.DisableBackColor = System.Drawing.Color.Red;
            this.m_rBtnCamera.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnCamera.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnCamera.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnCamera.FlatAppearance.BorderSize = 0;
            this.m_rBtnCamera.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnCamera.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnCamera.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnCamera.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnCamera.Location = new System.Drawing.Point(186, 62);
            this.m_rBtnCamera.Name = "m_rBtnCamera";
            this.m_rBtnCamera.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnCamera.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnCamera.Radius = 20;
            this.m_rBtnCamera.Size = new System.Drawing.Size(160, 39);
            this.m_rBtnCamera.TabIndex = 2;
            this.m_rBtnCamera.Text = "开始";
            this.m_rBtnCamera.UseVisualStyleBackColor = true;
            this.m_rBtnCamera.Click += new System.EventHandler(this.m_rBtnCamera_Click);
            // 
            // m_rBtnValveCali
            // 
            this.m_rBtnValveCali.DisableBackColor = System.Drawing.Color.Red;
            this.m_rBtnValveCali.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnValveCali.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnValveCali.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnValveCali.FlatAppearance.BorderSize = 0;
            this.m_rBtnValveCali.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnValveCali.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnValveCali.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnValveCali.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnValveCali.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnValveCali.Location = new System.Drawing.Point(186, 128);
            this.m_rBtnValveCali.Name = "m_rBtnValveCali";
            this.m_rBtnValveCali.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnValveCali.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnValveCali.Radius = 20;
            this.m_rBtnValveCali.Size = new System.Drawing.Size(160, 39);
            this.m_rBtnValveCali.TabIndex = 3;
            this.m_rBtnValveCali.Text = "开始";
            this.m_rBtnValveCali.UseVisualStyleBackColor = true;
            this.m_rBtnValveCali.Click += new System.EventHandler(this.m_rBtnValveCali_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(17, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 177);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "标定";
            // 
            // CVisionSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 480);
            this.Controls.Add(this.m_rBtnValveCali);
            this.Controls.Add(this.m_rBtnCamera);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Open Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximumSize = new System.Drawing.Size(500, 480);
            this.MinimumSize = new System.Drawing.Size(500, 480);
            this.Name = "CVisionSetting";
            this.Text = "ParameterSetting";
            this.Load += new System.EventHandler(this.CVisionSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Repaint.CRoundButton m_rBtnCamera;
        private Repaint.CRoundButton m_rBtnValveCali;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}