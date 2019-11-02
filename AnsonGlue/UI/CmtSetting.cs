using System;
using System.Drawing;
using System.Windows.Forms;
using AnsonGlue.Kernel;

namespace AnsonGlue.UI
{
    public partial class CCmtSetting : Form
    {
        private CKernel m_oKernel;
        public CCmtSetting()
        {
            InitializeComponent();
            m_oKernel = CKernel.GetInstance();
        }

        private void CmtSetting_Load(object sender, EventArgs e)
        {
            ControlerInit();
        }

        private void ControlerInit()
        {
            //通讯方式下拉框
            m_cBoxCmtPattern.Items.Add(@"串口");
            m_cBoxCmtPattern.Items.Add(@"TCP客户端");
            m_cBoxCmtPattern.SelectedIndex = 0;

            //选择设备下拉框
            m_cBoxSelHardware.Items.Clear();
            m_cBoxSelHardware.Items.Add(@"电子秤");
            m_cBoxSelHardware.Items.Add(@"扫码枪");
            m_cBoxSelHardware.Items.Add(@"点胶阀");
            m_cBoxSelHardware.Items.Add(@"视觉");
            m_cBoxSelHardware.SelectedIndex = 0;

            //串口波特率
            m_cBoxBaudRate.Items.Add(@"9600");
            m_cBoxBaudRate.Items.Add(@"19200");
            m_cBoxBaudRate.Items.Add(@"38400");
            m_cBoxBaudRate.Items.Add(@"115200");
            m_cBoxBaudRate.SelectedIndex = 0;

            //串口数据位
            m_cBoxDateBits.Items.Add(@"8");
            m_cBoxDateBits.Items.Add(@"7");
            m_cBoxDateBits.SelectedIndex = 0;

            //串口停止位
            m_cBoxStopBits.Items.Add(@"None");
            m_cBoxStopBits.Items.Add(@"One");
            m_cBoxStopBits.Items.Add(@"Two");
            m_cBoxStopBits.SelectedIndex = 0;

            //串口校验位
            m_cBoxParity.Items.Add(@"None");
            m_cBoxParity.Items.Add(@"Odd");
            m_cBoxParity.Items.Add(@"Even");
            m_cBoxParity.SelectedIndex = 0;

            //Socket设置
            m_tBoxAddress.Text = @"127.0.0.1";
            m_tBoxPort.Text = @"8080";
        }

        private void m_btnSaveParaToIni_Click(object sender, EventArgs e)
        {
            string strMsg = string.Format("确定要保存{0}的通讯参数吗？", m_cBoxSelHardware.Text);
            if (MessageBox.Show(strMsg, @"提醒", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            string strEquipment = m_cBoxSelHardware.Text;
            STRUCT_CMT_INFO tCmtInfo = new STRUCT_CMT_INFO { m_nType = m_cBoxCmtPattern.SelectedIndex };
            switch (m_cBoxCmtPattern.SelectedIndex)
            {
                case 0:
                    tCmtInfo.m_strSerialPortNum = m_cBoxPortNo.Text;
                    tCmtInfo.m_nSerialBaudRate = Convert.ToInt32(m_cBoxBaudRate.Text);
                    tCmtInfo.m_nSerialDateBits = Convert.ToInt32(m_cBoxDateBits.Text);
                    tCmtInfo.m_strSerialStopBits = m_cBoxStopBits.Text;
                    tCmtInfo.m_strSerialParity = m_cBoxParity.Text;

                    break;
                case 1:
                    tCmtInfo.m_strStcpAddress = m_tBoxAddress.Text;
                    tCmtInfo.m_nStcpPort = Convert.ToInt32(m_tBoxPort.Text);
                    break;
            }

            m_oKernel.SaveCmtParaToIni(strEquipment,tCmtInfo);
        }

        private void m_cBoxSelHardware_SelectedIndexChanged(object sender, EventArgs e)
        {
            STRUCT_CMT_INFO tCmtInfo = m_oKernel.GetCmtPara(m_cBoxSelHardware.Text);
            m_cBoxCmtPattern.SelectedIndex = tCmtInfo.m_nType;
            //m_cBoxCmtPattern.SelectedIndex = 0;
            m_tBoxAddress.Text = tCmtInfo.m_strStcpAddress;
            m_tBoxPort.Text = tCmtInfo.m_nStcpPort.ToString();
            m_cBoxPortNo.Text = tCmtInfo.m_strSerialPortNum;
            m_cBoxBaudRate.Text = tCmtInfo.m_nSerialBaudRate.ToString();
            m_cBoxDateBits.Text = tCmtInfo.m_nSerialDateBits.ToString();
            m_cBoxStopBits.Text = tCmtInfo.m_strSerialStopBits;
            m_cBoxParity.Text = tCmtInfo.m_strSerialParity;
        }

        private void m_cBoxCmtPattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_gBoxTcpClient.Visible = false;
            m_gBoxSerialPort.Visible = false;
            switch (m_cBoxCmtPattern.SelectedIndex)
            {
                case 0:
                    m_gBoxSerialPort.Location = new Point(30, 120);
                    m_gBoxSerialPort.Visible = true;
                    break;
                case 1:
                    m_gBoxTcpClient.Location = new Point(30, 120);
                    m_gBoxTcpClient.Visible = true;
                    break;
            }
        }
    }
}
