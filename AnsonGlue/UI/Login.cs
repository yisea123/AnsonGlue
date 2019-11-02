using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnsonGlue.UI
{
    public partial class CLogin : Form
    {
        /// <summary>
        ///     用于修改模式选择窗口样式的委托，等同于创建一个函数指针类型
        /// </summary>
        /// <param name="iModel"></param>
        public delegate void CHANGE_MODEL_SELECT_BTN(int iModel);

        private const int m_c_DISABLE_ALL = 4;
        //private CKernel m_fileTcp;

        public CLogin()
        {
            InitializeComponent();
            //m_fileTcp = CKernel.GetKernel();
        }

        /// <summary>
        ///     声明一个ChangeModelSelectBtn的函数指针
        /// </summary>
        public event CHANGE_MODEL_SELECT_BTN m_eChangeModel;

        private void m_rBtnLogin_Click(object sender, EventArgs e)
        {
            if (string.Compare(m_rBtnLogin.Text, @"Login", StringComparison.Ordinal) == 0)
            {
                //先判断事件是否为空
                if (m_eChangeModel != null)                                
                    m_eChangeModel(m_comboBoxUser.SelectedIndex);                   

                m_textBoxPossword.Enabled = false;
                m_comboBoxUser.Enabled = false;
                m_rBtnLogin.Text = @"Cancel";
                m_rBtnLogin.HoverBackColor = Color.DarkOrange;
                
            }
            else if (string.Compare(m_rBtnLogin.Text, @"Cancel", StringComparison.Ordinal) == 0)
            {
                if (m_eChangeModel != null)
                    m_eChangeModel(m_c_DISABLE_ALL);

                m_comboBoxUser.Enabled = true;
                m_textBoxPossword.Enabled = true;
                m_rBtnLogin.Text = @"Login";
                m_rBtnLogin.HoverBackColor = Color.FromArgb(192, 255, 192);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            m_comboBoxUser.Items.Add(@"Productor");
            m_comboBoxUser.Items.Add(@"Engineer");
            m_comboBoxUser.Items.Add(@"CPK/GRR");
            m_comboBoxUser.Items.Add(@"Debug");
            m_comboBoxUser.SelectedIndex = 0;
        }
    }
}