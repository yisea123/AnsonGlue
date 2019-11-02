namespace AnsonGlue.UI
{
    partial class CPositionSetting
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView_Position = new System.Windows.Forms.DataGridView();
            this.位置 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip_Operation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.获取当前位置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Position)).BeginInit();
            this.contextMenuStrip_Operation.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_Position
            // 
            this.dataGridView_Position.AllowUserToAddRows = false;
            this.dataGridView_Position.AllowUserToDeleteRows = false;
            this.dataGridView_Position.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Position.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.位置,
            this.xPosition,
            this.yPosition,
            this.zPosition});
            this.dataGridView_Position.ContextMenuStrip = this.contextMenuStrip_Operation;
            this.dataGridView_Position.Location = new System.Drawing.Point(11, 11);
            this.dataGridView_Position.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_Position.Name = "dataGridView_Position";
            this.dataGridView_Position.RowTemplate.Height = 27;
            this.dataGridView_Position.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Position.Size = new System.Drawing.Size(518, 553);
            this.dataGridView_Position.TabIndex = 10;
            // 
            // 位置
            // 
            this.位置.HeaderText = "Position";
            this.位置.Name = "位置";
            // 
            // xPosition
            // 
            this.xPosition.HeaderText = "X";
            this.xPosition.Name = "xPosition";
            // 
            // yPosition
            // 
            this.yPosition.HeaderText = "Y";
            this.yPosition.Name = "yPosition";
            // 
            // zPosition
            // 
            this.zPosition.HeaderText = "Z";
            this.zPosition.Name = "zPosition";
            // 
            // contextMenuStrip_Operation
            // 
            this.contextMenuStrip_Operation.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip_Operation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.获取当前位置ToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.运动ToolStripMenuItem});
            this.contextMenuStrip_Operation.Name = "contextMenuStrip1";
            this.contextMenuStrip_Operation.Size = new System.Drawing.Size(169, 76);
            // 
            // 获取当前位置ToolStripMenuItem
            // 
            this.获取当前位置ToolStripMenuItem.Name = "获取当前位置ToolStripMenuItem";
            this.获取当前位置ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.获取当前位置ToolStripMenuItem.Text = "获取当前位置";
            this.获取当前位置ToolStripMenuItem.Click += new System.EventHandler(this.获取当前位置ToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.saveToolStripMenuItem.Text = "保存";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // 运动ToolStripMenuItem
            // 
            this.运动ToolStripMenuItem.Name = "运动ToolStripMenuItem";
            this.运动ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.运动ToolStripMenuItem.Text = "运动";
            this.运动ToolStripMenuItem.Click += new System.EventHandler(this.运动ToolStripMenuItem_Click);
            // 
            // CPositionSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 590);
            this.Controls.Add(this.dataGridView_Position);
            this.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(462, 405);
            this.Name = "CPositionSetting";
            this.Text = "ParaSetting";
            this.Load += new System.EventHandler(this.ParaSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Position)).EndInit();
            this.contextMenuStrip_Operation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn 位置;
        private System.Windows.Forms.DataGridViewTextBoxColumn xPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn yPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn zPosition;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Operation;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 获取当前位置ToolStripMenuItem;
    }
}