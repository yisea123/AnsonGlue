using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using AnsonGlue.Motion;

namespace AnsonGlue.Kernel
{
    #region 自定义变量


    public enum HOME_TYPE
    {
        CAPTURE_HOME = 1,
        CAPTURE_INDEX
    }

    public enum AXIS_TYPE
    {
        X_AXIS = 1,
        Y_AXIS,
        Z_AXIS,
        ALL_AXIS
    }

    internal struct CRD_PARA
    {
        public short nCardNum;
        public short nCrd;
        public short axis1;
        public short axis2;
        public List<double> listAxis1;
        public List<double> listAxis2;
        public double dVel;
        public double dAcce;
    }

    #endregion

    internal class CMotionKernel
    {
        #region 运动控制变量

        /// <summary>
        ///     插补运动状态标志位
        /// </summary>
        public bool m_bCrdSts;

        /// <summary>
        ///     设备回原标志位
        /// </summary>
        public bool m_bHomed;

        private short m_uCardIndex;

        private CFileTcp m_fileTcp;

        #endregion

        #region 运动控制参数  

        /// <summary>
        ///     板卡初始化标志位
        /// </summary>
        public bool m_bMotionCardInit;

        /// <summary>
        ///     运动控制业务类
        /// </summary>
        private static List<CMotionWorkBase> _LIST_MOTION_WORK = new List<CMotionWorkBase>();

        #endregion

        #region 单例

        /// <summary>
        ///     单例对象
        /// </summary>
        private static CMotionKernel _MOTION_KERNEL;

        /// <summary>
        ///     锁
        /// </summary>
        private static object _LOCK = new object();


        /// <summary>
        ///     构造函数
        /// </summary>
        private CMotionKernel()
        {
            m_bCrdSts = false;
            m_bHomed = false;
            m_uCardIndex = 0;
            m_fileTcp = CFileTcp.GetInstance();
        }

        /// <summary>
        /// 添加运动控制板卡
        /// </summary>
        /// <param name="nType">板卡类型</param>
        /// <param name="nMaxAxisNUm">板卡最大支持轴数</param>
        /// <returns></returns>
        public bool AddMotionCard(MOTION_TYPE nType, short nMaxAxisNUm)
        {
            //向该类链表_LIST_MOTION_WORK添加新的对象
            _LIST_MOTION_WORK.Add(CMotionWorkChristmas.GetInstance(nType, nMaxAxisNUm, m_uCardIndex));
            //卡号索引加一
            m_uCardIndex++;
            return true;
        }

        /// <summary>
        /// 得到对应卡号的单例对象
        /// </summary>
        /// <returns></returns>
        public static CMotionKernel GetInstance()
        {
            if (_MOTION_KERNEL != null) return _MOTION_KERNEL;
            lock (_LOCK)
            {
                if (_MOTION_KERNEL == null)
                    _MOTION_KERNEL = new CMotionKernel();
                return _MOTION_KERNEL;
            }
        }

        #endregion

        #region 运动控制函数

        /// <summary>
        ///     板卡初始化
        /// </summary>
        public bool InitMotionCard(STRUCT_MOTION_CARD sCardNum)
        {
            //如果该类对象链表里面为空
            if (_LIST_MOTION_WORK.Count<1)
            {
                MessageBox.Show(@"板卡初始化失败,请先添加运动控制板卡！");
                m_fileTcp.DisplayWarningInfo(@"板卡初始化失败,请先添加运动控制板卡！");
                return false;
            }

            //获取卡号
            int iCardNo = Convert.ToInt32(sCardNum.strCardNo);
            //从传入的结构体里获取该板卡的配置文件
            var bRtn = _LIST_MOTION_WORK[iCardNo].InitMotionCard(sCardNum.strCfgPath);
            if (!bRtn)
            {
                MessageBox.Show(@"板卡初始化失败");
                m_fileTcp.DisplayWarningInfo(@"板卡初始化失败");
                return false;
            }

            //从传入的结构体里获取轴的细分
            m_bMotionCardInit = true;
            double dResoX = Convert.ToDouble(sCardNum.m_listAxisRes[0]);
            double dResoY = Convert.ToDouble(sCardNum.m_listAxisRes[0]);
            double dResoZ = Convert.ToDouble(sCardNum.m_listAxisRes[0]);
            //设置轴的细分
            _LIST_MOTION_WORK[iCardNo].SetAxisResolution((short)AXIS_TYPE.X_AXIS, dResoX);
            _LIST_MOTION_WORK[iCardNo].SetAxisResolution((short)AXIS_TYPE.Y_AXIS, dResoY);
            _LIST_MOTION_WORK[iCardNo].SetAxisResolution((short)AXIS_TYPE.Z_AXIS, dResoZ);
            return true;
        }

        /// <summary>
        /// 急停
        /// </summary>
        /// <param name="nCardNum"></param>
        public void SetEStop(short nCardNum)
        {
            _LIST_MOTION_WORK[nCardNum].SetEStop();
        }

