namespace AnsonGlue.UI
{
    partial class CProject
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
            this.m_lName = new System.Windows.Forms.Label();
            this.m_comboBoxProjectName = new System.Windows.Forms.ComboBox();
            this.m_textBoxNewProject = new System.Windows.Forms.TextBox();
            this.m_rBtnAddProject = new AnsonGlue.Repaint.CRoundButton();
            this.m_lProject = new AnsonGlue.Repaint.CRoundButton();
            this.SuspendLayout();
            // 
            // m_lName
            // 
            this.m_lName.AutoSize = true;
            this.m_lName.Location = new System.Drawing.Point(45, 92);
            this.m_lName.Name = "m_lName";
            this.m_lName.Size = new System.Drawing.Size(69, 33);
            this.m_lName.TabIndex = 1;
            this.m_lName.Text = "名称:";
            // 
            // m_comboBoxProjectName
            // 
            this.m_comboBoxProjectName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxProjectName.FormattingEnabled = true;
            this.m_comboBoxProjectName.Location = new System.Drawing.Point(138, 89);
            this.m_comboBoxProjectName.Name = "m_comboBoxProjectName";
            this.m_comboBoxProjectName.Size = new System.Drawing.Size(196, 40);
            this.m_comboBoxProjectName.TabIndex = 2;
            // 
            // m_textBoxNewProject
            // 
            this.m_textBoxNewProject.Location = new System.Drawing.Point(138, 152);
            this.m_textBoxNewProject.Name = "m_textBoxNewProject";
            this.m_textBoxNewProject.Size = new System.Drawing.Size(196, 39);
            this.m_textBoxNewProject.TabIndex = 3;
            // 
            // m_rBtnAddProject
            // 
            this.m_rBtnAddProject.DisableBackColor = System.Drawing.Color.Empty;
            this.m_rBtnAddProject.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnAddProject.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnAddProject.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnAddProject.FlatAppearance.BorderSize = 0;
            this.m_rBtnAddProject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnAddProject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnAddProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnAddProject.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_rBtnAddProject.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnAddProject.Location = new System.Drawing.Point(357, 152);
            this.m_rBtnAddProject.Name = "m_rBtnAddProject";
            this.m_rBtnAddProject.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnAddProject.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnAddProject.Radius = 20;
            this.m_rBtnAddProject.Size = new System.Drawing.Size(107, 39);
            this.m_rBtnAddProject.TabIndex = 4;
            this.m_rBtnAddProject.Text = "添加";
            this.m_rBtnAddProject.UseVisualStyleBackColor = true;
            // 
            // m_lProject
            // 
            this.m_lProject.DisableBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.m_lProject.Enabled = false;
            this.m_lProject.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.m_lProject.EnterForeColor = System.Drawing.Color.Black;
            this.m_lProject.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_lProject.FlatAppearance.BorderSize = 0;
            this.m_lProject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_lProject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_lProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_lProject.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.m_lProject.HoverForeColor = System.Drawing.Color.Black;
            this.m_lProject.Location = new System.Drawing.Point(30, 30);
            this.m_lProject.Name = "m_lProject";
            this.m_lProject.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.m_lProject.PressForeColor = System.Drawing.Color.Black;
            this.m_lProject.Radius = 20;
            this.m_lProject.Size = new System.Drawing.Size(120, 40);
            this.m_lProject.TabIndex = 5;
            this.m_lProject.Text = "项目";
            this.m_lProject.UseVisualStyleBackColor = true;
            // 
            // CProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 260);
            this.ControlBox = false;
            this.Controls.Add(this.m_lProject);
            this.Controls.Add(this.m_rBtnAddProject);
            this.Controls.Add(this.m_textBoxNewProject);
            this.Controls.Add(this.m_comboBoxProjectName);
            this.Controls.Add(this.m_lName);
            this.Font = new System.Drawing.Font("Open Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximumSize = new System.Drawing.Size(500, 260);
            this.MinimumSize = new System.Drawing.Size(500, 260);
            this.Name = "CProject";
            this.Text = "Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_lName;
        private System.Windows.Forms.ComboBox m_comboBoxProjectName;
        private System.Windows.Forms.TextBox m_textBoxNewProject;
        private Repaint.CRoundButton m_rBtnAddProject;
        private Repaint.CRoundButton m_lProject;
    }
}