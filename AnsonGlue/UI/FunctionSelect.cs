using System;
using System.Windows.Forms;
using AnsonGlue.Kernel;

namespace AnsonGlue.UI
{
    public partial class CFunctionSelect : Form
    {
        private CKernel m_oKernel;

        public CFunctionSelect()
        {
            InitializeComponent();
            m_oKernel = CKernel.GetInstance();
        }

        public void EnableAllBtn(bool bEnable)
        {
            m_gBoxAnalogSignal.Enabled = bEnable;
            m_gBoxRestart.Enabled = bEnable;
        }


        private void CFunctionSelect_Load(object sender, EventArgs e)
        {
            EnableAllBtn(false);
        }

        private void m_rBtnRestartServer_Click(object sender, EventArgs e)
        {
            //m_oKernel.DisconnectVision();
            //CKernel.Delay(500);
            //STRUCT_CMT_INFO tCmtScannerInfo = m_oKernel.GetCmtPara(@"视觉");
            //m_oKernel.ConnectVision();
        }
    }
}