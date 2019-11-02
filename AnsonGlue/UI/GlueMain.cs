using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using AnsonGlue.Kernel;
using AnsonGlue.Properties;
using AnsonGlue.Repaint;

namespace AnsonGlue.UI
{
    #region 自定义变量

    public enum ENUM_INPUT_POINT
    {
        ESTOP_BUTTON = 0, //0:急停
        START_BUTTON = 1, //1：开始
        STOP_BUTTON = 2, //2：停止
        RESET_BUTTON = 3, //3：复位
        LINE_WAIT_SENSOR = 4, //4：载具入料传感器，第一个传感器
        LINE_STOPSENSOR = 5, //5：载具到位，传送带停止，第二个传感器
        LINE_OUTSENSOR = 6, //6：载具流出，第三个传感器
        FM_OUT_TRAY = 7, //7：前机出板信号
        BM_ASK_TRAY = 8, //8：后机要板信号
        LIFT_CYL_UP = 9, //9：中间顶升气缸上到位
        LIFT_CYL_DN = 10, //10：中间顶升气缸下到位
        BLOCK_CYL_UP = 11, //11：后阻挡上到位
        BLOCK_CYL_DN = 12, //12：后阻挡下到位
        GLUE_CHECK1 = 13, //13：主阀检胶传感器
        GLUE_CHECK2 = 14, //14：副阀检胶传感器
        DOOR_SENSOR = 15, //15：门传感器
        FOR_BLOCK_UP = 16, //16: 前挡板终点
        FOR_BLOCK_DN = 17 //17: 前挡板原点
    }

    public enum ENUM_OUTPUT_POINT
    {
        GREEN_LAMP, //0：绿灯
        RED_LAMP, //1：红灯
        YELLOW_LAMP, //2：黄灯
        BUZZOR, //3：蜂鸣器
        CLEANING_VACUUM, //4：吹气清洁
        LIFT_CYL, //5：顶升气缸
        BLOCK_CYL, //6：后阻挡气缸
        FRONT_BLOCK_CYL, //7：前阻挡气缸
        CAMERA1_LIGHT1, //8：相机1光源1
        CAMERA1_LIGHT2, //9：相机1光源2
        CAMERA2_LIGHT1, //10：相机2光源1
        CAMERA2_LIGHT2, //11：相机2光源2
        ASK_TRAY, //12：向前机要板
        OUT_TRAY, //13：向后机出板
        GLUE, //14：阀点胶(气压阀出胶用普通口控制)
        PIN_CLAMPING //15：针头夹紧
    }

    /// <summary>
    ///     登陆模式枚举
    /// </summary>
    internal enum CModeSelectButtonName //模式选择窗口对应按键
    {
        PRODUCTION = 0, //生产者模式
        ENGINEER, //工程师模式
        CPK_GRR, //CPK模式
        CHECK, //设备调试模式（主要用于家里设备检查）
        DISABLE_ALL //注销
    }

    /// <summary>
    ///     窗口的枚举
    /// </summary>
    public enum CDialogName //模式选择窗口对应按键
    {
        //显示在左边
        CAMERA_IMAGE_DIALOG = 0,
        MODE_SELECT_DIALOG,
        IO_DIALOG,
        PLUGIN_DEBUG_DIALOG,

        //显示在右上角
        LOGIN_DIALOG,
        JOG_DIALOG,
        VISION_SETTING_DIALOG,

        //显示在右下角
        CHECK_DIALOG,
        FUNCTION_DIALOG,
        PARA_SETTING_DIALOG,
        PROJECT_DIALOG,
        OK_NG_DIALOG,

        //直接弹出
        OPERATION_IONFO_DIALOG,
        WARNING_DIALOG,
        GLUE_PARA_DIALOG,
        MACHINE_SET_DIALOG,

        //窗口数量
        DIALOG_NUM
    }

    #endregion

    /// <summary>
    ///     主窗体类
    /// </summary>
    public sealed partial class CGlue : Form
    {
        #region 自定义变量

