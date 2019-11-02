using System;
using System.Windows.Forms;
using AnsonGlue.Kernel;

namespace AnsonGlue.UI
{
    public partial class CIoDilalog : Form
    {
        private CKernel m_oKernel;

        public CIoDilalog()
        {
            InitializeComponent();
            m_oKernel = CKernel.GetInstance();
            timer_IO_Update.Enabled = false;
        }


        private void CIoDilalog_Load(object sender, EventArgs e)
        {
            if (!m_oKernel.m_bMotionCardInit)
                timer_IO_Update.Enabled = true;
            timer_IO_Update.Start();
        }

        private void timer_IO_Update_Tick(object sender, EventArgs e)
        {
            if (!m_oKernel.m_bMotionCardInit)
            {
                timer_IO_Update.Stop();
                timer_IO_Update.Enabled = false;
                MessageBox.Show(@"板卡初始化失败，不能扫描IO状态！", @"提示", MessageBoxButtons.OKCancel);
                return;
            }

            UpdateDiSts();
            UpdateDoSts();
        }

        private void UpdateDiSts()
        {
            m_lExI0.Enabled = m_oKernel.GetDiSts(0, (ushort) ENUM_INPUT_POINT.ESTOP_BUTTON);
            m_lExI1.Enabled = m_oKernel.GetDiSts(0, (ushort) ENUM_INPUT_POINT.START_BUTTON);
            m_lExI2.Enabled = m_oKernel.GetDiSts(0, (ushort) ENUM_INPUT_POINT.STOP_BUTTON);
            m_lExI3.Enabled = m_oKernel.GetDiSts(0, (ushort) ENUM_INPUT_POINT.RESET_BUTTON);
            m_lExI4.Enabled = m_oKernel.GetDiSts(0, (ushort) ENUM_INPUT_POINT.LINE_WAIT_SENSOR);
            m_lExI5.Enabled = m_oKernel.GetDiSts(0, (ushort) ENUM_INPUT_POINT.LINE_STOPSENSOR);
            m_lExI6.Enabled = m_oKernel.GetDiSts(0, (ushort) ENUM_INPUT_POINT.LINE_OUTSENSOR);
            m_lExI7.Enabled = m_oKernel.GetDiSts(0, (ushort) ENUM_INPUT_POINT.FM_OUT_TRAY);
            m_lExI8.Enabled = m_oKernel.GetDiSts(0, (ushort) ENUM_INPUT_POINT.BM_ASK_TRAY);
            m_lExI9.Enabled = m_oKernel.GetDiSts(0, (ushort) ENUM_INPUT_POINT.LIFT_CYL_UP);
            m_lExI10.Enabled = m_oKernel.GetDiSts(0, (ushort) ENUM_INPUT_POINT.LIFT_CYL_DN);
            m_lExI11.Enabled = m_oKernel.GetDiSts(0, (ushort) ENUM_INPUT_POINT.BLOCK_CYL_UP);
            m_lExI12.Enabled = m_oKernel.GetDiSts(0, (ushort) ENUM_INPUT_POINT.BLOCK_CYL_DN);
            m_lExI13.Enabled = m_oKernel.GetDiSts(0, (ushort) ENUM_INPUT_POINT.GLUE_CHECK1);
            m_lExI14.Enabled = m_oKernel.GetDiSts(0, (ushort) ENUM_INPUT_POINT.GLUE_CHECK2);
            m_lExI15.Enabled = m_oKernel.GetDiSts(0, (ushort) ENUM_INPUT_POINT.DOOR_SENSOR);
        }

