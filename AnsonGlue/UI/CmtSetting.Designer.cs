namespace AnsonGlue.UI
{
    partial class CCmtSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCmtSetting));
            this.m_cBoxSelHardware = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_gBoxTcpClient = new System.Windows.Forms.GroupBox();
            this.m_tBoxPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_tBoxAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_gBoxSerialPort = new System.Windows.Forms.GroupBox();
            this.m_cBoxPortNo = new System.Windows.Forms.ComboBox();
            this.m_cBoxParity = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.m_cBoxStopBits = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_cBoxDateBits = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_cBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cBoxCmtPattern = new System.Windows.Forms.ComboBox();
            this.m_btnSaveParaToIni = new System.Windows.Forms.Button();
            this.m_gBoxTcpClient.SuspendLayout();
            this.m_gBoxSerialPort.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cBoxSelHardware
            // 
            this.m_cBoxSelHardware.FormattingEnabled = true;
            this.m_cBoxSelHardware.Location = new System.Drawing.Point(149, 18);
            this.m_cBoxSelHardware.Name = "m_cBoxSelHardware";
            this.m_cBoxSelHardware.Size = new System.Drawing.Size(121, 23);
            this.m_cBoxSelHardware.TabIndex = 0;
            this.m_cBoxSelHardware.SelectedIndexChanged += new System.EventHandler(this.m_cBoxSelHardware_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择设备：";
            // 
            // m_gBoxTcpClient
            // 
            this.m_gBoxTcpClient.Controls.Add(this.m_tBoxPort);
            this.m_gBoxTcpClient.Controls.Add(this.label4);
            this.m_gBoxTcpClient.Controls.Add(this.m_tBoxAddress);
            this.m_gBoxTcpClient.Controls.Add(this.label3);
            this.m_gBoxTcpClient.Location = new System.Drawing.Point(30, 93);
            this.m_gBoxTcpClient.Name = "m_gBoxTcpClient";
            this.m_gBoxTcpClient.Size = new System.Drawing.Size(296, 157);
            this.m_gBoxTcpClient.TabIndex = 7;
            this.m_gBoxTcpClient.TabStop = false;
            this.m_gBoxTcpClient.Text = "Tcp客户端";
            // 
            // m_tBoxPort
            // 
            this.m_tBoxPort.Location = new System.Drawing.Point(106, 81);
            this.m_tBoxPort.Name = "m_tBoxPort";
            this.m_tBoxPort.Size = new System.Drawing.Size(121, 25);
            this.m_tBoxPort.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "端口：";
            // 
            // m_tBoxAddress
            // 
            this.m_tBoxAddress.Location = new System.Drawing.Point(106, 30);
            this.m_tBoxAddress.Name = "m_tBoxAddress";
            this.m_tBoxAddress.Size = new System.Drawing.Size(121, 25);
            this.m_tBoxAddress.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "地址：";
            // 
            // m_gBoxSerialPort
            // 
            this.m_gBoxSerialPort.Controls.Add(this.m_cBoxPortNo);
            this.m_gBoxSerialPort.Controls.Add(this.m_cBoxParity);
            this.m_gBoxSerialPort.Controls.Add(this.label9);
            this.m_gBoxSerialPort.Controls.Add(this.m_cBoxStopBits);
            this.m_gBoxSerialPort.Controls.Add(this.label8);
            this.m_gBoxSerialPort.Controls.Add(this.m_cBoxDateBits);
            this.m_gBoxSerialPort.Controls.Add(this.label7);
            this.m_gBoxSerialPort.Controls.Add(this.m_cBoxBaudRate);
            this.m_gBoxSerialPort.Controls.Add(this.label6);
            this.m_gBoxSerialPort.Controls.Add(this.label5);
            this.m_gBoxSerialPort.Location = new System.Drawing.Point(30, 256);
            this.m_gBoxSerialPort.Name = "m_gBoxSerialPort";
            this.m_gBoxSerialPort.Size = new System.Drawing.Size(296, 286);
            this.m_gBoxSerialPort.TabIndex = 8;
            this.m_gBoxSerialPort.TabStop = false;
            this.m_gBoxSerialPort.Text = "串口";
            // 
            // m_cBoxPortNo
            // 
            this.m_cBoxPortNo.FormattingEnabled = true;
            this.m_cBoxPortNo.Location = new System.Drawing.Point(106, 40);
            this.m_cBoxPortNo.Name = "m_cBoxPortNo";
            this.m_cBoxPortNo.Size = new System.Drawing.Size(121, 23);
            this.m_cBoxPortNo.TabIndex = 10;
            // 
            // m_cBoxParity
            // 
            this.m_cBoxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cBoxParity.FormattingEnabled = true;
            this.m_cBoxParity.Location = new System.Drawing.Point(106, 234);
            this.m_cBoxParity.Name = "m_cBoxParity";
            this.m_cBoxParity.Size = new System.Drawing.Size(121, 23);
            this.m_cBoxParity.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "奇偶校验：";
            // 
            // m_cBoxStopBits
            // 
            this.m_cBoxStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cBoxStopBits.FormattingEnabled = true;
            this.m_cBoxStopBits.Location = new System.Drawing.Point(106, 188);
            this.m_cBoxStopBits.Name = "m_cBoxStopBits";
            this.m_cBoxStopBits.Size = new System.Drawing.Size(121, 23);
            this.m_cBoxStopBits.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "停止位：";
            // 
            // m_cBoxDateBits
            // 
            this.m_cBoxDateBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cBoxDateBits.FormattingEnabled = true;
            this.m_cBoxDateBits.Location = new System.Drawing.Point(106, 141);
            this.m_cBoxDateBits.Name = "m_cBoxDateBits";
            this.m_cBoxDateBits.Size = new System.Drawing.Size(121, 23);
            this.m_cBoxDateBits.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "数据位：";
            // 
            // m_cBoxBaudRate
            // 
            this.m_cBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cBoxBaudRate.FormattingEnabled = true;
            this.m_cBoxBaudRate.Location = new System.Drawing.Point(106, 92);
            this.m_cBoxBaudRate.Name = "m_cBoxBaudRate";
            this.m_cBoxBaudRate.Size = new System.Drawing.Size(121, 23);
            this.m_cBoxBaudRate.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "波特率：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "串口号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "通讯方式：";
            // 
            // m_cBoxCmtPattern
            // 
            this.m_cBoxCmtPattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cBoxCmtPattern.FormattingEnabled = true;
            this.m_cBoxCmtPattern.Location = new System.Drawing.Point(149, 63);
            this.m_cBoxCmtPattern.Name = "m_cBoxCmtPattern";
            this.m_cBoxCmtPattern.Size = new System.Drawing.Size(121, 23);
            this.m_cBoxCmtPattern.TabIndex = 9;
            this.m_cBoxCmtPattern.SelectedIndexChanged += new System.EventHandler(this.m_cBoxCmtPattern_SelectedIndexChanged);
            // 
            // m_btnSaveParaToIni
            // 
            this.m_btnSaveParaToIni.Location = new System.Drawing.Point(424, 512);
            this.m_btnSaveParaToIni.Name = "m_btnSaveParaToIni";
            this.m_btnSaveParaToIni.Size = new System.Drawing.Size(92, 30);
            this.m_btnSaveParaToIni.TabIndex = 11;
            this.m_btnSaveParaToIni.Text = "Save";
            this.m_btnSaveParaToIni.UseVisualStyleBackColor = true;
            this.m_btnSaveParaToIni.Click += new System.EventHandler(this.m_btnSaveParaToIni_Click);
            // 
            // CCmtSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 563);
            this.Controls.Add(this.m_btnSaveParaToIni);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_cBoxCmtPattern);
            this.Controls.Add(this.m_gBoxTcpClient);
            this.Controls.Add(this.m_gBoxSerialPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_cBoxSelHardware);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CCmtSetting";
            this.Text = "通讯方式选择";
            this.Load += new System.EventHandler(this.CmtSetting_Load);
            this.m_gBoxTcpClient.ResumeLayout(false);
            this.m_gBoxTcpClient.PerformLayout();
            this.m_gBoxSerialPort.ResumeLayout(false);
            this.m_gBoxSerialPort.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox m_cBoxSelHardware;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox m_gBoxTcpClient;
        private System.Windows.Forms.TextBox m_tBoxPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox m_tBoxAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox m_gBoxSerialPort;
        private System.Windows.Forms.ComboBox m_cBoxPortNo;
        private System.Windows.Forms.ComboBox m_cBoxParity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox m_cBoxStopBits;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox m_cBoxDateBits;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox m_cBoxBaudRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox m_cBoxCmtPattern;
        private System.Windows.Forms.Button m_btnSaveParaToIni;
    }
}