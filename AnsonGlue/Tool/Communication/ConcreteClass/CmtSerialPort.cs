using System;
using System.IO.Ports;
using System.Text;
using AnsonGlue.Tool.Communication.AbstractClass;

namespace AnsonGlue.Tool.Communication.ConcreteClass
{
    public class CCmtSerialPort:CCmtAbs
    {
        private string m_strSerialPort;
        private int m_nSerialBaudRate;
        private int m_nSerialDateBits;
        private string m_strSerialParity;
        private string m_strSerialStopBits;

        /// <summary>
        /// 声明一个串口
        /// </summary>
        private SerialPort m_serialPort;

        public CCmtSerialPort(string strPortName, int nSerialBaudRate, int nSerialDateBits, string strSerialParity, string strSerialStopBits)
        {
            m_strSerialPort = strPortName;
            m_nSerialBaudRate = nSerialBaudRate;
            m_nSerialDateBits = nSerialDateBits;
            m_strSerialParity = strSerialParity;
            m_strSerialStopBits = strSerialStopBits;
        }

        /// <summary>
        ///     断开通讯连接
        /// </summary>
        public override void Disconnect()
        {
            try
            {
                if (m_serialPort.IsOpen)  //判断串口是否已经被打开
                {
                    m_serialPort.Close(); //关闭串口
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }


        /// <summary>
        ///     初始化通讯
        /// </summary>
        /// <returns>是否初始化成功</returns>
        public override bool InitCmt()
        {
            try
            {
                m_serialPort = new SerialPort();       //实例化一个串行端口

                if (m_serialPort.IsOpen)              //例行判断一下
                {
                    m_serialPort.Close();
                }

                //波特率
                m_serialPort.BaudRate = m_nSerialBaudRate;
                //数据位
                m_serialPort.DataBits = m_nSerialDateBits;
                //停止位
                switch (m_strSerialStopBits)
                {
                    case "None":
                        m_serialPort.StopBits = StopBits.None;
                        break;
                    case "One":
                        m_serialPort.StopBits = StopBits.One;
                        break;
                    case "Two":
                        m_serialPort.StopBits = StopBits.Two;
                        break;
                    case "OnePointFive":
                        m_serialPort.StopBits = StopBits.OnePointFive;
                        break;
                }
                //校验位
                switch (m_strSerialParity)
                {
                    case "None":
                        m_serialPort.Parity = Parity.None;
                        break;
                    case "Odd":
                        m_serialPort.Parity = Parity.Odd;
                        break;
                    case "Even":
                        m_serialPort.Parity = Parity.Even;
                        break;
                    case "Mark":
                        m_serialPort.Parity = Parity.Mark;
                        break;
                    case "Space":
                        m_serialPort.Parity = Parity.Space;
                        break;
                }
                //串口号
                m_serialPort.PortName = m_strSerialPort;
               
                m_serialPort.DataReceived += ReceiveThreadFun;

                if (!m_serialPort.IsOpen)
                {
                    m_serialPort.Open();
                }
                return true;
            }
            catch (Exception )
            {
                return false;

            }

        }

        /// <summary>
        ///     发送消息
        /// </summary>
        /// <param name="msg">内容</param>
        /// <param name="address">地址,服务器发送时用</param>
        /// <returns>发送的字节数，负数说明发送失败</returns>
        public override int Send(string msg, string address = "")
        {
            try
            {
                if (m_serialPort.IsOpen)
                {
                    m_serialPort.Write(msg);
                }
                return msg.Length;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// 接收串口消息的线程函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ReceiveThreadFun(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //Comm.BytesToRead中为要读入的字节长度
                int len = m_serialPort.BytesToRead;
                Byte[] readBuffer = new Byte[len];
                m_serialPort.Read(readBuffer, 0, len); //将数据读入缓存
                //处理readBuffer中的数据，自定义处理过程
                string strMsg = Encoding.ASCII.GetString(readBuffer, 0, len);
                m_strCmtMsg = strMsg;//回调的数据
                Msg();//使用回调
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
