using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using AnsonGlue.Equipment.Blance.AbstractClass;
using AnsonGlue.Equipment.Blance.ConcreteClass;
using AnsonGlue.Equipment.Motion.Function.AbstractClass;
using AnsonGlue.Equipment.Motion.Function.ConcreteClass;
using AnsonGlue.Equipment.ScannerGun.AbstractClass;
using AnsonGlue.Equipment.ScannerGun.ConcreteClass;
using AnsonGlue.Equipment.Vision.AbstractClass;
using AnsonGlue.Equipment.Vision.ConcreteClass;
using AnsonGlue.Tool;
using AnsonGlue.Tool.Communication.Factory.AbstractClass;
using AnsonGlue.Tool.Communication.Factory.ConcreteClass;

namespace AnsonGlue.Kernel
{
    #region 自定义变量

    public struct STRUCT_CMT_INFO
    {
        /// <summary>
        ///     通讯类型
        /// </summary>
        public int m_nType;

        //TCP
        /// <summary>
        ///     TCP服务器IP地址
        /// </summary>
        public string m_strStcpAddress;

        /// <summary>
        ///     TCP服务器端口
        /// </summary>
        public int m_nStcpPort;

        //串口
        /// <summary>
        ///     串口号
        /// </summary>
        public string m_strSerialPortNum;

        /// <summary>
        ///     串口比特率
        /// </summary>
        public int m_nSerialBaudRate;

        /// <summary>
        ///     串口比较位
        /// </summary>
        public int m_nSerialDateBits;

        /// <summary>
        ///     串口停止位
        /// </summary>
        public string m_strSerialStopBits;

        /// <summary>
        ///     串口奇偶校验位
        /// </summary>
        public string m_strSerialParity;

        private STRUCT_CMT_INFO(string str = @"127.0.0.1")
        {
            m_nType = 0;
            m_strStcpAddress = str;
            m_nStcpPort = 60000;
            m_strSerialPortNum = @"COM1";
            m_nSerialBaudRate = 9600;
            m_nSerialDateBits = 8;
            m_strSerialStopBits = @"One";
            m_strSerialParity = @"None";
        }
    }

    /// <summary>
    ///     消息函数规则
    /// </summary>
    /// <param name="strMsg">传入信息</param>
    public delegate void DELEGATE_MSG(string strMsg);

    #endregion

    internal class CKernel
    {
        #region 自定义变量

        /// <summary>
        ///     运动控制板卡设置参数结构体
        /// </summary>
        public struct STRUCT_MOTION_CARD
        {
            public readonly string m_strCardName;
            public readonly string m_strCardNo;
            public string m_strMaxAxisNum;
            public string m_strCfgPath;
            public List<string> m_listOfAxisRes;

            public STRUCT_MOTION_CARD(string strName, string strCardNo, string strMaxNum, List<string> listAxisRes)
                : this()
            {
                m_strCardName = strName;
                m_strCardNo = strCardNo;
                m_strMaxAxisNum = strMaxNum;
                m_listOfAxisRes = listAxisRes;
            }
        }

        /// <summary>
        ///     运动控制轴坐标结构体
        /// </summary>
        public struct STRUCT_POSITION
        {
            public string m_strPositionX;
            public string m_strPositionY;
            public string m_strPositionZ;

            public STRUCT_POSITION(string strX, string strY, string strZ)
                : this()
            {
                m_strPositionX = strX;
                m_strPositionY = strY;
                m_strPositionZ = strZ;
            }
        }

        #endregion

        #region 运动控制

        #region 自定义变量

        /// <summary>
        ///     回原点类型
        /// </summary>
        public enum ENUM_HOME_TYPE
        {
            CAPTURE_HOME = 1,
            CAPTURE_INDEX
        }

        /// <summary>
        ///     运动控制轴名
        /// </summary>
        public enum ENUM_AXIS_TYPE
        {
            X_AXIS = 1,
            Y_AXIS,
            Z_AXIS,
            ALL_AXIS
        }

        /// <summary>
        ///     插补运动参数结构体（支持最多四轴插补）
        /// </summary>
        public struct STRUCT_CRD_PARA_KERENEL
        {
            public short m_sDatatype; //0：直线； 1：IO ；2：延时； 3：圆弧；     
            public double m_dPositionOfAxis1; //轴一的点位信息
            public double m_dPositionOfAxis2;
            public double m_dPositionOfAxis3;
            public double m_dPositionOfAxis4;
            public ushort m_usDoMask; //数字输出的掩码，即有效位
            public ushort m_usDoValue; //数字输出的值
            public ushort m_usDelayTime; //延时
            public double m_dVel;
            public double m_dAcc;
            public double m_dCircleEndX; //圆弧终点位置
            public double m_dCircleEndY;
            public double m_dCenterX; //圆弧中心位置
            public double m_dCenterY;
            public short m_sDir; //圆弧方向

            public STRUCT_CRD_PARA_KERENEL(short datatype)
                : this()
            {
                m_sDatatype = datatype;
                m_dPositionOfAxis1 = 0;
                m_dPositionOfAxis2 = 0;
                m_dPositionOfAxis3 = 0;
                m_dPositionOfAxis4 = 0;
                m_usDoMask = 0x0000;
                m_usDoValue = 0x0000;
                m_usDelayTime = 1;
                m_dVel = 10;
                m_dAcc = 0.5;
                m_dCircleEndX = 0;
                m_dCircleEndY = 0;
                m_dCenterX = 0;
                m_dCenterY = 0;
                m_sDir = 0;
            }
        }

        #endregion

        #region 运动控制变量

        /// <summary>
        ///     插补运动状态标志位
        /// </summary>
        private bool m_bCrdSts;

        /// <summary>
        ///     设备回原标志位
        /// </summary>
        public bool m_bHomed;

        /// <summary>
        ///     已经添加了的运动卡编号，避免添加运动卡的编号重复
        /// </summary>
        private short m_oCardNoOfHadAdd;

        #endregion

        #region 运动控制参数

