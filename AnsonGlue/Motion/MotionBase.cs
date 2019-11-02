using System.Collections.Generic;

namespace AnsonGlue.Motion
{
    /// <summary>
    ///     不同运动卡的统一函数
    /// </summary>
    public abstract class CMotionBase
    {
        #region 成员变量
        /// <summary>
        /// 最大轴数量
        /// </summary>
        public short m_nMaxAxisNum;
        
        #endregion

        #region 私有函数
        /// <summary>
        /// 初始化板卡
        /// </summary>
        /// <param name="nCardNum">卡号</param>
        /// <param name="nAxisNum">轴号</param>
        protected abstract short InitAxis(short nCardNum, short nAxisNum);

        #endregion

        #region 自定义变量

        /// <summary>
        /// /二维比较参数设置结构体
        /// </summary>
        public struct DD_COMPARE_PRM
        {
            //固高灵猴通用
            public short nEncx;
            public short nEncy;
            public short nSource;
            public short nOutputType;
            public short nStartLevel;
            public short nTime;
            public short nMaxerr;
            public short nThreshold;

            //灵猴多余的
            public short nPluseCount;
            public short nSpacetime;
        }

        #endregion

        #region 公有函数

        /// <summary>
        ///     初始化运动卡
        /// </summary>
        /// <param name="nCardNum">卡号</param>
        /// <param name="nAxisNum">轴数</param>
        /// <param name="pFile">配置文件</param>
        /// <returns></returns>
        public abstract short InitMotionCard(short nCardNum, short nAxisNum, string pFile);

        /// <summary>
        ///     轴停止
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="mask">bit0--8 哪个轴</param>
        /// <param name="option">bit0--8 对应的停止方式：1：急停， 0：平滑停止</param>
        public abstract short Stop(short nCardNum, short mask, short option);

        /// <summary>
        ///     绝对坐标走位
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="dPos">位置,脉冲为单位</param>
        /// <param name="dVel">速度</param>
        /// <param name="dAcce">加减速度</param>
        /// <returns></returns>
        public abstract short AbsMove(short nCardNum, short nAxis, int dPos, double dVel, double dAcce);

        /// <summary>
        ///     JOG移动
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="dVel"></param>
        /// <param name="dAcce"></param>
        /// <returns></returns>
        public abstract short JogMove(short nCardNum, short nAxis, double dVel, double dAcce);

        /// <summary>
        ///     相对距离移动
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="dVel">速度</param>
        /// <param name="dAcce">加减速度</param>
        /// <param name="dOffset">相对移动量,单位脉冲</param>
        /// <returns></returns>
        public abstract short RMove(short nCardNum, short nAxis, double dVel, double dAcce, double dOffset);

        /// <summary>
        ///     轴启动
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <returns></returns>
        public abstract short AxisOn(short nCardNum, short nAxis);

        /// <summary>
        ///     获取轴状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="count">轴数量</param>
        /// <param name="status">轴状态</param>
        /// <returns></returns>
        public abstract short GetSts(short nCardNum, short nAxis, short count, out int status);

        /// <summary>
        ///     扫描输入状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="type">类型</param>
        /// <param name="status">状态信息</param>
        /// <returns></returns>
        public abstract short GetDi(short nCardNum, short type, out int status);

        /// <summary>
        ///     扫描通用输出状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="status">状态信息</param>
        /// <returns></returns>
        public abstract short GetDo(short nCardNum, out int status);

        /// <summary>
        ///     获取扩展Di的输入信号
        /// </summary>
        /// <param name="address">第几个扩展卡</param>
        /// <param name="diStatus">状态</param>
        /// <param name="nCardNum">运动卡号</param>
        /// <returns></returns>
        public abstract short GetExtendDi(short nCardNum, short address, out int diStatus);

        /// <summary>
        ///     按索引值设置通用数字 I/O 的输出信号
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="doIndex"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract short SetDoBit(short nCardNum, short doIndex, short value);

