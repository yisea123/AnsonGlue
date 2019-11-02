using AnsonGlue.Tool.Communication.AbstractClass;

namespace AnsonGlue.Equipment.Blance.AbstractClass
{
    public abstract class CBalanceAbs
    {
        /// <summary>
        ///     消息函数规则
        /// </summary>
        /// <param name="strMsg">传入信息</param>
        public delegate void DELEGATE_MSG(string strMsg);

        /// <summary>
        ///     通讯类抽象指针
        /// </summary>
        protected readonly CCmtAbs m_oCmtAbs;

        private bool m_bIsOpen;

        /// <summary>
        ///     用于给客户发消息的委托
        /// </summary>
        private DELEGATE_MSG m_delegateMsg;

        /// <summary>
        ///     扫描枪的构造函数，传入通讯方式的抽象类指针
        /// </summary>
        /// <param name="oCmtAbs">通讯方式的抽象类指针</param>
        protected CBalanceAbs(CCmtAbs oCmtAbs)
        {
            m_oCmtAbs = oCmtAbs;
            m_bIsOpen = false;
        }

        /// <summary>
        ///     用于接收通讯类消息的回调函数
        /// </summary>
        /// <param name="strMsg">消息</param>
        private void Receiver(string strMsg)
        {
            m_delegateMsg(strMsg);
        }

        /// <summary>
        ///     初始化电子秤
        /// </summary>
        /// <param name="fun">用于接收消息的委托函数</param>
        /// <returns></returns>
        public bool InitBalance(DELEGATE_MSG fun)
        {
            //初始化通讯类
            var bRtn = m_oCmtAbs.InitCmt();

            //传入回调函数给通讯类
            if (bRtn)
            {
                m_oCmtAbs.m_eMsgFun += Receiver;

                //给当前委托赋值
                m_delegateMsg = fun;

                m_bIsOpen = true;
            }

            return bRtn;
        }

        public bool IsOpen()
        {
            return m_bIsOpen;
        }

        /// <summary>
        ///     重启
        /// </summary>
        /// <returns></returns>
        public abstract bool Restart();

        /// <summary>
        ///     归零
        /// </summary>
        /// <returns></returns>
        public abstract bool Reset();

        /// <summary>
        ///     触发
        /// </summary>
        /// <returns></returns>
        public abstract bool Touch();

        /// <summary>
        ///     断开连接
        /// </summary>
        /// <returns></returns>
        public void Disconnect()
        {
            m_oCmtAbs.Disconnect();
            m_bIsOpen = false;
        }

        /// <summary>
        ///     用于释放资源的函数
        /// </summary>
        protected abstract void Released();


        ~CBalanceAbs()
        {
            Released();
        }
    }
}