        /// <summary>
        ///     主窗口工具栏按键枚举
        /// </summary>
        private enum ENUM_BTN_NAME
        {
            HOME_BTN,
            VELOCITY_BTN,
            VISION_BTN,
            WARNING_BTN,
            PRODUCE_BTN,
            START_BTN,
            SUSPEND_BTN,
            STOP_BTN,
            OPEN_EXCEL_BTN,
            OPEN_PHOTO_BTN,
            LOGIN_BTN,
            COODINATE_BTN
        }

        /// <summary>
        ///     主窗口容器Panel枚举
        /// </summary>
        private enum ENUM_PANEL_NAME
        {
            LEFT_PANEL,
            RIGHT_UP,
            RIGHT_DOWN
        }

        #endregion

        #region 成员变量

        #region 窗口声明

        /// <summary>
        ///     声明需要的窗口
        /// </summary>
        private readonly CCameraImage m_oDlgCameraImage;

        private readonly CParaSetting m_oDlgParaSetting;
        private readonly CCheck m_oDlgCheck;
        private readonly CFunctionSelect m_oDlgFunctionSelect;
        private readonly CIoDilalog m_oDlgDispalyIo;
        private readonly CMachineParaSetting m_oDlgMachineParaSetting;
        private readonly CPluginDebug m_oDlgPluginDebug;
        private CJog m_oDlgJog;
        private readonly CLogin m_oDlgLogin;
        private readonly CModeSelect m_oDlgModeSelect;
        private readonly COperationInfo m_oDlgOperationInfo;
        private readonly CPositionSetting m_oDlgPositionSetting;
        private readonly CVisionSetting m_oDlgVisionSetting;
        private readonly CWarning m_oDlgWarning;

        #endregion

        /// <summary>
        ///     主业务逻辑类
        /// </summary>
        private CKernel m_oKernel;

        /// <summary>
        ///     报警信号扫描线程标志位
        /// </summary>
        private bool m_bScanWarnningThread;

        #endregion

        #region 系统函数

        /// <summary>
        ///     构造函数
        /// </summary>
        public CGlue()
        {
            //实例化所有想要显示的窗口
            m_oDlgLogin = new CLogin();
            m_oDlgModeSelect = new CModeSelect();
            m_oDlgFunctionSelect = new CFunctionSelect();
            m_oDlgCameraImage = new CCameraImage();
            m_oDlgJog = new CJog();
            m_oDlgPositionSetting = new CPositionSetting();
            m_oDlgVisionSetting = new CVisionSetting();
            m_oDlgWarning = new CWarning();
            m_oDlgOperationInfo = new COperationInfo();
            m_oDlgCheck = new CCheck();
            m_oDlgDispalyIo = new CIoDilalog();
            m_oDlgMachineParaSetting = new CMachineParaSetting();
            m_oDlgParaSetting = new CParaSetting();
            m_oDlgPluginDebug = new CPluginDebug();


            m_bScanWarnningThread = false;

            InitializeComponent();

            //得到单例对象
            //获取文件和Tcp资源对象
            m_oKernel = CKernel.GetInstance();

            //与主业务逻辑类建立联系，使用自描述语言
            m_oKernel.m_eDisplayMsg += DisplayMsg;
        }

        /// <summary>
        ///     界面移动的时候，刷新界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CGlue_Move(object sender, EventArgs e)
        {
            Refresh();
        }