        /// <summary>
        ///     板卡初始化标志位
        /// </summary>
        public bool m_bMotionCardInit;

        /// <summary>
        ///     运动控制业务类
        /// </summary>
        private static List<CMotionWorkBase> s_listMotionWork = new List<CMotionWorkBase>();

        #endregion

        #region 运动控制函数

        private void InitMotion()
        {
            m_bCrdSts = false;
            m_bHomed = false;
            m_oCardNoOfHadAdd = 0;
        }

        /// <summary>
        ///     添加运动控制板卡
        /// </summary>
        /// <param name="cardType">板卡类型</param>
        /// <param name="nMaxAxisNUm">板卡最大支持轴数</param>
        /// <returns></returns>
        public bool AddMotionCard(short cardType, short nMaxAxisNUm)
        {
            //向该类链表_LIST_MOTION_WORK添加新的对象
            s_listMotionWork.Add(CMotionWorkChristmas.GetInstance(cardType, nMaxAxisNUm, m_oCardNoOfHadAdd));
            //卡号索引加一
            m_oCardNoOfHadAdd++;
            return true;
        }

        /// <summary>
        ///     板卡初始化
        /// </summary>
        public short InitMotionCard(STRUCT_MOTION_CARD sCardNum)
        {
            //如果该类对象链表里面为空
            if (s_listMotionWork.Count < 1)
            {
                MessageBox.Show(@"运动控制板卡为空，请先添加运动控制板卡！");
                return -1;
            }

            //获取卡号
            var iCardNo = ConverToInt32(sCardNum.m_strCardNo);
            //从传入的结构体里获取该板卡的配置文件
            var bRtn = s_listMotionWork[iCardNo].InitMotionCard(sCardNum.m_strCfgPath);
            if (!bRtn)
            {
                MessageBox.Show(@"板卡初始化失败");
                return -2;
            }

            //从传入的结构体里获取轴的细分
            m_bMotionCardInit = true;
            var dResoX = Convert.ToDouble(sCardNum.m_listOfAxisRes[0]);
            var dResoY = Convert.ToDouble(sCardNum.m_listOfAxisRes[0]);
            var dResoZ = Convert.ToDouble(sCardNum.m_listOfAxisRes[0]);
            //设置轴的细分
            s_listMotionWork[iCardNo].SetAxisResolution((short) ENUM_AXIS_TYPE.X_AXIS, dResoX);
            s_listMotionWork[iCardNo].SetAxisResolution((short) ENUM_AXIS_TYPE.Y_AXIS, dResoY);
            s_listMotionWork[iCardNo].SetAxisResolution((short) ENUM_AXIS_TYPE.Z_AXIS, dResoZ);
            return 0;
        }

        /// <summary>
        ///     急停
        /// </summary>
        /// <param name="nCardNum"></param>
        public void SetEStop(short nCardNum)
        {
            s_listMotionWork[nCardNum].SetEStop();
        }

        /// <summary>
        ///     清除状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis"></param>
        /// <param name="nCount"></param>
        public void ClrSts(short nCardNum, short nAxis, short nCount)
        {
            s_listMotionWork[nCardNum].ClrSts(nAxis, nCount);
        }

        /// <summary>
        ///     割一刀轴位置信息
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis"></param>
        /// <returns></returns>
        public double GetAxisCurPos(short nCardNum, ENUM_AXIS_TYPE nAxis)
        {
            return s_listMotionWork[nCardNum].GetAxisCurPos((short) nAxis);
        }

        /// <summary>
        ///     轴Jog运动
        /// </summary>
        /// <param name="nType"></param>
        /// <param name="dVel"></param>
        /// <param name="dAcc"></param>
        /// <param name="nCardNum"></param>
        public void AxisJogMove(ENUM_AXIS_TYPE nType, double dVel, double dAcc, short nCardNum = 0)
        {
            if (GetAxisMotionSts(nCardNum, ENUM_AXIS_TYPE.ALL_AXIS))
            {
                MessageBox.Show(@"请先等待轴停止！");
                return;
            }

            s_listMotionWork[nCardNum].JogMove((short) nType, dVel, dAcc);
        }

        /// <summary>
        ///     轴相对位置运动
        /// </summary>
        /// <param name="nType">轴号</param>
        /// <param name="dVel">速度</param>
        /// <param name="dAcc">加速度</param>
        /// <param name="dDistance">距离</param>
        /// <param name="nCardNum">卡号</param>
        public void AxisRMove(ENUM_AXIS_TYPE nType, double dVel, double dAcc, double dDistance, short nCardNum = 0)
        {
            if (GetAxisMotionSts(nCardNum, ENUM_AXIS_TYPE.ALL_AXIS))
            {
                MessageBox.Show(@"请先等待轴停止！");
                return;
            }

            s_listMotionWork[nCardNum].RMove((short) nType, dVel, dAcc, dDistance);
        }

        /// <summary>
        ///     轴平滑停止
        /// </summary>
        /// <param name="nAxis"></param>
        /// <param name="nCardNum"></param>
        public void SmoothStopAxis(ENUM_AXIS_TYPE nAxis, short nCardNum = 0)
        {
            s_listMotionWork[nCardNum].SetSStop((short) nAxis);
        }

        /// <summary>
        ///     单轴回原
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis"></param>
        /// <param name="nType"></param>
        public short SingleAxisHome(short nCardNum, ENUM_AXIS_TYPE nAxis, ENUM_HOME_TYPE nType)
        {
            if (GetAxisMotionSts(nCardNum, ENUM_AXIS_TYPE.ALL_AXIS))
            {
                MessageBox.Show(@"请先等待轴停止！");
                return -1;
            }

            var rtn = s_listMotionWork[nCardNum].StartSingleHome((short) nAxis, (short) nType, -1, 10, 1000000, 100);
            return rtn;
        }

