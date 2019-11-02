using AnsonGlue.Equipment.Vision.AbstractClass;
using AnsonGlue.Tool.Communication.AbstractClass;

namespace AnsonGlue.Equipment.Vision.ConcreteClass
{
    public class CAnsonVision : CVisionAbs
    {
        public CAnsonVision(CCmtAbs oCmtAbs)
            : base(oCmtAbs)
        {
        }

        public override bool SendMsgToVision(string strMsg)
        {
            var nRtn = m_oCmtAbs.Send(strMsg);
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