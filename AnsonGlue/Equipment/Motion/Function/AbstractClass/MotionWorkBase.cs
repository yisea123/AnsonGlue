using System.Collections.Generic;
using AnsonGlue.Equipment.Motion.Business.AbstractClass;

namespace AnsonGlue.Equipment.Motion.Function.AbstractClass
{
    /// <summary>
    ///     运动控制工作类
    /// </summary>
    public abstract class CMotionWorkBase
    {
        #region 自定义变量

        public struct STRUCT_CRD_PARA
        {
            public short m_datatype; //0：直线； 1：IO ；2：延时； 3：圆弧；
            public double m_dPositionOfAxis1; //轴一的点位信息
            public double m_dPositionOfAxis2;
            public double m_dPositionOfAxis3;
            public double m_dPositionOfAxis4;
            public ushort m_usDoMask; //数字输出的掩码，即有效位
            public ushort m_usDoValue; //数字输出的值
            public ushort m_usDelayTime; //延时
            public double m_dVel;
            public double m_dAcc;
            public double m_dCircleX; //圆弧终点位置
            public double m_dCircleY;
            public double m_dCenterX; //圆弧中心位置
            public double m_dCenterY;
            public short m_sDir; //圆弧方向
        }

        #endregion

        #region 成员变量

        /// <summary>
        ///     运动控制板卡的抽象类接口
        /// </summary>
        protected readonly CMotionBase m_oMotionBase;

        /// <summary>
        ///     轴数量
        /// </summary>
        public short m_maxAxisNum;

        /// <summary>
        ///     数字输入口数
        /// </summary>
        protected short m_diNum;

        /// <summary>
        ///     数字输出口数
        /// </summary>
        protected short m_doNum;

        /// <summary>
        ///     //扫描输入信号的报警
        /// </summary>
        protected bool[] m_bsAxisAlarm; //扫描输入信号的报警

        /// <summary>
        ///     //扫描输入信号的Home
        /// </summary>
        protected bool[] m_bsAxisHome; //扫描输入信号的Home

        /// <summary>
        ///     //扫描输入信号的负限位
        /// </summary>
        protected bool[] m_bsAxisNegLmt; //扫描输入信号的负限位

        /// <summary>
        ///     //扫描输入信号的正限位
        /// </summary>
        protected bool[] m_bsAxisPosLmt; //扫描输入信号的正限位

        /// <summary>
        ///     //扫描轴状态的伺服报警
        /// </summary>
        protected bool[] m_bsServoAlarm; //扫描轴状态的伺服报警

        /// <summary>
        ///     //扫描轴状态的紧急停止
        /// </summary>
        protected bool[] m_bsAxisStop; //扫描轴状态的紧急停止

        /// <summary>
        ///     //扫描轴状态的运动出错
        /// </summary>
        protected bool[] m_bsMotionError; //扫描轴状态的运动出错

        /// <summary>
        ///     //扫描轴状态的运动状态 TRUE:规划器运动中,FALSE:规划器停止
        /// </summary>
        protected bool[] m_bsMotionSts; //扫描轴状态的运动状态 FALSE:规划器运动中,TRUE:规划器停止

        /// <summary>
        ///     //扫描轴状态的负向限位报警
        /// </summary>
        protected bool[] m_bsNegLimit; //扫描轴状态的负向限位报警

        /// <summary>
        ///     //扫描轴状态的正向限位报警
        /// </summary>
        protected bool[] m_bsPosLimit; //扫描轴状态的正向限位报警

        /// <summary>
        ///     //扫描轴状态的伺服状态
        /// </summary>
        protected bool[] m_bsServoOn; //扫描轴状态的伺服状态

        /// <summary>
        ///     //扫描轴状态的平滑停止
        /// </summary>
        protected bool[] m_bsSmoothStop; //扫描轴状态的平滑停止

        /// <summary>
        ///     通用输入
        /// </summary>
        public bool[] m_bsUniversalIn;


        /// <summary>
        ///     通用输出
        /// </summary>
        public bool[] m_bsUniversalOut;

        /// <summary>
        ///     //各轴规划位置,在此当实际位置用
        /// </summary>
        protected double[] m_dsAxisPos; //各轴规划位置,在此当实际位置用

        /// <summary>
        ///     一个脉冲走多少毫米
        /// </summary>
        protected double[] m_dsAxisResolution;

        //正负限位，停止，运动，无触发时为true 触发时为false

        /// <summary>
        ///     //扫描轴的状态
        /// </summary>
        protected int[] m_dsAxisStatus; //扫描轴的状态

        /// <summary>
        ///     卡号该对象绑定的卡号
        /// </summary>
        protected readonly short m_sCardNo;

        //正负限位，停止，运动，无触发时为true 触发时为false

        /// <summary>
        ///     扫面输入的信号状态
        /// </summary>
        protected int[] m_nsDiStatus; //扫描输入的信号状态

        /// <summary>
        ///     扩展IO
        /// </summary>
        protected ushort m_unsExtIo;

        /// <summary>
        ///     通用输入IO状态
        /// </summary>
        protected int m_nsInput;

        /// <summary>
        ///     通用输出IO状态
        /// </summary>
        protected int m_nsOutput;

        #endregion

        #region 成员函数

        protected CMotionWorkBase(CMotionBase cMotionBase, short nCardNo)
        {
            m_oMotionBase = cMotionBase;
            m_sCardNo = nCardNo;
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
        public abstract void ClrSts(short nAxis, short nCount);

        public abstract bool MulLineCrd(short crdNo, IReadOnlyList<short> listOfAxisNo,
            List<STRUCT_CRD_PARA> structCrdPara);

        #endregion
    }
}