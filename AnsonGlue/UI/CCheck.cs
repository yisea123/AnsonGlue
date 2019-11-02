using System;
using System.Windows.Forms;

namespace AnsonGlue.UI
{
    public partial class CCheck : Form
    {
        /// <summary>
        /// 显示IO窗口的委托
        /// </summary>
        /// <param name="uDialog"></param>
        public delegate void DISPLAY_DIALOG(CDialogName uDialog);


        public CCheck()
        {
            InitializeComponent();
        }

        public event DISPLAY_DIALOG m_eDisplayDlg;

        /// <summary>
        /// 显示IO窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_rBtnOpenIo_Click(object sender, EventArgs e)
        {
            if (m_eDisplayDlg != null)
                m_eDisplayDlg( CDialogName.IO_DIALOG);
        }

        private void m_rBtnOpenMachine_Click(object sender, EventArgs e)
        {
            if (m_eDisplayDlg != null)
                m_eDisplayDlg(CDialogName.MACHINE_SET_DIALOG);
        }

        private void m_rBtnPluginDebug_Click(object sender, EventArgs e)
        {
            if (m_eDisplayDlg != null)
                m_eDisplayDlg(CDialogName.PLUGIN_DEBUG_DIALOG);
        }
    }
}