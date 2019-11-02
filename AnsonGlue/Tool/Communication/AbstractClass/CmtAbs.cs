
namespace AnsonGlue.Tool.Communication.AbstractClass
{
    public abstract class CCmtAbs
    {
        /// <summary>
        ///     消息函数规则
        /// </summary>
        /// <param name="strMsg">传入信息</param>
        public delegate void DELEGATE_MSG(string strMsg);

        /// <summary>
        ///     委托对象
        /// </summary>
        public event DELEGATE_MSG m_eMsgFun;

        /// <summary>
        ///  通讯对象的消息
        /// </summary>
        protected string m_strCmtMsg;

        /// <summary>
        ///     初始化通讯
        /// </summary>
        /// <returns>是否初始化成功</returns>
        public abstract bool InitCmt();

        /// <summary>
        ///     发送消息
        /// </summary>
        /// <param name="msg">内容</param>
        /// <param name="address">地址,服务器发送时用</param>
        /// <returns>发送的字节数，负数说明发送失败</returns>
        public abstract int Send(string msg, string address = "");

        /// <summary>
        ///     断开通讯连接
        /// </summary>
        public abstract void Disconnect();


        /// <summary>
        ///     触发消息事件
        /// </summary>
        protected void Msg()
        {
            if (m_eMsgFun != null) m_eMsgFun(m_strCmtMsg);
            //m_strCmdInfo = @"";
        }
    }
}