using AnsonGlue.Equipment.Blance.AbstractClass;
using AnsonGlue.Tool.Communication.AbstractClass;

namespace AnsonGlue.Equipment.Blance.ConcreteClass
{
    public class CSartorius : CBalanceAbs
    {
        /// <summary>
        ///     扫描枪的构造函数，传入通讯方式的抽象类指针
        /// </summary>
        /// <param name="oCmtAbs">通讯方式的抽象类指针</param>
        public CSartorius(CCmtAbs oCmtAbs)
            : base(oCmtAbs)
        {
        }

        /// <summary>
        ///     重启
        /// </summary>
        /// <returns></returns>
        public override bool Restart()
        {
            var nRtn = m_oCmtAbs.Send("\\ESCS\r\n");
            if (nRtn > 0)
                return true;
            return false;
        }

        /// <summary>
        ///     归零
        /// </summary>
        /// <returns></returns>
        public override bool Reset()
        {
            var nRtn = m_oCmtAbs.Send("\\ESCT\r\n");
            if (nRtn > 0)
                return true;
            return false;
        }

        /// <summary>
        ///     /触发
        /// </summary>
        /// <returns></returns>
        public override bool Touch()
        {
            var nRtn = m_oCmtAbs.Send("\\ESCP\r\n");
            if (nRtn > 0)
                return true;
            return false;
        }

        protected override void Released()
        {
            m_oCmtAbs.Disconnect();
        }
    }
}