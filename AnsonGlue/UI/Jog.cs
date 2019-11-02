using System;
using System.Threading;
using System.Windows.Forms;
using AnsonGlue.Kernel;

namespace AnsonGlue.UI
{
    public partial class CJog : Form
    {
        private CKernel m_oKernel;

        public CJog()
        {
            InitializeComponent();
            m_oKernel = CKernel.GetInstance();
        }

        private void Jog_Load(object sender, EventArgs e)
        {
            timer_UpdatePosition.Start();
        }

        private void m_rBtnHome_Click(object sender, EventArgs e)
        {
            var tHomeThread = new Thread(HomeThread) {IsBackground = true};
            tHomeThread.Start();
        }

        /// <summary>
        ///     回原点线程
        /// </summary>
        private void HomeThread()
        {
            if (m_oKernel.SingleAxisHome(0, CKernel.ENUM_AXIS_TYPE.Y_AXIS, CKernel.ENUM_HOME_TYPE.CAPTURE_INDEX) == 0)
                m_oKernel.m_bHomed = true;
        }

        /// <summary>
        ///     定时器触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_UpdatePosition_Tick(object sender, EventArgs e)
        {
            if (!m_oKernel.m_bMotionCardInit) return;
            UpdatePositionData();
            UpdateAxisSts();
            UpdateAxisLimitHomeSts();
            UpdateAxisAlarm();
        }

        private void UpdatePositionData()
        {
            if (m_oKernel.m_bMotionCardInit)
            {
                var dXCurPos = m_oKernel.GetAxisCurPos(0, CKernel.ENUM_AXIS_TYPE.X_AXIS);
                var dYCurPos = m_oKernel.GetAxisCurPos(0, CKernel.ENUM_AXIS_TYPE.Y_AXIS);
                var dZCurPos = m_oKernel.GetAxisCurPos(0, CKernel.ENUM_AXIS_TYPE.Z_AXIS);

                //坐标
                m_labelPositionX.Text = dXCurPos.ToString("f3");
                m_labelPositionY.Text = dYCurPos.ToString("f3");
                m_labelPositionZ.Text = dZCurPos.ToString("f3");
            }
        }


        private void UpdateAxisSts()
        {
            m_labelXStatus.Enabled = !m_oKernel.GetAxisMotionSts(0, CKernel.ENUM_AXIS_TYPE.X_AXIS);
            m_labelYStatus.Enabled = !m_oKernel.GetAxisMotionSts(0, CKernel.ENUM_AXIS_TYPE.Y_AXIS);
            m_labelZStatus.Enabled = !m_oKernel.GetAxisMotionSts(0, CKernel.ENUM_AXIS_TYPE.Z_AXIS);
        }
        /// <summary>
        /// 更新轴限位、原点状态
        /// </summary>
        private void UpdateAxisLimitHomeSts()
        {
            m_labelXPosLimit.Enabled = m_oKernel.GetAxisPosLimitSts(0, CKernel.ENUM_AXIS_TYPE.X_AXIS);
            m_labelYPosLimit.Enabled = m_oKernel.GetAxisPosLimitSts(0, CKernel.ENUM_AXIS_TYPE.Y_AXIS);
            m_labelZPosLimit.Enabled = m_oKernel.GetAxisPosLimitSts(0, CKernel.ENUM_AXIS_TYPE.Z_AXIS);

            m_labelXNegLimit.Enabled = m_oKernel.GetAxisNegLimitSts(0, CKernel.ENUM_AXIS_TYPE.X_AXIS);
            m_labelYNegLimit.Enabled = m_oKernel.GetAxisNegLimitSts(0, CKernel.ENUM_AXIS_TYPE.Y_AXIS);
            m_labelZNegLimit.Enabled = m_oKernel.GetAxisNegLimitSts(0, CKernel.ENUM_AXIS_TYPE.Z_AXIS);

            m_labelXHome.Enabled = !m_oKernel.GetAxisHomeLimitSts(0, CKernel.ENUM_AXIS_TYPE.X_AXIS);
            m_labelYHome.Enabled = !m_oKernel.GetAxisHomeLimitSts(0, CKernel.ENUM_AXIS_TYPE.Y_AXIS);
            m_labelZHome.Enabled = !m_oKernel.GetAxisHomeLimitSts(0, CKernel.ENUM_AXIS_TYPE.Z_AXIS);
        }
        /// <summary>
        /// 更新轴状态
        /// </summary>
        private void UpdateAxisAlarm()
        {
            m_labelXAlarm.Enabled = m_oKernel.GetAxisAlarmSts(0, CKernel.ENUM_AXIS_TYPE.X_AXIS);
            m_labelYAlarm.Enabled = m_oKernel.GetAxisAlarmSts(0, CKernel.ENUM_AXIS_TYPE.Y_AXIS);
            m_labelZAlarm.Enabled = m_oKernel.GetAxisAlarmSts(0, CKernel.ENUM_AXIS_TYPE.Z_AXIS);
        }
        /// <summary>
        /// Jog按键按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MotionBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (!m_oKernel.m_bMotionCardInit) return;