        /// <summary>
        /// 清除状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis"></param>
        /// <param name="nCount"></param>
        public void ClrSts(short nCardNum,short nAxis,short nCount)
        {
            _LIST_MOTION_WORK[nCardNum].ClrSts(nAxis, nCount);
        }

        /// <summary>
        ///     割一刀轴位置信息
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis"></param>
        /// <returns></returns>
        public double GetAxisCurPos(short nCardNum,AXIS_TYPE nAxis)
        {
            return _LIST_MOTION_WORK[nCardNum].GetAxisCurPos((short)nAxis);
        }

        /// <summary>
        ///     轴Jog运动
        /// </summary>
        /// <param name="nType"></param>
        /// <param name="dVel"></param>
        /// <param name="dAcc"></param>
        /// <param name="nCardNum"></param>
        public void AxisJogMove(AXIS_TYPE nType, double dVel, double dAcc, short nCardNum = 0)
        {
            if (GetAxisMotionSts(nCardNum, AXIS_TYPE.ALL_AXIS))
            {
                MessageBox.Show(@"请先等待轴停止！");
                return;
            }
            _LIST_MOTION_WORK[nCardNum].JogMove((short)nType, dVel, dAcc);
        }

        /// <summary>
        ///     轴平滑停止
        /// </summary>
        /// <param name="nAxis"></param>
        /// <param name="nCardNum"></param>
        public void SmoothStopAxis(AXIS_TYPE nAxis, short nCardNum = 0)
        {
            _LIST_MOTION_WORK[nCardNum].SetSStop((short)nAxis);
        }

        /// <summary>
        ///     单轴回原
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis"></param>
        /// <param name="nType"></param>
        public void SingleAxisHome(short nCardNum,AXIS_TYPE nAxis, HOME_TYPE nType)
        {
            if (GetAxisMotionSts(nCardNum, AXIS_TYPE.ALL_AXIS))
            {
                MessageBox.Show(@"请先等待轴停止！");
                return;
            }
            _LIST_MOTION_WORK[nCardNum].StartSingleHome((short)nAxis, (short)nType, -1, 10, 1000000, 100);
        }

        /// <summary>
        ///     得到轴运动状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <returns>true：运动 false：静止</returns>
        public bool GetAxisMotionSts(short nCardNum,AXIS_TYPE nAxis)
        {
            //如果选择ALL_AXIS，返回整个板卡的运动状态
            if (nAxis == AXIS_TYPE.ALL_AXIS)
            {
                var bAllAxisSts = false;
                for (short i = 1; i < _LIST_MOTION_WORK[nCardNum].m_nMaxAxisNum; i++)
                {
                    var bAxisSts = _LIST_MOTION_WORK[nCardNum].IsMoving(i);
                    bAllAxisSts = bAllAxisSts || bAxisSts;
                }

                return bAllAxisSts;
            }

            return _LIST_MOTION_WORK[nCardNum].IsMoving((short)nAxis);
        }

        /// <summary>
        ///     得到轴正限位状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <returns></returns>
        public bool GetAxisPosLimitSts(short nCardNum,AXIS_TYPE nAxis)
        {
            return _LIST_MOTION_WORK[nCardNum].GetAxisPosLimit((short)nAxis);
        }

        /// <summary>
        ///     得到轴负限位状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <returns></returns>
        public bool GetAxisNegLimitSts(short nCardNum,AXIS_TYPE nAxis)
        {
            return _LIST_MOTION_WORK[nCardNum].GetAxisNegLimit((short)nAxis);
        }

        /// <summary>
        ///     得到轴Home状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <returns></returns>
        public bool GetAxisHomeLimitSts(short nCardNum,AXIS_TYPE nAxis)
        {
            return _LIST_MOTION_WORK[nCardNum].GetAxisHomeStatus((short)nAxis);
        }

        /// <summary>
        ///     得到轴报警状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis"></param>
        /// <returns></returns>
        public bool GetAxisAlarmSts(short nCardNum,AXIS_TYPE nAxis)
        {
            return _LIST_MOTION_WORK[nCardNum].GetAxisAlarm((short)nAxis);
        }

        public bool GetDiSts(short nCardNum,ushort uDi)
        {
            return _LIST_MOTION_WORK[nCardNum].m_bUniversalIn[uDi];
        }

        public bool GetDoSts(short nCardNum,ushort uDo)
        {
            return _LIST_MOTION_WORK[nCardNum].m_bUniversalOut[uDo]; 
        }

        public void SetDiSts(short nCardNum,ushort uDi, bool bOn)
        {
            _LIST_MOTION_WORK[nCardNum].SetDoBit(uDi, bOn);
        }

        /// <summary>
        ///     阻塞式等待轴结束运动
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        public void WaitAxisOverMotion(short nCardNum,AXIS_TYPE nAxis)
        {
            var bAxisSts = GetAxisMotionSts(nCardNum,nAxis);
            //等待点位运动停止
            while (bAxisSts)
            {
                bAxisSts = GetAxisMotionSts(nCardNum,nAxis);
                Thread.Sleep(1);
            }
        }