        /// <summary>
        ///     设置扩展数字 I/O 的输出信号
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="address">第几个扩展IO板</param>
        /// <param name="doIndex">IO索引</param>
        /// <param name="value">结果</param>
        /// <returns></returns>
        public abstract short SetExtendDoBit(short nCardNum, short address, short doIndex, short value);

        /// <summary>
        ///     获取规划位置
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴</param>
        /// <param name="dVal">值</param>
        /// <param name="count">轴数量</param>
        /// <returns></returns>
        public abstract short GetPrfPos(short nCardNum, short nAxis, out double dVal, short count);

        /// <summary>
        ///     获取编码器位置
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴</param>
        /// <param name="dVal">值</param>
        /// <param name="count">轴数量</param>
        /// <returns></returns>
        public abstract short GetEncPos(short nCardNum, short nAxis, out double dVal, short count);

        /// <summary>
        ///     清除轴状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public abstract short ClrSts(short nCardNum, short nAxis, short count);

        /// <summary>
        ///     切换轴运动为点位运动
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <returns></returns>
        public abstract short PrfTrap(short nCardNum, short nAxis);

        /// <summary>
        ///     切换轴运动为Jog运动
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <returns></returns>
        public abstract short PrfJog(short nCardNum, short nAxis);

        /// <summary>
        ///     设置Jog运动参数
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="acc">加速度 单位“脉冲/毫秒2”</param>
        /// <param name="dec">减速度 单位“脉冲/毫秒2”</param>
        /// <param name="smooth">平滑系数，取值范围[0,1]</param>
        /// <returns></returns>
        public abstract short SetJogPrm(short nCardNum, short nAxis, double acc, double dec, double smooth = 0);

        /// <summary>
        ///     获取Jog运动参数
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="acc">加速度</param>
        /// <param name="dec">减速度</param>
        /// <param name="smooth">平滑系数</param>
        /// <returns></returns>
        public abstract short GetJogPrm(short nCardNum, short nAxis, out double acc, out double dec, out double smooth);

        /// <summary>
        ///     设置Trap运动参数
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="acc">加速度 单位“脉冲/毫秒2”</param>
        /// <param name="dec">减速度 单位“脉冲/毫秒2”</param>
        /// <param name="smoothTime">平滑系数，取值范围[0,1]</param>
        /// <returns></returns>
        public abstract short SetTrapPrm(short nCardNum, short nAxis, double acc, double dec, short smoothTime = 5);

        /// <summary>
        ///     获取Trap运动参数
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="acc">加速度</param>
        /// <param name="dec">减速度</param>
        /// <param name="smoothTime"></param>
        /// <returns></returns>
        public abstract short GetTrapPrm(short nCardNum, short nAxis, out double acc, out double dec,
            out short smoothTime);

        /// <summary>
        ///     设置速度
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="vel">速度 单位是“脉冲/毫秒”</param>
        /// <returns></returns>
        public abstract short SetVel(short nCardNum, short nAxis, double vel);

        /// <summary>
        ///     设置位置
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="nPos">位置，单位脉冲</param>
        /// <returns></returns>
        public abstract short SetPos(short nCardNum, short nAxis, int nPos);

        /// <summary>
        ///     更新轴参数
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <returns></returns>
        public abstract short Update(short nCardNum, int nAxis);

        /// <summary>
        ///     设置捕获的电平状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="mode">方式 1：Home 捕获  2：Index 捕获</param>
        /// <param name="sense">捕获电平 0:下降沿触发;1:上升沿触发</param>
        /// <returns></returns>
        public abstract short SetCaptureSense(short nCardNum, short nAxis, short mode, short sense);

        /// <summary>
        ///     设置捕获的电平状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="mode">方式 1：Home 捕获  2：Index 捕获</param>
        /// <returns></returns>
        public abstract short SetCaptureMode(short nCardNum, short nAxis, short mode);