        /// <summary>
        ///     得到轴运动状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <returns>true：运动 false：静止</returns>
        public bool GetAxisMotionSts(short nCardNum, ENUM_AXIS_TYPE nAxis)
        {
            //如果选择ALL_AXIS，返回整个板卡的运动状态
            if (nAxis == ENUM_AXIS_TYPE.ALL_AXIS)
            {
                var bAllAxisSts = false;
                for (short i = 1; i < s_listMotionWork[nCardNum].m_maxAxisNum; i++)
                {
                    var bAxisSts = s_listMotionWork[nCardNum].IsMoving(i);
                    bAllAxisSts = bAllAxisSts || bAxisSts;
                }

                return bAllAxisSts;
            }

            return s_listMotionWork[nCardNum].IsMoving((short) nAxis);
        }

        /// <summary>
        ///     得到轴正限位状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <returns></returns>
        public bool GetAxisPosLimitSts(short nCardNum, ENUM_AXIS_TYPE nAxis)
        {
            return s_listMotionWork[nCardNum].GetAxisPosLimit((short) nAxis);
        }

        /// <summary>
        ///     得到轴负限位状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <returns></returns>
        public bool GetAxisNegLimitSts(short nCardNum, ENUM_AXIS_TYPE nAxis)
        {
            return s_listMotionWork[nCardNum].GetAxisNegLimit((short) nAxis);
        }

        /// <summary>
        ///     得到轴Home状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <returns></returns>
        public bool GetAxisHomeLimitSts(short nCardNum, ENUM_AXIS_TYPE nAxis)
        {
            return s_listMotionWork[nCardNum].GetAxisHomeStatus((short) nAxis);
        }

        /// <summary>
        ///     得到轴报警状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis"></param>
        /// <returns></returns>
        public bool GetAxisAlarmSts(short nCardNum, ENUM_AXIS_TYPE nAxis)
        {
            return s_listMotionWork[nCardNum].GetAxisAlarm((short) nAxis);
        }

        public bool GetDiSts(short nCardNum, ushort uDi)
        {
            return s_listMotionWork[nCardNum].m_bsUniversalIn[uDi];
        }

        public bool GetDoSts(short nCardNum, ushort uDo)
        {
            return s_listMotionWork[nCardNum].m_bsUniversalOut[uDo];
        }

        public void SetDoSts(short nCardNum, ushort uDi, bool bOn)
        {
            s_listMotionWork[nCardNum].SetDoBit(uDi, bOn);
        }

