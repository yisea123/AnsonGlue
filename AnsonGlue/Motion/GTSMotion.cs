using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using gts;

namespace AnsonGlue.Motion
{
    /// <summary>
    ///     固高运动卡功能类
    /// </summary>
    public class CGtMotion : CMotionBase
    {
        #region 构造函数

        public CGtMotion(short nAxisMaxNum)
        {
            m_nMaxAxisNum = nAxisMaxNum;
        }

        #endregion

        #region 自定义变量

        /// <summary>
        ///     2维比较点位集合结构体
        /// </summary>
        public struct DD_POINT
        {
            public List<int> m_lAxis1;
            public List<int> m_lAxis2;
            public short nCardNum;
            public int nIndex;
            public short nChn;
        }

        #endregion

        #region 变量

        /// <summary>
        ///     固高要的，不要管
        /// </summary>
        private uint m_clk;

        private mc.TCrdData[] m_pLookAheadBuf = new mc.TCrdData[200];

        #endregion

        #region 函数

        /// <summary>
        ///     初始化轴
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxisNum">轴数</param>
        protected override short InitAxis(short nCardNum, short nAxisNum)
        {
            short nRtn = 0;
            for (short i = 1; i <= nAxisNum; i++)
            {
                if (i < 4)
                    nRtn |= mc.GT_EncOn(nCardNum, i); //设置计数源为编码器，
                else
                    nRtn |= mc.GT_EncOff(nCardNum, i); //设置为“脉冲计数器”计数方式,因为步进马达没有编码器,为统一方便都设为脉冲计数

                nRtn |= mc.GT_ZeroPos(nCardNum, i, 1); //马达位置清零,原点回归完成时也用该指令来置零
                nRtn |= mc.GT_SetPrfPos(nCardNum, i, 0); //轴规划位置清零 
                Thread.Sleep(200); //等待伺服稳定
                nRtn |= mc.GT_ClrSts(nCardNum, i, nAxisNum); //清楚轴状态
                nRtn |= mc.GT_AxisOn(nCardNum, i); //马达伺服使能
            }

            return nRtn;
        }