        /// <summary>
        ///     获取捕获状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="pStatus">状态</param>
        /// <param name="pValue">捕获位置</param>
        /// <param name="count">轴数</param>
        /// <returns></returns>
        public abstract short GetCaptureStatus(short nCardNum, short nAxis, out short pStatus, out int pValue,
            short count);

        /// <summary>
        ///     位置置零
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="count">粥熟了</param>
        /// <returns></returns>
        public abstract short ZeroPos(short nCardNum, short nAxis, short count);

        /// <summary>
        ///     设置插补坐标系
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nDim">坐标系维数</param>
        /// <param name="synVelMax">坐标系的最大合成速度</param>
        /// <param name="synAccMax">坐标系的最大合成加速度</param>
        /// <param name="evenTime">坐标系的最小匀速时间</param>
        /// <param name="profile">规划器对应的轴</param>
        /// <returns></returns>
        public abstract short SetLineOrdi(short nCardNum, short nDim, double synVelMax, double synAccMax,
            short evenTime, short[] profile);

        /// <summary>
        ///     初始化插补前瞻缓存区
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="crd">坐标系号，取值范围[1,2]</param>
        /// <param name="fifo">插补缓存区号，0：FIFO1 1：FIFO2</param>
        /// <param name="T">拐弯时间，取值范围[0,100]，单位 ms</param>
        /// <param name="accMax">最大加速度，单位 pulse/ms^2</param>
        /// <param name="n">前瞻缓存区大小</param>
        /// <param name="lenght">前瞻缓存区内存指针</param>
        /// <returns></returns>
        public abstract short InitLookAhead(short nCardNum, short crd, short fifo, double T, double accMax, short n,
            int lenght);

        /// <summary>
        ///     使用前瞻时，把前瞻缓存区的数据压入运动缓存区
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="crd">坐标系号，取值范围[1,2]</param>
        /// <param name="fifo">插补缓存区号，0：FIFO1 1：FIFO2</param>
        /// <returns></returns>
        public abstract short CrdData(short nCardNum, short crd, short fifo = 0);

        /// <summary>
        ///     读取坐标系缓冲区剩余空间大小
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="crd">坐标系号，取值范围[1,2]</param>
        /// <param name="pSpace">插补缓存的剩余空间</param>
        /// <param name="count">（灵猴）轴数</param>
        /// <param name="fifo">插补缓存区号，0：FIFO1 1：FIFO2</param>
        /// <returns></returns>
        public abstract short CrdSpace(short nCardNum, short crd, out int pSpace, short count = 1, short fifo = 0);

        /// <summary>
        ///     坐标系开始运行
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="mask">bit0 对应坐标系 1，bit1 对应坐标系 2。  0：不启动该坐标系，1：启动该坐标系。</param>
        /// <param name="option">bit0 对应坐标系 1，bit1 对应坐标系 2。  0：启动坐标系中 FIFO0 的运动，1：启动坐标系中 FIFO1 的运动。</param>
        /// <returns></returns>
        public abstract short CrdStart(short nCardNum, short mask, short option = 0);

        /// <summary>
        ///     查询插补运动坐标系状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="crd">坐标系号。正整数，取值范围：[1, 2]</param>
        /// <param name="pRun">读取插补运动状态。0：该坐标系的该 FIFO 没有在运动；1：该坐标系的该 FIFO 正在进行插补运动。</param>
        /// <param name="pSegment">（固高参数）读取当前已经完成的插补段数。</param>
        /// <param name="pCmdNum">（灵猴参数）缓存区当前指令数量</param>
        /// <param name="pSpace">（灵猴参数）缓冲区剩余空间</param>
        /// <param name="fifo">所要查询运动状态的插补缓存区号。正整数，取值范围：[0, 1]</param>
        /// <returns></returns>
        public abstract short CrdStatus(short nCardNum, short crd, out short pRun, out int pSegment, out short pCmdNum,
            out int pSpace, short fifo = 0);

