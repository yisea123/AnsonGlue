using System;

using System.Windows.Forms;
using AnsonGlue.Kernel;

namespace AnsonGlue.UI
{
   
    public partial class CPluginDebug : Form
    {
        private CKernel m_oKernel;
        public CPluginDebug()
        {
            InitializeComponent();
            m_oKernel = CKernel.GetInstance();
        }

        private void m_rBtnTouchScanner_Click(object sender, EventArgs e)
        {
            m_oKernel.TouchScanner();
        }

        private void m_rBtnTouchBalance_Click(object sender, EventArgs e)
        {
            m_oKernel.TouchBalance();
        }

        private void m_rBtnRestartBalance_Click(object sender, EventArgs e)
        {
            m_oKernel.RestartBalance();
        }

        private void m_rBtnZeroBalance_Click(object sender, EventArgs e)
        {
            m_oKernel.ZeroBalance();

        }
    }
}
