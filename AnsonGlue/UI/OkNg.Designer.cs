namespace AnsonGlue.UI
{
    partial class COkNg
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.m_chartOkNg = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.m_chartOkNg)).BeginInit();
            this.SuspendLayout();
            // 
            // m_chartOkNg
            // 
            this.m_chartOkNg.BackColor = System.Drawing.SystemColors.Control;
            this.m_chartOkNg.BorderlineColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.m_chartOkNg.ChartAreas.Add(chartArea1);
            this.m_chartOkNg.Enabled = false;
            legend1.Name = "Legend1";
            this.m_chartOkNg.Legends.Add(legend1);
            this.m_chartOkNg.Location = new System.Drawing.Point(12, 12);
            this.m_chartOkNg.MaximumSize = new System.Drawing.Size(476, 236);
            this.m_chartOkNg.Name = "m_chartOkNg";
            this.m_chartOkNg.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.IsValueShownAsLabel = true;
            series1.Label = "#VALX:#VAL";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.m_chartOkNg.Series.Add(series1);
            this.m_chartOkNg.Size = new System.Drawing.Size(460, 236);
            this.m_chartOkNg.TabIndex = 0;
            this.m_chartOkNg.Text = "Check";
            // 
            // OkNg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 260);
            this.Controls.Add(this.m_chartOkNg);
            this.Font = new System.Drawing.Font("Open Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "COkNg";
            this.Text = "OkNg";
            this.Load += new System.EventHandler(this.OkNg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_chartOkNg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart m_chartOkNg;
    }
}