        /// <summary>
        ///     界面初始化加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Glue_Load(object sender, EventArgs e)
        {
            //初始化按键图片
            InitAllButtonImage();
            m_bLogin.Image = Resources.Login_sel;
            ShowForm(m_pRightUp, m_oDlgLogin);
            ShowForm(m_pRightDown, m_oDlgFunctionSelect);
            ShowForm(m_pLeft, m_oDlgModeSelect);

            //与模式选择窗口建立联系
            m_oDlgLogin.m_eChangeModel += ChangeModelSelectBtn;
            //修改主窗口颜色事件
            m_oDlgModeSelect.m_eChangeMainDialogColorBtn += ChangeMainDialogBackColorBtn;
            //调制窗口修改主窗口显示事件
            m_oDlgCheck.m_eDisplayDlg += DisplayDialogInLeft;
            //关闭所有使能
            EnableAllBtn(false);
            //打开登陆按键使能
            m_bLogin.Enabled = true;


            //********************电子秤-------现在写界面，先屏蔽***************************//
            var bRtn = CreatAndConnectBalance();
            if (!bRtn)
            {
                MessageBox.Show(@"连接电子秤失败！");
                m_oKernel.DisplayAndRecordWarningInfo(@"连接电子秤失败！");
            }

            //********************扫码枪-------现在写界面，先屏蔽***************************//
            bRtn = CreatAndConnectScanner();
            if (!bRtn)
            {
                MessageBox.Show(@"连接扫码枪失败！");
                m_oKernel.DisplayAndRecordWarningInfo(@"连接扫码枪失败！");
            }

            //********************视觉-------现在写界面，先屏蔽***************************//
            bRtn = CreatAndConnectVision();
            if (!bRtn)
            {
                MessageBox.Show(@"连接视觉失败！");
                m_oKernel.DisplayAndRecordWarningInfo(@"连接视觉失败！");
            }


            //创建板卡为固高，卡号为0的板卡对象
            var listAxisRes = new List<string> {"", "", "", "", "", "", "", ""};
            var sMotionCard =
                new CKernel.STRUCT_MOTION_CARD(@"Googol", @"0", @"", listAxisRes);
            //从配置文件得到指定卡的详细信息
            m_oKernel.GetMachineParaFromIni(ref sMotionCard);
            //如果得不到最大轴数，说明没有设置相应参数
            if (sMotionCard.m_strMaxAxisNum.Length == 0)
            {
                MessageBox.Show(@"该板卡信息没有设置!");
                m_oKernel.DisplayAndRecordWarningInfo(@"该板卡信息没有设置！");
                return;
            }

            var nMaxAxisNum = Convert.ToInt32(sMotionCard.m_strMaxAxisNum);


            //为程序增加运动控制板卡
            if (!m_oKernel.AddMotionCard(0, (short) nMaxAxisNum))
            {
                m_oKernel.DisplayAndRecordWarningInfo(@"添加运动板卡失败！");
                return;
            }

            //板卡初始化
            switch (m_oKernel.InitMotionCard(sMotionCard))
            {
                case -1: //没有添加运动控制板卡
                    m_oKernel.DisplayAndRecordWarningInfo(@"运动控制板卡为空，请先添加运动控制板卡！");
                    return;
                case -2:
                    m_oKernel.DisplayAndRecordWarningInfo(@"运动控制板卡初始化失败！");
                    break;
                case 0:
                    ////开启急停监控线程
                    var tScanWarnningThread = new Thread(ScanWarnningThread) {IsBackground = true};
                    tScanWarnningThread.Start();
                    m_bScanWarnningThread = true;
                    break;
            }
        }

        /// <summary>
        ///     创造并连接电子秤
        /// </summary>
        /// <returns></returns>
        private bool CreatAndConnectBalance()
        {
            //获取电子秤通讯方式
            var tCmtBalanceInfo = m_oKernel.GetCmtPara(@"电子秤");
            //创造电子秤对象
            m_oKernel.CreatBalance(tCmtBalanceInfo);
            //把软件和硬件联系在一起
            var bRtn = m_oKernel.ConnectBalance(ReceiverBalanceMsg);
            return bRtn;
        }

        /// <summary>
        ///     创造并连接扫码枪
        /// </summary>
        /// <returns></returns>
        private bool CreatAndConnectScanner()
        {
            //获取扫码枪通讯方式
            var tCmtScannerInfo = m_oKernel.GetCmtPara(@"扫码枪");
            //创造扫码枪对象
            m_oKernel.CreatScanner(tCmtScannerInfo);
            //把软件和硬件联系在一起
            var bRtn = m_oKernel.ConnectScanner(ReceiverScannerMsg);
            return bRtn;
        }

