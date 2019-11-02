using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using AnsonGlue.Tool;

namespace AnsonGlue.Kernel
{
    #region 自定义类型

    /// <summary>
    ///     TCP事件列表，用于和视觉交互
    /// </summary>
    public enum TCP_EVENT
    {
        CAMERA_CALIBRATION_START,
        CAMERA_CALIBRATION_CAMERA,
        CAMERA_CALIBRATION_END,
        VALVE_CALIBRATION,
        TAKE_PHOTO
    }

    public enum PARAMETER_TYPE
    {
        VELOCITY,
        POSITION,
        ACCELERATION,
        DIRECTION
    }

    public enum DIRECTION_TYPE
    {
        EXCEL,
        IMAGE
    }

    public enum VELOCITY_TYPE
    {
        JOG,
        GLUE,
        CAMERA
    }

    public enum POSITION_TYPE
    {
        PHOTO_SPACE,
        Z_SAVE
    }


    public enum OPERATION_INFO_TYPE
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

    public struct STRUCT_POSITION
    {
        public string strX;
        public string strY;
        public string strZ;

        public STRUCT_POSITION(string strX, string strY, string strZ)
            : this()
        {
            this.strX = strX;
            this.strY = strY;
            this.strZ = strZ;
        }
    }

    /// <summary>
    /// 运动控制板卡设置参数结构体
    /// </summary>
    public struct STRUCT_MOTION_CARD
    {
        public string strName;
        public string strCardNo;
        public string strMaxNum;
        public string strCfgPath;
        public List<string> m_listAxisRes;

        public STRUCT_MOTION_CARD(string strName, string strCardNo, string strMaxNum, List<string> listAxisRes)
            : this()
        {
            this.strName = strName;
            this.strCardNo = strCardNo;
            this.strMaxNum = strMaxNum;
            m_listAxisRes = listAxisRes;
        }
    }

    #endregion


    internal class CFileTcp
    {
        #region 成员变量

        /// <summary>
        ///     单例对象
        /// </summary>
        private static CFileTcp _FILE_TCP;

        private static object _LOCK = new object();

        /// <summary>
        ///     路径名数组
        /// </summary>
        private readonly string[] m_strPath = {"Excel", "Image"};

        /// <summary>
        ///     参数类型数组
        /// </summary>
        private readonly string[] m_strParameter = {"Velocity", "Position", "Acceleration", "Path"};

        /// <summary>
        ///     字节名数组
        /// </summary>
        private readonly string[,] m_strSection =
        {
            {"Jog", "Glue", "PhotoGraph"},
            {"PhotoSpace", "ZSave", ""},
            {"", "Jog", "Glue"}
        };

        /// <summary>
        ///     用于显示的操作信息
        /// </summary>
        private readonly string[] m_strOperationInfo =
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
        private readonly CTcpIpClient m_tClient;

        /// <summary>
        ///     读写Ini对象
        /// </summary>
        private readonly CIniFile m_tIniFile;

        /// <summary>
        ///     保存视觉发送过来的二重点位链表
        /// </summary>
        private List<List<STRUCT_POSITION>> m_listImage = new List<List<STRUCT_POSITION>>();

        #endregion

        #region CKernel

        /// <summary>
        ///     构造函数
        /// </summary>
        private CFileTcp()
        {
            m_tIniFile = new CIniFile();
            m_tClient = new CTcpIpClient();


            //设置ini文件路径
            var strSystemPath = AppDomain.CurrentDomain.BaseDirectory;
            m_strSettingPath = strSystemPath + @"Setting.ini";
            m_strPositionPath = strSystemPath + @"Position.ini";
            m_strMotionCardSettingPath = strSystemPath + @"MotionCard.ini";

            var strWarning = string.Format(@"WarningLog{0:D4}{1:D2}{2:D2}.txt", DateTime.Now.ToLocalTime().Year,
                DateTime.Now.ToLocalTime().Month, DateTime.Now.ToLocalTime().Day);
            m_strWarningLogTxtPath = strSystemPath + strWarning;

            var strOperation = string.Format(@"OperationLog{0:D4}{1:D2}{2:D2}.txt", DateTime.Now.ToLocalTime().Year,
                DateTime.Now.ToLocalTime().Month, DateTime.Now.ToLocalTime().Day);

            m_strOperationLogTxtPath = strSystemPath + strOperation;
        }


        /// <summary>
        ///     析构函数
        /// </summary>
        ~CFileTcp()
        {
            m_tClient.CloseSocket();
        }