        /// <summary>
        ///     清除插补坐标系数据
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="crd">坐标系号 1跟2</param>
        /// <param name="count">不用管</param>
        /// <param name="fifo">缓冲区号 fifo0  fifo1</param>
        /// <returns></returns>
        public abstract short CrdClear(short nCardNum, short crd, short fifo, short count = 1);

        /// <summary>
        ///     XY 平面二维直线插补。
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="crd">坐标系号。正整数，取值范围：[1, 2]。</param>
        /// <param name="x">插补段 x 轴终点坐标值。取值范围：[-1073741823, 1073741823]，单位：pulse。</param>
        /// <param name="y">插补段 y 轴终点坐标值。取值范围：[-1073741823, 1073741823]，单位：pulse。</param>
        /// <param name="synVel">插补段的目标合成速度。取值范围：(0, 32767)，单位：pulse/ms。</param>
        /// <param name="synAcc">插补段的合成加速度。取值范围：(0, 32767)，单位：pulse/ms 2 </param>
        /// <param name="velEnd">插补段的终点速度。取值范围：[0, 32767)，单位：pulse/ms</param>
        /// <param name="fifo">插补缓存区号。取值范围：[0, 1]</param>
        /// <returns></returns>
        public abstract short LnXy(short nCardNum, short crd, int x, int y, double synVel, double synAcc,
            double velEnd = 0, short fifo = 0);

        /// <summary>
        ///     三维直线插补
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="crd">坐标系号。正整数，取值范围：[1, 2]。</param>
        /// <param name="x">插补段 x 轴终点坐标值。取值范围：[-1073741823, 1073741823]，单位：pulse。</param>
        /// <param name="y">插补段 y 轴终点坐标值。取值范围：[-1073741823, 1073741823]，单位：pulse。</param>
        /// <param name="z">插补段 z 轴终点坐标值。取值范围：[-1073741823, 1073741823]，单位：pulse</param>
        /// <param name="synVel">插补段的目标合成速度。取值范围：(0, 32767)，单位：pulse/ms</param>
        /// <param name="synAcc">插补段的合成加速度。取值范围：(0, 32767)，单位：pulse/ms 2 </param>
        /// <param name="velEnd">插补段的终点速度。取值范围：[0, 32767)，单位：pulse/ms。</param>
        /// <param name="fifo">插补缓存区号，取值范围：[0, 1]，默认值为：0</param>
        /// <returns></returns>
        public abstract short LnXyz(short nCardNum, short crd, int x, int y, int z, double synVel, double synAcc,
            double velEnd = 0, short fifo = 0);

        /// <summary>
        ///     四维直线插补。
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="crd">坐标系号。正整数，取值范围：[1, 2]。</param>
        /// <param name="x">插补段 x 轴终点坐标值。取值范围：[-1073741823, 1073741823]，单位：pulse。</param>
        /// <param name="y">插补段 y 轴终点坐标值。取值范围：[-1073741823, 1073741823]，单位：pulse。</param>
        /// <param name="z">插补段 z 轴终点坐标值。取值范围：[-1073741823, 1073741823]，单位：pulse</param>
        /// <param name="a">第四个轴</param>
        /// <param name="synVel">插补段的目标合成速度。取值范围：(0, 32767)，单位：pulse/ms</param>
        /// <param name="synAcc">插补段的合成加速度。取值范围：(0, 32767)，单位：pulse/ms 2 </param>
        /// <param name="velEnd">插补段的终点速度。取值范围：[0, 32767)，单位：pulse/ms。</param>
        /// <param name="fifo">插补缓存区号，取值范围：[0, 1]，默认值为：0</param>
        /// <returns></returns>
        public abstract short LnXyza(short nCardNum, short crd, int x, int y, int z, int a, double synVel,
            double synAcc, double velEnd = 0, short fifo = 0);