            double dVel = m_oKernel.GetMotionParaFromIni(@"Velocity", @"Jog");
            double dAcc = m_oKernel.GetMotionParaFromIni(@"Acceleration", @"Jog");

            var btn = (Button) sender;

            if (m_cBoxInchSel.Checked)
            {
                var distanceOfMotion = Convert.ToDouble(m_tBoxInchDis.Text);

                if (btn == m_rBtnXp) m_oKernel.AxisRMove(CKernel.ENUM_AXIS_TYPE.X_AXIS, dVel, 2, distanceOfMotion);
                if (btn == m_rBtnXn) m_oKernel.AxisRMove(CKernel.ENUM_AXIS_TYPE.X_AXIS, dVel, 2, -distanceOfMotion);

                if (btn == m_rBtnYp) m_oKernel.AxisRMove(CKernel.ENUM_AXIS_TYPE.Y_AXIS, dVel, 2, distanceOfMotion);
                if (btn == m_rBtnYn) m_oKernel.AxisRMove(CKernel.ENUM_AXIS_TYPE.Y_AXIS, dVel, 2, -distanceOfMotion);

                if (btn == m_rBtnZp) m_oKernel.AxisRMove(CKernel.ENUM_AXIS_TYPE.Z_AXIS, dVel, 2, distanceOfMotion);
                if (btn == m_rBtnZn) m_oKernel.AxisRMove(CKernel.ENUM_AXIS_TYPE.Z_AXIS, dVel, 2, -distanceOfMotion);
            }
            else
            {
                if (btn == m_rBtnXp) m_oKernel.AxisJogMove(CKernel.ENUM_AXIS_TYPE.X_AXIS, dVel, dAcc);
                if (btn == m_rBtnXn) m_oKernel.AxisJogMove(CKernel.ENUM_AXIS_TYPE.X_AXIS, -dVel, dAcc);

                if (btn == m_rBtnYp) m_oKernel.AxisJogMove(CKernel.ENUM_AXIS_TYPE.Y_AXIS, dVel, dAcc);
                if (btn == m_rBtnYn) m_oKernel.AxisJogMove(CKernel.ENUM_AXIS_TYPE.Y_AXIS, -dVel, dAcc);

                if (btn == m_rBtnZp) m_oKernel.AxisJogMove(CKernel.ENUM_AXIS_TYPE.Z_AXIS, dVel, dAcc);
                if (btn == m_rBtnZn) m_oKernel.AxisJogMove(CKernel.ENUM_AXIS_TYPE.Z_AXIS, -dVel, dAcc);
            }

        }
        /// <summary>
        /// Jog按键抬起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MotionBtn_MouseUp(object sender, MouseEventArgs e)
        {
            if (!m_oKernel.m_bMotionCardInit) return;
            if (m_cBoxInchSel.Checked) return;
            m_oKernel.SmoothStopAxis(CKernel.ENUM_AXIS_TYPE.X_AXIS);
            m_oKernel.SmoothStopAxis(CKernel.ENUM_AXIS_TYPE.Y_AXIS);
            m_oKernel.SmoothStopAxis(CKernel.ENUM_AXIS_TYPE.Z_AXIS);
        }
    }
}