        /// <summary>
        ///     得到单例对象
        /// </summary>
        /// <returns></returns>
        public static CFileTcp GetInstance()
        {
            if (_FILE_TCP != null) return _FILE_TCP;
            lock (_LOCK)
            {
                if (_FILE_TCP == null)
                    _FILE_TCP = new CFileTcp();
                return _FILE_TCP;
            }
        }

        /// <summary>
        ///     初始化硬件
        /// </summary>
        /// <returns></returns>
        public void ConnectTcp()
        {
            //连接服务器
            var nRtn = ConnectServer();
            if (nRtn != 0) MessageBox.Show(@"连接服务器失败，检查服务器状态！");
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

        #endregion

        #region 报警显示

        /// <summary>
        ///     用于显示报警的委托
        /// </summary>
        /// <param name="strMsg"></param>
        public delegate void DISPLAY_WARNING_MSG(string strMsg);

        /// <summary>
        ///     用于显示报警信息
        /// </summary>
        public event DISPLAY_WARNING_MSG m_eDisplayWarningMsg;

        public void DisplayOperationInfo(string strInfo)
        {
            if (m_eDisplayOperationMsg != null) m_eDisplayOperationMsg(strInfo);
            WriteLogToTst(m_strOperationLogTxtPath, false);
        }

        public void DisplayWarningInfo(string  strWraningInfo)
        {
            if (m_eDisplayWarningMsg != null) m_eDisplayWarningMsg(strWraningInfo);
            WriteLogToTst(strWraningInfo, true);
        }

        #endregion

        #region 操作信息显示

        /// <summary>
        ///     用于显示报警的委托
        /// </summary>
        /// <param name="strMsg"></param>
        public delegate void DISPLAY_OPERATION_MSG(string strMsg);

        /// <summary>
        ///     用于显示报警信息
        /// </summary>
        public event DISPLAY_OPERATION_MSG m_eDisplayOperationMsg;

        #endregion

        #region 操作ini&Txt文件读写

        /// <summary>
        ///     点位设置ini路径
        /// </summary>
        private string m_strPositionPath;

        /// <summary>
        ///     设置参数ini路径
        /// </summary>
        private string m_strSettingPath;

        /// <summary>
        ///     运动控制板卡设置参数ini路径
        /// </summary>
        private string m_strMotionCardSettingPath;

        /// <summary>
        ///     日志Txt文件路径
        /// </summary>
        private string m_strWarningLogTxtPath;

        private string m_strOperationLogTxtPath;


        /// <summary>
        ///     得到保存图片的文件夹路径
        /// </summary>
        /// <param name="nType">类型</param>
        /// <param name="strPath">路径</param>
        public void GetExcelImageDirFromIni(short nType, out string strPath)
        {
            strPath = m_tIniFile.ReadContentValueFromIni(m_strParameter[(int) PARAMETER_TYPE.DIRECTION],
                m_strPath[nType], m_strSettingPath);
        }

        /// <summary>
        ///     设置表格保存的路径
        /// </summary>
        /// <param name="nType">类型</param>
        /// <param name="strPath">路径</param>
        public void SetExcelImageDirToIni(short nType, string strPath)
        {
            m_tIniFile.WriteContentValueToIni(m_strParameter[(int) PARAMETER_TYPE.DIRECTION], m_strPath[nType], strPath,
                m_strSettingPath);
        }

        /// <summary>
        ///     得到视觉Ip地址和Port号
        /// </summary>
        /// <param name="strIp">Ip地址</param>
        /// <param name="strPort">端口号</param>
        public void GetVisionIpPortFromIni(out string strIp, out string strPort)
        {
            strIp = m_tIniFile.ReadContentValueFromIni("Vision", "Address", m_strSettingPath);
            strPort = m_tIniFile.ReadContentValueFromIni("Vision", "Port", m_strSettingPath);
        }

        /// <summary>
        ///     设置视觉Ip地址和Port号
        /// </summary>
        /// <param name="strIp">Ip地址</param>
        /// <param name="strPort">端口号</param>
        public void SetVisionIpPortToIni(string strIp, string strPort)
        {
            m_tIniFile.WriteContentValueToIni("Vision", "Address", strIp, m_strSettingPath);
            m_tIniFile.WriteContentValueToIni("Vision", "Port", strPort, m_strSettingPath);
            if (m_eDisplayOperationMsg != null) m_eDisplayOperationMsg(@"设置视觉的Ip和Port");
        }

        /// <summary>
        ///     设置参数到Ini文件
        /// </summary>
        /// <param name="uParaType">参数类型</param>
        /// <param name="uType">字节类型</param>
        /// <param name="strValue">速度</param>
        public void SetParameterToIni(ushort uParaType, ushort uType, string strValue)
        {
            m_tIniFile.WriteContentValueToIni(m_strParameter[uParaType], m_strSection[uParaType, uType], strValue,
                m_strSettingPath);
        }

        /// <summary>
        /// 设置设备参数到ini文件
        /// </summary>
        /// <param name="sMotionCard">参数结构体</param>
        public void SetMachineParaToIni(STRUCT_MOTION_CARD sMotionCard)
        {
            string strSection = sMotionCard.strName +@"-"+sMotionCard.strCardNo;
            m_tIniFile.WriteContentValueToIni(strSection, @"MaxAxisNum", sMotionCard.strMaxNum, m_strMotionCardSettingPath);
            m_tIniFile.WriteContentValueToIni(strSection, @"CfgPath", sMotionCard.strCfgPath, m_strMotionCardSettingPath);

            for (int i = 0; i < sMotionCard.m_listAxisRes.Count; i++)
            {
                string strAxis = string.Format(@"AxisRes-{0:D2}" ,i+1 );
                m_tIniFile.WriteContentValueToIni(strSection, strAxis, sMotionCard.m_listAxisRes[i], m_strMotionCardSettingPath);
            }
        }

        /// <summary>
        /// 从ini文件的到设备信息
        /// </summary>
        /// <param name="sMotionCard"></param>
        public void GetMachineParaFromIni(ref STRUCT_MOTION_CARD sMotionCard)
        {
            string strSection = sMotionCard.strName +@"-"+sMotionCard.strCardNo;
            sMotionCard.strMaxNum = m_tIniFile.ReadContentValueFromIni(strSection, @"MaxAxisNum", m_strMotionCardSettingPath);
            sMotionCard.strCfgPath = m_tIniFile.ReadContentValueFromIni(strSection, @"CfgPath", m_strMotionCardSettingPath);
            for (int i = 0; i < sMotionCard.m_listAxisRes.Count; i++)
            {
                string strAxis = string.Format(@"AxisRes-{0:D2}", i + 1);
                sMotionCard.m_listAxisRes[i] = m_tIniFile.ReadContentValueFromIni(strSection, strAxis, m_strMotionCardSettingPath);
            }
        }

        /// <summary>
        ///     从Ini文件得到点胶参数
        /// </summary>
        /// <param name="uParaType">参数类型</param>
        /// <param name="uType">索引</param>
        /// <param name="strValue">值</param>
        public void GetParameterFromIni(ushort uParaType, ushort uType, out string strValue)
        {
            strValue = m_tIniFile.ReadContentValueFromIni(m_strParameter[uParaType], m_strSection[uParaType, uType],
                m_strSettingPath);
        }

        /// <summary>
        ///     设置点位ini文件
        /// </summary>
        /// <param name="strPosition">位置信息</param>
        /// <param name="sPosition">点位结构体</param>
        public void SetPositionToIni(string strPosition, STRUCT_POSITION sPosition)
        {
            m_tIniFile.WriteContentValueToIni(strPosition, "X", sPosition.strX, m_strPositionPath);
            m_tIniFile.WriteContentValueToIni(strPosition, "Y", sPosition.strY, m_strPositionPath);
            m_tIniFile.WriteContentValueToIni(strPosition, "Z", sPosition.strZ, m_strPositionPath);
        }

        /// <summary>
        ///     得到点位信息
        /// </summary>
        /// <param name="strPosition">位置信息</param>
        /// <param name="sPosition">点位结构体</param>
        public void GetPositionFromIni(string strPosition, out STRUCT_POSITION sPosition)
        {
            sPosition.strX = m_tIniFile.ReadContentValueFromIni(strPosition, "X", m_strPositionPath);
            sPosition.strY = m_tIniFile.ReadContentValueFromIni(strPosition, "Y", m_strPositionPath);
            sPosition.strZ = m_tIniFile.ReadContentValueFromIni(strPosition, "Z", m_strPositionPath);
        }

        /// <summary>
        ///     得到运动控制参数
        /// </summary>
        /// <param name="uParaType">参数类型</param>
        /// <param name="uType">字段类型</param>
        /// <param name="dValue">值</param>
        public void GetMotionPara(ushort uParaType, ushort uType, out double dValue)
        {
            var strValue = m_tIniFile.ReadContentValueFromIni(m_strParameter[uParaType], m_strSection[uParaType, uType],
                m_strSettingPath);
            dValue = Convert.ToDouble(strValue);
        }

        /// <summary>
        ///     向日志文件里面写值
        /// </summary>
        /// <param name="strInfo">需要写的信息</param>
        /// <param name="bWarning">是否为报警日志</param>
        public void WriteLogToTst(string strInfo, bool bWarning)
        {
            m_tIniFile.WriteStrToTxt(bWarning ? m_strWarningLogTxtPath : m_strOperationLogTxtPath, strInfo);
        }

        #endregion

        #region 操作Tcp通讯视觉

        /// <summary>
        ///     连接到服务器
        /// </summary>
        /// <returns></returns>
        public short ConnectServer()
        {
            try
            {
                string strAddress, strPort;
                GetVisionIpPortFromIni(out strAddress, out strPort);
                var sRtn = m_tClient.ClientConnect(strAddress, Convert.ToInt32(strPort));
                if (sRtn == 0) StartTcpListeningThread();
                return sRtn;
            }
            catch (Exception)
            {
                DisplayWarningInfo(@"服务器连接失败，请检查服务器连接状态！");
                //Console.WriteLine(e.Message);
                return -1;
            }
        }

        public void DisconnectServer()
        {
            m_tClient.CloseSocket();
        }

        /// <summary>
        ///     开始Tcp监听线程
        /// </summary>
        /// <returns></returns>
        private void StartTcpListeningThread()
        {
            var tListening = new Thread(ThreadTcpListening) {IsBackground = true};
            tListening.Start();
            if (m_eDisplayOperationMsg != null)
                m_eDisplayOperationMsg(m_strOperationInfo[(int) OPERATION_INFO_TYPE.SERVER_CONNECT]);
        }

        private void ThreadTcpListening()
        {
            while (true)
            {
                string strMsg;
                var iLenght = m_tClient.ReceiveMsg(out strMsg);
                if (iLenght <= 0)
                {
                    Debug.WriteLine(@"接受数据失败，检查客户端是否连接后重新连接");
                    m_tClient.CloseSocket();
                    DisplayWarningInfo(@"接受数据失败，检查客户端是否连接后重新连接");
                    return;
                }

                #region 判断返回类型

                if (strMsg.Remove(2) == @"T1")
                    if (strMsg.Replace("T1,", string.Empty).Remove(1) == @"1")
                        SplitMsgToPoint(strMsg.Replace(@"T1,1,", string.Empty));

                #endregion

                DisplayOperationInfo(strMsg);
            }
        }

        private void SplitMsgToPoint(string strMsg)
        {
            var strImage = strMsg.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            m_listImage.Clear();
            foreach (var str in strImage)
            {
                var listLine = new List<STRUCT_POSITION>();
                var strLine = str.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var strPoint in strLine)
                {
                    var strPosition = strPoint.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                    var sPoint = new STRUCT_POSITION {strX = strPosition[0], strY = strPosition[1]};
                    listLine.Add(sPoint);
                }

                m_listImage.Add(listLine);
            }

            if (m_eDisplayOperationMsg != null)
                m_eDisplayOperationMsg(m_strOperationInfo[(int) OPERATION_INFO_TYPE.STRING_SPLIT_OK]);
        }

