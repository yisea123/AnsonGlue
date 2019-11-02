using AnsonGlue.Tool.Communication.AbstractClass;
using AnsonGlue.Tool.Communication.ConcreteClass;
using AnsonGlue.Tool.Communication.Factory.AbstractClass;

namespace AnsonGlue.Tool.Communication.Factory.ConcreteClass
{
    public class CSerialPortFactory : CCmtFactoryAbs
    {
        private string m_strSerialPort;
        private int m_nSerialBaudRate;
        private int m_nSerialDateBits;
        private string m_strSerialParity;
        private string m_strSerialStopBits;

        /// <summary>
        /// 串口类工厂构造函数
        /// </summary>
        /// <param name="strPortName">串口号</param>
        /// <param name="nSerialBaudRate">波特率</param>
        /// <param name="nSerialDateBits">数据位</param>
        /// <param name="strSerialParity">串口校验位</param>
        /// <param name="strSerialStopBits">停止位</param>
        public CSerialPortFactory(string strPortName, int nSerialBaudRate, int nSerialDateBits, string strSerialParity, string strSerialStopBits)
        {
            m_strSerialPort = strPortName;
            m_nSerialBaudRate = nSerialBaudRate;
            m_nSerialDateBits = nSerialDateBits;
            m_strSerialParity = strSerialParity;
            m_strSerialStopBits = strSerialStopBits;
        }

        public override CCmtAbs Creat()
        {
            //实例化串口类
            CCmtAbs cmtAbs = new CCmtSerialPort(m_strSerialPort, m_nSerialBaudRate, m_nSerialDateBits, m_strSerialParity, m_strSerialStopBits);
            return cmtAbs;
        }
    }
}
