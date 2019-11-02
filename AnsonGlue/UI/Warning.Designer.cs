using System.Drawing;

namespace AnsonGlue.UI
{
    partial class CWarning
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

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
            this.m_dataGridViewWarning = new System.Windows.Forms.DataGridView();
            this.Column_WarningInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridViewWarning)).BeginInit();
            this.SuspendLayout();
            // 
            // m_dataGridViewWarning
            // 
            this.m_dataGridViewWarning.AllowUserToAddRows = false;
            this.m_dataGridViewWarning.AllowUserToDeleteRows = false;
            this.m_dataGridViewWarning.AllowUserToResizeRows = false;
            this.m_dataGridViewWarning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dataGridViewWarning.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_WarningInfo,
            this.Column_Time});
            this.m_dataGridViewWarning.GridColor = System.Drawing.Color.SeaGreen;
            this.m_dataGridViewWarning.Location = new System.Drawing.Point(1, 1);
            this.m_dataGridViewWarning.MultiSelect = false;
            this.m_dataGridViewWarning.Name = "m_dataGridViewWarning";
            this.m_dataGridViewWarning.ReadOnly = true;
            this.m_dataGridViewWarning.RowTemplate.Height = 27;
            this.m_dataGridViewWarning.Size = new System.Drawing.Size(570, 722);
            this.m_dataGridViewWarning.TabIndex = 0;
            this.m_dataGridViewWarning.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.m_dataGridView_CellPainting);
            // 
            // Column_WarningInfo
            // 
            this.Column_WarningInfo.HeaderText = "报警信息";
            this.Column_WarningInfo.MinimumWidth = 280;
            this.Column_WarningInfo.Name = "Column_WarningInfo";
            this.Column_WarningInfo.ReadOnly = true;
            this.Column_WarningInfo.Width = 280;
            // 
            // Column_Time
            // 
            this.Column_Time.HeaderText = "时间";
            this.Column_Time.MinimumWidth = 240;
            this.Column_Time.Name = "Column_Time";
            this.Column_Time.ReadOnly = true;
            this.Column_Time.Width = 240;
            // 
            // CWarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 753);
            this.Controls.Add(this.m_dataGridViewWarning);
            this.Name = "CWarning";
            this.Text = "报警信息";
            this.Load += new System.EventHandler(this.Warning_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridViewWarning)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView m_dataGridViewWarning;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_WarningInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Time;
    }
}