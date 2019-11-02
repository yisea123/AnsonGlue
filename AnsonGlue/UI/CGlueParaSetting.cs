using System;
using System.Windows.Forms;
using AnsonGlue.Kernel;

namespace AnsonGlue.UI
{
    public partial class CGlueParaSetting : Form
    {
        private CKernel m_oKernel; 
        public CGlueParaSetting()
        {
            InitializeComponent();
            m_oKernel = CKernel.GetInstance();
        }

        private void CGlueParaSetting_Load(object sender, EventArgs e)
        {
            LoadAllVelocity();
            LoadSpace();
            LoadAcc();
        }

        private void m_rBtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 下载所有速度
        /// </summary>
        private void LoadAllVelocity()
        {
            string strValue;
            m_oKernel.GetParameterFromIni(@"Velocity", @"Jog", out strValue);
            m_tBoxJogValue.Text = strValue;
            m_oKernel.GetParameterFromIni(@"Velocity", @"Glue", out strValue);
            m_tBoxGlueValue.Text= strValue;
            m_oKernel.GetParameterFromIni(@"Velocity", @"Camera", out strValue);
            m_tBoxCameraValue.Text= strValue;
        }


        /// <summary>
        /// 下载所有延时
        /// </summary>
        private void LoadSpace()
        {
            string strValue;
            m_oKernel.GetParameterFromIni(@"Position", @"PhotoSpace", out strValue);
            m_tBoxPhotographSpace.Text = strValue;
            m_oKernel.GetParameterFromIni(@"Position", @"ZSave", out strValue);
            m_tBoxZSavePosition.Text = strValue;
        }

        /// <summary>
        /// 下载所有加速度
        /// </summary>
        private void LoadAcc()
        {
            string strValue;
            m_oKernel.GetParameterFromIni(@"Acceleration", @"Glue", out strValue);
            m_tBoxGlueAcc.Text = strValue;
            m_oKernel.GetParameterFromIni(@"Acceleration", @"Camera", out strValue);
            m_tBoxCameraAcc.Text = strValue;
        }


        /// <summary>
        /// 保存所有速度
        /// </summary>
        private void SaveAllVelocity()
        {
            m_oKernel.SetParameterToIni(@"Velocity", @"Jog", m_tBoxJogValue.Text);
            m_oKernel.SetParameterToIni(@"Velocity", @"Glue", m_tBoxGlueValue.Text);
            m_oKernel.SetParameterToIni(@"Velocity", @"Camera", m_tBoxCameraValue.Text);
        }

        /// <summary>
        /// 保存所有加速度
        /// </summary>
        private void SaveAllAcc()
        {
            m_oKernel.SetParameterToIni(@"Acceleration", @"Glue", m_tBoxGlueAcc.Text);
            m_oKernel.SetParameterToIni(@"Acceleration", @"Camera", m_tBoxCameraAcc.Text);
        }

        /// <summary>
        /// 保存所有延时
        /// </summary>
        private void SavePosition()
        {
            m_oKernel.SetParameterToIni(@"Position", @"PhotoSpace", m_tBoxPhotographSpace.Text);
            m_oKernel.SetParameterToIni(@"Position", @"ZSave", m_tBoxZSavePosition.Text);
        }



        private void m_rBtnSave_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"是否保存参数？", @"提示", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            SaveAllVelocity();
            SavePosition();
            SaveAllAcc();
        }

        private void m_rBtnSetImagePath_Click(object sender, EventArgs e)
        {
            SavePath(@"Excel");
        }

        /// <summary>
        /// 保存路径
        /// </summary>
        /// <param name="strType">保存的路径类型</param>
        private void SavePath(string strType)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                var strImagePath = folderDialog.SelectedPath;
                m_oKernel.SetExcelImageDirToIni(strType, strImagePath);
            }

        }

        private void m_rBtnSetExcelPath_Click(object sender, EventArgs e)
        {
            SavePath(@"Image"); 
        }

    }
}