        /// <summary>
        ///     XY 平面圆弧插补。使用圆心描述方法描述圆弧。
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="crd">坐标系号。正整数，取值范围：[1, 2]。</param>
        /// <param name="x">圆弧插补 x 轴的终点坐标值。取值范围：[-1073741823, 1073741823]，单位：pulse。</param>
        /// <param name="y">圆弧插补 y 轴的终点坐标值。取值范围：[-1073741823, 1073741823]，单位：pulse。</param>
        /// <param name="xCenter">圆弧插补的圆心 x 方向相对于起点位置的偏移量。</param>
        /// <param name="yCenter">圆弧插补的圆心 y 方向相对于起点位置的偏移量。</param>
        /// <param name="circleDir">0：顺时针圆弧。1：逆时针圆弧。</param>
        /// <param name="synVel">插补段的目标合成速度。取值范围：(0, 32767)，单位：pulse/ms。</param>
        /// <param name="synAcc">插补段的合成加速度。取值范围：(0, 32767)，单位：pulse/ms 2 。</param>
        /// <param name="velEnd">插补段的终点速度。取值范围：[0, 32767)，单位：pulse/ms。</param>
        /// <param name="fifo">插补缓存区号。正整数，取值范围：[0, 1]，默认值为：0。</param>
        /// <returns></returns>
        public abstract short ArcXyc(short nCardNum, short crd, int x, int y, double xCenter, double yCenter,
            short circleDir, double synVel, double synAcc, double velEnd = 0, short fifo = 0);

        /// <summary>
        ///     缓存区内数字量 IO 输出设置指令。
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="crd">坐标系号。正整数，取值范围：[1, 2]。</param>
        /// <param name="doType">数字量输出的类型。 10)：输出驱动器使能。11)：输出驱动器报警清除。 12)：输出通用输出。</param>
        /// <param name="doMask">从 bit0~bit15 按位表示指定的数字量输出是否有操作。0：该路数字量输出无操作。1：该路数字量输出有操作。</param>
        /// <param name="doValue">从 bit0~bit15 按位表示指定的数字量输出的值。</param>
        /// <param name="fifo">插补缓存区号。正整数，取值范围：[0, 1]，默认值为：0。</param>
        /// <returns></returns>
        public abstract short BufIo(short nCardNum, short crd, ushort doType, ushort doMask, ushort doValue,
            short fifo = 0);


        /// <summary>
        ///    设置扩展IO卡数量
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="count"></param>
        public abstract void SetExtendCardCount(short nCardNum, int count);

        #endregion

        #region 二维比较

        /// <summary>
        ///     二维位置比较参数
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="chn">通道号 0：HSIO1 ; 通道号 1: HSIO2</param>
        /// <param name="pPrm">参数</param>
        /// <returns></returns>
        public abstract short D2DCompareSetPrm(short nCardNum, short chn, ref object pPrm);

        /// <summary>
        ///     二维位置压入
        /// </summary>
        /// <param name="nCardNum">位置比较数据个数</param>
        /// <param name="axis1">轴1坐标</param>
        /// <param name="axis2">轴2坐标</param>
        /// <param name="chn">通道号 0：HSIO1 ; 通道号 1: HSIO2</param>
        /// <param name="fifo">数据压入的 FIFO,范围: [0,1],该数据目前保留,使用 0 即可</param>
        /// <returns></returns>
        public abstract short D2DCompareData(short nCardNum, List<int> axis1, List<int> axis2, short chn, short fifo);

        /// <summary>
        ///     启动二维位置比较
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="chn">通道号 0：HSIO1 ; 通道号 1: HSIO2</param>
        /// <returns></returns>
        public abstract short D2DCompareStart(short nCardNum, short chn);

        /// <summary>
        ///     单点触发高速口
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="chn">高速口 0 1</param>
        /// <param name="level"></param>
        /// <param name="outputType"></param>
        /// <param name="time"></param>
        public abstract short D2DComparePulse(short nCardNum, short chn, short level, short outputType, short time);

        #endregion
    }
}