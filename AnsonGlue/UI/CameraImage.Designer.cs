namespace AnsonGlue.UI
{
    sealed partial class CCameraImage
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
            this.m_pBoxImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_pBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // m_pBoxImage
            // 
            this.m_pBoxImage.BackgroundImage = global::AnsonGlue.Properties.Resources.Image;
            this.m_pBoxImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_pBoxImage.Location = new System.Drawing.Point(32, 56);
            this.m_pBoxImage.Name = "m_pBoxImage";
            this.m_pBoxImage.Size = new System.Drawing.Size(752, 562);
            this.m_pBoxImage.TabIndex = 0;
            this.m_pBoxImage.TabStop = false;
            // 
            // CCameraImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 670);
            this.Controls.Add(this.m_pBoxImage);
            this.Font = new System.Drawing.Font("Open Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "CCameraImage";
            this.Text = "CameraImage";
            this.Load += new System.EventHandler(this.CameraImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_pBoxImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox m_pBoxImage;


    }
}