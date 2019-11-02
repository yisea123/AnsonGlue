using AnsonGlue.Tool.Communication.AbstractClass;
using AnsonGlue.Tool.Communication.ConcreteClass;
using AnsonGlue.Tool.Communication.Factory.AbstractClass;

namespace AnsonGlue.Tool.Communication.Factory.ConcreteClass
{
    public class CTcpClientFactory : CCmtFactoryAbs
    {
        private string m_strStcpAddress;
        private int m_nStcpPort;
        public CTcpClientFactory(string strStcpAddress, int nStcpPort)
        {
           m_strStcpAddress = strStcpAddress;
           m_nStcpPort = nStcpPort;
        }

        public override CCmtAbs Creat()
        {
            //实例化tcp的Client类
            CCmtAbs cmtAbs = new CCmtTcpClient(m_strStcpAddress, m_nStcpPort);
            return cmtAbs;
        }
    }
}
