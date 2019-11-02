using System;

using System.Windows.Forms;

namespace AnsonGlue.UI
{
    public partial class CParaSetting : Form
    {
        private CGlueParaSetting m_oDlgParaSetting;
        private CCmtSetting m_oDlgCmtSetting;

        public CParaSetting()
        {
            InitializeComponent();
            m_oDlgParaSetting = new CGlueParaSetting();
            m_oDlgCmtSetting = new CCmtSetting();
        }

        private void m_rBtnMotionSetting_Click(object sender, EventArgs e)
        {
            m_oDlgParaSetting.ShowDialog();
        }

        private void m_rBtnCmtSetting_Click(object sender, EventArgs e)
        {
            m_oDlgCmtSetting.ShowDialog();
        }
    }
}