        /// <summary>
        ///     阻塞式等待轴结束运动
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        public void WaitAxisOverMotion(short nCardNum, ENUM_AXIS_TYPE nAxis)
        {
            var bAxisSts = GetAxisMotionSts(nCardNum, nAxis);
            //等待点位运动停止
            while (bAxisSts)
            {
                bAxisSts = GetAxisMotionSts(nCardNum, nAxis);
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
        public bool AxisAbsMotion(short nCardNum, ENUM_AXIS_TYPE nAxis, double dPosition, double dVel = 10,
            double dAcc = 1)
        {
            if (GetAxisMotionSts(0, nAxis))
            {
                MessageBox.Show(@"请等待轴停止！");
                return false;
            }

            return s_listMotionWork[nCardNum].AbsMove((short) nAxis, dPosition, dVel, dAcc);
        }

        /// <summary>
        ///     使用二维插补移动轴
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="strPosition"></param>
        public void Go2DPosition(short nCardNum, string strPosition)
        {
            if (GetAxisMotionSts(0, ENUM_AXIS_TYPE.X_AXIS) || GetAxisMotionSts(0, ENUM_AXIS_TYPE.Y_AXIS))
            {
                MessageBox.Show(@"请先停止轴X、Y停止！");
                return;
            }

            //得到Z安全位置
            string strValue;
            GetParameterFromIni(@"Position", @"ZSave", out strValue);
            var dZSave = Convert.ToDouble(strValue);
            //得到Z当前位置
            var dCurPosition = GetAxisCurPos(nCardNum, ENUM_AXIS_TYPE.Z_AXIS);
            //比较
            if (dCurPosition > dZSave)
            {
                //点位运动
                AxisAbsMotion(nCardNum, ENUM_AXIS_TYPE.Z_AXIS, dZSave);
                //获取轴停止
                WaitAxisOverMotion(nCardNum, ENUM_AXIS_TYPE.Z_AXIS);
            }

            //获取保存点位信息
            STRUCT_POSITION structPosition;
            GetPositionFromIni(strPosition, out structPosition);

            //设置需要2D插补运动的轴号链表
            IReadOnlyList<short> listOfAxisNo = new List<short>
                {(short) ENUM_AXIS_TYPE.X_AXIS, (short) ENUM_AXIS_TYPE.Y_AXIS};

            var crdParaKerenel = new STRUCT_CRD_PARA_KERENEL
            {
                m_dAcc = 2,
                m_dVel = 150,
                m_dPositionOfAxis1 = Convert.ToDouble(structPosition.m_strPositionX),
                m_dPositionOfAxis2 = Convert.ToDouble(structPosition.m_strPositionY),
                m_sDatatype = 0
            };

            IReadOnlyList<STRUCT_CRD_PARA_KERENEL> listOfCrdParaKernel = new List<STRUCT_CRD_PARA_KERENEL>
                {crdParaKerenel};


            //开始插补
            LinesCrdMotion(nCardNum, 1, listOfAxisNo, listOfCrdParaKernel);
            //等待插补完成
            while (m_bCrdSts) Thread.Sleep(1);

            var dZPosition = Convert.ToDouble(structPosition.m_strPositionZ);
            //点位运动
            AxisAbsMotion(nCardNum, ENUM_AXIS_TYPE.Z_AXIS, dZPosition);
            //获取轴停止
            WaitAxisOverMotion(nCardNum, ENUM_AXIS_TYPE.Z_AXIS);
        }

        /// <summary>
        ///     直线插补运动
        /// </summary>
        /// <param name="cardNo">卡号</param>
        /// <param name="crdNo">坐标系号</param>
        /// <param name="listOfAxisNo">轴号链表</param>
        /// <param name="crdParaKernelList">插补运动参数链表</param>
        public void LinesCrdMotion(short cardNo, short crdNo, IReadOnlyList<short> listOfAxisNo,
            IReadOnlyList<STRUCT_CRD_PARA_KERENEL> crdParaKernelList)
        {
            var listOfCrdParas = new List<CMotionWorkBase.STRUCT_CRD_PARA>();

            var crdParas = new CMotionWorkBase.STRUCT_CRD_PARA();
            foreach (var crdParaKerne in crdParaKernelList)
            {
                crdParas.m_dAcc = crdParaKerne.m_dAcc;
                crdParas.m_dVel = crdParaKerne.m_dVel;

                crdParas.m_datatype = crdParaKerne.m_sDatatype;
                crdParas.m_dPositionOfAxis1 = crdParaKerne.m_dPositionOfAxis1;
                crdParas.m_dPositionOfAxis2 = crdParaKerne.m_dPositionOfAxis2;
                crdParas.m_dPositionOfAxis3 = crdParaKerne.m_dPositionOfAxis3;
                crdParas.m_dPositionOfAxis4 = crdParaKerne.m_dPositionOfAxis4;

                crdParas.m_usDoMask = crdParaKerne.m_usDoMask;
                crdParas.m_usDoValue = crdParaKerne.m_usDoValue;
                crdParas.m_usDelayTime = crdParaKerne.m_usDelayTime;
                crdParas.m_dCircleX = crdParaKerne.m_dCircleEndX;
                crdParas.m_dCircleY = crdParaKerne.m_dCircleEndY;
                crdParas.m_dCenterX = crdParaKerne.m_dCenterX;
                crdParas.m_dCenterY = crdParaKerne.m_dCenterY;
                crdParas.m_sDir = crdParaKerne.m_sDir;

                listOfCrdParas.Add(crdParas);
            }

            //把插补运动状态设置为true
            m_bCrdSts = true;
            s_listMotionWork[cardNo].MulLineCrd(crdNo, listOfAxisNo, listOfCrdParas);
            //把插补运动状态设置为false
            m_bCrdSts = false;
        }

        #endregion

        #endregion

        #region 文件保存

        #region 自定义变量

        /// <summary>
        ///     显示消息的委托类型
        /// </summary>
        /// <param name="strMsg"></param>
        public delegate void DISPLAY_MSG(string strMsg);

        /// <summary>
        ///     用于显示消息的事件
        /// </summary>
        public event DISPLAY_MSG m_eDisplayMsg;

        #endregion

        #region 成员变量

        /// <summary>
        ///     读写Ini对象
        /// </summary>
        private CIniFile m_oIniFile;

        /// <summary>
        ///     点位设置ini路径
        /// </summary>
        private string m_strPathOfSetPosition;

        /// <summary>
        ///     设置参数ini路径
        /// </summary>
        private string m_strPathOfSetPara;

        /// <summary>
        ///     运动控制板卡设置参数ini路径
        /// </summary>
        private string m_strPathOfSetMotionCard;

        /// <summary>
        ///     通讯方式参数设置Ini路径
        /// </summary>
        private string m_strCmtIniPath;

        /// <summary>
        ///     日志Txt文件路径
        /// </summary>
        private string m_strTxtPathOfWarningLog;

        /// <summary>
        ///     报警Txt文件路径
        /// </summary>
        private string m_strTxtPathOfOperationLog;

        #endregion

        #region 成员函数

        /// <summary>
        ///     ini文件初始化
        /// </summary>
        private void InitFile()
        {
            m_oIniFile = new CIniFile();
            //设置ini文件路径
            var strSystemPath = AppDomain.CurrentDomain.BaseDirectory;
            m_strPathOfSetPara = strSystemPath + @"Setting.ini";
            m_strPathOfSetPosition = strSystemPath + @"Position.ini";
            m_strPathOfSetMotionCard = strSystemPath + @"MotionCard.ini";
            m_strCmtIniPath += AppDomain.CurrentDomain.BaseDirectory + "\\CmtSetting.ini";

            var strWarning = string.Format(@"WarningLog{0:D4}{1:D2}{2:D2}.txt", DateTime.Now.ToLocalTime().Year,
                DateTime.Now.ToLocalTime().Month, DateTime.Now.ToLocalTime().Day);
            m_strTxtPathOfWarningLog = strSystemPath + strWarning;

            var strOperation = string.Format(@"OperationLog{0:D4}{1:D2}{2:D2}.txt", DateTime.Now.ToLocalTime().Year,
                DateTime.Now.ToLocalTime().Month, DateTime.Now.ToLocalTime().Day);

            m_strTxtPathOfOperationLog = strSystemPath + strOperation;
        }

        /// <summary>
        ///     得到保存图片的文件夹路径
        /// </summary>
        /// <param name="strType">类型</param>
        public string GetExcelImageDirFromIni(string strType)
        {
            var strPath = m_oIniFile.ReadContentValueFromIni(@"Path", strType, m_strPathOfSetPara);
            return strPath;
        }

        /// <summary>
        ///     设置表格保存的路径
        /// </summary>
        /// <param name="strType">类型</param>
        /// <param name="strPath">路径</param>
        public void SetExcelImageDirToIni(string strType, string strPath)
        {
            m_oIniFile.WriteContentValueToIni(@"Path", strType, strPath, m_strPathOfSetPara);
        }

        /// <summary>
        ///     得到视觉Ip地址和Port号
        /// </summary>
        /// <param name="strIp">Ip地址</param>
        /// <param name="strPort">端口号</param>
        public void GetVisionIpPortFromIni(out string strIp, out string strPort)
        {
            strIp = m_oIniFile.ReadContentValueFromIni("Vision", "Address", m_strPathOfSetPara);
            strPort = m_oIniFile.ReadContentValueFromIni("Vision", "Port", m_strPathOfSetPara);
        }

        /// <summary>
        ///     设置参数到Ini文件
        /// </summary>
        /// <param name="strSection">参数类型</param>
        /// <param name="strKey">字节类型</param>
        /// <param name="strValue">速度</param>
        public void SetParameterToIni(string strSection, string strKey, string strValue)
        {
            m_oIniFile.WriteContentValueToIni(strSection, strKey, strValue, m_strPathOfSetPara);
        }

        /// <summary>
        ///     从Ini文件得到点胶参数
        /// </summary>
        /// <param name="strSection">参数类型</param>
        /// <param name="strKey">索引</param>
        /// <param name="strValue">值</param>
        public void GetParameterFromIni(string strSection, string strKey, out string strValue)
        {
            strValue = m_oIniFile.ReadContentValueFromIni(strSection, strKey, m_strPathOfSetPara);
        }

        /// <summary>
        ///     设置设备参数到ini文件
        /// </summary>
        /// <param name="sMotionCard">参数结构体</param>
        public void SetMachineParaToIni(STRUCT_MOTION_CARD sMotionCard)
        {
            var strSection = sMotionCard.m_strCardName + @"-" + sMotionCard.m_strCardNo;
            m_oIniFile.WriteContentValueToIni(strSection, @"MaxAxisNum", sMotionCard.m_strMaxAxisNum,
                m_strPathOfSetMotionCard);
            m_oIniFile.WriteContentValueToIni(strSection, @"CfgPath", sMotionCard.m_strCfgPath,
                m_strPathOfSetMotionCard);

            for (var i = 0; i < sMotionCard.m_listOfAxisRes.Count; i++)
            {
                var strAxis = string.Format(@"AxisRes-{0:D2}", i + 1);
                m_oIniFile.WriteContentValueToIni(strSection, strAxis, sMotionCard.m_listOfAxisRes[i],
                    m_strPathOfSetMotionCard);
            }
        }

        /// <summary>
        ///     从ini文件的到设备信息
        /// </summary>
        /// <param name="sMotionCard"></param>
        public void GetMachineParaFromIni(ref STRUCT_MOTION_CARD sMotionCard)
        {
            var strSection = sMotionCard.m_strCardName + @"-" + sMotionCard.m_strCardNo;
            //获得最大轴数
            sMotionCard.m_strMaxAxisNum =
                m_oIniFile.ReadContentValueFromIni(strSection, @"MaxAxisNum", m_strPathOfSetMotionCard);
            //获得配置文件路径
            sMotionCard.m_strCfgPath =
                m_oIniFile.ReadContentValueFromIni(strSection, @"CfgPath", m_strPathOfSetMotionCard);

            var maxAxisNum = ConverToInt32(sMotionCard.m_strMaxAxisNum);
            for (var i = 0; i < maxAxisNum; i++)
            {
                var strAxis = string.Format(@"AxisRes-{0:D2}", i + 1);
                sMotionCard.m_listOfAxisRes[i] =
                    m_oIniFile.ReadContentValueFromIni(strSection, strAxis, m_strPathOfSetMotionCard);
            }
        }

        /// <summary>
        ///     设置点位ini文件
        /// </summary>
        /// <param name="strPosition">位置信息</param>
        /// <param name="sPosition">点位结构体</param>
        public void SetPositionToIni(string strPosition, STRUCT_POSITION sPosition)
        {
            m_oIniFile.WriteContentValueToIni(strPosition, "X", sPosition.m_strPositionX, m_strPathOfSetPosition);
            m_oIniFile.WriteContentValueToIni(strPosition, "Y", sPosition.m_strPositionY, m_strPathOfSetPosition);
            m_oIniFile.WriteContentValueToIni(strPosition, "Z", sPosition.m_strPositionZ, m_strPathOfSetPosition);
        }

        /// <summary>
        ///     得到点位信息
        /// </summary>
        /// <param name="strPosition">位置信息</param>
        /// <param name="sPosition">点位结构体</param>
        public void GetPositionFromIni(string strPosition, out STRUCT_POSITION sPosition)
        {
            sPosition.m_strPositionX = m_oIniFile.ReadContentValueFromIni(strPosition, "X", m_strPathOfSetPosition);
            sPosition.m_strPositionY = m_oIniFile.ReadContentValueFromIni(strPosition, "Y", m_strPathOfSetPosition);
            sPosition.m_strPositionZ = m_oIniFile.ReadContentValueFromIni(strPosition, "Z", m_strPathOfSetPosition);
        }

        /// <summary>
        ///     得到运动控制参数
        /// </summary>
        /// <param name="strSection">参数类型</param>
        /// <param name="strKey">字段类型</param>
        public double GetMotionParaFromIni(string strSection, string strKey)
        {
            var strValue = m_oIniFile.ReadContentValueFromIni(strSection, strKey, m_strPathOfSetPara);
            return Convert.ToDouble(strValue);
        }

        /// <summary>
        ///     获取ini中某一字段下的所有键名
        /// </summary>
        /// <param name="strSection">字段名</param>
        /// <param name="strPath">文件路径</param>
        /// <returns></returns>
        public List<string> GetIniAllKey(string strSection, string strPath)
        {
            var listKey = m_oIniFile.ReadKeys(strSection, strPath);
            return listKey;
        }

        /// <summary>
        ///     获取ini中所有字段名
        /// </summary>
        /// <param name="strPath">路径</param>
        /// <returns></returns>
        public List<string> GetIniAllSection(string strPath)
        {
            var listKey = m_oIniFile.ReadSections(strPath);
            return listKey;
        }

        /// <summary>
        ///     向日志文件里面写值
        /// </summary>
        /// <param name="strInfo">需要写的信息</param>
        /// <param name="bWarning">是否为报警日志</param>
        private void WriteLogToTst(string strInfo, bool bWarning)
        {
            m_oIniFile.WriteStrToTxt(bWarning ? m_strTxtPathOfWarningLog : m_strTxtPathOfOperationLog, strInfo);
        }

        #endregion

        #region 信息显示

        /// <summary>
        ///     显示并记录操作信息
        /// </summary>
        /// <param name="strInfo"></param>
        public void DisplayAndRecordOperationInfo(string strInfo)
        {
            if (m_eDisplayMsg != null) m_eDisplayMsg("Operation;" + strInfo);

            WriteLogToTst(m_strTxtPathOfOperationLog, false);
        }

        /// <summary>
        ///     显示并记录报警信息
        /// </summary>
        /// <param name="strWraningInfo"></param>
        public void DisplayAndRecordWarningInfo(string strWraningInfo)
        {
            if (m_eDisplayMsg != null) m_eDisplayMsg("Warning;" + strWraningInfo);

            WriteLogToTst(strWraningInfo, true);
        }

        #endregion

        #endregion

        #region 视觉通讯

        #region 自定义变量

        /// <summary>
        ///     TCP事件列表，用于和视觉交互
        /// </summary>
        public enum ENUM_TCP_EVENT
        {
            CAMERA_CALIBRATION_START,
            CAMERA_CALIBRATION_CAMERA,
            CAMERA_CALIBRATION_END,
            VALVE_CALIBRATION,
            TAKE_PHOTO
        }

        /// <summary>
        ///     m_strsOperationInfo数组变量的索引
        /// </summary>
        private enum ENUM_OPERATION_INFO_TYPE
        {
            SERVER_CONNECT,
            SERVER_DISCONNECT,
            STRING_SPLIT_OK,
            CALIBRATION_START,
            CALIBRATION,
            CALIBRATION_END,
            VALVE_CALIBRATION,
            PHOTOGRAPH
        }

        #endregion

        #region 成员变量

        /// <summary>
        ///     用于显示的操作信息
        /// </summary>
        private readonly string[] m_strsOperationInfo =
        {
            @"与服务器连接成功",
            @"与服务器断开连接",
            @"字符串处理完成",
            @"开始相机标定",
            @"相机标定",
            @"相机标定结束",
            @"手眼标定",
            @"拍照"
        };

        /// <summary>
        ///     TcpIp对象
        /// </summary>
        private CVisionAbs m_oVisionAbs;

        /// <summary>
        ///     用于给客户发消息的委托
        /// </summary>
        private DELEGATE_MSG m_delegateMsgVision; //视觉

        /// <summary>
        ///     保存视觉发送过来的二重点位链表
        /// </summary>
        private List<List<STRUCT_POSITION>> m_oListOfImagePosition = new List<List<STRUCT_POSITION>>();

        #endregion

        #region 成员函数

        /// <summary>
        ///     创建操作视觉的对象
        /// </summary>
        /// <param name="tCmtInfo"></param>
        public void CreatVision(STRUCT_CMT_INFO tCmtInfo)
        {
            var oCmtFactory = CreatCmtFactory(tCmtInfo);
            m_oVisionAbs = new CAnsonVision(oCmtFactory.Creat());
        }

        /// <summary>
        ///     连接视觉
        /// </summary>
        /// <returns></returns>
        public bool ConnectVision(DELEGATE_MSG fun)
        {
            var bRtn = m_oVisionAbs.InitVision(ReceiverVisionMsg);
            //把界面接收扫码枪消息的函数绑定委托
            if (bRtn) m_delegateMsgVision = fun;
            return bRtn;
        }

        /// <summary>
        ///     扫码枪从串口或者网口接收消息的回调函数
        /// </summary>
        /// <param name="strMsg"></param>
        private void ReceiverVisionMsg(string strMsg)
        {
            m_delegateMsgVision(strMsg);
        }

        /// <summary>
        ///     分解视觉返回来的字符串
        /// </summary>
        /// <param name="strMsg">视觉返回来的字符串</param>
        private void SplitMsgToPoint(string strMsg)
        {
            var strImage = strMsg.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            m_oListOfImagePosition.Clear();
            foreach (var str in strImage)
            {
                var listLine = new List<STRUCT_POSITION>();
                var strLine = str.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var strPoint in strLine)
                {
                    var strPosition = strPoint.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                    var sPoint = new STRUCT_POSITION {m_strPositionX = strPosition[0], m_strPositionY = strPosition[1]};
                    listLine.Add(sPoint);
                }

                m_oListOfImagePosition.Add(listLine);
            }

            DisplayAndRecordOperationInfo(m_strsOperationInfo[(int) ENUM_OPERATION_INFO_TYPE.STRING_SPLIT_OK]);
        }

        /// <summary>
        ///     断开视觉连接
        /// </summary>
        public void DisconnectVision()
        {
            m_oVisionAbs.Disconnect();
        }

        /// <summary>
        ///     发送消息给服务器
        /// </summary>
        /// <param name="uType">类型</param>
        public void SendMsgToServer(ENUM_TCP_EVENT uType)
        {
            try
            {
                switch (uType)
                {
                    case ENUM_TCP_EVENT.CAMERA_CALIBRATION_START:
                        m_oVisionAbs.SendMsgToVision("SC,1\r\n");
                        DisplayAndRecordOperationInfo(
                            m_strsOperationInfo[(int) ENUM_OPERATION_INFO_TYPE.CALIBRATION_START]);
                        break;
                    case ENUM_TCP_EVENT.CAMERA_CALIBRATION_CAMERA:
                        m_oVisionAbs.SendMsgToVision("C1\r\n");
                        DisplayAndRecordOperationInfo(m_strsOperationInfo[(int) ENUM_OPERATION_INFO_TYPE.CALIBRATION]);
                        break;
                    case ENUM_TCP_EVENT.CAMERA_CALIBRATION_END:
                        m_oVisionAbs.SendMsgToVision("EC,1\r\n");
                        DisplayAndRecordOperationInfo(
                            m_strsOperationInfo[(int) ENUM_OPERATION_INFO_TYPE.CALIBRATION_END]);
                        break;
                    case ENUM_TCP_EVENT.VALVE_CALIBRATION:
                        m_oVisionAbs.SendMsgToVision("Offset,1\r\n");
                        DisplayAndRecordOperationInfo(
                            m_strsOperationInfo[(int) ENUM_OPERATION_INFO_TYPE.VALVE_CALIBRATION]);
                        break;
                    case ENUM_TCP_EVENT.TAKE_PHOTO:
                        m_oVisionAbs.SendMsgToVision("T1,1\r\n");
                        DisplayAndRecordOperationInfo(m_strsOperationInfo[(int) ENUM_OPERATION_INFO_TYPE.PHOTOGRAPH]);
                        break;
                }
            }
            catch (Exception e)
            {
                var str = string.Format("{0}:发送信息失败，请检查服务器状态！", e.Message);
                MessageBox.Show(str);
                DisplayAndRecordWarningInfo(@"发送信息失败，请检查服务器状态！");
                Console.WriteLine(e.Message);
            }
        }

        #endregion

        #endregion

        #region 电子秤

        #region 成员变量

        /// <summary>
        ///     电子秤的抽象对象
        /// </summary>
        private CBalanceAbs m_oBalanceAbs;

        /// <summary>
        ///     用于给界面发消息的委托
        /// </summary>
        private DELEGATE_MSG m_delegateMsgBalance; //电子秤

        #endregion

        #region 成员函数

        /// <summary>
        ///     创造电子秤
        /// </summary>
        /// <param name="tCmtInfo"></param>
        public void CreatBalance(STRUCT_CMT_INFO tCmtInfo)
        {
            var oCmtFactory = CreatCmtFactory(tCmtInfo);
            m_oBalanceAbs = new CSartorius(oCmtFactory.Creat());
        }

        /// <summary>
        ///     连接电子秤
        /// </summary>
        /// <param name="fun">界面接收电子秤返回消息的函数</param>
        /// <returns></returns>
        public bool ConnectBalance(DELEGATE_MSG fun)
        {
            var bRtn = m_oBalanceAbs.InitBalance(ReceiverBalanceMsg);
            //把界面接收电子秤消息的函数绑定委托
            if (bRtn) m_delegateMsgBalance = fun;
            return bRtn;
        }

        /// <summary>
        ///     电子秤从串口或者网口接收到消息
        /// </summary>
        /// <param name="strMsg"></param>
        private void ReceiverBalanceMsg(string strMsg)
        {
            m_delegateMsgBalance(strMsg);
        }

        /// <summary>
        ///     触发电子秤
        /// </summary>
        /// <returns></returns>
        public bool TouchBalance()
        {
            bool bRtn;
            if (m_oBalanceAbs.IsOpen())
            {
                bRtn = m_oBalanceAbs.Touch();
            }
            else
            {
                MessageBox.Show(@"电子秤未打开，请确认打开后再操作！");
                DisplayAndRecordWarningInfo(@"电子秤未打开，请确认打开后再操作！");
                bRtn = false;
            }

            return bRtn;
        }

        /// <summary>
        ///     重启电子秤
        /// </summary>
        /// <returns></returns>
        public bool RestartBalance()
        {
            bool bRtn;
            if (m_oBalanceAbs.IsOpen())
            {
                bRtn = m_oBalanceAbs.Restart();
            }
            else
            {
                MessageBox.Show(@"电子秤未打开，请确认打开后再操作！");
                DisplayAndRecordWarningInfo(@"电子秤未打开，请确认打开后再操作！");
                bRtn = false;
            }

            return bRtn;
        }

        /// <summary>
        ///     清零电子秤
        /// </summary>
        /// <returns></returns>
        public bool ZeroBalance()
        {
            bool bRtn;
            if (m_oBalanceAbs.IsOpen())
            {
                bRtn = m_oBalanceAbs.Reset();
            }
            else
            {
                MessageBox.Show(@"电子秤未打开，请确认打开后再操作！");
                DisplayAndRecordWarningInfo(@"电子秤未打开，请确认打开后再操作！");
                bRtn = false;
            }

            return bRtn;
        }

        #endregion

        #endregion

        #region 扫码枪

        #region 成员变量

        /// <summary>
        ///     扫码枪抽象类
        /// </summary>
        private CScannerGunAbs m_oScannerAbs;

        /// <summary>
        ///     用于给客户发消息的委托
        /// </summary>
        private DELEGATE_MSG m_delegateMsgScanner; //扫描枪

        #endregion

        #region 成员函数

        /// <summary>
        ///     创造扫码枪
        /// </summary>
        /// <param name="tCmtInfo"></param>
        public void CreatScanner(STRUCT_CMT_INFO tCmtInfo)
        {
            var oCmtFactory = CreatCmtFactory(tCmtInfo);
            m_oScannerAbs = new CCognexScanner(oCmtFactory.Creat());
        }

        /// <summary>
        ///     连接扫码枪
        /// </summary>
        /// <param name="fun">界面用于接收扫码枪返回消息的函数</param>
        /// <returns></returns>
        public bool ConnectScanner(DELEGATE_MSG fun)
        {
            var bRtn = m_oScannerAbs.InitScannerGun(ReceiverScannerMsg);
            //把界面接收扫码枪消息的函数绑定委托
            if (bRtn) m_delegateMsgScanner = fun;
            return bRtn;
        }

        /// <summary>
        ///     扫码枪从串口或者网口接收消息的回调函数
        /// </summary>
        /// <param name="strMsg"></param>
        private void ReceiverScannerMsg(string strMsg)
        {
            m_delegateMsgScanner(strMsg);
        }

        /// <summary>
        ///     触发扫码枪
        /// </summary>
        /// <returns></returns>
        public bool TouchScanner()
        {
            bool bRtn;
            if (m_oScannerAbs.IsOpen())
            {
                bRtn = m_oScannerAbs.Touch();
            }
            else
            {
                MessageBox.Show(@"扫码枪未打开，请确认打开后再操作！");
                DisplayAndRecordWarningInfo(@"扫码枪未打开，请确认打开后再操作！");
                bRtn = false;
            }

            return bRtn;
        }

        #endregion

        #endregion

        #region 点胶线程

        #endregion

        #region 拍照线程

        #endregion

        #region 单例

        /// <summary>
        ///     单例对象
        /// </summary>
        private static CKernel s_motionKernel;

        /// <summary>
        ///     锁
        /// </summary>
        private static object s_lock = new object();

        /// <summary>
        ///     创造通讯抽象类工厂
        /// </summary>
        /// <param name="tCmtInfo"></param>
        /// <returns></returns>
        private CCmtFactoryAbs CreatCmtFactory(STRUCT_CMT_INFO tCmtInfo)
        {
            CCmtFactoryAbs oCmtFactory = null;
            switch (tCmtInfo.m_nType)
            {
                case 0:
                    //电子秤通讯使用的是串口
                    oCmtFactory = new CSerialPortFactory(tCmtInfo.m_strSerialPortNum, tCmtInfo.m_nSerialBaudRate,
                        tCmtInfo.m_nSerialDateBits,
                        tCmtInfo.m_strSerialParity, tCmtInfo.m_strSerialStopBits);
                    break;
                case 1:
                    oCmtFactory = new CTcpClientFactory(tCmtInfo.m_strStcpAddress, tCmtInfo.m_nStcpPort);
                    break;
            }

            return oCmtFactory;
        }

        /// <summary>
        ///     保存通讯参数到Ini
        /// </summary>
        /// <param name="strEquipment"></param>
        /// <param name="tCmtInfo"></param>
        public void SaveCmtParaToIni(string strEquipment, STRUCT_CMT_INFO tCmtInfo)
        {
            m_oIniFile.WriteContentValueToIni(strEquipment, @"Type", tCmtInfo.m_nType.ToString(),
                m_strCmtIniPath);
            switch (tCmtInfo.m_nType)
            {
                case 0:
                    m_oIniFile.WriteContentValueToIni(strEquipment, @"COM", tCmtInfo.m_strSerialPortNum,
                        m_strCmtIniPath);
                    m_oIniFile.WriteContentValueToIni(strEquipment, @"Baud", tCmtInfo.m_nSerialBaudRate.ToString(),
                        m_strCmtIniPath);
                    m_oIniFile.WriteContentValueToIni(strEquipment, @"Date", tCmtInfo.m_nSerialDateBits.ToString(),
                        m_strCmtIniPath);
                    m_oIniFile.WriteContentValueToIni(strEquipment, @"Stop", tCmtInfo.m_strSerialStopBits,
                        m_strCmtIniPath);
                    m_oIniFile.WriteContentValueToIni(strEquipment, @"Parity", tCmtInfo.m_strSerialParity,
                        m_strCmtIniPath);
                    break;
                case 1:
                    m_oIniFile.WriteContentValueToIni(strEquipment, @"Address", tCmtInfo.m_strStcpAddress,
                        m_strCmtIniPath);
                    m_oIniFile.WriteContentValueToIni(strEquipment, @"Port", tCmtInfo.m_nStcpPort.ToString(),
                        m_strCmtIniPath);
                    break;
            }
        }

        /// <summary>
        ///     得到通讯参数
        /// </summary>
        /// <param name="strEquipment"></param>
        /// <returns></returns>
        public STRUCT_CMT_INFO GetCmtPara(string strEquipment)
        {
            var tCmtInfo = new STRUCT_CMT_INFO
            {
                m_nType = ConverToInt32(m_oIniFile.ReadContentValueFromIni(strEquipment, "Type", m_strCmtIniPath))
            };
            switch (tCmtInfo.m_nType)
            {
                case 0:
                    tCmtInfo.m_nSerialBaudRate =
                        ConverToInt32(m_oIniFile.ReadContentValueFromIni(strEquipment, "Baud", m_strCmtIniPath));
                    tCmtInfo.m_nSerialDateBits =
                        ConverToInt32(m_oIniFile.ReadContentValueFromIni(strEquipment, "Date", m_strCmtIniPath));
                    tCmtInfo.m_strSerialParity =
                        m_oIniFile.ReadContentValueFromIni(strEquipment, "Parity", m_strCmtIniPath);
                    tCmtInfo.m_strSerialPortNum =
                        m_oIniFile.ReadContentValueFromIni(strEquipment, "COM", m_strCmtIniPath);
                    tCmtInfo.m_strSerialStopBits =
                        m_oIniFile.ReadContentValueFromIni(strEquipment, "Stop", m_strCmtIniPath);
                    break;
                case 1:
                    tCmtInfo.m_nStcpPort =
                        Convert.ToInt32(m_oIniFile.ReadContentValueFromIni(strEquipment, "Port", m_strCmtIniPath));

                    tCmtInfo.m_strStcpAddress =
                        m_oIniFile.ReadContentValueFromIni(strEquipment, "Address", m_strCmtIniPath);
                    break;
            }

            return tCmtInfo;
        }

        /// <summary>
        ///     构造函数
        /// </summary>
        private CKernel()
        {
            InitFile();
            InitMotion();
        }

        ~CKernel()
        {
            if (m_oVisionAbs != null)
                m_oVisionAbs.Disconnect();

            if (m_oBalanceAbs != null)
                m_oBalanceAbs.Disconnect();

            if (m_oScannerAbs != null)
                m_oScannerAbs.Disconnect();


            //m_oBalanceAbs.Disconnect();
        }

        /// <summary>
        ///     延时函数
        /// </summary>
        /// <param name="milliSecond">毫秒</param>
        public static void Delay(int milliSecond)
        {
            var start = Environment.TickCount;
            var iValue = Math.Abs(Environment.TickCount - start);
            while (iValue < milliSecond) //毫秒
                iValue = Math.Abs(Environment.TickCount - start);
        }

        /// <summary>
        ///     得到对应卡号的单例对象
        /// </summary>
        /// <returns></returns>
        public static CKernel GetInstance()
        {
            if (s_motionKernel != null) return s_motionKernel;
            lock (s_lock)
            {
                if (s_motionKernel == null)
                    s_motionKernel = new CKernel();
                return s_motionKernel;
            }
        }

        /// <summary>
        ///     string 转化到Int32
        /// </summary>
        /// <param name="strInt32"></param>
        /// <returns></returns>
        private int ConverToInt32(string strInt32)
        {
            var iRtn = strInt32 == "" ? 0 : Convert.ToInt32(strInt32);
            return iRtn;
        }

        #endregion
    }
}