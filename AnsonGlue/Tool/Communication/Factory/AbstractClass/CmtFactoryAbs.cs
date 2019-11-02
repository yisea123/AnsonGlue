using AnsonGlue.Tool.Communication.AbstractClass;

namespace AnsonGlue.Tool.Communication.Factory.AbstractClass
{
    /// <summary>
    /// 通讯类工厂抽象类
    /// </summary>
    public abstract class CCmtFactoryAbs
    {
        /// <summary>
        /// 创造通讯类
        /// </summary>
        /// <returns></returns>
        public abstract CCmtAbs Creat();

    }
}