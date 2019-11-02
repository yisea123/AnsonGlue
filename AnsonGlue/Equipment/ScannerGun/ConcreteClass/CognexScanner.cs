using AnsonGlue.Equipment.ScannerGun.AbstractClass;
using AnsonGlue.Tool.Communication.AbstractClass;

namespace AnsonGlue.Equipment.ScannerGun.ConcreteClass
{
    public class CCognexScanner : CScannerGunAbs
    {
        public CCognexScanner(CCmtAbs oCmtAbs)
            : base(oCmtAbs)
        {
        }

        /// <summary>
        ///     触发扫描枪
        /// </summary>
        /// <returns></returns>
        public override bool Touch()
        {
            var nRtn = m_oCmtAbs.Send("\\T\r\n");
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