        /// <summary>
        ///     初始化运动卡
        /// </summary>
        /// <param name="nCardNum">卡号</param>
        /// <param name="nAxisNum">轴数</param>
        /// <param name="pFile">配置文件</param>
        /// <returns></returns>
        public override short InitMotionCard(short nCardNum, short nAxisNum, string pFile)
        {
            short nRtn = 0;
            nRtn |= mc.GT_Open(nCardNum, 0, 1); //打开运动控制器设备

            if (nRtn != 0)
            {
                MessageBox.Show(@"打开运动卡失败，可能原因：1.运动卡没有插好；2.有其他的程序正在对运动卡操作", @"提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return nRtn;
            }

            if (File.Exists("gts.dll") && File.Exists("ExtMdl.cfg"))
            {
                nRtn |= mc.GT_OpenExtMdl(nCardNum, "gts.dll");
                nRtn |= mc.GT_LoadExtConfig(nCardNum, "ExtMdl.cfg");
            }
            else
            {
                MessageBox.Show(@"扩展模块加载失败，请检查文件是否存在", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // return m_iCmdRtn;
            }

            nRtn |= mc.GT_Reset(nCardNum); //复位运动控制器


            nRtn |= mc.GT_LoadConfig(nCardNum, pFile); //加载配置文件


            if (nRtn == 0)
            {
                m_nMaxAxisNum = nAxisNum;
                nRtn = mc.GT_ClrSts(nCardNum, 1, m_nMaxAxisNum);
                InitAxis(nCardNum, m_nMaxAxisNum);
            }

            return nRtn;
        }

        /// <inheritdoc />
        /// <summary>
        ///     轴停止
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="mask">bit0--8 哪个轴</param>
        /// <param name="option">bit0--8 对应的停止方式：1：急停， 0：平滑停止</param>
        public override short Stop(short nCardNum, short mask, short option)
        {
            short nRtn = 0;
            nRtn |= mc.GT_Stop(nCardNum, mask, option);
            return nRtn;
        }

        /// <summary>
        ///     JOG移动
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="dVel"></param>
        /// <param name="dAcce"></param>
        /// <returns></returns>
        public override short JogMove(short nCardNum, short nAxis, double dVel, double dAcce)
        {
            short nRtn = 0;
            if (nCardNum < 0 || nAxis > m_nMaxAxisNum)
                return -1;

            //获取标志位状态

            nRtn |= mc.GT_ClrSts(nCardNum, 1, m_nMaxAxisNum);


            int sts;
            nRtn |= mc.GT_GetSts(nCardNum, nAxis, out sts, 1, out m_clk);

            int mode;
            nRtn |= mc.GT_GetPrfMode(nCardNum, nAxis, out mode, 1,
                out m_clk); //mode值  //0：trap 1：Jog 2：S 3：PT 4：PVS 5：interpolation 6：gear


            if ((sts & 0x400) != 0) //运动情况下可以改变速度和加速度
            {
                if (1 != mode)
                    return nRtn;
            }
            else //静止情况下才能修改运动模式
            {
                if (1 != mode) nRtn |= mc.GT_PrfJog(nCardNum, nAxis);
            }

            //设置Jog运动参数
            mc.TJogPrm jogPrm;
            jogPrm.acc = dAcce; //加速度，单位“脉冲/毫秒2”
            jogPrm.dec = dAcce; //减速度，单位“脉冲/毫秒2”
            jogPrm.smooth = 0.625; //平滑系数，取值范围[0,1]
            nRtn |= mc.GT_SetJogPrm(nCardNum, nAxis, ref jogPrm);

            //启动运动
            nRtn |= mc.GT_SetVel(nCardNum, nAxis, dVel); //设置目标速度，单位是“脉冲/毫秒”
            nRtn |= mc.GT_Update(nCardNum, 1 << (nAxis - 1));
            return nRtn;
        }

        /// <summary>
        ///     绝对坐标走位
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="dPos">位置,脉冲为单位</param>
        /// <param name="dVel">速度</param>
        /// <param name="dAcce">加减速度</param>
        /// <returns></returns>
        public override short AbsMove(short nCardNum, short nAxis, int dPos, double dVel, double dAcce)
        {
            short nRtn = 0;
            if (nAxis > m_nMaxAxisNum) return -1;

            //lock (m_lockMove)
            int sts;

            //获取标志位状态
            nRtn |= mc.GT_GetSts(nCardNum, nAxis, out sts, 1, out m_clk);


            if ((sts & 0x400) == 0) //该轴必须静止
            {
                //设定Trap运动模式，失败则返回

                int mode;
                nRtn |= mc.GT_GetPrfMode(nCardNum, nAxis, out mode, 1, out m_clk);


                if (mode != 0)
                {
                    nRtn |= mc.GT_ClrSts(nCardNum, nAxis, 1);

                    nRtn |= mc.GT_PrfTrap(nCardNum, nAxis);
                }
            }

            //设定Trap运动参数

            mc.TTrapPrm trap;
            trap.acc = dAcce;
            trap.dec = dAcce;
            trap.velStart = 0;
            trap.smoothTime = 10;
            nRtn |= mc.GT_SetTrapPrm(nCardNum, nAxis, ref trap);


            //开始运动

            nRtn |= mc.GT_SetPos(nCardNum, nAxis, dPos);

            nRtn |= mc.GT_SetVel(nCardNum, nAxis, dVel);

            nRtn |= mc.GT_Update(nCardNum, 1 << (nAxis - 1));

            return nRtn;
        }

        /// <summary>
        ///     相对距离移动
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="dVel">速度</param>
        /// <param name="dAcce">加减速度</param>
        /// <param name="dOffset">相对移动量,单位脉冲</param>
        /// <returns></returns>
        public override short RMove(short nCardNum, short nAxis, double dVel, double dAcce, double dOffset)
        {
            short nRtn = 0;
            if (nCardNum < 0 || nAxis > m_nMaxAxisNum)
                return -1;

            int sts;

            nRtn |= mc.GT_GetSts(nCardNum, nAxis, out sts, 1, out m_clk);


            if ((sts & 0x400) != 0) //必须停止
                return nRtn;

            //设定Trap运动模式，失败则返回
            int lMode;
            nRtn |= mc.GT_GetPrfMode(nCardNum, nAxis, out lMode, 1,
                out m_clk); //mode值  //0：trap 1：Jog 2：S 3：PT 4：PVS 5：interpolation 6：gear
            if (0 != lMode)
            {
                nRtn |= mc.GT_ClrSts(nCardNum, nAxis, 1);

                nRtn |= mc.GT_PrfTrap(nCardNum, nAxis);
            }

            //设定Trap运动参数
            mc.TTrapPrm trap;
            trap.acc = dAcce;
            trap.dec = dAcce;
            trap.velStart = 0;
            trap.smoothTime = 1;
            nRtn |= mc.GT_SetTrapPrm(nCardNum, nAxis, ref trap);

            //开始运动
            double dCurrentPos;
            nRtn |= mc.GT_GetPrfPos(nCardNum, nAxis, out dCurrentPos, 1, out m_clk);

            var lPrfpos = dOffset + dCurrentPos;

            nRtn |= mc.GT_SetPrfPos(nCardNum, nAxis, (int) lPrfpos);

            nRtn |= mc.GT_SetVel(nCardNum, nAxis, dVel);

            nRtn |= mc.GT_Update(nCardNum, 1 << (nAxis - 1));


            return nRtn;
        }

        /// <summary>
        ///     轴启动
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <returns></returns>
        public override short AxisOn(short nCardNum, short nAxis)
        {
            short nRtn = 0;
            nRtn |= mc.GT_AxisOn(nCardNum, nAxis);
            return nRtn;
        }

        /// <summary>
        ///     获取轴状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="count">轴数量</param>
        /// <param name="status">轴状态</param>
        /// <returns></returns>
        public override short GetSts(short nCardNum, short nAxis, short count, out int status)
        {
            short nRtn = 0;
            nRtn |= mc.GT_GetSts(nCardNum, nAxis, out status, count, out m_clk);

            return nRtn;
        }

        /// <summary>
        ///     扫描输入状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="diType">类型</param>
        /// <param name="diStatus">状态信息</param>
        /// <returns></returns>
        public override short GetDi(short nCardNum, short diType, out int diStatus)
        {
            short nRtn = 0;
            nRtn |= mc.GT_GetDi(nCardNum, diType, out diStatus);
            return nRtn;
        }

        /// <summary>
        ///     扫描通用输出状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="status">状态信息</param>
        /// <returns></returns>
        public override short GetDo(short nCardNum, out int status)
        {
            short nRtn = 0;
            nRtn |= mc.GT_GetDo(nCardNum, mc.MC_GPO, out status);
            return nRtn;
        }

        /// <summary>
        ///     获取扩展Di的输入信号
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="address">第几个扩招卡</param>
        /// <param name="status"></param>
        /// <returns></returns>
        public override short GetExtendDi(short nCardNum, short address, out int status)
        {
            short nRtn = 0;
            ushort sts;
            var sts1 = new ushort[16];
            status = 0;
            //m_iCmdRtn = mc.GT_GetExtIoValue(0, out _Sts);
            for (short i = 0; i < 16; i++) nRtn |= mc.GT_GetExtIoBit(nCardNum, 0, i, out sts1[i]);
            nRtn |= mc.GT_GetExtIoValue(nCardNum, 0, out sts);
            status = Convert.ToInt32(sts);


            return nRtn;
        }

        /// <summary>
        ///     按索引值设置通用数字 I/O 的输出信号
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="doIndex"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override short SetDoBit(short nCardNum, short doIndex, short value)
        {
            short nRtn = 0;
            nRtn |= mc.GT_SetDoBit(nCardNum, mc.MC_GPO, doIndex, value);

            return nRtn;
        }

        /// <summary>
        ///     设置扩展数字 I/O 的输出信号
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="address">第几个扩展IO板</param>
        /// <param name="doIndex">IO索引</param>
        /// <param name="value">结果</param>
        /// <returns></returns>
        public override short SetExtendDoBit(short nCardNum, short address, short doIndex, short value)
        {
            short nRtn = 0;
            var val = Convert.ToUInt16(value);
            nRtn |= mc.GT_SetExtIoValue(nCardNum, doIndex, val);

            return nRtn;
        }

        /// <summary>
        ///     获取规划位置
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴</param>
        /// <param name="dVal">值</param>
        /// <param name="count">轴数量</param>
        /// <returns></returns>
        public override short GetPrfPos(short nCardNum, short nAxis, out double dVal, short count)
        {
            short nRtn = 0;
            nRtn |= mc.GT_GetPrfPos(nCardNum, nAxis, out dVal, count, out m_clk);
            return nRtn;
        }

        /// <summary>
        ///     获取编码器位置
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴</param>
        /// <param name="dVal">值</param>
        /// <param name="count">轴数量</param>
        /// <returns></returns>
        public override short GetEncPos(short nCardNum, short nAxis, out double dVal, short count)
        {
            short nRtn = 0;
            nRtn |= mc.GT_GetEncPos(nCardNum, nAxis, out dVal, count, out m_clk);
            return nRtn;
        }

        /// <summary>
        ///     清除轴状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public override short ClrSts(short nCardNum, short nAxis, short count)
        {
            short nRtn = 0;
            nRtn |= mc.GT_ClrSts(nCardNum, nAxis, count); // 清除指定轴的报警和限位

            return nRtn;
        }

        /// <summary>
        ///     切换轴运动为点位运动
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <returns></returns>
        public override short PrfTrap(short nCardNum, short nAxis)
        {
            short nRtn = 0;
            nRtn |= mc.GT_PrfTrap(nCardNum, nAxis);

            return nRtn;
        }

        /// <summary>
        ///     切换轴运动为Jog运动
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <returns></returns>
        public override short PrfJog(short nCardNum, short nAxis)
        {
            short nRtn = 0;
            nRtn |= mc.GT_PrfJog(nCardNum, nAxis);
            return nRtn;
        }

        /// <summary>
        ///     设置Jog运动参数
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="acc">加速度 单位“脉冲/毫秒2”</param>
        /// <param name="dec">减速度 单位“脉冲/毫秒2”</param>
        /// <param name="smooth">平滑系数，取值范围[0,1]</param>
        /// <returns></returns>
        public override short SetJogPrm(short nCardNum, short nAxis, double acc, double dec, double smooth = 0)
        {
            //设置Jog运动参数
            short nRtn = 0;
            mc.GT_PrfJog(nCardNum, nAxis);
            mc.TJogPrm mytprfvel;
            mytprfvel.acc = acc; //加速度，单位“脉冲/毫秒2”
            mytprfvel.dec = dec; //减速度，单位“脉冲/毫秒2”
            mytprfvel.smooth = smooth; //平滑系数，取值范围[0,1]
            nRtn |= mc.GT_SetJogPrm(nCardNum, nAxis, ref mytprfvel);


            return nRtn;
        }

        /// <summary>
        ///     获取Jog运动参数
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="acc">加速度</param>
        /// <param name="dec">减速度</param>
        /// <param name="smooth">平滑系数</param>
        /// <returns></returns>
        public override short GetJogPrm(short nCardNum, short nAxis, out double acc, out double dec, out double smooth)
        {
            short nRtn = 0;
            mc.TJogPrm trapPrm;
            nRtn |= mc.GT_GetJogPrm(nCardNum, nAxis, out trapPrm);
            acc = trapPrm.acc;
            dec = trapPrm.dec;
            smooth = trapPrm.smooth;

            return nRtn ;
        }

        /// <summary>
        ///     设置Trap运动参数
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="acc">加速度 单位“脉冲/毫秒2”</param>
        /// <param name="dec">减速度 单位“脉冲/毫秒2”</param>
        /// <param name="smoothTime">平滑系数，取值范围[0,1]</param>
        /// <returns></returns>
        public override short SetTrapPrm(short nCardNum, short nAxis, double acc, double dec, short smoothTime = 5)
        {
            short nRtn = 0;
            //设置Jog运动参数
            var mytprfvel = new mc.TTrapPrm();
            mytprfvel.acc = acc; //加速度，单位“脉冲/毫秒2”
            mytprfvel.dec = dec; //减速度，单位“脉冲/毫秒2”
            mytprfvel.smoothTime = smoothTime; //平滑时间，取值范围[0,1]
            nRtn  |= mc.GT_SetTrapPrm(nCardNum, nAxis, ref mytprfvel);


            return nRtn ;
        }

        /// <summary>
        ///     获取Trap运动参数
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="acc">加速度</param>
        /// <param name="dec">减速度</param>
        /// <param name="smoothTime"></param>
        /// <returns></returns>
        public override short GetTrapPrm(short nCardNum, short nAxis, out double acc, out double dec,
            out short smoothTime)
        {
            short nRtn = 0;
            mc.TTrapPrm trapPrm;
            nRtn |= mc.GT_GetTrapPrm(nCardNum, nAxis, out trapPrm);
            acc = trapPrm.acc;
            dec = trapPrm.dec;
            smoothTime = trapPrm.smoothTime;

            return nRtn ;
        }

        /// <summary>
        ///     设置速度
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="vel">速度 单位是“脉冲/毫秒”</param>
        /// <returns></returns>
        public override short SetVel(short nCardNum, short nAxis, double vel)
        {
            short nRtn = 0;
            nRtn |= mc.GT_SetVel(nCardNum, nAxis, vel); //设置目标速度，单位是“脉冲/毫秒”

            return nRtn ;
        }

        /// <summary>
        ///     设置位置
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="nPos">位置，单位脉冲</param>
        /// <returns></returns>
        public override short SetPos(short nCardNum, short nAxis, int nPos)
        {
            short nRtn = 0;
            nRtn |= mc.GT_SetPos(nCardNum, nAxis, nPos);

            return nRtn ;
        }

        /// <summary>
        ///     更新轴参数
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <returns></returns>
        public override short Update(short nCardNum, int nAxis)
        {
            short nRtn = 0;
            nRtn |= mc.GT_Update(nCardNum, 1 << (nAxis - 1));

            return nRtn ;
        }


        /// <summary>
        ///     设置捕获的电平状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="mode">方式 1：Home 捕获  2：Index 捕获</param>
        /// <param name="sense">捕获电平 0:下降沿触发;1:上升沿触发</param>
        /// <returns></returns>
        public override short SetCaptureSense(short nCardNum, short nAxis, short mode, short sense)
        {
            short nRtn = 0;
            nRtn |= mc.GT_SetCaptureSense(nCardNum, nAxis, mode, sense); //0:下降沿触发;1:上升沿触发
            return nRtn ;
        }

        /// <summary>
        ///     设置捕获的电平状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="mode">方式 1：Home 捕获  2：Index 捕获</param>
        /// <returns></returns>
        public override short SetCaptureMode(short nCardNum, short nAxis, short mode)
        {
            short nRtn = 0;
            nRtn |= mc.GT_SetCaptureMode(nCardNum, nAxis, mode);
            return nRtn ;
        }

        /// <summary>
        ///     获取捕获状态
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="pStatus">状态</param>
        /// <param name="pValue">捕获位置</param>
        /// <param name="count">轴数</param>
        /// <returns></returns>
        public override short GetCaptureStatus(short nCardNum, short nAxis, out short pStatus, out int pValue,
            short count)
        {
            short nRtn = 0;
            nRtn |= mc.GT_GetCaptureStatus(nCardNum, nAxis, out pStatus, out pValue, count, out m_clk);

            if (nRtn  != 0) return nRtn ;
            return nRtn ;
        }

        /// <summary>
        ///     位置置零
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="nAxis">轴号</param>
        /// <param name="count">粥熟了</param>
        /// <returns></returns>
        public override short ZeroPos(short nCardNum, short nAxis, short count)
        {
            short nRtn = 0;
            nRtn |= mc.GT_ZeroPos(nCardNum, nAxis, count);
            return nRtn ;
        }

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
        public override short SetLineOrdi(short nCardNum, short nDim, double synVelMax, double synAccMax,
            short evenTime, short[] profile)
        {
            short nRtn = 0;
            var crdPrm = new mc.TCrdPrm();
            crdPrm.dimension = nDim; // 建立二/三/四维的坐标系
            crdPrm.synVelMax = synVelMax; // 坐标系的最大合成速度是: 500 pulse/ms
            crdPrm.synAccMax = synAccMax; // 坐标系的最大合成加速度是: 2 pulse/ms^2
            crdPrm.evenTime = evenTime; // 坐标系的最小匀速时间为0

            crdPrm.profile1 = profile[0];
            crdPrm.profile2 = profile[1];
            crdPrm.profile3 = profile[2];
            crdPrm.profile4 = profile[3];
            crdPrm.profile5 = profile[4];
            crdPrm.profile6 = profile[5];
            crdPrm.profile7 = profile[6];
            crdPrm.profile8 = profile[7];

            crdPrm.setOriginFlag = 1; // 需要设置加工坐标系原点位置
            crdPrm.originPos1 = 0; // 加工坐标系原点位置在(0,0)，即与机床坐标系原点重合
            crdPrm.originPos2 = 0;
            crdPrm.originPos3 = 0;
            crdPrm.originPos4 = 0;
            crdPrm.originPos5 = 0;
            crdPrm.originPos6 = 0;
            crdPrm.originPos7 = 0;
            crdPrm.originPos8 = 0;

            nRtn |= mc.GT_SetCrdPrm(nCardNum, 1, ref crdPrm);
            return nRtn ;
        }


        #region 二维比较

        /// <summary>
        ///     二维位置比较强制输出
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="chn">通道号</param>
        /// <param name="level">位置比较输出电平起始电平 0 1</param>
        /// <param name="outputType">输出类型:0 表示脉冲输出，1 表示电平输出</param>
        /// <param name="time">脉冲模式下输出脉冲的时间</param>
        public override short D2DComparePulse(short nCardNum, short chn, short level, short outputType, short time)
        {
            short nRtn = 0;
            //清除
            nRtn |= mc.GT_2DCompareClear(nCardNum, chn);
            nRtn |= mc.GT_2DComparePulse(nCardNum, chn, level, outputType, time);
            return nRtn ;
        }

        /// <summary>
        ///     二维位置压入
        /// </summary>
        /// <param name="nCardNum">位置比较数据个数</param>
        /// <param name="axis1">轴1坐标</param>
        /// <param name="axis2">D轴2坐标</param>
        /// <param name="chn">通道号 0：HSIO1 ; 通道号 1: HSIO2</param>
        /// <param name="fifo">数据压入的 FIFO,范围: [0,1],该数据目前保留,使用 0 即可</param>
        /// <returns></returns>
        public override short D2DCompareData(short nCardNum, List<int> axis1, List<int> axis2, short chn, short fifo)
        {
            short nRtn = 0;
            //清除
            nRtn |= mc.GT_2DCompareClear(nCardNum, chn);

            //设置模式
            nRtn |= mc.GT_2DCompareMode(nCardNum, chn, mc.COMPARE2D_MODE_2D);

            var ll = axis1.Count;
            int maxL;

            if (ll > 1000)
                maxL = 1000;
            else
                maxL = ll;


            var td = new mc.T2DCompareData[1000];


            for (var i = 0; i < maxL; i++)
            {
                td[i].px = axis1[i];
                td[i].py = axis2[i];
            }

            //压入数据
            nRtn |= mc.GT_2DCompareData(nCardNum, chn, (short)maxL, ref td[0], fifo);


            //如果数量超过1000个，开启线程继续压入
            if (maxL == 1000)
            {
                DD_POINT t2P;
                t2P.m_lAxis1 = axis1;
                t2P.m_lAxis2 = axis2;
                t2P.nIndex = 1000;
                t2P.nChn = chn;
                t2P.nCardNum = nCardNum;


                var t = new Thread(ThreadAddP);

                t.IsBackground = true;
                t.Start(t2P);
            }


            return nRtn ;
        }

        private void ThreadAddP(object point)
        {
            var t2P = (DD_POINT) point;

            //已经添加的个数
            var index = t2P.nIndex;
            var td = new mc.T2DCompareData[t2P.m_lAxis1.Count - index];

            var maxL = t2P.m_lAxis1.Count - index;

            //提取剩下的点
            for (var i = 0; i < maxL; i++)
            {
                td[i].px = t2P.m_lAxis1[i + index];
                td[i].py = t2P.m_lAxis2[i + index];
            }

            //当前索引
            var preIndex = 0;

            while (index < t2P.m_lAxis1.Count)
            {
                short pStatus; //0 :正在进行比较输出 1：比较输出完成
                int pCount; //位置比较已输出次数
                short pFifo; //当前空闲 FIFO
                short pFifoCount; //当前空闲 FIFO 剩余空间
                short pBufCount; //FPGA 中 FIFO 剩余空间，FPGA 的 FIFO 总大小为 512，启动位置比较之前，压入的数据先进入 FPGA 的 FIFO
                mc.GT_2DCompareStatus(t2P.nCardNum, t2P.nChn, out pStatus, out pCount, out pFifo,
                    out pFifoCount, out pBufCount);

                if (pFifoCount >= 1024)
                {
                    if (index + pFifoCount > t2P.m_lAxis1.Count) //如果pFifoCount大于剩余点数量，
                        pFifoCount = (short) (t2P.m_lAxis1.Count - index); //=总数-已加数

                    //压入数据
                    mc.GT_2DCompareData(t2P.nCardNum, t2P.nChn, pFifoCount, ref td[preIndex], pFifo);
                    index = index + pFifoCount;
                    preIndex = preIndex + pFifoCount;
                }
            }
        }

        /// <summary>
        ///     二维位置比较参数
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="chn">通道号 0：HSIO1 ; 通道号 1: HSIO2</param>
        /// <param name="pPrm">参数</param>
        /// <returns></returns>
        public override short D2DCompareSetPrm(short nCardNum, short chn, ref object pPrm)
        {
            short nRtn = 0;
            var newPrm = (DD_COMPARE_PRM) pPrm;
            var gprm = new mc.T2DComparePrm();
            gprm.encx = newPrm.nEncx;
            gprm.ency = newPrm.nEncy;
            gprm.source = newPrm.nSource;
            gprm.outputType = newPrm.nOutputType;
            gprm.startLevel = newPrm.nStartLevel;
            gprm.time = newPrm.nTime;
            gprm.maxerr = newPrm.nMaxerr;
            gprm.threshold = newPrm.nThreshold;

            nRtn |= mc.GT_2DCompareSetPrm(nCardNum, chn, ref gprm);
            return nRtn ;
        }

        /// <summary>
        ///     启动二维位置比较
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="chn">通道号 0：HSIO1 ; 通道号 1: HSIO2</param>
        /// <returns></returns>
        public override short D2DCompareStart(short nCardNum, short chn)
        {
            short nRtn = 0;
            nRtn |= mc.GT_2DCompareStart(nCardNum, chn);

            return nRtn ;
        }

        #endregion

        #region 插补运动

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
        public override short InitLookAhead(short nCardNum, short crd, short fifo, double T, double accMax, short n,
            int lenght)
        {
            short nRtn = 0;
            m_pLookAheadBuf = new mc.TCrdData[lenght];
            nRtn |= mc.GT_InitLookAhead(nCardNum, crd, fifo, T, accMax, n, ref m_pLookAheadBuf[0]);

            return nRtn ;
        }

        /// <summary>
        ///     使用前瞻时，把前瞻缓存区的数据压入运动缓存区
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="crd">坐标系号，取值范围[1,2]</param>
        /// <param name="fifo">插补缓存区号，0：FIFO1 1：FIFO2</param>
        /// <returns></returns>
        public override short CrdData(short nCardNum, short crd, short fifo = 0)
        {
            short nRtn = 0;
            nRtn |= mc.GT_CrdData(nCardNum, crd, new IntPtr(), fifo);

            return nRtn ;
        }

        /// <summary>
        ///     读取坐标系缓冲区剩余空间大小
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="crd">坐标系号，取值范围[1,2]</param>
        /// <param name="pSpace">插补缓存的剩余空间</param>
        /// <param name="count">（灵猴）轴数</param>
        /// <param name="fifo">插补缓存区号，0：FIFO1 1：FIFO2</param>
        /// <returns></returns>
        public override short CrdSpace(short nCardNum, short crd, out int pSpace, short count = 1, short fifo = 0)
        {
            short nRtn = 0;
            nRtn |= mc.GT_CrdSpace(nCardNum, crd, out pSpace, fifo);

            return nRtn ;
        }

        /// <summary>
        ///     坐标系开始运行
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="mask">bit0 对应坐标系 1，bit1 对应坐标系 2。  0：不启动该坐标系，1：启动该坐标系。</param>
        /// <param name="option">bit0 对应坐标系 1，bit1 对应坐标系 2。  0：启动坐标系中 FIFO0 的运动，1：启动坐标系中 FIFO1 的运动。</param>
        /// <returns></returns>
        public override short CrdStart(short nCardNum, short mask, short option = 0)
        {
            short nRtn = 0;
            nRtn  |= mc.GT_CrdStart(nCardNum, mask, option);

            return nRtn ;
        }

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
        public override short CrdStatus(short nCardNum, short crd, out short pRun, out int pSegment, out short pCmdNum,
            out int pSpace, short fifo = 0)
        {
            short nRtn = 0;
            pRun = 3;
            pSegment = -1;
            pCmdNum = -1;
            pSpace = -1;
            nRtn |= mc.GT_CrdStatus(nCardNum, crd, out pRun, out pSegment, fifo);

            return nRtn ;
        }

        /// <summary>
        ///     清除插补坐标系数据
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="crd">坐标系号 1跟2</param>
        /// <param name="count">不用管</param>
        /// <param name="fifo">缓冲区号 fifo0  fifo1</param>
        /// <returns></returns>
        public override short CrdClear(short nCardNum, short crd, short fifo, short count = 1)
        {
            short nRtn = 0;
            nRtn |= mc.GT_CrdClear(nCardNum, crd, fifo);
            return nRtn ;
        }


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
        public override short LnXy(short nCardNum, short crd, int x, int y, double synVel, double synAcc,
            double velEnd = 0, short fifo = 0)
        {
            short nRtn = 0;
            nRtn |= mc.GT_LnXY(nCardNum, crd, x, y, synVel, synAcc, velEnd, fifo);
            return nRtn ;
        }

        public override short LnXyz(short nCardNum, short crd, int x, int y, int z, double synVel, double synAcc,
            double velEnd = 0, short fifo = 0)
        {
            short nRtn = 0;
            nRtn |= mc.GT_LnXYZ(nCardNum, crd, x, y, z, synVel, synAcc, velEnd, fifo);
            return nRtn ;
        }

        public override short LnXyza(short nCardNum, short crd, int x, int y, int z, int a, double synVel,
            double synAcc, double velEnd = 0, short fifo = 0)
        {
            short nRtn = 0;
            nRtn |= mc.GT_LnXYZA(nCardNum, crd, x, y, z, a, synVel, synAcc, velEnd, fifo);
            return nRtn ;
        }

        public override short ArcXyc(short nCardNum, short crd, int x, int y, double xCenter, double yCenter,
            short circleDir, double synVel, double synAcc, double velEnd = 0, short fifo = 0)
        {
            short nRtn = 0;
            nRtn |= mc.GT_ArcXYC(nCardNum, crd, x, y, xCenter, yCenter, circleDir, synVel, synAcc, velEnd, fifo);
            return nRtn ;
        }

        public override short BufIo(short nCardNum, short crd, ushort doType, ushort doMask, ushort doValue,
            short fifo = 0)
        {
            short nRtn = 0;
            nRtn |= mc.GT_BufIO(nCardNum, crd, doType, doMask, doValue, fifo);
            return nRtn ;
        }

        #endregion

        /// <summary>
        ///     设置扩展IO卡数量
        /// </summary>
        /// <param name="nCardNum"></param>
        /// <param name="count"></param>
        public override void SetExtendCardCount(short nCardNum, int count)
        {
        }

        #endregion
    }
}