        /// <summary>
        ///     创造并连接视觉
        /// </summary>
        /// <returns></returns>
        private bool CreatAndConnectVision()
        {
            //获取视觉通讯方式
            var tCmtVisionInfo = m_oKernel.GetCmtPara(@"视觉");
            //创造视觉对象
            m_oKernel.CreatVision(tCmtVisionInfo);
            //和视觉联系在一起
            var bRtn = m_oKernel.ConnectVision(ReceiverVisionMsg);
            return bRtn;
        }

        /// <summary>
        ///     点击Home按钮
        /// </summary>
        /// <param name="sender">就是按钮自己的引用</param>
        /// <param name="e">事件描述，包括位置信息，左右键等</param>
        private void m_bHome_Click(object sender, EventArgs e)
        {
            UpdateMainDisplay((ushort) ENUM_BTN_NAME.HOME_BTN);
        }

        /// <summary>
        ///     点击Setting按钮
        /// </summary>
        /// <param name="sender">就是按钮自己的引用</param>
        /// <param name="e">事件描述，包括位置信息，左右键等</param>
        private void m_bSetting_Click(object sender, EventArgs e)
        {
            UpdateMainDisplay((ushort) ENUM_BTN_NAME.VELOCITY_BTN);
        }

        /// <summary>
        ///     点击Vision按钮
        /// </summary>
        /// <param name="sender">就是按钮自己的引用</param>
        /// <param name="e">事件描述，包括位置信息，左右键等</param>
        private void m_bVision_Click(object sender, EventArgs e)
        {
            UpdateMainDisplay((ushort) ENUM_BTN_NAME.VISION_BTN);
        }

        /// <summary>
        ///     点击Warning按钮
        /// </summary>
        /// <param name="sender">就是按钮自己的引用</param>
        /// <param name="e">事件描述，包括位置信息，左右键等</param>
        private void m_bWarning_Click(object sender, EventArgs e)
        {
            UpdateMainDisplay((ushort) ENUM_BTN_NAME.WARNING_BTN);
        }

        /// <summary>
        ///     点击ProduceDate按钮
        /// </summary>
        /// <param name="sender">就是按钮自己的引用</param>
        /// <param name="e">事件描述，包括位置信息，左右键等</param>
        private void m_bProduceDate_Click(object sender, EventArgs e)
        {
            UpdateMainDisplay((ushort) ENUM_BTN_NAME.PRODUCE_BTN);
        }

        /// <summary>
        ///     点击Start按钮
        /// </summary>
        /// <param name="sender">就是按钮自己的引用</param>
        /// <param name="e">事件描述，包括位置信息，左右键等</param>
        private void m_bStart_Click(object sender, EventArgs e)
        {
            UpdateMainDisplay((ushort) ENUM_BTN_NAME.START_BTN);
        }

        /// <summary>
        ///     点击Suspend按钮
        /// </summary>
        /// <param name="sender">就是按钮自己的引用</param>
        /// <param name="e">事件描述，包括位置信息，左右键等</param>
        private void m_bSuspend_Click(object sender, EventArgs e)
        {
            UpdateMainDisplay((ushort) ENUM_BTN_NAME.SUSPEND_BTN);
        }

        /// <summary>
        ///     点击Stop按钮
        /// </summary>
        /// <param name="sender">就是按钮自己的引用</param>
        /// <param name="e">事件描述，包括位置信息，左右键等</param>
        private void m_bStop_Click(object sender, EventArgs e)
        {
            UpdateMainDisplay((ushort) ENUM_BTN_NAME.STOP_BTN);
        }

