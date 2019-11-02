using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using AnsonGlue.Equipment.Motion.Business.AbstractClass;
using AnsonGlue.Equipment.Motion.Business.ConcreteClass;
using AnsonGlue.Equipment.Motion.Function.AbstractClass;

namespace AnsonGlue.Equipment.Motion.Function.ConcreteClass
{
    public class CMotionWorkChristmas : CMotionWorkBase
    {
        #region 自定义变量

        private enum HOME_TYPE
        {
            MC_CAPTURE_HOME = 1, //（宏定义为 1）：Home 捕获
            MC_CAPTURE_INDEX = 2, //（宏定义为 2）：Index 捕获
            MC_CAPTURE_PROBE = 3, //(宏定义为 3)：Probe 捕获
            MC_CAPTURE_HOME_INDEX = 4, //（宏定义为 4）：Home+Index 捕获
            CAPTURE_HOME = 1, //回零模式1：走限位捕获home
            CAPTURE_INDEX = 2 //回零模式2：走限位捕获home+index
        }

        #endregion

        #region 成员变量

        /// <summary>
        ///     用于扫描IO的线程
        /// </summary>
        private Thread m_threadScanState;

        /// <summary>
        ///     退出扫描
        /// </summary>
        private bool m_bFlagOfScanEnd;

        /// <summary>
        ///     遍历数字输入锁
        /// </summary>
        private object m_oLockOfScanDiBit;

        /// <summary>
        ///     设置数字输出锁
        /// </summary>
        private object m_oLockOfSetDoBit;

        /// <summary>
        ///     单例模式所用的锁
        /// </summary>
        private static object s_lock = new object();

        /// <summary>
        ///     运动控制板卡实现类对象
        /// </summary>
        private static CMotionBase s_motionBase;

        /// <summary>
        ///     Di口数量
        /// </summary>
        private const short m_c_DI_NUM = 16;

        /// <summary>
        ///     Do口数量
        /// </summary>
        private const short m_c_DO_NUM = 16;

        #endregion

        #region 获取单例对象

        private static List<CMotionWorkChristmas> s_listMotionWorkingGts = new List<CMotionWorkChristmas>();

        private static List<CMotionWorkChristmas> s_listMotionWorkingLh = new List<CMotionWorkChristmas>();


        /// <summary>
        ///     单例初始化
        /// </summary>
        /// <param name="cardType">运动控制板卡类型</param>
        /// <param name="nMaxAxisNum">最大轴数,最大8</param>
        /// <param name="nCardNum">卡号</param>
        /// <returns></returns>
        public static CMotionWorkChristmas GetInstance(short cardType, short nMaxAxisNum, short nCardNum)
        {
            CMotionWorkChristmas cMotionWorkChristmas = null;
            //判断形参是否正确
            var nRtn = CheckFormatPara(cardType, nCardNum);
            //返回为负，说明形参错误
            if (nRtn < 0) return null;
            //返回为零，说明现有链表有需要卡号对象
            if (nRtn == 0)
                switch (cardType)
                {
                    case 0: //固高
                        cMotionWorkChristmas = s_listMotionWorkingGts[nCardNum];
                        break;
                    case 1: //灵猴
                        cMotionWorkChristmas = s_listMotionWorkingLh[nCardNum];
                        break;
                }
            //返回为正，说明现有链表没有需要卡号对象，需要先实例化
            if (nRtn > 0)
                lock (s_lock)
                {
                    switch (cardType)
                    {
                        case 0: //固高
                            s_motionBase = new CGtMotion(nMaxAxisNum, m_c_DI_NUM, m_c_DO_NUM);
                            s_listMotionWorkingGts.Add(new CMotionWorkChristmas(s_motionBase, nCardNum));
                            cMotionWorkChristmas = s_listMotionWorkingGts[nCardNum];
                            break;
                        case 1: //灵猴
                            break;
                    }
                }

            return cMotionWorkChristmas;
        }

        private static short CheckFormatPara(short cardType, short nCardNum)
        {
            var listMotionWorking = new List<CMotionWorkChristmas>();
            switch (cardType)
            {
                case 0:
                    listMotionWorking = s_listMotionWorkingGts;
                    break;
                case 1:
                    listMotionWorking = s_listMotionWorkingLh;
                    break;
            }

            //链表里面元素个数大于卡号，说明现在板卡对象以存在
            if (listMotionWorking.Count > nCardNum)
                return 0;
            //链表里面元素个数小于卡号，说明现在板卡对象不存在，且形参过大
            if (nCardNum > listMotionWorking.Count)
            {
                MessageBox.Show(@"卡号设置过大！，请重新设置卡号");
                return -1;
            }

            return 1;
        }

        #endregion

        #region 系统函数

