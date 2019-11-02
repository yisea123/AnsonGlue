using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using AnsonGlue.Tool.Communication.AbstractClass;

namespace AnsonGlue.Tool.Communication.ConcreteClass
{
    public class CCmtTcpClient : CCmtAbs
    {
        /// <summary>
        ///     socket号
        /// </summary>
        private Socket m_sockeClient;

        private string m_strStcpAddress;
        private int m_nStcpPort;

        public CCmtTcpClient(string strStcpAddress, int nStcpPort)
        {
            m_strStcpAddress = strStcpAddress;
            m_nStcpPort = nStcpPort;
            m_sockeClient = null;
        }

        /// <summary>
        ///     断开通讯连接
        /// </summary>
        public override void Disconnect()
        {
            if (m_sockeClient!=null)
            {
                m_sockeClient.Dispose();
                m_sockeClient.Close();
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
                //创建一个客户端socket号
                m_sockeClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //获得服务器的地址
                var ip2 = IPAddress.Parse(m_strStcpAddress);
                //获得服务器的端口号
                var point = new IPEndPoint(ip2, m_nStcpPort);
                //连接服务器
                m_sockeClient.Connect(point);
                //前面没异常，开始监听线程
                var th = new Thread(ReceiveThreadFun) {IsBackground = true};
                th.Start(m_sockeClient);
                return true;
            }
            catch (Exception)
            {
                return false; //有异常，返回false
            }
        }

        /// <summary>
        ///     tcp监听消息线程
        /// </summary>
        /// <param name="o"></param>
        private void ReceiveThreadFun(object o)
        {
            //所监听的socket号
            var socketsend = o as Socket;

            while (true) //循环，在服务端断开和异常时退出
                try
                {
                    var buffer = new byte[1024 * 1024 * 2];

                    //等待获取客户端发送过来的信息
                    if (socketsend != null)
                    {
                        var r = socketsend.Receive(buffer);
                        if (r == 0) //为空时说明服务器断开连接
                        {
                            m_strCmtMsg = @"Server Disconnect";
                            Msg(); //回调触发，发送"Server Disconnect"
                            Disconnect();
                            return;
                        }

                        var strMsg = Encoding.UTF8.GetString(buffer, 0, r);
                        m_strCmtMsg = strMsg; //回调函数发送的内容
                        Msg(); //回调触发
                    }
                }
                catch (Exception)
                {
                    m_strCmtMsg = @"Server Exception";
                    Msg(); //回调触发一下，发送"Server Exception"
                    return;
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
                var buffer = Encoding.UTF8.GetBytes(msg);
                var nRtn = m_sockeClient.Send(buffer);
                return nRtn;
            }
            catch (Exception)
            {
                // ignored
                return -1;
            }
        }
    }
}