        /// <summary>
        ///     点击OpenExcelDir按钮 用于打开Excel目录
        /// </summary>
        /// <param name="sender">就是按钮自己的引用</param>
        /// <param name="e">事件描述，包括位置信息，左右键等</param>
        private void m_pOpenExcelDir_Click(object sender, EventArgs e)
        {
            var strPath = m_oKernel.GetExcelImageDirFromIni(@"Excel");
            if (Directory.Exists(strPath))
            {
                Process.Start(strPath);
            }
            else
            {
                MessageBox.Show(@"表格路径不存在，请设置路径！");
                m_oKernel.DisplayAndRecordWarningInfo(@"表格路径不存在，请设置路径！");
            }
        }

        /// <summary>
        ///     点击ImageOpen按钮，用于打开保存Image的目录
        /// </summary>
        /// <param name="sender">就是按钮自己的引用</param>
        /// <param name="e">事件描述，包括位置信息，左右键等</param>
        private void m_pOpenImageDir_Click(object sender, EventArgs e)
        {
            var strPath = m_oKernel.GetExcelImageDirFromIni(@"Image");
            if (Directory.Exists(strPath))
            {
                Process.Start(strPath);
            }
            else
            {
                MessageBox.Show(@"图片路径不存在，请设置路径！");
                m_oKernel.DisplayAndRecordWarningInfo(@"图片路径不存在，请设置路径！");
            }
        }

        /// <summary>
        ///     点击Login按钮，显示登陆窗口
        /// </summary>
        /// <param name="sender">就是按钮自己的引用</param>
        /// <param name="e">事件描述，包括位置信息，左右键等</param>
        private void m_bLogin_Click(object sender, EventArgs e)
        {
            UpdateMainDisplay((ushort) ENUM_BTN_NAME.LOGIN_BTN);
        }

        /// <summary>
        ///     点击运动控制按键，显示运动控制界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_rBtnCoordinate_Click(object sender, EventArgs e)
        {
            UpdateMainDisplay((ushort) ENUM_BTN_NAME.COODINATE_BTN);
        }

        /// <summary>
        ///     用于接收电子秤消息的回调函数
        /// </summary>
        /// <param name="strMsg"></param>
        private void ReceiverBalanceMsg(string strMsg)
        {
            Console.Write(strMsg);
        }

        /// <summary>
        ///     用于接收扫码枪消息的回调函数
        /// </summary>
        /// <param name="strMsg"></param>
        private void ReceiverScannerMsg(string strMsg)
        {
            Console.Write(strMsg);
        }

        /// <summary>
        ///     用于接收视觉消息的回调函数
        /// </summary>
        /// <param name="strMsg"></param>
        private void ReceiverVisionMsg(string strMsg)
        {
            Console.Write(strMsg);
        }

        /// <summary>
        ///     监控报警按键线程
        /// </summary>
        private void ScanWarnningThread()
        {
            while (true)
            {
                //m_bScanWarnningThread是监控报警线程标志位，用来退出线程
                if (!m_bScanWarnningThread) return;
                if (m_oKernel.GetDiSts(0, (ushort) ENUM_INPUT_POINT.ESTOP_BUTTON))
                {
                    m_oKernel.SetEStop(0); //表示按下
                    m_oKernel.ClrSts(0, 1, 4);
                }
                else
                {
                    m_oKernel.ClrSts(0, 1, 4);
                }
            }
        }

        /// <summary>
        ///     关闭弹出的窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CGlue_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_oDlgWarning.Close();
            m_oDlgOperationInfo.Close();
            m_bScanWarnningThread = false;
        }

        #endregion

        #region 自定义函数

        /// <summary>
        ///     在指定的Panel上显示指定的窗体
        /// </summary>
        /// <param name="panel">Panel的引用</param>
        /// <param name="frm">窗体的引用</param>
        private void ShowForm(CRoundPanel panel, Form frm)
        {
            lock (this)
            {
                frm.TopLevel = false;
                frm.Parent = panel;
                panel.Controls.Clear();
                panel.Controls.Add(frm);
                frm.Show();
                frm.Dock = DockStyle.Fill;
                Refresh();
            }
        }