        private CMotionWorkChristmas(CMotionBase obj, short nCardNo)
            : base(obj, nCardNo)
        {
            m_maxAxisNum = obj.m_maxAxisNum;
            m_diNum = obj.m_diNum;
            m_doNum = obj.m_doNum;

            m_oLockOfScanDiBit = new object();

            m_oLockOfSetDoBit = new object();


            m_dsAxisResolution = new double[m_maxAxisNum];

            m_bFlagOfScanEnd = false;

            m_bsUniversalIn = new bool[m_c_DI_NUM];
            m_bsUniversalOut = new bool[m_c_DI_NUM];
            //m_bInit = false;

            m_nsDiStatus = new[] {0, 0, 0, 0, 0};
            m_bsAxisPosLmt = new bool[m_maxAxisNum];
            m_bsAxisNegLmt = new bool[m_maxAxisNum];
            m_bsAxisAlarm = new bool[m_maxAxisNum];
            m_bsAxisHome = new bool[m_maxAxisNum];


            m_dsAxisStatus = new int[m_maxAxisNum];
            m_bsServoAlarm = new bool[m_maxAxisNum];
            m_bsMotionError = new bool[m_maxAxisNum];
            m_bsPosLimit = new bool[m_maxAxisNum];
            m_bsNegLimit = new bool[m_maxAxisNum];
            m_bsAxisStop = new bool[m_maxAxisNum];
            m_bsSmoothStop = new bool[m_maxAxisNum];
            m_bsMotionSts = new bool[m_maxAxisNum];
            m_bsServoOn = new bool[m_maxAxisNum];

            m_dsAxisPos = new double[m_maxAxisNum];

            for (var i = 0; i < m_diNum; i++) m_bsUniversalIn[i] = true;

            for (var i = 0; i < m_doNum; i++) m_bsUniversalOut[i] = true;

            for (var i = 0; i < m_maxAxisNum; i++)
            {
                m_dsAxisResolution[i] = 0;


                m_bsAxisPosLmt[i] = true;
                m_bsAxisNegLmt[i] = true;
                m_bsAxisAlarm[i] = true;
                m_bsAxisHome[i] = true;

                m_dsAxisStatus[i] = 0;
                m_bsServoAlarm[i] = true;
                m_bsMotionError[i] = true;
                m_bsPosLimit[i] = true;
                m_bsNegLimit[i] = true;
                m_bsAxisStop[i] = true;
                m_bsSmoothStop[i] = true;
                m_bsMotionSts[i] = true;
                m_bsServoOn[i] = true;

                m_dsAxisPos[i] = 0.0;
            }
        }

        ~CMotionWorkChristmas()
        {
            EndScanIo();
        }


        #region 扫描IO

        private void ScanThreadFunction()
        {
            while (true)
            {
                if (m_bFlagOfScanEnd) break;

                lock (m_oLockOfScanDiBit)
                {
                    UpdateAxisStatus();
                    ScanDi();
                    UpdateAxisPos();
                }
            }
        }

        private void StartScanIo()
        {
            if (m_threadScanState != null && !m_threadScanState.IsAlive)
            {
                m_bFlagOfScanEnd = false;
                m_threadScanState.Start();
            }
        }

        private void EndScanIo()
        {
            m_bFlagOfScanEnd = true;
            Thread.Sleep(100);
        }

