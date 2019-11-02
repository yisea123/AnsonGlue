using System;
using System.Threading;
using AnsonGlue.Kernel;
using System.Windows.Forms;

namespace AnsonGlue.UI
{
    public partial class CVisionSetting : Form
    {
        private CKernel m_oKernel;
        public CVisionSetting()
        {
            InitializeComponent();
            m_oKernel = CKernel.GetInstance();
        }

        private void CVisionSetting_Load(object sender, EventArgs e)
        {

            string strIp;
            string strPort;
            m_oKernel.GetVisionIpPortFromIni(out strIp, out strPort);

        }

        private void m_rBtnValveCali_Click(object sender, EventArgs e)
        {
            m_oKernel.SendMsgToServer(CKernel.ENUM_TCP_EVENT.VALVE_CALIBRATION);
        }

        private void m_rBtnCamera_Click(object sender, EventArgs e)
        {
            var tCameraCalibration = new Thread(ThreadCameraCalibration) { IsBackground = true };
            tCameraCalibration.Start();
        }

        private void ThreadCameraCalibration()
        {
            m_oKernel.SendMsgToServer(CKernel.ENUM_TCP_EVENT.CAMERA_CALIBRATION_START);
            CKernel.Delay(1000);
            m_oKernel.SendMsgToServer(CKernel.ENUM_TCP_EVENT.CAMERA_CALIBRATION_CAMERA);
            CKernel.Delay(1000);
            m_oKernel.SendMsgToServer(CKernel.ENUM_TCP_EVENT.CAMERA_CALIBRATION_END);
        }
    }
}