        /// <summary>
        ///     初始化按钮的图片，在每次点击按键时在第一步使用
        /// </summary>
        private void InitAllButtonImage()
        {
            m_bHome.Image = Resources.Home;
            m_bSetting.Image = Resources.Setting;
            m_bVision.Image = Resources.Vision;
            m_bWarning.Image = Resources.Warnning;
            m_bProduceDate.Image = Resources.ProduceData;
            m_bStart.Image = Resources.Start;
            m_bSuspend.Image = Resources.Suspend;
            m_bStop.Image = Resources.Stop;
            m_bLogin.Image = Resources.Login;
        }

        /// <summary>
        ///     根据工具栏按钮更新主窗口显示
        /// </summary>
        /// <param name="uBtn"></param>
        private void UpdateMainDisplay(ushort uBtn)
        {
            InitAllButtonImage();
            switch (uBtn)
            {
                //Home按钮
                case (ushort) ENUM_BTN_NAME.HOME_BTN:
                    m_bHome.Image = Resources.Home_sel;
                    ShowForm(m_pRightDown, m_oDlgFunctionSelect);
                    ShowForm(m_pLeft, m_oDlgCameraImage);
                    break;
                //设置按钮
                case (ushort) ENUM_BTN_NAME.VELOCITY_BTN:
                    m_bSetting.Image = Resources.Setting_sel;
                    ShowForm(m_pRightDown, m_oDlgParaSetting);
                    ShowForm(m_pRightUp, m_oDlgPositionSetting);
                    ShowForm(m_pLeft, m_oDlgCameraImage);
                    break;
                //视觉按钮
                case (ushort) ENUM_BTN_NAME.VISION_BTN:
                    m_bVision.Image = Resources.Vision_sel;
                    ShowForm(m_pRightUp, m_oDlgVisionSetting);
                    ShowForm(m_pLeft, m_oDlgCameraImage);
                    break;
                //报警按钮
                case (ushort) ENUM_BTN_NAME.WARNING_BTN:
                    m_bWarning.Image = Resources.Warnning_sel;
                    m_oDlgWarning.Show();
                    break;
                //操作信息窗口
                case (ushort) ENUM_BTN_NAME.PRODUCE_BTN:
                    m_bProduceDate.Image = Resources.ProduceData_sel;
                    m_oDlgOperationInfo.Show();
                    break;
                //开始按钮
                case (ushort) ENUM_BTN_NAME.START_BTN:
                    m_bStart.Image = Resources.Start_sel;
                    break;
                //暂停按钮
                case (ushort) ENUM_BTN_NAME.SUSPEND_BTN:
                    m_bSuspend.Image = Resources.Suspend_sel;
                    break;
                //停止按钮
                case (ushort) ENUM_BTN_NAME.STOP_BTN:
                    m_bStop.Image = Resources.Stop_sel;
                    break;
                //登陆按钮
                case (ushort) ENUM_BTN_NAME.LOGIN_BTN:
                    m_bLogin.Image = Resources.Login_sel;
                    ShowForm(m_pRightUp, m_oDlgLogin);
                    ShowForm(m_pRightDown, m_oDlgFunctionSelect);
                    ShowForm(m_pLeft, m_oDlgModeSelect);
                    break;
                //坐标系按钮
                case (ushort) ENUM_BTN_NAME.COODINATE_BTN:
                    // m_bLogin.Image = Resources.Login_sel;
                    if (m_oDlgJog == null || m_oDlgJog.IsDisposed) m_oDlgJog = new CJog();
                    m_oDlgJog.Show();
                    break;
            }
        }

        /// <summary>
        ///     修改模式选择窗口按钮状态
        /// </summary>
        /// <param name="iModel"></param>
        private void ChangeModelSelectBtn(int iModel)
        {
            m_oDlgModeSelect.ChangeBtnStatus(iModel);
            m_oDlgFunctionSelect.EnableAllBtn(true);
        }

