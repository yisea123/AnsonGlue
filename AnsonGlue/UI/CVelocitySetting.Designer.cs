namespace AnsonGlue.UI
{
    partial class CVelocitySetting
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
            this.m_rBtnSave = new AnsonGlue.Repaint.RoundButton();
            this.m_rBtnCancel = new AnsonGlue.Repaint.RoundButton();
            this.SuspendLayout();
            // 
            // m_rBtnSave
            // 
            this.m_rBtnSave.DisableBackColor = System.Drawing.Color.Red;
            this.m_rBtnSave.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnSave.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnSave.FlatAppearance.BorderSize = 0;
            this.m_rBtnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnSave.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnSave.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnSave.Location = new System.Drawing.Point(405, 427);
            this.m_rBtnSave.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.m_rBtnSave.Name = "m_rBtnSave";
            this.m_rBtnSave.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnSave.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnSave.Radius = 20;
            this.m_rBtnSave.Size = new System.Drawing.Size(121, 43);
            this.m_rBtnSave.TabIndex = 0;
            this.m_rBtnSave.Text = "Save";
            this.m_rBtnSave.UseVisualStyleBackColor = true;
            // 
            // m_rBtnCancel
            // 
            this.m_rBtnCancel.DisableBackColor = System.Drawing.Color.Red;
            this.m_rBtnCancel.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnCancel.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnCancel.FlatAppearance.BorderSize = 0;
            this.m_rBtnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnCancel.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnCancel.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnCancel.Location = new System.Drawing.Point(536, 427);
            this.m_rBtnCancel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.m_rBtnCancel.Name = "m_rBtnCancel";
            this.m_rBtnCancel.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnCancel.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnCancel.Radius = 20;
            this.m_rBtnCancel.Size = new System.Drawing.Size(121, 43);
            this.m_rBtnCancel.TabIndex = 1;
            this.m_rBtnCancel.Text = "Cancel";
            this.m_rBtnCancel.UseVisualStyleBackColor = true;
            this.m_rBtnCancel.Click += new System.EventHandler(this.m_rBtnCancel_Click);
            // 
            // VelocitySetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 506);
            this.ControlBox = false;
            this.Controls.Add(this.m_rBtnCancel);
            this.Controls.Add(this.m_rBtnSave);
            this.Font = new System.Drawing.Font("Open Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "VelocitySetting";
            this.Text = "VelocitySetting";
            this.ResumeLayout(false);

        }

        #endregion

        private Repaint.RoundButton m_rBtnSave;
        private Repaint.RoundButton m_rBtnCancel;
    }
}