using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AnsonGlue.Kernel;

namespace AnsonGlue.UI
{
    public partial class CMachineParaSetting : Form
    {
        private readonly CKernel m_oKernel;

        public CMachineParaSetting()
        {
            InitializeComponent();
            m_oKernel = CKernel.GetInstance();
        }

        private void MachineParaSetting_Load(object sender, EventArgs e)
        {
            m_cBoxCardNo.Items.Add("0");
            m_cBoxCardNo.Items.Add("1");
            m_cBoxCardNo.Items.Add("2");
            m_cBoxCardNo.Items.Add("3");
            m_cBoxCardNo.Items.Add("4");
            //m_cBoxCardNo.SelectedIndex = 0;
            m_cBtnCardType.Items.Add(@"Googol");
            m_cBtnCardType.Items.Add(@"LeiSai");
            m_cBtnCardType.Items.Add(@"LingHou");
            m_cBtnCardType.SelectedIndex = 0;
        }

        private void m_rBtnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"确定保存本窗口参数？", @"确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) !=
                DialogResult.OK) return;

            var listAxisRes = new List<string>
            {
                m_tBoxAxis1Res.Text,
                m_tBoxAxis2Res.Text,
                m_tBoxAxis3Res.Text,
                m_tBoxAxis4Res.Text,
                m_tBoxAxis5Res.Text,
                m_tBoxAxis6Res.Text,
                m_tBoxAxis7Res.Text,
                m_tBoxAxis8Res.Text
            };
            var sMotionCard =
                new CKernel.STRUCT_MOTION_CARD(m_cBtnCardType.Text, m_cBoxCardNo.Text, m_tBoxMaxAxisNum.Text, listAxisRes)
                {
                    //板卡配置信息
                    m_strCfgPath = m_tBoxCfgPath.Text
                };
            //设置设备信息到ini文件
            m_oKernel.SetMachineParaToIni(sMotionCard);
        }

        private void m_cBoxCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_cBtnCardType.Text == "" || m_cBoxCardNo.Text == "")
            {
                MessageBox.Show(@"请选择板卡品牌和卡号！");
                return;
            }

            var listAxisRes = new List<string>
            {
                m_tBoxAxis1Res.Text,
                m_tBoxAxis2Res.Text,
                m_tBoxAxis3Res.Text,
                m_tBoxAxis4Res.Text,
                m_tBoxAxis5Res.Text,
                m_tBoxAxis6Res.Text,
                m_tBoxAxis7Res.Text,
                m_tBoxAxis8Res.Text
            };
            var sMotionCard =
                new CKernel.STRUCT_MOTION_CARD(m_cBtnCardType.Text, m_cBoxCardNo.Text, m_tBoxMaxAxisNum.Text, listAxisRes);

            //从ini文件得到设备信息
            m_oKernel.GetMachineParaFromIni(ref sMotionCard);
            m_tBoxMaxAxisNum.Text = sMotionCard.m_strMaxAxisNum;
            m_tBoxCfgPath.Text = sMotionCard.m_strCfgPath;
            m_tBoxAxis1Res.Text = sMotionCard.m_listOfAxisRes[0];
            m_tBoxAxis2Res.Text = sMotionCard.m_listOfAxisRes[1];
            m_tBoxAxis3Res.Text = sMotionCard.m_listOfAxisRes[2];
            m_tBoxAxis4Res.Text = sMotionCard.m_listOfAxisRes[3];
            m_tBoxAxis5Res.Text = sMotionCard.m_listOfAxisRes[4];
            m_tBoxAxis6Res.Text = sMotionCard.m_listOfAxisRes[5];
            m_tBoxAxis7Res.Text = sMotionCard.m_listOfAxisRes[6];
            m_tBoxAxis8Res.Text = sMotionCard.m_listOfAxisRes[7];
        }

        private void m_rBtnCfgPath_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK) m_tBoxCfgPath.Text = dialog.FileName;
        }
    }
}