        /// <summary>
        ///     点位运动
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="dPosition">位置</param>
        /// <param name="dVel">速度：默认10</param>
        /// <param name="dAcc">加速度：默认1</param>
        /// <returns></returns>
        public bool AxisAbsMotion(short nCardNum,AXIS_TYPE nAxis, double dPosition, double dVel = 10, double dAcc = 1)
        {
            if (GetAxisMotionSts(0, nAxis))
            {
                MessageBox.Show(@"请等待轴停止！");
                return false;
            }
            return _LIST_MOTION_WORK[nCardNum].AbsMove((short)nAxis, dPosition, dVel, dAcc);
        }

        /// <summary>
        ///     使用二维插补移动轴
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="strPosition"></param>
        public void Go2DPosition(short nCardNum,string strPosition)
        {
            if (GetAxisMotionSts(0, AXIS_TYPE.ALL_AXIS))
            {
                MessageBox.Show(@"请等待轴停止！");
                return;
            }
            //得到Z安全位置
            string strValue;
            m_fileTcp.GetParameterFromIni((ushort) PARAMETER_TYPE.POSITION, (ushort) POSITION_TYPE.Z_SAVE,
                out strValue);
            var dZSave = Convert.ToDouble(strValue);
            //得到Z当前位置
            var dCurPosition = GetAxisCurPos(nCardNum,AXIS_TYPE.Z_AXIS);
            //比较
            if (dCurPosition > dZSave)
            {
                //点位运动
                AxisAbsMotion(nCardNum,AXIS_TYPE.Z_AXIS, dZSave);
                //获取轴停止
                WaitAxisOverMotion(nCardNum,AXIS_TYPE.Z_AXIS);
            }

            //获取保存点位信息
            STRUCT_POSITION structPosition;
            m_fileTcp.GetPositionFromIni(strPosition, out structPosition);
            var listAxis1 = new List<double>();
            var listAxis2 = new List<double>();
            listAxis1.Add(Convert.ToDouble(structPosition.strX));
            listAxis2.Add(Convert.ToDouble(structPosition.strY));
            //开始插补
            LinesCrdMotion(nCardNum,1, (short)AXIS_TYPE.X_AXIS, (short)AXIS_TYPE.Y_AXIS, listAxis1, listAxis2);
            //等待插补完成
            while (m_bCrdSts) Thread.Sleep(1);

            var dZPosition = Convert.ToDouble(structPosition.strZ);
            //点位运动
            AxisAbsMotion(nCardNum,AXIS_TYPE.Z_AXIS, dZPosition);
            //获取轴停止
            WaitAxisOverMotion(nCardNum,AXIS_TYPE.Z_AXIS);
        }

        /// <summary>
        ///     多线段插补运动
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nCrd">坐标系号</param>
        /// <param name="axis1">轴1</param>
        /// <param name="axis2">轴2</param>
        /// <param name="listAxis1">轴1坐标List</param>
        /// <param name="listAxis2">轴2坐标List</param>
        /// <param name="dVel">速度，默认为10</param>
        /// <param name="dAcce">加速度，默认为1</param>
        /// <returns></returns>
        public void LinesCrdMotion(short nCardNum,short nCrd, short axis1, short axis2, List<double> listAxis1, List<double> listAxis2,
            double dVel = 10, double dAcce = 1)
        {
            m_bCrdSts = true;
            var sCrdPara = new CRD_PARA
            {
                nCardNum = nCardNum,
                nCrd = nCrd,
                axis1 = axis1,
                axis2 = axis2,
                listAxis1 = listAxis1,
                listAxis2 = listAxis2,
                dVel = dVel,
                dAcce = dAcce
            };
            var tCrdThread = new Thread(CrdThread) {IsBackground = true};
            tCrdThread.Start(sCrdPara);
        }

        /// <summary>
        ///     插补运动线程
        /// </summary>
        /// <param name="obj">插补运动参数</param>
        private void CrdThread(object obj)
        {
            var sCrdPara = (CRD_PARA) obj;
            var nCardNum = sCrdPara.nCardNum;
            var nCrd = sCrdPara.nCrd;
            var axis1 = sCrdPara.axis1;
            var axis2 = sCrdPara.axis2;
            var listAxis1 = sCrdPara.listAxis1;
            var listAxis2 = sCrdPara.listAxis2;
            var dVel = sCrdPara.dVel;
            var dAcce = sCrdPara.dAcce;
            _LIST_MOTION_WORK[nCardNum].MulLine2DCrd(nCrd, axis1, axis2, listAxis1, listAxis2, dVel, dAcce);
            m_bCrdSts = false;
        }

        #endregion

        #region 点胶线程

        #endregion

        #region 拍照线程

        #endregion
    }
}