        /// <summary>
        ///     发送消息给服务器
        /// </summary>
        /// <param name="uType">类型</param>
        public void SendMsgToServer(TCP_EVENT uType)
        {
            try
            {
                switch (uType)
                {
                    case TCP_EVENT.CAMERA_CALIBRATION_START:
                        m_tClient.SendMsg("SC,1\r\n");
                        DisplayOperationInfo(m_strOperationInfo[(int) OPERATION_INFO_TYPE.CALIBRATION_START]);
                        break;
                    case TCP_EVENT.CAMERA_CALIBRATION_CAMERA:
                        m_tClient.SendMsg("C1\r\n");
                        DisplayOperationInfo(m_strOperationInfo[(int) OPERATION_INFO_TYPE.CALIBRATION]);
                        break;
                    case TCP_EVENT.CAMERA_CALIBRATION_END:
                        m_tClient.SendMsg("EC,1\r\n");
                        DisplayOperationInfo(m_strOperationInfo[(int) OPERATION_INFO_TYPE.CALIBRATION_END]);
                        break;
                    case TCP_EVENT.VALVE_CALIBRATION:
                        m_tClient.SendMsg("Offset,1\r\n");
                        DisplayOperationInfo(m_strOperationInfo[(int) OPERATION_INFO_TYPE.VALVE_CALIBRATION]);
                        break;
                    case TCP_EVENT.TAKE_PHOTO:
                        m_tClient.SendMsg("T1,1\r\n");
                        DisplayOperationInfo(m_strOperationInfo[(int) OPERATION_INFO_TYPE.PHOTOGRAPH]);
                        break;
                }
            }
            catch (Exception e)
            {
                var str = string.Format("{0}:发送信息失败，请检查服务器状态！", e.Message);
                MessageBox.Show(str);
                DisplayWarningInfo(@"发送信息失败，请检查服务器状态！");
                Console.WriteLine(e.Message);
            }
        }

        #endregion
    }
}