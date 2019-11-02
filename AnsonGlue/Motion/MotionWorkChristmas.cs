using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using AnsonGlue.UI;

namespace AnsonGlue.Motion
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
        private Thread m_tScanStateThread;

        /// <summary>
        ///     退出扫描
        /// </summary>
        private bool m_bScanEnd;

        /// <summary>
        ///     遍历数字输入锁
        /// </summary>
        private object m_oLockScanDiBit;

        /// <summary>
        ///     设置数字输出锁
        /// </summary>
        private object m_oLockSetDoBit;

        /// <summary>
        ///     单例模式所用的锁
        /// </summary>
        private static object _LOCK = new object();

        /// <summary>
        ///     运动控制板卡实现类对象
        /// </summary>
        private static CMotionBase _MOTION_BASE;

        /// <summary>
        ///     Di口数量
        /// </summary>
        private const ushort DI_NUM = 16;

        /// <summary>
        ///     Do口数量
        /// </summary>
        private const ushort DO_NUM = 16;

        #endregion

        #region 获取单例对象

        private static List<CMotionWorkChristmas> _LIST_MOTION_WORKING = new List<CMotionWorkChristmas>();


        /// <summary>
        ///     单例初始化
        /// </summary>
        /// <param name="nType">运动控制板卡类型</param>
        /// <param name="nAxisNum">最大轴数,最大8</param>
        /// <param name="nCardNum">卡号</param>
        /// <returns></returns>
        public static CMotionWorkChristmas GetInstance(MOTION_TYPE nType, short nAxisNum, short nCardNum)
        {
            if (_LIST_MOTION_WORKING.Count > nCardNum)
                if (_LIST_MOTION_WORKING[nCardNum] != null)
                    return _LIST_MOTION_WORKING[nCardNum];

            lock (_LOCK)
            {
                switch (nType)
                {
                    case (short) MOTION_TYPE.GTS_MOTION: //固高
                        _MOTION_BASE = new CGtMotion(nAxisNum);
                        break;
                    default: //默认固高
                        _MOTION_BASE = new CGtMotion(nAxisNum);
                        break;
                }

                //if (_LIST_MOTION_WORKING[nCardNum] == null) _LIST_MOTION_WORKING[nCardNum] = new CMotionWorkChristmas(_MOTION_BASE, nCardNum);
                if (!(_LIST_MOTION_WORKING.Count > nCardNum))
                    _LIST_MOTION_WORKING.Add(new CMotionWorkChristmas(_MOTION_BASE, nCardNum));
                return _LIST_MOTION_WORKING[nCardNum];
            }
        }

        #endregion

        #region 系统函数

        private CMotionWorkChristmas(CMotionBase obj, short nCardNum)
            : base(obj, nCardNum)
        {
            m_nMaxAxisNum = obj.m_nMaxAxisNum;
            m_nDiNum = DI_NUM;
            m_nDoNum = DO_NUM;

            m_oLockScanDiBit = new object();

            m_oLockSetDoBit = new object();


            m_dAxisResolution = new double[m_nMaxAxisNum];

            m_bScanEnd = false;

            m_bUniversalIn = new bool[DI_NUM];
            m_bUniversalOut = new bool[DI_NUM];
            //m_bInit = false;

            m_nDiStatus = new[] {0, 0, 0, 0, 0};
            m_bAxisPosLmt = new bool[m_nMaxAxisNum];
            m_bAxisNegLmt = new bool[m_nMaxAxisNum];
            m_bAxisAlarm = new bool[m_nMaxAxisNum];
            m_bAxisHome = new bool[m_nMaxAxisNum];


            m_nAxisStatus = new int[m_nMaxAxisNum];
            m_bFlagAlarm = new bool[m_nMaxAxisNum];
            m_bFlagMError = new bool[m_nMaxAxisNum];
            m_bFlagPosLimit = new bool[m_nMaxAxisNum];
            m_bFlagNegLimit = new bool[m_nMaxAxisNum];
            m_bFlagAStop = new bool[m_nMaxAxisNum];
            m_bFlagSStop = new bool[m_nMaxAxisNum];
            m_bFlagMotion = new bool[m_nMaxAxisNum];
            m_bFlagServoOn = new bool[m_nMaxAxisNum];

            m_dAxisPos = new double[m_nMaxAxisNum];

            for (var i = 0; i < m_nDiNum; i++) m_bUniversalIn[i] = true;

            for (var i = 0; i < m_nDoNum; i++) m_bUniversalOut[i] = true;

            for (var i = 0; i < m_nMaxAxisNum; i++)
            {
                m_dAxisResolution[i] = 0;


                m_bAxisPosLmt[i] = true;
                m_bAxisNegLmt[i] = true;
                m_bAxisAlarm[i] = true;
                m_bAxisHome[i] = true;

                m_nAxisStatus[i] = 0;
                m_bFlagAlarm[i] = true;
                m_bFlagMError[i] = true;
                m_bFlagPosLimit[i] = true;
                m_bFlagNegLimit[i] = true;
                m_bFlagAStop[i] = true;
                m_bFlagSStop[i] = true;
                m_bFlagMotion[i] = true;
                m_bFlagServoOn[i] = true;

                m_dAxisPos[i] = 0.0;
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
                if (m_bScanEnd) break;

                lock (m_oLockScanDiBit)
                {
                    UpdateAxisStatus();
                    ScanDi();
                    UpdateAxisPos();
                }
            }
        }

        private void StartScanIo()
        {
            if (m_tScanStateThread != null && !m_tScanStateThread.IsAlive)
            {
                m_bScanEnd = false;
                m_tScanStateThread.Start();
            }
        }

        private void EndScanIo()
        {
            m_bScanEnd = true;
            Thread.Sleep(100);
        }

        /// <summary>
        ///     更新轴状态
        /// </summary>
        /// <returns></returns>
        protected override bool UpdateAxisStatus()
        {
            for (var i = 0; i < m_nMaxAxisNum; i++)
            {
                //获取标志位状态
                int iSts;

                var nRtn = m_cMotionBase.GetSts(m_nCardNo, (short) (i + 1), 1, out iSts);

                if (nRtn == 0)
                {
                    m_nAxisStatus[i] = iSts;
                    //0000 0010 伺服报警标志
                    m_bFlagAlarm[i] = (m_nAxisStatus[i] & 0x2) != 0;
                    //0001 0000 运动出错
                    m_bFlagMError[i] = (m_nAxisStatus[i] & 0x10) != 0;
                    //0010 0000 正限位
                    m_bFlagPosLimit[i] = (m_nAxisStatus[i] & 0x20) != 0;
                    //0100 0000 负限位
                    m_bFlagNegLimit[i] = (m_nAxisStatus[i] & 0x40) != 0;
                    //0010 0000 0000 伺服使能
                    m_bFlagServoOn[i] = (m_nAxisStatus[i] & 0x200) != 0;
                    //0100 0000 0000 运动状态
                    m_bFlagMotion[i] = (m_nAxisStatus[i] & 0x400) != 0;
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
                nCmdRtn = m_cMotionBase.GetDi(m_nCardNo, i, out m_nDiStatus[i]);

            if (nCmdRtn != 0) return false;

            for (var j = 0; j < m_nMaxAxisNum; j++)
            {
                //正限位输入
                var bitFlag = 1 << j;
                m_bAxisPosLmt[j] = (m_nDiStatus[0] & bitFlag) == 0;
                //负限位输入
                m_bAxisNegLmt[j] = (m_nDiStatus[1] & bitFlag) == 0;
                //伺服报警输入状态显示                       
                m_bAxisAlarm[j] = (m_nDiStatus[2] & bitFlag) == 0;
                //Home信号输入状态显示                      
                m_bAxisHome[j] = (m_nDiStatus[3] & bitFlag) == 0;
            }


            //遍历数字输入口
            for (var k = 0; k < m_nDiNum; k++)
            {
                var nMask = 1 << k;
                //按位与，如果结果不为0，则说明该位有值
                m_bUniversalIn[k] = (m_nDiStatus[4] & nMask) != 0;
            }

            m_nInput = m_nDiStatus[4];

            m_cMotionBase.GetDo(0, out m_nOutput);
            //遍历数字输出口
            for (var k = 0; k < m_nDoNum; k++)
            {
                var nMask = 1 << k;
                //按位与，如果结果不为0，则说明该位有值，对应数组位置true
                m_bUniversalOut[k] = (m_nOutput & nMask) != 0;
            }

            m_cMotionBase.GetExtendDi(m_nCardNo, 0, out m_nExtIo);

            return true;
        }

        /// <summary>
        ///     更新轴坐标
        /// </summary>
        /// <returns></returns>
        protected override short UpdateAxisPos()
        {
            short nRtn = 0;
            for (short k = 1; k <= m_nMaxAxisNum; k++)
            {
                //----------------运动数据的显示-------------------//
                double dValue;
                nRtn |= k < 4
                    ? m_cMotionBase.GetEncPos(m_nCardNo, k, out dValue, 1)
                    : m_cMotionBase.GetPrfPos(m_nCardNo, k, out dValue, 1);

                if (nRtn != 0) return nRtn;

                m_dAxisPos[k - 1] = dValue;
            }

            return nRtn;
        }

        #endregion

        #region 获取&设置

        public override bool InitMotionCard(string sFileCfg)
        {
            //m_nCardNo = nCardNum;
            if (m_cMotionBase.InitMotionCard(m_nCardNo, m_nMaxAxisNum, sFileCfg) == 0)
            {
                //m_bInit = true;
                m_tScanStateThread = new Thread(ScanThreadFunction) {IsBackground = true};
                StartScanIo();
                return true;
            }

            // MessageBox.Show(@"运动卡初始化失败", @"提示");
            //m_bInit = false;
            return false;
        }

        /// <summary>
        ///     轴是否停止
        /// </summary>
        /// <param name="nAxis"></param>
        /// <returns></returns>
        public override bool IsMoving(short nAxis)
        {
            return m_bFlagMotion[nAxis - 1];
        }

        /// <summary>
        ///     获取Home信号
        /// </summary>
        /// <param name="nAxis">轴号</param>
        public override bool GetAxisHomeStatus(short nAxis)
        {
            return m_bAxisHome[nAxis - 1];
        }

        /// <summary>
        ///     获取负限位信号
        /// </summary>
        /// <param name="nAxis">轴号</param>
        public override bool GetAxisNegLimit(short nAxis)
        {
            return m_bAxisNegLmt[nAxis - 1];
        }

        /// <summary>
        ///     获取正限位信号
        /// </summary>
        /// <param name="nAxis">轴号</param>
        public override bool GetAxisPosLimit(short nAxis)
        {
            return m_bAxisPosLmt[nAxis - 1];
        }

        /// <summary>
        ///     获取轴报警信号
        /// </summary>
        /// <param name="nAxis">轴号</param>
        public override bool GetAxisAlarm(short nAxis)
        {
            return m_bAxisAlarm[nAxis - 1];
        }

        /// <summary>
        ///     获取运动错误
        /// </summary>
        /// <param name="nAxis"></param>
        /// <returns></returns>
        public override bool GetMotionError(short nAxis)
        {
            return m_bFlagMError[nAxis - 1];
        }

        /// <summary>
        ///     获取轴坐标
        /// </summary>
        /// <param name="nAxis">轴号</param>
        /// <returns></returns>
        public override double GetAxisCurPos(short nAxis)
        {
            return PulseToUnit(nAxis, m_dAxisPos[nAxis - 1]);
        }

        /// <summary>
        ///     获取报警
        /// </summary>
        /// <param name="nAxis"></param>
        /// <returns></returns>
        public override bool GetMotorAlarm(short nAxis)
        {
            return m_bFlagAlarm[nAxis - 1];
        }

        /// <summary>
        ///     设置脉冲当量
        /// </summary>
        /// <param name="nAxis">轴号</param>
        /// <param name="dResolution">当量</param>
        public override void SetAxisResolution(short nAxis, double dResolution)
        {
            m_dAxisResolution[nAxis - 1] = dResolution;
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

            if (index <= m_nDoNum)
                lock (m_oLockSetDoBit)
                {
                    m_cMotionBase.SetDoBit(m_nCardNo, index, sOn);
                }
            else if (index > m_nDoNum)
                lock (m_oLockSetDoBit)
                {
                    m_cMotionBase.SetExtendDoBit(m_nCardNo, 1, (short) (index - m_nDoNum), sOn);
                }
        }

        /// <summary>
        ///     急停
        /// </summary>
        public override void SetEStop()
        {
            for (var i = 0; i < m_nMaxAxisNum; i++)
            {
                var msk = 1 << i;
                m_cMotionBase.Stop(m_nCardNo, (short) msk, (short) msk);
            }
        }

        /// <summary>
        ///     平滑停止
        /// </summary>
        /// <param name="nAxis">轴号</param>
        public override void SetSStop(short nAxis)
        {
            var msk = 1 << (nAxis - 1);

            m_cMotionBase.Stop(m_nCardNo, (short) msk, 0);
        }

        /// <summary>
        ///     脉冲转换位物理坐标
        /// </summary>
        /// <param name="nAxis">轴号</param>
        /// <param name="dValue">值</param>
        /// <returns></returns>
        public override double PulseToUnit(short nAxis, double dValue)
        {
            var dReturnValue = dValue * m_dAxisResolution[nAxis - 1];
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
            var lReturnValue = (long) (dValue / m_dAxisResolution[nAxis - 1]);
            return lReturnValue;
        }

        /// <summary>
        ///     设置坐标为0
        /// </summary>
        public void SetZero()
        {
            m_cMotionBase.ZeroPos(m_nCardNo, 1, m_nMaxAxisNum);
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

            nRtn |= m_cMotionBase.ClrSts(m_nCardNo, nAxis, 1);
            Thread.Sleep(50);
            if (m_bFlagNegLimit[nAxis - 1] && nLimit == -1 || m_bFlagPosLimit[nAxis - 1] && nLimit == 1)
                return true; //若已经在限位位置

            //设置Jog运动参数
            nRtn |= m_cMotionBase.PrfJog(m_nCardNo, nAxis);
            nRtn |= m_cMotionBase.SetJogPrm(m_nCardNo, nAxis, 0.5, 0.5, 0.625);
            if (nRtn != 0) return false;

            //启动运动
            nRtn |= m_cMotionBase.SetVel(m_nCardNo, nAxis, nLimit * dSpeed); //设置目标速度，单位是“脉冲/毫秒”
            if (nRtn != 0) return false;
            nRtn |= m_cMotionBase.Update(m_nCardNo, nAxis);
            Thread.Sleep(200);

            var bLimit = false;
            var nStopNum = 0;

            while (!m_bFlagMError[nAxis - 1] && !bLimit)
            {
                if (nLimit == 1) //只关注正限位
                    if (!m_bAxisPosLmt[nAxis - 1])
                    {
                        bLimit = true;
                        SetSStop(nAxis); //感应到正限位后运动停止
                    }

                if (nLimit == -1) //只关注负限位
                    if (!m_bAxisNegLmt[nAxis - 1]) //感应到负限位
                    {
                        bLimit = true;
                        SetSStop(nAxis); //感应到负限位后运动停止
                    }

                // 读取规划位置
                double prfPos;
                nRtn |= m_cMotionBase.GetPrfPos(m_nCardNo, nAxis, out prfPos, 1);
                // 读取编码器位置
                double encPos;
                nRtn |= m_cMotionBase.GetEncPos(m_nCardNo, nAxis, out encPos, 1);
                // 如果运动停止，返回出错信息
                if (m_bFlagMotion[nAxis - 1] == false && !bLimit) //没到限位却停止了
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
            m_cMotionBase.AbsMove(m_nCardNo, nAxis, (int) nPos, dVel, dAcce);
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
            m_cMotionBase.JogMove(m_nCardNo, nAxis, dVel, dAcce);
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
            m_cMotionBase.RMove(m_nCardNo, nAxis, dVel, dAcce, dOffset);
            return true;
        }

        public override void ClrSts(short nAxis, short nCount)
        {
            m_cMotionBase.ClrSts(m_nCardNo, nAxis, nCount);
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
            if (m_nCardNo < 0 || nAxis > m_nMaxAxisNum || nHomeMode != 1 && nHomeMode != 2)
                return -1;
            //先去离HOME近的限位点
            var bRst = GotoLimit(nAxis, nDir, dHomeVel);
            if (bRst)
                Thread.Sleep(500);
            else
                return nRtn;

            nRtn |= m_cMotionBase.ClrSts(m_nCardNo, nAxis, 1); // 清除指定轴的报警和限位
            if (nRtn != 0) return nRtn;
            ////此处添加捕获状态清除////

            // 启动Home捕获

            //设定Trap运动参数

            double prfPos, encPos;
            short sCapture;
            int lPosition;
            //设置为Home捕获模式
            nRtn |= m_cMotionBase.SetCaptureMode(m_nCardNo, nAxis, (int) HOME_TYPE.CAPTURE_HOME);
            // 切换到点位运动模式
            // 读取点位模式运动参数

            short smoothtime = 25;
            var acc = 0.5;
            var dec = 0.5;
            // 设置点位模式运动参数
            nRtn |= m_cMotionBase.SetTrapPrm(m_nCardNo, nAxis, acc, dec, smoothtime);

            // 设置点位模式目标速度，即回原点速度
            nRtn |= m_cMotionBase.SetVel(m_nCardNo, nAxis, dHomeVel); //原点开始速度，需要更改
            //得到当前位置
            nRtn |= m_cMotionBase.GetPrfPos(m_nCardNo, nAxis, out prfPos, 1);
            // 设置点位模式目标位置，即原点搜索距离
            nRtn |= m_cMotionBase.SetPos(m_nCardNo, nAxis, (int) (prfPos + lPos)); //负方向点位运动脉冲，需要更改

            // 启动运动
            nRtn |= m_cMotionBase.Update(m_nCardNo, nAxis);

            do
            {
                //读取轴状态
                nRtn |= m_cMotionBase.GetSts(m_nCardNo, nAxis, 1, out lStatus);
                // 读取规划位置
                nRtn |= m_cMotionBase.GetPrfPos(m_nCardNo, nAxis, out prfPos, 1);
                // 读取编码器位置
                nRtn |= m_cMotionBase.GetEncPos(m_nCardNo, nAxis, out encPos, 1);
                //读取捕获状态
                nRtn |= m_cMotionBase.GetCaptureStatus(m_nCardNo, nAxis, out sCapture, out lPosition, 1);
                if (0 == (lStatus & 0x400))
                {
                    MessageBox.Show(@"没找到原点");
                    return nRtn;
                }

                Thread.Sleep(1);
            } while (sCapture == 0);

            SetSStop(nAxis);
            // 运动到“捕获位置+偏移量”
            nRtn |= m_cMotionBase.SetPos(m_nCardNo, nAxis, (int) (prfPos + lOffset));
            // 在运动状态下更新目标位置
            nRtn |= m_cMotionBase.Update(m_nCardNo, nAxis);
            do
            {
                //读取轴状态
                nRtn |= m_cMotionBase.GetSts(m_nCardNo, nAxis, 1, out lStatus);
                // 读取规划位置
                nRtn |= m_cMotionBase.GetPrfPos(m_nCardNo, nAxis, out prfPos, 1);
                // 读取编码器位置
                nRtn |= m_cMotionBase.GetEncPos(m_nCardNo, nAxis, out encPos, 1);
                Thread.Sleep(1);
                // 等待运动停止
            } while ((lStatus & 0x400) != 0);

            if (nHomeMode == (int) HOME_TYPE.CAPTURE_HOME)
            {
                nRtn |= m_cMotionBase.ZeroPos(m_nCardNo, nAxis, 1);
                return nRtn;
            }

            //设置伺服电机Z相捕获
            nRtn |= m_cMotionBase.SetCaptureMode(m_nCardNo, nAxis, (int) HOME_TYPE.MC_CAPTURE_INDEX);
            // 切换到点位运动模式
            nRtn |= m_cMotionBase.PrfTrap(m_nCardNo, nAxis);
            // 读取点位模式运动参数
            nRtn |= m_cMotionBase.GetTrapPrm(m_nCardNo, nAxis, out acc, out dec, out smoothtime);
            acc = 0.15;
            dec = 0.15;
            // 设置点位模式运动参数
            nRtn |= m_cMotionBase.SetTrapPrm(m_nCardNo, nAxis, acc, dec, smoothtime);
            // 设置点位模式目标速度，即回原点速度
            nRtn |= m_cMotionBase.SetVel(m_nCardNo, nAxis, 2); //原点开始速度，需要更改

            // 设置点位模式目标位置，即原点搜索距离
            nRtn |= m_cMotionBase.SetPos(m_nCardNo, nAxis, (int) (prfPos + 10000)); //负方向点位运动脉冲，需要更改
            // 启动运动
            nRtn |= m_cMotionBase.Update(m_nCardNo, nAxis);

            do
            {
                //读取轴状态
                nRtn |= m_cMotionBase.GetSts(m_nCardNo, nAxis, 1, out lStatus);
                // 读取规划位置
                nRtn |= m_cMotionBase.GetPrfPos(m_nCardNo, nAxis, out prfPos, 1);
                // 读取编码器位置
                nRtn |= m_cMotionBase.GetEncPos(m_nCardNo, nAxis, out encPos, 1);
                //读取捕获状态
                nRtn |= m_cMotionBase.GetCaptureStatus(m_nCardNo, nAxis, out sCapture, out lPosition, 1);
                if (0 == (lStatus & 0x400))
                {
                    MessageBox.Show(@"没找到编码器Z相信号，原点回归失败");
                    return nRtn;
                }

                Thread.Sleep(1);
            } while (0 == sCapture);

            // 设置偏移量
            nRtn |= m_cMotionBase.SetPos(m_nCardNo, nAxis, (int) (prfPos + 1000));
            // 在运动状态下更新目标位置
            nRtn |= m_cMotionBase.Update(m_nCardNo, nAxis);
            do
            {
                //读取轴状态
                nRtn |= m_cMotionBase.GetSts(m_nCardNo, nAxis, 1, out lStatus);
                // 读取规划位置
                nRtn |= m_cMotionBase.GetPrfPos(m_nCardNo, nAxis, out prfPos, 1);
                // 读取编码器位置
                nRtn |= m_cMotionBase.GetEncPos(m_nCardNo, nAxis, out encPos, 1);
                // 等待运动停止
                Thread.Sleep(1);
            } while ((lStatus & 0x400) != 0);

            //位置清零
            nRtn |= m_cMotionBase.ZeroPos(m_nCardNo, nAxis, 1);
            return nRtn;
        }

        #endregion

        #region 二维插补运动

        /// <summary>
        ///     插补运动
        /// </summary>
        /// <param name="nCrd">坐标系</param>
        /// <param name="axis1">轴1</param>
        /// <param name="axis2">轴2</param>
        /// <param name="dX">轴1坐标，单位脉冲</param>
        /// <param name="dY">轴2坐标，单位脉冲</param>
        /// <param name="dVel">速度</param>
        /// <param name="dAcce">加速度</param>
        /// <returns></returns>
        public override bool MulLine2DCrd(short nCrd, short axis1, short axis2, List<double> dX, List<double> dY,
            double dVel,
            double dAcce)
        {
            //if (!m_bInit && !m_bIsHomeOk) return false;

            short[] profile = {0, 0, 0, 0, 0, 0, 0, 0};

            profile[0] = axis1;
            profile[1] = axis2;

            if (m_cMotionBase.SetLineOrdi(m_nCardNo, 2, 500, 5, 0, profile) == 0)
            {
                m_cMotionBase.CrdClear(m_nCardNo, nCrd, 0);
                int space, nCrdPoint = 0;
                for (var i = 0; i < dX.Count; i++)
                {
                    var iAxis1 = (int) UnitToPulse(axis1, dX[i]);
                    var iAxis2 = (int) UnitToPulse(axis2, dY[i]);
                    int nRtn = m_cMotionBase.LnXy(m_nCardNo, nCrd, iAxis1, iAxis2, dVel, dAcce);
                    if (nRtn != 0) //如果插补数据压入失败
                    {
                        nCrdPoint = i;
                        break; //退出压入
                    }
                }

                //先开始插补运动
                m_cMotionBase.CrdStart(m_nCardNo, 1);

                for (var i = nCrdPoint; i < dX.Count; i++)
                {
                    //继续加入
                    var iAxis1 = (int) UnitToPulse(axis1, dX[i]);
                    var iAxis2 = (int) UnitToPulse(axis2, dY[i]);
                    int nRtn = m_cMotionBase.LnXy(m_nCardNo, nCrd, iAxis1, iAxis2, dVel, dAcce);
                    if (nRtn != 0)
                    {
                        do
                        {
                            //查询空间
                            m_cMotionBase.CrdSpace(m_nCardNo, 1, out space, 2);
                            Thread.Sleep(1);
                        } while (0 == space);

                        m_cMotionBase.LnXy(m_nCardNo, nCrd, iAxis1, iAxis2, dVel, dAcce);
                    }
                }

                short pCmdNum, run;
                int segment;
                //m_pCrdRunStatus = -1;

                //查询状态
                m_cMotionBase.CrdStatus(m_nCardNo, 1, out run, out segment, out pCmdNum, out space);
                //等待停止
                do
                {
                    m_cMotionBase.CrdStatus(m_nCardNo, 1, out run, out segment, out pCmdNum, out space);
                    Thread.Sleep(1);
                    //m_pCrdRunStatus = run;
                } while (run == 1);
            }

            return true;
        }

        ///// <summary>
        /////     插补运动状态
        ///// </summary>
        //public short m_pCrdRunStatus { get; set; }

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
            CMotionBase.DD_COMPARE_PRM prm)
        {
            short nRtn = 0;
            var obj = (object) prm;
            nRtn |= m_cMotionBase.D2DCompareSetPrm(m_nCardNo, chn, ref obj);
            nRtn |= m_cMotionBase.D2DCompareData(m_nCardNo, axis1, axis2, chn, fifo);
            nRtn |= m_cMotionBase.D2DCompareStart(m_nCardNo, chn);
            return nRtn;
        }

        public short SinglePulse(short chn, short nTime)
        {
            short nRtn = 0;
            nRtn |= m_cMotionBase.D2DComparePulse(m_nCardNo, chn, 0, 0, nTime);
            nRtn |= m_cMotionBase.D2DCompareStart(m_nCardNo, 0);
            return nRtn;
        }

        #endregion

        #endregion
    }
}