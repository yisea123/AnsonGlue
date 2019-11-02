namespace AnsonGlue.UI
{
    partial class CLogin
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
            this.m_bLoginImage = new System.Windows.Forms.Button();
            this.m_lUser = new System.Windows.Forms.Label();
            this.m_lPassword = new System.Windows.Forms.Label();
            this.m_textBoxPossword = new System.Windows.Forms.TextBox();
            this.m_comboBoxUser = new System.Windows.Forms.ComboBox();
            this.m_rBtnLogin = new AnsonGlue.Repaint.CRoundButton();
            this.m_lLogin = new AnsonGlue.Repaint.CRoundButton();
            this.SuspendLayout();
            // 
            // m_bLoginImage
            // 
            this.m_bLoginImage.BackgroundImage = global::AnsonGlue.Properties.Resources.Login;
            this.m_bLoginImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_bLoginImage.Location = new System.Drawing.Point(237, 59);
            this.m_bLoginImage.Name = "m_bLoginImage";
            this.m_bLoginImage.Size = new System.Drawing.Size(85, 86);
            this.m_bLoginImage.TabIndex = 0;
            this.m_bLoginImage.UseVisualStyleBackColor = true;
            // 
            // m_lUser
            // 
            this.m_lUser.AutoSize = true;
            this.m_lUser.Location = new System.Drawing.Point(89, 197);
            this.m_lUser.Name = "m_lUser";
            this.m_lUser.Size = new System.Drawing.Size(69, 33);
            this.m_lUser.TabIndex = 1;
            this.m_lUser.Text = "用户:";
            // 
            // m_lPassword
            // 
            this.m_lPassword.AutoSize = true;
            this.m_lPassword.Location = new System.Drawing.Point(89, 258);
            this.m_lPassword.Name = "m_lPassword";
            this.m_lPassword.Size = new System.Drawing.Size(69, 33);
            this.m_lPassword.TabIndex = 2;
            this.m_lPassword.Text = "密码:";
            // 
            // m_textBoxPossword
            // 
            this.m_textBoxPossword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_textBoxPossword.Location = new System.Drawing.Point(167, 256);
            this.m_textBoxPossword.Name = "m_textBoxPossword";
            this.m_textBoxPossword.PasswordChar = '*';
            this.m_textBoxPossword.Size = new System.Drawing.Size(248, 39);
            this.m_textBoxPossword.TabIndex = 4;
            // 
            // m_comboBoxUser
            // 
            this.m_comboBoxUser.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.m_comboBoxUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxUser.FormattingEnabled = true;
            this.m_comboBoxUser.Location = new System.Drawing.Point(167, 190);
            this.m_comboBoxUser.Name = "m_comboBoxUser";
            this.m_comboBoxUser.Size = new System.Drawing.Size(248, 40);
            this.m_comboBoxUser.TabIndex = 5;
            // 
            // m_rBtnLogin
            // 
            this.m_rBtnLogin.DisableBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_rBtnLogin.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnLogin.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnLogin.FlatAppearance.BorderSize = 0;
            this.m_rBtnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnLogin.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_rBtnLogin.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnLogin.Location = new System.Drawing.Point(218, 323);
            this.m_rBtnLogin.Name = "m_rBtnLogin";
            this.m_rBtnLogin.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnLogin.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnLogin.Radius = 20;
            this.m_rBtnLogin.Size = new System.Drawing.Size(123, 43);
            this.m_rBtnLogin.TabIndex = 8;
            this.m_rBtnLogin.Text = "Login";
            this.m_rBtnLogin.UseVisualStyleBackColor = true;
            this.m_rBtnLogin.Click += new System.EventHandler(this.m_rBtnLogin_Click);
            // 
            // m_lLogin
            // 
            this.m_lLogin.DisableBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.m_lLogin.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.m_lLogin.EnterForeColor = System.Drawing.Color.Black;
            this.m_lLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_lLogin.FlatAppearance.BorderSize = 0;
            this.m_lLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_lLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_lLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_lLogin.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.m_lLogin.HoverForeColor = System.Drawing.Color.Black;
            this.m_lLogin.Location = new System.Drawing.Point(38, 33);
            this.m_lLogin.Name = "m_lLogin";
            this.m_lLogin.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.m_lLogin.PressForeColor = System.Drawing.Color.Black;
            this.m_lLogin.Radius = 20;
            this.m_lLogin.Size = new System.Drawing.Size(120, 40);
            this.m_lLogin.TabIndex = 9;
            this.m_lLogin.Text = "登陆";
            this.m_lLogin.UseVisualStyleBackColor = true;
            // 
            // CLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 480);
            this.ControlBox = false;
            this.Controls.Add(this.m_lLogin);
            this.Controls.Add(this.m_rBtnLogin);
            this.Controls.Add(this.m_comboBoxUser);
            this.Controls.Add(this.m_textBoxPossword);
            this.Controls.Add(this.m_lPassword);
            this.Controls.Add(this.m_lUser);
            this.Controls.Add(this.m_bLoginImage);
            this.Font = new System.Drawing.Font("Open Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "CLogin";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_bLoginImage;
        private System.Windows.Forms.Label m_lUser;
        private System.Windows.Forms.Label m_lPassword;
        private System.Windows.Forms.TextBox m_textBoxPossword;
        private System.Windows.Forms.ComboBox m_comboBoxUser;
        private Repaint.CRoundButton m_rBtnLogin;
        private Repaint.CRoundButton m_lLogin;
    }
}