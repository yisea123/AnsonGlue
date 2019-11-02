using System;
using System.Windows.Forms;

namespace AnsonGlue.UI
{
    public partial class CModeSelect : Form
    {
        /// <summary>
        /// 创建一个委托
        /// </summary>
        /// <param name="iModel"></param>
        public delegate void CHANGE_MAIN_DIALOG_COLOR_BTN(int iModel);
        /// <summary>
        /// 构造
        /// </summary>
        public CModeSelect()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 声明用于改变主窗口颜色和按钮使能的事件
        /// </summary>
        public event CHANGE_MAIN_DIALOG_COLOR_BTN m_eChangeMainDialogColorBtn;
        /// <summary>
        /// 改变ModeSelect窗口的按钮状态
        /// </summary>
        /// <param name="iModel"></param>
        public void ChangeBtnStatus(int iModel)
        {
            EbableAllBtn(false);
            switch (iModel)
            {
                case (int) CModeSelectButtonName.PRODUCTION:
                {
                    m_rBtnProductionMode.Enabled = true;
                    break;
                }
                case (int) CModeSelectButtonName.ENGINEER:
                {
                    m_rBtnEngineeringMode.Enabled = true;
                    m_rBtnProductionMode.Enabled = true;
                    m_rBtnCpkGrrMode.Enabled = true;
                    m_rBrtnCheckMode.Enabled = true;
                    break;
                }
                case (int) CModeSelectButtonName.CPK_GRR:
                {
                    m_rBtnCpkGrrMode.Enabled = true;
                    break;
                }
                case (int) CModeSelectButtonName.CHECK:
                {
                    m_rBrtnCheckMode.Enabled = true;
                    break;
                }
                case (int) CModeSelectButtonName.DISABLE_ALL:
                {
                    if (m_eChangeMainDialogColorBtn != null)
                        m_eChangeMainDialogColorBtn((int) CModeSelectButtonName.DISABLE_ALL);
                    break;
                }
            }
        }
        /// <summary>
        /// 更改按钮使能
        /// </summary>
        /// <param name="bEnable"></param>
        private void EbableAllBtn(bool bEnable)
        {
            m_rBtnProductionMode.Enabled = bEnable;
            m_rBtnEngineeringMode.Enabled = bEnable;
            m_rBtnCpkGrrMode.Enabled = bEnable;
            m_rBrtnCheckMode.Enabled = bEnable;
        }

        private void ModeSelect_Load(object sender, EventArgs e)
        {
            EbableAllBtn(false);
        }

        private void m_rBtnProductionMode_Click(object sender, EventArgs e)
        {
            if (m_eChangeMainDialogColorBtn != null)
                m_eChangeMainDialogColorBtn((int) CModeSelectButtonName.PRODUCTION);
        }

        private void m_rBtnEngineeringMode_Click(object sender, EventArgs e)
        {
            if (m_eChangeMainDialogColorBtn != null)
                m_eChangeMainDialogColorBtn((int) CModeSelectButtonName.ENGINEER);
        }

        private void m_rBtnCpkGrrMode_Click(object sender, EventArgs e)
        {
            if (m_eChangeMainDialogColorBtn != null)
                m_eChangeMainDialogColorBtn((int) CModeSelectButtonName.CPK_GRR);
        }

        private void m_rBrtnCheckMode_Click(object sender, EventArgs e)
        {
            if (m_eChangeMainDialogColorBtn != null)
                m_eChangeMainDialogColorBtn((int) CModeSelectButtonName.CHECK);
        }
    }
}