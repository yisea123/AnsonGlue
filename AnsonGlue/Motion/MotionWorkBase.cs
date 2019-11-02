using System.Collections.Generic;

namespace AnsonGlue.Motion
{
    /// <summary>
    ///     运动控制工作类
    /// </summary>
    public abstract class CMotionWorkBase
    {
        #region 成员变量

        /// <summary>
        ///     运动控制板卡的抽象类接口
        /// </summary>
        protected CMotionBase m_cMotionBase;

        /// <summary>
        ///     轴数量
        /// </summary>
        protected short m_nMaxAxisNum;

        /// <summary>
        ///     数字输入口数
        /// </summary>
        protected ushort m_nDiNum;

        /// <summary>
        ///     数字输出口数
        /// </summary>
        protected ushort m_nDoNum;

        /// <summary>
        ///     //扫描输入信号的报警
        /// </summary>
        protected bool[] m_bAxisAlarm; //扫描输入信号的报警

        /// <summary>
        ///     //扫描输入信号的Home
        /// </summary>
        protected bool[] m_bAxisHome; //扫描输入信号的Home

        /// <summary>
        ///     //扫描输入信号的负限位
        /// </summary>
        protected bool[] m_bAxisNegLmt; //扫描输入信号的负限位

        /// <summary>
        ///     //扫描输入信号的正限位
        /// </summary>
        protected bool[] m_bAxisPosLmt; //扫描输入信号的正限位

        /// <summary>
        ///     //扫描轴状态的伺服报警
        /// </summary>
        protected bool[] m_bFlagAlarm; //扫描轴状态的伺服报警

        /// <summary>
        ///     //扫描轴状态的紧急停止
        /// </summary>
        protected bool[] m_bFlagAStop; //扫描轴状态的紧急停止

        /// <summary>
        ///     //扫描轴状态的运动出错
        /// </summary>
        protected bool[] m_bFlagMError; //扫描轴状态的运动出错

        /// <summary>
        ///     //扫描轴状态的运动状态 TRUE:规划器运动中,FALSE:规划器停止
        /// </summary>
        protected bool[] m_bFlagMotion; //扫描轴状态的运动状态 FALSE:规划器运动中,TRUE:规划器停止

        /// <summary>
        ///     //扫描轴状态的负向限位报警
        /// </summary>
        protected bool[] m_bFlagNegLimit; //扫描轴状态的负向限位报警

        /// <summary>
        ///     //扫描轴状态的正向限位报警
        /// </summary>
        protected bool[] m_bFlagPosLimit; //扫描轴状态的正向限位报警

        /// <summary>
        ///     //扫描轴状态的伺服状态
        /// </summary>
        protected bool[] m_bFlagServoOn; //扫描轴状态的伺服状态

        /// <summary>
        ///     //扫描轴状态的平滑停止
        /// </summary>
        protected bool[] m_bFlagSStop; //扫描轴状态的平滑停止

        ///// <summary>
        /////     初始化标志位
        ///// </summary>
        //public bool m_bInit;


        ///// <summary>
        /////     true为回零已经结束
        ///// </summary>
        //public bool m_bIsHomed = true;

        ///// <summary>
        /////     true回零成功
        ///// </summary>
        //public bool m_bIsHomeOk = false;

        ///// <summary>
        /////     true为回零中
        ///// </summary>
        //public bool m_bIsHoming = false;

        /// <summary>
        ///     通用输入
        /// </summary>
        public bool[] m_bUniversalIn;

        /// <summary>
        ///     通用输出
        /// </summary>
        public bool[] m_bUniversalOut;

        /// <summary>
        ///     //各轴规划位置,在此当实际位置用
        /// </summary>
        protected double[] m_dAxisPos; //各轴规划位置,在此当实际位置用

        /// <summary>
        ///     一个脉冲走多少毫米
        /// </summary>
        protected double[] m_dAxisResolution;

        //正负限位，停止，运动，无触发时为true 触发时为false

        /// <summary>
        ///     //扫描轴的状态
        /// </summary>
        protected int[] m_nAxisStatus; //扫描轴的状态

        /// <summary>
        ///     卡号该对象绑定的卡号
        /// </summary>
        protected short m_nCardNo;

        //正负限位，停止，运动，无触发时为true 触发时为false

        /// <summary>
        ///     扫面输入的信号状态
        /// </summary>
        protected int[] m_nDiStatus; //扫面输入的信号状态

        /// <summary>
        ///     扩展IO
        /// </summary>
        public int m_nExtIo;

        /// <summary>
        ///     通用输入IO状态
        /// </summary>
        protected int m_nInput;

        /// <summary>
        ///     通用输出IO状态
        /// </summary>
        protected int m_nOutput;

        #endregion

        #region 成员函数

        protected CMotionWorkBase(CMotionBase cMotionBase,short nCardNum)
        {
            m_cMotionBase = cMotionBase;
            m_nCardNo = nCardNum;
        }

        /// <summary>
        ///     轴是否在运动
        /// </summary>
        /// <param name="nAxis">轴号，从1开始</param>
        /// <returns>true：运动 false：停止</returns>
        public abstract bool IsMoving(short nAxis);

        public abstract bool GetAxisHomeStatus(short nAxis);
        public abstract bool GetAxisNegLimit(short nAxis);
        public abstract bool GetAxisPosLimit(short nAxis);
        public abstract bool GetAxisAlarm(short nAxis);
        public abstract bool GetMotionError(short nAxis);
        public abstract double GetAxisCurPos(short nAxis);
        public abstract bool GetMotorAlarm(short nAxis);
        public abstract void SetAxisResolution(short nAxis, double dResolution);
        public abstract void SetDoBit(ushort nIoIndex, bool bOn);
        public abstract void SetEStop();
        public abstract void SetSStop(short nAxis);
        public abstract double PulseToUnit(short nAxis, double dValue);
        public abstract long UnitToPulse(short nAxis, double dValue);
        public abstract bool GotoLimit(short nAxis, int nLimit, double dSpeed);

        public abstract short StartSingleHome(short nAxis, short nHomeMode, int nDir, double dHomeVel, long lPos,
            long lOffset);

        protected abstract bool UpdateAxisStatus();
        protected abstract bool ScanDi();
        protected abstract short UpdateAxisPos();
        public abstract bool InitMotionCard(string sFileCfg);
        public abstract bool AbsMove(short nAxis, double dPos, double dVel, double dAcce);
        public abstract bool JogMove(short nAxis, double dVel, double dAcce);
        public abstract bool RMove(short nAxis, double dVel, double dAcce, double dOffset);
        public abstract void ClrSts(short nAxis,short nCount);
        public abstract bool MulLine2DCrd(short nCrd, short axis1, short axis2, List<double> dX, List<double> dY,
            double dVel,
            double dAcce);

        #endregion
    }
}