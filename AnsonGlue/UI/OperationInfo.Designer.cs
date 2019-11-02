namespace AnsonGlue.UI
{
    partial class COperationInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
       // private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            Hide();
            //if (disposing && (components != null))
            //{
            //    components.Dispose();
            //}
            //base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_dataGridViewInfo = new System.Windows.Forms.DataGridView();
            this.Column_Info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridViewInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // m_dataGridViewInfo
            // 
            this.m_dataGridViewInfo.AllowUserToAddRows = false;
            this.m_dataGridViewInfo.AllowUserToDeleteRows = false;
            this.m_dataGridViewInfo.AllowUserToResizeRows = false;
            this.m_dataGridViewInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dataGridViewInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Info,
            this.Column_Time});
            this.m_dataGridViewInfo.GridColor = System.Drawing.Color.SeaGreen;
            this.m_dataGridViewInfo.Location = new System.Drawing.Point(12, 12);
            this.m_dataGridViewInfo.MultiSelect = false;
            this.m_dataGridViewInfo.Name = "m_dataGridViewInfo";
            this.m_dataGridViewInfo.ReadOnly = true;
            this.m_dataGridViewInfo.RowTemplate.Height = 27;
            this.m_dataGridViewInfo.Size = new System.Drawing.Size(581, 722);
            this.m_dataGridViewInfo.TabIndex = 0;
            this.m_dataGridViewInfo.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.m_dataGridView_CellPainting);
            // 
            // Column_Info
            // 
            this.Column_Info.HeaderText = "操作信息";
            this.Column_Info.MinimumWidth = 280;
            this.Column_Info.Name = "Column_Info";
            this.Column_Info.ReadOnly = true;
            this.Column_Info.Width = 280;
            // 
            // Column_Time
            // 
            this.Column_Time.HeaderText = "时间";
            this.Column_Time.MinimumWidth = 240;
            this.Column_Time.Name = "Column_Time";
            this.Column_Time.ReadOnly = true;
            this.Column_Time.Width = 240;
            // 
            // COperationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 753);
            this.Controls.Add(this.m_dataGridViewInfo);
            this.Name = "COperationInfo";
            this.Text = "操作信息";
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridViewInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView m_dataGridViewInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Info;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Time;
    }
}