        private void UpdateDoSts()
        {
            m_lExO0.Enabled = m_oKernel.GetDoSts(0, (ushort) ENUM_OUTPUT_POINT.GREEN_LAMP);
            m_lExO1.Enabled = m_oKernel.GetDoSts(0, (ushort) ENUM_OUTPUT_POINT.RED_LAMP);
            m_lExO2.Enabled = m_oKernel.GetDoSts(0, (ushort) ENUM_OUTPUT_POINT.YELLOW_LAMP);
            m_lExO3.Enabled = m_oKernel.GetDoSts(0, (ushort) ENUM_OUTPUT_POINT.BUZZOR);
            m_lExO4.Enabled = m_oKernel.GetDoSts(0, (ushort) ENUM_OUTPUT_POINT.CLEANING_VACUUM);
            m_lExO5.Enabled = m_oKernel.GetDoSts(0, (ushort) ENUM_OUTPUT_POINT.LIFT_CYL);
            m_lExO6.Enabled = m_oKernel.GetDoSts(0, (ushort) ENUM_OUTPUT_POINT.BLOCK_CYL);
            m_lExO7.Enabled = m_oKernel.GetDoSts(0, (ushort) ENUM_OUTPUT_POINT.FRONT_BLOCK_CYL);
            m_lExO8.Enabled = m_oKernel.GetDoSts(0, (ushort) ENUM_OUTPUT_POINT.CAMERA1_LIGHT1);
            m_lExO9.Enabled = m_oKernel.GetDoSts(0, (ushort) ENUM_OUTPUT_POINT.CAMERA1_LIGHT2);
            m_lExO10.Enabled = m_oKernel.GetDoSts(0, (ushort) ENUM_OUTPUT_POINT.CAMERA2_LIGHT1);
            m_lExO11.Enabled = m_oKernel.GetDoSts(0, (ushort) ENUM_OUTPUT_POINT.CAMERA2_LIGHT2);
            m_lExO12.Enabled = m_oKernel.GetDoSts(0, (ushort) ENUM_OUTPUT_POINT.ASK_TRAY);
            m_lExO13.Enabled = m_oKernel.GetDoSts(0, (ushort) ENUM_OUTPUT_POINT.OUT_TRAY);
            m_lExO14.Enabled = m_oKernel.GetDoSts(0, (ushort) ENUM_OUTPUT_POINT.GLUE);
            m_lExO15.Enabled = m_oKernel.GetDoSts(0, (ushort) ENUM_OUTPUT_POINT.PIN_CLAMPING);
        }

        private void ExO_Click(object sender, EventArgs e)
        {
            if (!m_oKernel.m_bMotionCardInit) return;
            var btn = (Button) sender;
            if (btn == m_rBtnExO0) m_oKernel.SetDoSts(0, (ushort) ENUM_OUTPUT_POINT.GREEN_LAMP, !m_lExO0.Enabled);
            if (btn == m_rBtnExO1) m_oKernel.SetDoSts(0, (ushort) ENUM_OUTPUT_POINT.RED_LAMP, !m_lExO1.Enabled);
            if (btn == m_rBtnExO2) m_oKernel.SetDoSts(0, (ushort) ENUM_OUTPUT_POINT.YELLOW_LAMP, !m_lExO2.Enabled);
            if (btn == m_rBtnExO3) m_oKernel.SetDoSts(0, (ushort) ENUM_OUTPUT_POINT.BUZZOR, !m_lExO3.Enabled);
            if (btn == m_rBtnExO4) m_oKernel.SetDoSts(0, (ushort) ENUM_OUTPUT_POINT.CLEANING_VACUUM, !m_lExO4.Enabled);
            if (btn == m_rBtnExO5) m_oKernel.SetDoSts(0, (ushort) ENUM_OUTPUT_POINT.LIFT_CYL, !m_lExO5.Enabled);
            if (btn == m_rBtnExO6) m_oKernel.SetDoSts(0, (ushort) ENUM_OUTPUT_POINT.BLOCK_CYL, !m_lExO6.Enabled);
            if (btn == m_rBtnExO7) m_oKernel.SetDoSts(0, (ushort) ENUM_OUTPUT_POINT.FRONT_BLOCK_CYL, !m_lExO7.Enabled);
            if (btn == m_rBtnExO8) m_oKernel.SetDoSts(0, (ushort) ENUM_OUTPUT_POINT.CAMERA1_LIGHT1, !m_lExO8.Enabled);
            if (btn == m_rBtnExO9) m_oKernel.SetDoSts(0, (ushort) ENUM_OUTPUT_POINT.CAMERA1_LIGHT2, !m_lExO9.Enabled);
            if (btn == m_rBtnExO10) m_oKernel.SetDoSts(0, (ushort) ENUM_OUTPUT_POINT.CAMERA2_LIGHT1, !m_lExO10.Enabled);
            if (btn == m_rBtnExO11) m_oKernel.SetDoSts(0, (ushort) ENUM_OUTPUT_POINT.CAMERA2_LIGHT2, !m_lExO11.Enabled);
            if (btn == m_rBtnExO12) m_oKernel.SetDoSts(0, (ushort) ENUM_OUTPUT_POINT.ASK_TRAY, !m_lExO12.Enabled);
            if (btn == m_rBtnExO13) m_oKernel.SetDoSts(0, (ushort) ENUM_OUTPUT_POINT.OUT_TRAY, !m_lExO13.Enabled);
            if (btn == m_rBtnExO14) m_oKernel.SetDoSts(0, (ushort) ENUM_OUTPUT_POINT.GLUE, !m_lExO14.Enabled);
            if (btn == m_rBtnExO15) m_oKernel.SetDoSts(0, (ushort) ENUM_OUTPUT_POINT.PIN_CLAMPING, !m_lExO15.Enabled);
        }
    }
}