        /// <summary>
        ///     修改主窗口背景颜色和按键使能状态
        /// </summary>
        /// <param name="iModel">模式选择</param>
        private void ChangeMainDialogBackColorBtn(int iModel)
        {
            switch (iModel)
            {
                //生产模式
                case (int) CModeSelectButtonName.PRODUCTION:
                    BackColor = Color.White;
                    EnableAllBtn(false);
                    m_bHome.Enabled = true;
                    m_bStart.Enabled = true;
                    m_bStop.Enabled = true;
                    m_bSuspend.Enabled = true;
                    m_pOpenExcelDir.Enabled = true;
                    m_pOpenImageDir.Enabled = true;
                    m_bWarning.Enabled = true;
                    m_bProduceDate.Enabled = true;
                    break;
                //工程师模式
                case (int) CModeSelectButtonName.ENGINEER:
                    BackColor = Color.FromArgb(255, 192, 203);
                    EnableAllBtn(true);
                    break;
                //cpk模式
                case (int) CModeSelectButtonName.CPK_GRR:
                    BackColor = Color.White;
                    EnableAllBtn(true);
                    break;
                //调试模式
                case (int) CModeSelectButtonName.CHECK:
                    BackColor = Color.White;
                    //ShowForm(m_pRightUp, m_oDlgOfJog);
                    ShowForm(m_pRightDown, m_oDlgCheck);
                    EnableAllBtn(true);
                    break;
                //全部关使能
                case (int) CModeSelectButtonName.DISABLE_ALL:
                    BackColor = Color.White;
                    EnableAllBtn(false);
                    break;
                default:
                    BackColor = Color.White;
                    break;
            }
        }

        /// <summary>
        ///     修改所有按钮的使能状态
        /// </summary>
        /// <param name="bEnable"></param>
        private void EnableAllBtn(bool bEnable)
        {
            m_bHome.Enabled = bEnable;
            m_bVision.Enabled = bEnable;
            m_bSetting.Enabled = bEnable;
            m_bWarning.Enabled = bEnable;
            m_bProduceDate.Enabled = bEnable;
            m_bStart.Enabled = bEnable;
            m_bSuspend.Enabled = bEnable;
            m_bStop.Enabled = bEnable;
            m_pOpenExcelDir.Enabled = bEnable;
            m_pOpenImageDir.Enabled = bEnable;
        }

        /// <summary>
        ///     回调函数， 作用：在左边窗口显示相应子窗口
        /// </summary>
        /// <param name="uDialog">窗口的枚举</param>
        private void DisplayDialogInLeft(CDialogName uDialog)
        {
            switch (uDialog)
            {
                //显示在左边
                case CDialogName.CAMERA_IMAGE_DIALOG:
                    ShowForm(m_pLeft, m_oDlgCameraImage);
                    break;
                case CDialogName.MODE_SELECT_DIALOG:
                    ShowForm(m_pLeft, m_oDlgModeSelect);
                    break;
                case CDialogName.IO_DIALOG:
                    ShowForm(m_pLeft, m_oDlgDispalyIo);
                    break;
                case CDialogName.MACHINE_SET_DIALOG:
                    ShowForm(m_pLeft, m_oDlgMachineParaSetting);
                    break;
                case CDialogName.PLUGIN_DEBUG_DIALOG:
                    ShowForm(m_pLeft, m_oDlgPluginDebug);
                    break;
            }
        }

        /// <summary>
        ///     接收子描述语言，解析后对各个窗口操作
        /// </summary>
        /// <param name="strMsg"></param>
        private void DisplayMsg(string strMsg)
        {
            var strsMsg = strMsg.Split(';');
            switch (strsMsg[0])
            {
                case "Warning":
                    m_oDlgWarning.AddWarningMsg(strsMsg[1]);
                    break;
                case "Operation":
                    m_oDlgOperationInfo.AddOperationInfo(strsMsg[1]);
                    break;
            }
        }

        #endregion
    }
}