        /// <summary>
        ///     更新轴状态
        /// </summary>
        /// <returns></returns>
        protected override bool UpdateAxisStatus()
        {
            for (var i = 0; i < m_maxAxisNum; i++)
            {
                //获取标志位状态
                int iSts;

                var nRtn = m_oMotionBase.GetSts(m_sCardNo, (short) (i + 1), 1, out iSts);

                if (nRtn == 0)
                {
                    m_dsAxisStatus[i] = iSts;
                    //0000 0010 伺服报警标志
                    m_bsServoAlarm[i] = (m_dsAxisStatus[i] & 0x2) != 0;
                    //0001 0000 运动出错
                    m_bsMotionError[i] = (m_dsAxisStatus[i] & 0x10) != 0;
                    //0010 0000 正限位
                    m_bsPosLimit[i] = (m_dsAxisStatus[i] & 0x20) != 0;
                    //0100 0000 负限位
                    m_bsNegLimit[i] = (m_dsAxisStatus[i] & 0x40) != 0;
                    //0010 0000 0000 伺服使能
                    m_bsServoOn[i] = (m_dsAxisStatus[i] & 0x200) != 0;
                    //0100 0000 0000 运动状态
                    m_bsMotionSts[i] = (m_dsAxisStatus[i] & 0x400) != 0;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     扫描IO
        /// </summary>
        /// <returns></returns>
        protected override bool ScanDi()
        {
            short nCmdRtn = -1;
            //获取数字量输入状态
            for (short i = 0; i < 5; i++)
                //0:MC_LIMIT_POSITIVE；1:MC_LIMIT_NEGATIVE；2:MC_ALARM；3:MC_HOME；4:MC_GPI
                nCmdRtn = m_oMotionBase.GetDi(m_sCardNo, i, out m_nsDiStatus[i]);

            if (nCmdRtn != 0) return false;

            for (var j = 0; j < m_maxAxisNum; j++)
            {
                //正限位输入
                var bitFlag = 1 << j;
                m_bsAxisPosLmt[j] = (m_nsDiStatus[0] & bitFlag) == 0;
                //负限位输入
                m_bsAxisNegLmt[j] = (m_nsDiStatus[1] & bitFlag) == 0;
                //伺服报警输入状态显示                       
                m_bsAxisAlarm[j] = (m_nsDiStatus[2] & bitFlag) == 0;
                //Home信号输入状态显示                      
                m_bsAxisHome[j] = (m_nsDiStatus[3] & bitFlag) == 0;
            }


            //遍历数字输入口
            for (var k = 0; k < m_diNum; k++)
            {
                var nMask = 1 << k;
                //按位与，如果结果不为0，则说明该位有值
                m_bsUniversalIn[k] = (m_nsDiStatus[4] & nMask) != 0;
            }

            m_nsInput = m_nsDiStatus[4];

            m_oMotionBase.GetDo(0, out m_nsOutput);
            //遍历数字输出口
            for (var k = 0; k < m_doNum; k++)
            {
                var nMask = 1 << k;
                //按位与，如果结果不为0，则说明该位有值，对应数组位置true
                m_bsUniversalOut[k] = (m_nsOutput & nMask) != 0;
            }

            m_oMotionBase.GetExtendDi(m_sCardNo, 0, out m_unsExtIo);

            return true;
        }

        /// <summary>
        ///     更新轴坐标
        /// </summary>
        /// <returns></returns>
        protected override short UpdateAxisPos()
        {
            short nRtn = 0;
            for (short k = 1; k <= m_maxAxisNum; k++)
            {
                //----------------运动数据的显示-------------------//
                double dValue;
                nRtn |= k < 4
                    ? m_oMotionBase.GetEncPos(m_sCardNo, k, out dValue, 1)
                    : m_oMotionBase.GetPrfPos(m_sCardNo, k, out dValue, 1);

                if (nRtn != 0) return nRtn;

                m_dsAxisPos[k - 1] = dValue;
            }

            return nRtn;
        }

        #endregion

        #region 获取&设置

        public override bool InitMotionCard(string sFileCfg)
        {
            if (!File.Exists(sFileCfg))
            {
                MessageBox.Show(@"配置文件不存在，请检查！");
                return false;
            }

            if (m_oMotionBase.InitMotionCard(m_sCardNo, m_maxAxisNum, sFileCfg) == 0)
            {
                //m_bInit = true;
                m_threadScanState = new Thread(ScanThreadFunction) {IsBackground = true};
                StartScanIo();
                return true;
            }

            return false;
        }

        /// <summary>
        ///     轴是否停止
        /// </summary>
        /// <param name="nAxis"></param>
        /// <returns></returns>
        public override bool IsMoving(short nAxis)
        {
            return m_bsMotionSts[nAxis - 1];
        }

        /// <summary>
        ///     获取Home信号
        /// </summary>
        /// <param name="nAxis">轴号</param>
        public override bool GetAxisHomeStatus(short nAxis)
        {
            return m_bsAxisHome[nAxis - 1];
        }

        /// <summary>
        ///     获取负限位信号
        /// </summary>
        /// <param name="nAxis">轴号</param>
        public override bool GetAxisNegLimit(short nAxis)
        {
            return m_bsAxisNegLmt[nAxis - 1];
        }

        /// <summary>
        ///     获取正限位信号
        /// </summary>
        /// <param name="nAxis">轴号</param>
        public override bool GetAxisPosLimit(short nAxis)
        {
            return m_bsAxisPosLmt[nAxis - 1];
        }

        /// <summary>
        ///     获取轴报警信号
        /// </summary>
        /// <param name="nAxis">轴号</param>
        public override bool GetAxisAlarm(short nAxis)
        {
            return m_bsAxisAlarm[nAxis - 1];
        }

        /// <summary>
        ///     获取运动错误
        /// </summary>
        /// <param name="nAxis"></param>
        /// <returns></returns>
        public override bool GetMotionError(short nAxis)
        {
            return m_bsMotionError[nAxis - 1];
        }

        /// <summary>
        ///     获取轴坐标
        /// </summary>
        /// <param name="nAxis">轴号</param>
        /// <returns></returns>
        public override double GetAxisCurPos(short nAxis)
        {
            return PulseToUnit(nAxis, m_dsAxisPos[nAxis - 1]);
        }

        /// <summary>
        ///     获取报警
        /// </summary>
        /// <param name="nAxis"></param>
        /// <returns></returns>
        public override bool GetMotorAlarm(short nAxis)
        {
            return m_bsServoAlarm[nAxis - 1];
        }

        /// <summary>
        ///     设置脉冲当量
        /// </summary>
        /// <param name="nAxis">轴号</param>
        /// <param name="dResolution">当量</param>
        public override void SetAxisResolution(short nAxis, double dResolution)
        {
            m_dsAxisResolution[nAxis - 1] = dResolution;
        }

        /// <summary>
        ///     设置输出信号
        /// </summary>
        /// <param name="nIoIndex">索引</param>
        /// <param name="bOn">开关</param>
        public override void SetDoBit(ushort nIoIndex, bool bOn)
        {
            var index = (short) (nIoIndex + 1);
            var sOn = (short) (bOn ? 1 : 0);

            if (index < 1) return;

            if (index <= m_doNum)
                lock (m_oLockOfSetDoBit)
                {
                    m_oMotionBase.SetDoBit(m_sCardNo, index, sOn);
                }
            else if (index > m_doNum)
                lock (m_oLockOfSetDoBit)
                {
                    m_oMotionBase.SetExtendDoBit(m_sCardNo, 1, (short) (index - m_doNum), sOn);
                }
        }

        /// <summary>
        ///     急停
        /// </summary>
        public override void SetEStop()
        {
            for (var i = 0; i < m_maxAxisNum; i++)
            {
                var msk = 1 << i;
                m_oMotionBase.Stop(m_sCardNo, (short) msk, (short) msk);
            }
        }

        /// <summary>
        ///     平滑停止
        /// </summary>
        /// <param name="nAxis">轴号</param>
        public override void SetSStop(short nAxis)
        {
            var msk = 1 << (nAxis - 1);

            m_oMotionBase.Stop(m_sCardNo, (short) msk, 0);
        }

        /// <summary>
        ///     脉冲转换位物理坐标
        /// </summary>
        /// <param name="nAxis">轴号</param>
        /// <param name="dValue">值</param>
        /// <returns></returns>
        public override double PulseToUnit(short nAxis, double dValue)
        {
            var dReturnValue = dValue * m_dsAxisResolution[nAxis - 1];
            return dReturnValue;
        }

        /// <summary>
        ///     物理坐标转脉冲
        /// </summary>
        /// <param name="nAxis">轴号</param>
        /// <param name="dValue">坐标值</param>
        /// <returns></returns>
        /// 0
        public override long UnitToPulse(short nAxis, double dValue)
        {
            var lReturnValue = (long) (dValue / m_dsAxisResolution[nAxis - 1]);
            return lReturnValue;
        }

        /// <summary>
        ///     设置坐标为0
        /// </summary>
        public void SetZero()
        {
            m_oMotionBase.ZeroPos(m_sCardNo, 1, m_maxAxisNum);
        }

        #endregion

        #region 位移

        /// <summary>
        ///     移动到限位
        /// </summary>
        /// <param name="nAxis">轴号</param>
        /// <param name="nLimit">1：正限位   -1：负限位 </param>
        /// <param name="dSpeed">速度</param>
        /// <returns></returns>
        public override bool GotoLimit(short nAxis, int nLimit, double dSpeed)
        {
            short nRtn = 0;

            nRtn |= m_oMotionBase.ClrSts(m_sCardNo, nAxis, 1);
            Thread.Sleep(50);
            if (m_bsNegLimit[nAxis - 1] && nLimit == -1 || m_bsPosLimit[nAxis - 1] && nLimit == 1)
                return true; //若已经在限位位置

            //设置Jog运动参数
            nRtn |= m_oMotionBase.PrfJog(m_sCardNo, nAxis);
            nRtn |= m_oMotionBase.SetJogPrm(m_sCardNo, nAxis, 0.5, 0.5, 0.625);
            if (nRtn != 0) return false;

            //启动运动
            nRtn |= m_oMotionBase.SetVel(m_sCardNo, nAxis, nLimit * dSpeed); //设置目标速度，单位是“脉冲/毫秒”
            if (nRtn != 0) return false;
            nRtn |= m_oMotionBase.Update(m_sCardNo, nAxis);
            Thread.Sleep(200);

            var bLimit = false;
            var nStopNum = 0;

            while (!m_bsMotionError[nAxis - 1] && !bLimit)
            {
                if (nLimit == 1) //只关注正限位
                    if (!m_bsAxisPosLmt[nAxis - 1])
                    {
                        bLimit = true;
                        SetSStop(nAxis); //感应到正限位后运动停止
                    }

                if (nLimit == -1) //只关注负限位
                    if (!m_bsAxisNegLmt[nAxis - 1]) //感应到负限位
                    {
                        bLimit = true;
                        SetSStop(nAxis); //感应到负限位后运动停止
                    }

                // 读取规划位置
                double prfPos;
                nRtn |= m_oMotionBase.GetPrfPos(m_sCardNo, nAxis, out prfPos, 1);
                // 读取编码器位置
                double encPos;
                nRtn |= m_oMotionBase.GetEncPos(m_sCardNo, nAxis, out encPos, 1);
                // 如果运动停止，返回出错信息
                if (m_bsMotionSts[nAxis - 1] == false && !bLimit) //没到限位却停止了
                {
                    nStopNum++;
                    Thread.Sleep(50);
                    if (nStopNum >= 10)
                    {
                        MessageBox.Show(@"马达意外停止，原点回归失败，请重启程序" + nAxis);
                        return false;
                    }

                    continue;
                }

                Thread.Sleep(50);
            }

            return true;
        }

        /// <summary>
        ///     绝对坐标走位i
        /// </summary>
        /// <param name="nAxis">轴号</param>
        /// <param name="dPos">位置,脉冲为单位</param>
        /// <param name="dVel">速度</param>
        /// <param name="dAcce">加减速度</param>
        /// <returns></returns>
        public override bool AbsMove(short nAxis, double dPos, double dVel, double dAcce)
        {
            var nPos = UnitToPulse(nAxis, dPos);
            m_oMotionBase.AbsMove(m_sCardNo, nAxis, (int) nPos, dVel, dAcce);
            return true;
        }

        /// <summary>
        ///     JOG移动
        /// </summary>
        /// <param name="nAxis">轴号</param>
        /// <param name="dVel"></param>
        /// <param name="dAcce"></param>
        /// <returns></returns>
        public override bool JogMove(short nAxis, double dVel, double dAcce)
        {
            m_oMotionBase.JogMove(m_sCardNo, nAxis, dVel, dAcce);
            return true;
        }

        /// <summary>
        ///     相对距离移动
        /// </summary>
        /// <param name="nAxis">轴号</param>
        /// <param name="dVel">速度</param>
        /// <param name="dAcce">加减速度</param>
        /// <param name="dOffset">相对移动量,单位脉冲</param>
        /// <returns></returns>
        public override bool RMove(short nAxis, double dVel, double dAcce, double dOffset)
        {
            var nPos = UnitToPulse(nAxis, dOffset);
            m_oMotionBase.RMove(m_sCardNo, nAxis, dVel, dAcce, nPos);
            return true;
        }

        public override void ClrSts(short nAxis, short nCount)
        {
            m_oMotionBase.ClrSts(m_sCardNo, nAxis, nCount);
        }

        /// <summary>
        ///     lPos为搜索距离，以当前位置为起点，搜索距离为正时向正方向搜索，搜索距离为负时向负方向搜索，单位：脉冲
        ///     lOffset为原点偏移量，当原点信号触发时，将当前轴目标位置自动更新为“原点位置＋原点偏移” 。
        ///     如果原点偏移量为 0，当原点信号触发时，首先平滑停止减速到 0，然后返回原点
        /// </summary>
        /// <param name="nAxis">轴号</param>
        /// <param name="nHomeMode">模式</param>
        /// <param name="nDir">方向 1：正向  -1：负向</param>
        /// <param name="dHomeVel">回home速度</param>
        /// <param name="lPos">搜索距离</param>
        /// <param name="lOffset">原点偏移量</param>
        /// <returns></returns>
        public override short StartSingleHome(short nAxis, short nHomeMode, int nDir, double dHomeVel, long lPos,
            long lOffset)
        {
            short nRtn = 0;
            int lStatus;
            if (m_sCardNo < 0 || nAxis > m_maxAxisNum || nHomeMode != 1 && nHomeMode != 2)
                return -1;
            //先去离HOME近的限位点
            var bRst = GotoLimit(nAxis, nDir, dHomeVel);
            if (bRst)
                Thread.Sleep(500);
            else
                return nRtn;

            nRtn |= m_oMotionBase.ClrSts(m_sCardNo, nAxis, 1); // 清除指定轴的报警和限位
            if (nRtn != 0) return nRtn;
            ////此处添加捕获状态清除////

            // 启动Home捕获

            //设定Trap运动参数

            double prfPos, encPos;
            short sCapture;
            int lPosition;
            //设置为Home捕获模式
            nRtn |= m_oMotionBase.SetCaptureMode(m_sCardNo, nAxis, (int) HOME_TYPE.CAPTURE_HOME);
            // 切换到点位运动模式
            // 读取点位模式运动参数

            short smoothtime = 25;
            var acc = 0.5;
            var dec = 0.5;
            // 设置点位模式运动参数
            nRtn |= m_oMotionBase.SetTrapPrm(m_sCardNo, nAxis, acc, dec, smoothtime);

            // 设置点位模式目标速度，即回原点速度
            nRtn |= m_oMotionBase.SetVel(m_sCardNo, nAxis, dHomeVel); //原点开始速度，需要更改
            //得到当前位置
            nRtn |= m_oMotionBase.GetPrfPos(m_sCardNo, nAxis, out prfPos, 1);
            // 设置点位模式目标位置，即原点搜索距离
            nRtn |= m_oMotionBase.SetPos(m_sCardNo, nAxis, (int) (prfPos + lPos)); //负方向点位运动脉冲，需要更改

            // 启动运动
            nRtn |= m_oMotionBase.Update(m_sCardNo, nAxis);

            do
            {
                //读取轴状态
                nRtn |= m_oMotionBase.GetSts(m_sCardNo, nAxis, 1, out lStatus);
                // 读取规划位置
                nRtn |= m_oMotionBase.GetPrfPos(m_sCardNo, nAxis, out prfPos, 1);
                // 读取编码器位置
                nRtn |= m_oMotionBase.GetEncPos(m_sCardNo, nAxis, out encPos, 1);
                //读取捕获状态
                nRtn |= m_oMotionBase.GetCaptureStatus(m_sCardNo, nAxis, out sCapture, out lPosition, 1);
                if (0 == (lStatus & 0x400))
                {
                    MessageBox.Show(@"没找到原点");
                    return nRtn;
                }

                Thread.Sleep(1);
            } while (sCapture == 0);

            SetSStop(nAxis);
            // 运动到“捕获位置+偏移量”
            nRtn |= m_oMotionBase.SetPos(m_sCardNo, nAxis, (int) (prfPos + lOffset));
            // 在运动状态下更新目标位置
            nRtn |= m_oMotionBase.Update(m_sCardNo, nAxis);
            do
            {
                //读取轴状态
                nRtn |= m_oMotionBase.GetSts(m_sCardNo, nAxis, 1, out lStatus);
                // 读取规划位置
                nRtn |= m_oMotionBase.GetPrfPos(m_sCardNo, nAxis, out prfPos, 1);
                // 读取编码器位置
                nRtn |= m_oMotionBase.GetEncPos(m_sCardNo, nAxis, out encPos, 1);
                Thread.Sleep(1);
                // 等待运动停止
            } while ((lStatus & 0x400) != 0);

            if (nHomeMode == (int) HOME_TYPE.CAPTURE_HOME)
            {
                Thread.Sleep(200);
                nRtn |= m_oMotionBase.ZeroPos(m_sCardNo, nAxis, 1);
                nRtn |= m_oMotionBase.ClrSts(m_sCardNo, nAxis, 1);
                return nRtn;
            }

            //设置伺服电机Z相捕获
            nRtn |= m_oMotionBase.SetCaptureMode(m_sCardNo, nAxis, (int) HOME_TYPE.MC_CAPTURE_INDEX);
            // 切换到点位运动模式
            nRtn |= m_oMotionBase.PrfTrap(m_sCardNo, nAxis);
            // 读取点位模式运动参数
            nRtn |= m_oMotionBase.GetTrapPrm(m_sCardNo, nAxis, out acc, out dec, out smoothtime);
            acc = 0.15;
            dec = 0.15;
            // 设置点位模式运动参数
            nRtn |= m_oMotionBase.SetTrapPrm(m_sCardNo, nAxis, acc, dec, smoothtime);
            // 设置点位模式目标速度，即回原点速度
            nRtn |= m_oMotionBase.SetVel(m_sCardNo, nAxis, 2); //原点开始速度，需要更改

            // 设置点位模式目标位置，即原点搜索距离
            nRtn |= m_oMotionBase.SetPos(m_sCardNo, nAxis, (int) (prfPos + 10000)); //负方向点位运动脉冲，需要更改
            // 启动运动
            nRtn |= m_oMotionBase.Update(m_sCardNo, nAxis);

            do
            {
                //读取轴状态
                nRtn |= m_oMotionBase.GetSts(m_sCardNo, nAxis, 1, out lStatus);
                // 读取规划位置
                nRtn |= m_oMotionBase.GetPrfPos(m_sCardNo, nAxis, out prfPos, 1);
                // 读取编码器位置
                nRtn |= m_oMotionBase.GetEncPos(m_sCardNo, nAxis, out encPos, 1);
                //读取捕获状态
                nRtn |= m_oMotionBase.GetCaptureStatus(m_sCardNo, nAxis, out sCapture, out lPosition, 1);
                if (0 == (lStatus & 0x400))
                {
                    MessageBox.Show(@"没找到编码器Z相信号，原点回归失败");
                    return nRtn;
                }

                Thread.Sleep(1);
            } while (0 == sCapture);

            // 设置偏移量
            nRtn |= m_oMotionBase.SetPos(m_sCardNo, nAxis, (int) (prfPos + 1000));
            // 在运动状态下更新目标位置
            nRtn |= m_oMotionBase.Update(m_sCardNo, nAxis);
            do
            {
                //读取轴状态
                nRtn |= m_oMotionBase.GetSts(m_sCardNo, nAxis, 1, out lStatus);
                // 读取规划位置
                nRtn |= m_oMotionBase.GetPrfPos(m_sCardNo, nAxis, out prfPos, 1);
                // 读取编码器位置
                nRtn |= m_oMotionBase.GetEncPos(m_sCardNo, nAxis, out encPos, 1);
                // 等待运动停止
                Thread.Sleep(1);
            } while ((lStatus & 0x400) != 0);

            //位置清零
            Thread.Sleep(200);
            nRtn |= m_oMotionBase.ZeroPos(m_sCardNo, nAxis, 1);
            nRtn |= m_oMotionBase.ClrSts(m_sCardNo, nAxis, 1);
            return nRtn;
        }

        #endregion

        #region 二维插补运动

        /// <summary>
        ///     二轴插补运动
        /// </summary>
        /// <param name="crdNo">坐标系号</param>
        /// <param name="listOfAxisNo"></param>
        /// <param name="listOfCrdPara">插补数据链表</param>
        /// <returns></returns>
        public override bool MulLineCrd(short crdNo, IReadOnlyList<short> listOfAxisNo, List<STRUCT_CRD_PARA> listOfCrdPara)
        {
            if (listOfCrdPara.Count==0)
            {
                return false;
            }
            short[] profile = { 0, 0, 0, 0, 0, 0, 0, 0 };

            switch (listOfAxisNo.Count)
            {
                case 2:
                    profile[0] = listOfAxisNo[0];
                    profile[1] = listOfAxisNo[1];
                    break;
                case 3:
                    profile[0] = listOfAxisNo[0];
                    profile[1] = listOfAxisNo[1];
                    profile[2] = listOfAxisNo[2];
                    break;
                case 4:
                    profile[0] = listOfAxisNo[0];
                    profile[1] = listOfAxisNo[1];
                    profile[2] = listOfAxisNo[2];
                    profile[3] = listOfAxisNo[3];
                    break;
            }

            short dimNum = (short) listOfAxisNo.Count;

            //建立坐标系
            if (m_oMotionBase.SetLineOrdi(m_sCardNo, crdNo, dimNum, 500, 5, 0, profile) == 0)
            {
                m_oMotionBase.CrdClear(m_sCardNo, crdNo, 0);
                m_oMotionBase.InitLookAhead(m_sCardNo, crdNo,0,5,2,32000);
                int space, crdDataNo = 0;
                short sRtn = 0;
                for(var i=0;i<listOfCrdPara.Count;i++)
                {
                    var sCrdPara = listOfCrdPara[i];
                    
                    //压入数据
                     sRtn |= AddDataToCrd(crdNo, listOfAxisNo, sCrdPara);

                    if (sRtn != 0) //如果插补数据压入失败
                    {
                        crdDataNo = i;
                        break; //退出压入
                    }
                }

                //先开始插补运动
                m_oMotionBase.CrdData(m_sCardNo, crdNo);
                m_oMotionBase.CrdStart(m_sCardNo, 1);

                for (var i = crdDataNo; i < listOfCrdPara.Count; i++)
                {
                    var sCrdPara = listOfCrdPara[i];
                    //再压入数据
                    sRtn |= AddDataToCrd(crdNo, listOfAxisNo, sCrdPara);
                    if (sRtn != 0)
                    {
                        do
                        {
                            //查询空间
                            m_oMotionBase.CrdSpace(m_sCardNo, 1, out space);
                            Thread.Sleep(1);
                        } while (0 == space);

                        sRtn |= AddDataToCrd(crdNo, listOfAxisNo, sCrdPara);
                    }
                }
                short pCmdNum, run;
                int segment;

                //查询状态
                m_oMotionBase.CrdStatus(m_sCardNo, 1, out run, out segment, out pCmdNum, out space);
                //等待停止
                do
                {
                    m_oMotionBase.CrdStatus(m_sCardNo, 1, out run, out segment, out pCmdNum, out space);
                    Thread.Sleep(1);
                    //m_pCrdRunStatus = run;
                } while (run == 1);
            }

            return true;
        }

        /// <summary>
        /// 添加数据到插补空间
        /// </summary>
        /// <param name="crdNo">坐标系号</param>
        /// <param name="listOfAxisNo">轴号链表</param>
        /// <param name="sCrdPara">插补数据结构体</param>
        /// <returns></returns>
        private short AddDataToCrd(short crdNo, IReadOnlyList<short> listOfAxisNo, STRUCT_CRD_PARA sCrdPara)
        {
            short sRtn = 0;
            switch (sCrdPara.m_datatype)
            {
                case 0:  //直线
                    sRtn |= AddLineToCrd(crdNo, listOfAxisNo, sCrdPara);
                    break;
                case 1: //IO
                    sRtn |= m_oMotionBase.BufIo(m_sCardNo, crdNo, 12, sCrdPara.m_usDoMask, sCrdPara.m_usDoValue);
                    break;
                case 2: //延时
                    sRtn |= m_oMotionBase.BufDelay(m_sCardNo, crdNo, sCrdPara.m_usDelayTime);
                    break;
                case 3: //圆弧
                    sRtn |= AddCircleToCrd(crdNo, sCrdPara);
                    break;
            }

            return sRtn;
        }

        private short AddCircleToCrd(short crdNo, STRUCT_CRD_PARA sCrdPara)
        {
            short sRtn = 0;
            int nCircleX = (int)UnitToPulse(1, sCrdPara.m_dCircleX);
            int nCircleY = (int)UnitToPulse(2, sCrdPara.m_dCircleY);
            double dCenterX = (int)UnitToPulse(2, sCrdPara.m_dCenterX);
            double dCenterY = (int)UnitToPulse(2, sCrdPara.m_dCenterY);
            sRtn |= m_oMotionBase.ArcXyc(m_sCardNo, crdNo, nCircleX, nCircleY, dCenterX, dCenterY, sCrdPara.m_sDir, sCrdPara.m_dVel, sCrdPara.m_dAcc);
            return sRtn;
        }


        private short AddLineToCrd(short crdNo, IReadOnlyList<short> listOfAxisNo, STRUCT_CRD_PARA sCrdPara)
        {
            short sRtn = 0;
            int pulseNumOfAxis1, pulseNumOfAxis2, pulseNumOfAxis3, pulseNumOfAxis4;
            switch (listOfAxisNo.Count)
            {
                case 2:
                    pulseNumOfAxis1 = (int)UnitToPulse(listOfAxisNo[0], sCrdPara.m_dPositionOfAxis1);
                    pulseNumOfAxis2 = (int)UnitToPulse(listOfAxisNo[1], sCrdPara.m_dPositionOfAxis2);
                    sRtn |= m_oMotionBase.LnXy(m_sCardNo, crdNo, pulseNumOfAxis1, pulseNumOfAxis2, sCrdPara.m_dVel, sCrdPara.m_dAcc);
                    break;
                case 3:
                    pulseNumOfAxis1 = (int)UnitToPulse(listOfAxisNo[0], sCrdPara.m_dPositionOfAxis1);
                    pulseNumOfAxis2 = (int)UnitToPulse(listOfAxisNo[1], sCrdPara.m_dPositionOfAxis2);
                    pulseNumOfAxis3 = (int)UnitToPulse(listOfAxisNo[2], sCrdPara.m_dPositionOfAxis3);
                    sRtn |= m_oMotionBase.LnXyz(m_sCardNo, crdNo, pulseNumOfAxis1, pulseNumOfAxis2,pulseNumOfAxis3, sCrdPara.m_dVel, sCrdPara.m_dAcc);
                    break;
                case 4:
                    pulseNumOfAxis1 = (int)UnitToPulse(listOfAxisNo[0], sCrdPara.m_dPositionOfAxis1);
                    pulseNumOfAxis2 = (int)UnitToPulse(listOfAxisNo[1], sCrdPara.m_dPositionOfAxis2);
                    pulseNumOfAxis3 = (int)UnitToPulse(listOfAxisNo[2], sCrdPara.m_dPositionOfAxis3);
                    pulseNumOfAxis4 = (int)UnitToPulse(listOfAxisNo[3], sCrdPara.m_dPositionOfAxis4);
                    sRtn |= m_oMotionBase.LnXyza(m_sCardNo, crdNo, pulseNumOfAxis1, pulseNumOfAxis2,pulseNumOfAxis3,pulseNumOfAxis4, sCrdPara.m_dVel, sCrdPara.m_dAcc);
                    break;
            }

            return sRtn;
        }

        #endregion

        #region 二维比较

        /// <summary>
        ///     开始二维比较
        /// </summary>
        /// <param name="axis1">1轴坐标</param>
        /// <param name="axis2">2轴坐标</param>
        /// <param name="chn">通道号:[0，1]</param>
        /// <param name="fifo">fifo号:[0,1]</param>
        /// <param name="prm">二维比较参数</param>
        /// <returns></returns>
        public short StartD2DCompare(List<int> axis1, List<int> axis2, short chn, short fifo,
            CMotionBase.STRUCT_DD_COMPARE_PRM prm)
        {
            short nRtn = 0;
            var obj = (object) prm;
            nRtn |= m_oMotionBase.D2DCompareSetPrm(m_sCardNo, chn, ref obj);
            nRtn |= m_oMotionBase.D2DCompareData(m_sCardNo, axis1, axis2, chn, fifo);
            nRtn |= m_oMotionBase.D2DCompareStart(m_sCardNo, chn);
            return nRtn;
        }

        public short SinglePulse(short chn, short nTime)
        {
            short nRtn = 0;
            nRtn |= m_oMotionBase.D2DComparePulse(m_sCardNo, chn, 0, 0, nTime);
            nRtn |= m_oMotionBase.D2DCompareStart(m_sCardNo, 0);
            return nRtn;
        }

        #endregion

        #endregion
    }
}