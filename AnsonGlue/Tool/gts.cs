using System.Runtime.InteropServices;

namespace AnsonGlue.Tool
{
    public class CMc
    {
        public const short m_c_DLL_VERSION_0 = 2;
        public const short m_c_DLL_VERSION_1 = 1;
        public const short m_c_DLL_VERSION_2 = 0;

        public const short m_c_DLL_VERSION_3 = 1;
        public const short m_c_DLL_VERSION_4 = 5;
        public const short m_c_DLL_VERSION_5 = 0;
        public const short m_c_DLL_VERSION_6 = 6;
        public const short m_c_DLL_VERSION_7 = 0;
        public const short m_c_DLL_VERSION_8 = 7;

        public const short m_c_MC_NONE = -1;

        public const short m_c_MC_LIMIT_POSITIVE = 0;
        public const short m_c_MC_LIMIT_NEGATIVE = 1;
        public const short m_c_MC_ALARM = 2;
        public const short m_c_MC_HOME = 3;
        public const short m_c_MC_GPI = 4;
        public const short m_c_MC_ARRIVE = 5;
        public const short m_c_MC_MPG = 6;

        public const short m_c_MC_ENABLE = 10;
        public const short m_c_MC_CLEAR = 11;
        public const short m_c_MC_GPO = 12;

        public const short m_c_MC_DAC = 20;
        public const short m_c_MC_STEP = 21;
        public const short m_c_MC_PULSE = 22;
        public const short m_c_MC_ENCODER = 23;
        public const short m_c_MC_ADC = 24;

        public const short m_c_MC_AXIS = 30;
        public const short m_c_MC_PROFILE = 31;
        public const short m_c_MC_CONTROL = 32;

        public const short m_c_CAPTURE_HOME = 1;
        public const short m_c_CAPTURE_INDEX = 2;
        public const short m_c_CAPTURE_PROBE = 3;
        public const short m_c_CAPTURE_HSIO0 = 6;
        public const short m_c_CAPTURE_HSIO1 = 7;
        public const short m_c_CAPTURE_HOME_GPI = 8;

        public const short m_c_PT_MODE_STATIC = 0;
        public const short m_c_PT_MODE_DYNAMIC = 1;

        public const short m_c_PT_SEGMENT_NORMAL = 0;
        public const short m_c_PT_SEGMENT_EVEN = 1;
        public const short m_c_PT_SEGMENT_STOP = 2;

        public const short m_c_GEAR_MASTER_ENCODER = 1;
        public const short m_c_GEAR_MASTER_PROFILE = 2;
        public const short m_c_GEAR_MASTER_AXIS = 3;

        public const short m_c_FOLLOW_MASTER_ENCODER = 1;
        public const short m_c_FOLLOW_MASTER_PROFILE = 2;
        public const short m_c_FOLLOW_MASTER_AXIS = 3;

        public const short m_c_FOLLOW_EVENT_START = 1;
        public const short m_c_FOLLOW_EVENT_PASS = 2;

        public const short m_c_GEAR_EVENT_START = 1;
        public const short m_c_GEAR_EVENT_PASS = 2;
        public const short m_c_GEAR_EVENT_AREA = 5;

        public const short m_c_FOLLOW_SEGMENT_NORMAL = 0;
        public const short m_c_FOLLOW_SEGMENT_EVEN = 1;
        public const short m_c_FOLLOW_SEGMENT_STOP = 2;
        public const short m_c_FOLLOW_SEGMENT_CONTINUE = 3;

        public const short m_c_INTERPOLATION_AXIS_MAX = 4;
        public const short m_c_CRD_FIFO_MAX = 4096;
        public const short m_c_FIFO_MAX = 2;
        public const short m_c_CRD_MAX = 2;
        public const short m_c_CRD_OPERATION_DATA_EXT_MAX = 2;

        public const short m_c_CRD_OPERATION_TYPE_NONE = 0;
        public const short m_c_CRD_OPERATION_TYPE_BUF_IO_DELAY = 1;
        public const short m_c_CRD_OPERATION_TYPE_LASER_ON = 2;
        public const short m_c_CRD_OPERATION_TYPE_LASER_OFF = 3;
        public const short m_c_CRD_OPERATION_TYPE_BUF_DA = 4;
        public const short m_c_CRD_OPERATION_TYPE_LASER_CMD = 5;
        public const short m_c_CRD_OPERATION_TYPE_LASER_FOLLOW = 6;
        public const short m_c_CRD_OPERATION_TYPE_LMTS_ON = 7;
        public const short m_c_CRD_OPERATION_TYPE_LMTS_OFF = 8;
        public const short m_c_CRD_OPERATION_TYPE_SET_STOP_IO = 9;
        public const short m_c_CRD_OPERATION_TYPE_BUF_MOVE = 10;
        public const short m_c_CRD_OPERATION_TYPE_BUF_GEAR = 11;
        public const short m_c_CRD_OPERATION_TYPE_SET_SEG_NUM = 12;
        public const short m_c_CRD_OPERATION_TYPE_STOP_MOTION = 13;
        public const short m_c_CRD_OPERATION_TYPE_SET_VAR_VALUE = 14;
        public const short m_c_CRD_OPERATION_TYPE_JUMP_NEXT_SEG = 15;
        public const short m_c_CRD_OPERATION_TYPE_SYNCH_PRF_POS = 16;
        public const short m_c_CRD_OPERATION_TYPE_VIRTUAL_TO_ACTUAL = 17;
        public const short m_c_CRD_OPERATION_TYPE_SET_USER_VAR = 18;
        public const short m_c_CRD_OPERATION_TYPE_SET_DO_BIT_PULSE = 19;
        public const short m_c_CRD_OPERATION_TYPE_BUF_COMPAREPULSE = 20;
        public const short m_c_CRD_OPERATION_TYPE_LASER_ON_EX = 21;
        public const short m_c_CRD_OPERATION_TYPE_LASER_OFF_EX = 22;
        public const short m_c_CRD_OPERATION_TYPE_LASER_CMD_EX = 23;
        public const short m_c_CRD_OPERATION_TYPE_LASER_FOLLOW_RATIO_EX = 24;
        public const short m_c_CRD_OPERATION_TYPE_LASER_FOLLOW_MODE = 25;
        public const short m_c_CRD_OPERATION_TYPE_LASER_FOLLOW_OFF = 26;
        public const short m_c_CRD_OPERATION_TYPE_LASER_FOLLOW_OFF_EX = 27;
        public const short m_c_CRD_OPERATION_TYPE_LASER_FOLLOW_SPLINE = 28;
        public const short m_c_CRD_OPERATION_TYPE_MOTION_DATA = 29;
        
        public const short m_c_CRD_OPERATION_TYPE_BUF_TREND = 50;
        
        public const short m_c_CRD_OPERATION_TYPE_BUF_EVENT_ON = 70;
        public const short m_c_CRD_OPERATION_TYPE_BUF_EVENT_OFF = 71;

        public const short m_c_INTERPOLATION_MOTION_TYPE_LINE = 0;
        public const short m_c_INTERPOLATION_MOTION_TYPE_CIRCLE = 1;
        public const short m_c_INTERPOLATION_MOTION_TYPE_HELIX = 2;
        public const short m_c_INTERPOLATION_MOTION_TYPE_CIRCLE_3_D = 3;

        public const short m_c_INTERPOLATION_CIRCLE_PLAT_XY = 0;
        public const short m_c_INTERPOLATION_CIRCLE_PLAT_YZ = 1;
        public const short m_c_INTERPOLATION_CIRCLE_PLAT_ZX = 2;

        public const short m_c_INTERPOLATION_HELIX_CIRCLE_XY_LINE_Z = 0;
        public const short m_c_INTERPOLATION_HELIX_CIRCLE_YZ_LINE_X = 1;
        public const short m_c_INTERPOLATION_HELIX_CIRCLE_ZX_LINE_Y = 2;

        public const short m_c_INTERPOLATION_CIRCLE_DIR_CW = 0;
        public const short m_c_INTERPOLATION_CIRCLE_DIR_CCW = 1;

        public const short m_c_COMPARE_PORT_HSIO = 0;
        public const short m_c_COMPARE_PORT_GPO = 1;

        public const short m_c_COMPARE2_D_MODE_2_D = 1;
        public const short m_c_COMPARE2_D_MODE_1_D = 0;

        public const short m_c_INTERFACEBOARD20 = 2;
        public const short m_c_INTERFACEBOARD30 = 3;

        public const short m_c_AXIS_LASER = 7;
        public const short m_c_AXIS_LASER_EX = 8;

        public const short m_c_LASER_CTRL_MODE_PWM1 = 0;
        public const short m_c_LASER_CTRL_FREQUENCY = 1;
        public const short m_c_LASER_CTRL_VOLTAGE = 2;
        public const short m_c_LASER_CTRL_MODE_PWM2 = 3;
        
        public const short m_c_CRD_BUFFER_MODE_DYNAMIC_DEFAULT = 0;
        public const short m_c_CRD_BUFFER_MODE_DYNAMIC_KEEP = 1;
        public const short m_c_CRD_BUFFER_MODE_STATIC_INPUT = 11;
        public const short m_c_CRD_BUFFER_MODE_STATIC_READY = 12;
        public const short m_c_CRD_BUFFER_MODE_STATIC_START = 13;
        
        public const short m_c_CRD_SMOOTH_MODE_NONE = 0;
        public const short m_c_CRD_SMOOTH_MODE_PERCENT = 1;
        public const short m_c_CRD_SMOOTH_MODE_JERK = 2;

        public struct TRAP_PRM
        {
            public double m_acc;
            public double m_dec;
            public double m_velStart;
            public short  m_smoothTime;
        }

        public struct JOG_PRM
        {
            public double m_acc;
            public double m_dec;
            public double m_smooth;
        }

        public struct PID
        {
            public double m_kp;
            public double m_ki;
            public double m_kd;
            public double m_kvff;
            public double m_kaff;

            public int m_integralLimit;
            public int m_derivativeLimit;
            public short  m_limit;
        }

        public struct THREAD_STS
        {
            public short m_run;
            public short m_error;
            public double m_result;
            public short m_line;
        }

        public struct VAR_INFO
        {
            public short m_id;
            public short m_dataType;
            public double m_dumb0;
            public double m_dumb1;
            public double m_dumb2;
            public double m_dumb3;
        }
        public struct COMPILE_INFO
        {
            public string m_pFileName;
            public short m_pLineNo1;
            public short m_pLineNo2;
            public string m_pMessage;
        }
        public struct CRD_PRM
        {
            public short m_dimension;
            public short m_profile1;
            public short m_profile2;
            public short m_profile3;
            public short m_profile4;
            public short m_profile5;
            public short m_profile6;
            public short m_profile7;
            public short m_profile8;

            public double m_synVelMax;
            public double m_synAccMax;
            public short m_evenTime;
            public short m_setOriginFlag;
            public int m_originPos1;
            public int m_originPos2;
            public int m_originPos3;
            public int m_originPos4;
            public int m_originPos5;
            public int m_originPos6;
            public int m_originPos7;
            public int m_originPos8;
        }

        public struct CRD_BUF_OPERATION
        {
            public short m_flag;
            public ushort m_delay;
            public short m_doType;
            public ushort m_doMask;
            public ushort m_doValue;
            public ushort m_dataExt1;
            public ushort m_dataExt2;
        }

        public struct CRD_DATA
        {
            public short m_motionType;
            public short m_circlePlat;
            public int m_pos1;
            public int m_pos2;
            public int m_pos3;
            public int m_pos4;
            public int m_pos5;
            public int m_pos6;
            public int m_pos7;
            public int m_pos8;
            public double m_radius;
            public short m_circleDir;
            public double m_lCenterX;
            public double m_lCenterY;
            public double m_lCenterZ;
            public double m_vel;
            public double m_acc;
            public short m_velEndZero;
            public CRD_BUF_OPERATION m_operation;

            public double m_cos1;
            public double m_cos2;
            public double m_cos3;
            public double m_cos4;
            public double m_cos5;
            public double m_cos6;
            public double m_cos7;
            public double m_cos8;
            public double m_velEnd;
            public double m_velEndAdjust;
            public double m_r;
        }

        public struct TRIGGER
        {
            public short m_encoder;
            public short m_probeType;
            public short m_probeIndex;
            public short m_offset;
            public short m_windowOnly;
            public int m_firstPosition;
            public int m_lastPosition;
        }

        public struct TRIGGER_STATUS
        {
            public short m_execute;
            public short m_done;
            public int m_position;
        }
        
        public struct TRIGGER_STATUS_EX
        {
        		public short m_execute;
        		public short m_done;
        		public int m_position;
        		public int m_clock;
        		public int m_loopCount;
        }

        public struct T2_D_COMPARE_DATA
        {
            public int m_px;
            public int m_py;
        }

        public struct T2_D_COMPARE_PRM
        {
            public short m_encx;
            public short m_ency;
            public short m_source;
            public short m_outputType;
            public short m_startLevel;
            public short m_time;
            public short m_maxerr;
            public short m_threshold; 
        }
        
        public struct CRD_TIME
      	{
      			public double m_time;
      			public int m_segmentUsed;
      			public int m_segmentHead;
      			public int m_segmentTail;
      	}
      	
      	public struct CRD_SMOOTH_INFO
      	{
      			public short m_enable;
      			public short m_smoothMode;
      			public short m_percent;
      			public short m_accStartPercent;
      			public short m_decEndPercent;
      			public double m_jerkMax;
      	}
      	
      	public struct CRD_SMOOTH
      	{
      			public short m_percent;
      			public short m_accStartPercent;
      			public short m_decEndPercent;
      			public double m_reserve;
      	}
      	
        [DllImport("gts.dll")]
        public static extern short GT_GetDllVersion(short cardNum,out string pDllVersion);
        [DllImport("gts.dll")]
        public static extern short GT_SetCardNo(short cardNum,short index);
        [DllImport("gts.dll")]
        public static extern short GT_GetCardNo(short cardNum,out short index);

        [DllImport("gts.dll")]
        public static extern short GT_GetVersion(short cardNum,out string pVersion);
        [DllImport("gts.dll")]
        public static extern short GT_GetInterfaceBoardSts(short cardNum,out short pStatus);
        [DllImport("gts.dll")]
        public static extern short GT_SetInterfaceBoardSts(short cardNum,short type);

        [DllImport("gts.dll")]
        public static extern short GT_Open(short cardNum,short channel,short param);
        [DllImport("gts.dll")]
        public static extern short GT_Close(short cardNum);

        [DllImport("gts.dll")]
        public static extern short GT_LoadConfig(short cardNum,string pFile);

        [DllImport("gts.dll")]
        public static extern short GT_AlarmOff(short cardNum,short axis);
        [DllImport("gts.dll")]
        public static extern short GT_AlarmOn(short cardNum,short axis);
        [DllImport("gts.dll")]
        public static extern short GT_LmtsOn(short cardNum,short axis, short limitType);
        [DllImport("gts.dll")]
        public static extern short GT_LmtsOff(short cardNum,short axis, short limitType);
        [DllImport("gts.dll")]
        public static extern short GT_ProfileScale(short cardNum,short axis, short alpha, short beta);
        [DllImport("gts.dll")]
        public static extern short GT_EncScale(short cardNum,short axis, short alpha, short beta);
        [DllImport("gts.dll")]
        public static extern short GT_StepDir(short cardNum,short step);
        [DllImport("gts.dll")]
        public static extern short GT_StepPulse(short cardNum,short step);
        [DllImport("gts.dll")]
        public static extern short GT_SetMtrBias(short cardNum,short dac, short bias);
        [DllImport("gts.dll")]
        public static extern short GT_GetMtrBias(short cardNum,short dac, out short pBias);
        [DllImport("gts.dll")]
        public static extern short GT_SetMtrLmt(short cardNum,short dac, short limit);
        [DllImport("gts.dll")]
        public static extern short GT_GetMtrLmt(short cardNum,short dac, out short pLimit);
        [DllImport("gts.dll")]
        public static extern short GT_EncSns(short cardNum,ushort sense);
        [DllImport("gts.dll")]
        public static extern short GT_EncOn(short cardNum,short encoder);
        [DllImport("gts.dll")]
        public static extern short GT_EncOff(short cardNum,short encoder);
        [DllImport("gts.dll")]
        public static extern short GT_SetPosErr(short cardNum,short control, int error);
        [DllImport("gts.dll")]
        public static extern short GT_GetPosErr(short cardNum,short control, out int pError);
        [DllImport("gts.dll")]
        public static extern short GT_SetStopDec(short cardNum,short profile, double decSmoothStop, double decAbruptStop);
        [DllImport("gts.dll")]
        public static extern short GT_GetStopDec(short cardNum,short profile, out double pDecSmoothStop, out double pDecAbruptStop);
        [DllImport("gts.dll")]
        public static extern short GT_LmtSns(short cardNum,ushort sense);
        [DllImport("gts.dll")]
        public static extern short GT_CtrlMode(short cardNum,short axis, short mode);
        [DllImport("gts.dll")]
        public static extern short GT_SetStopIo(short cardNum,short axis, short stopType, short inputType, short inputIndex);
        [DllImport("gts.dll")]
        public static extern short GT_GpiSns(short cardNum,ushort sense);
        [DllImport("gts.dll")]
        public static extern short GT_SetAdcFilter(short cardNum,short adc,short filterTime);
        [DllImport("gts.dll")]
        public static extern short GT_SetAxisPrfVelFilter(short cardNum,short axis,short filterNumExp);
        [DllImport("gts.dll")]
        public static extern short GT_GetAxisPrfVelFilter(short cardNum,short axis,out short pFilterNumExp);
        [DllImport("gts.dll")]
        public static extern short GT_SetAxisEncVelFilter(short cardNum,short axis,short filterNumExp);
        [DllImport("gts.dll")]
        public static extern short GT_GetAxisEncVelFilter(short cardNum,short axis,out short pFilterNumExp);
        [DllImport("gts.dll")]
        public static extern short GT_SetAxisInputShaping(short cardNum,short axis, short enable, short count, double k);

        [DllImport("gts.dll")]
        public static extern short GT_SetDo(short cardNum,short doType,int value);
        [DllImport("gts.dll")]
        public static extern short GT_SetDoBit(short cardNum,short doType,short doIndex,short value);
        [DllImport("gts.dll")]
        public static extern short GT_GetDo(short cardNum,short doType,out int pValue);
        [DllImport("gts.dll")]
        public static extern short GT_SetDoBitReverse(short cardNum,short doType,short doIndex,short value,short reverseTime);
        [DllImport("gts.dll")]
        public static extern short GT_SetDoMask(short cardNum,short doType,ushort doMask,int value);
        [DllImport("gts.dll")]
        public static extern short GT_EnableDoBitPulse(short cardNum,short doType,short doIndex,ushort highLevelTime,ushort lowLevelTime,int pulseNum,short firstLevel);
        [DllImport("gts.dll")]
        public static extern short GT_DisableDoBitPulse(short cardNum,short doType, short doIndex);

        [DllImport("gts.dll")]
        public static extern short GT_GetDi(short cardNum,short diType,out int pValue);
        [DllImport("gts.dll")]
        public static extern short GT_GetDiReverseCount(short cardNum,short diType,short diIndex,out uint reverseCount,short count);
        [DllImport("gts.dll")]
        public static extern short GT_SetDiReverseCount(short cardNum,short diType,short diIndex,ref uint reverseCount,short count);
        [DllImport("gts.dll")]
        public static extern short GT_GetDiRaw(short cardNum,short diType,out int pValue);

        [DllImport("gts.dll")]
        public static extern short GT_SetDac(short cardNum,short dac,ref short value,short count);
        [DllImport("gts.dll")]
        public static extern short GT_GetDac(short cardNum,short dac,out short value,short count,out uint pClock);

        [DllImport("gts.dll")]
        public static extern short GT_GetAdc(short cardNum,short adc,out double pValue,short count,out uint pClock);
        [DllImport("gts.dll")]
        public static extern short GT_GetAdcValue(short cardNum,short adc,out short pValue,short count,out uint pClock);

        [DllImport("gts.dll")]
        public static extern short GT_SetEncPos(short cardNum,short encoder,int encPos);
        [DllImport("gts.dll")]
        public static extern short GT_GetEncPos(short cardNum,short encoder,out double pValue,short count,out uint pClock);
        [DllImport("gts.dll")]
        public static extern short GT_GetEncPosPre(short cardNum,short encoder,out double pValue,short count,uint pClock);
        [DllImport("gts.dll")]
        public static extern short GT_GetEncVel(short cardNum,short encoder,out double pValue,short count,out uint pClock);

        [DllImport("gts.dll")]
        public static extern short GT_SetCaptureMode(short cardNum,short encoder,short mode);
        [DllImport("gts.dll")]
        public static extern short GT_GetCaptureMode(short cardNum,short encoder,out short pMode,short count);
        [DllImport("gts.dll")]
        public static extern short GT_GetCaptureStatus(short cardNum,short encoder,out short pStatus,out int pValue,short count,out uint pClock);
        [DllImport("gts.dll")]
        public static extern short GT_SetCaptureSense(short cardNum,short encoder, short mode,short sense);
        [DllImport("gts.dll")]
        public static extern short GT_ClearCaptureStatus(short cardNum,short encoder);
        [DllImport("gts.dll")]
        public static extern short GT_SetCaptureRepeat(short cardNum,short encoder,short count);
        [DllImport("gts.dll")]
        public static extern short GT_GetCaptureRepeatStatus(short cardNum,short encoder,out short pCount);
        [DllImport("gts.dll")]
        public static extern short GT_GetCaptureRepeatPos(short cardNum,short encoder, out int pValue, short startNum, short count);
        [DllImport("gts.dll")]
        public static extern short GT_SetCaptureEncoder(short cardNum,short trigger,short encoder);
        [DllImport("gts.dll")]
        public static extern short GT_GetCaptureWidth(short cardNum,short trigger,out short pWidth,short count);
        [DllImport("gts.dll")]
        public static extern short GT_GetCaptureHomeGpi(short cardNum,short trigger,out short pHomeSts,out short pHomePos,out short pGpiSts,out short pGpiPos,short count);

        [DllImport("gts.dll")]
        public static extern short GT_Reset(short cardNum);
        [DllImport("gts.dll")]
        public static extern short GT_GetClock(short cardNum,out uint pClock,out uint pLoop);
        [DllImport("gts.dll")]
        public static extern short GT_GetClockHighPrecision(short cardNum,out uint pClock);

        [DllImport("gts.dll")]
        public static extern short GT_GetSts(short cardNum,short axis,out int pSts,short count,out uint pClock);
        [DllImport("gts.dll")]
        public static extern short GT_ClrSts(short cardNum,short axis,short count);
        [DllImport("gts.dll")]
        public static extern short GT_AxisOn(short cardNum,short axis);
        [DllImport("gts.dll")]
        public static extern short GT_AxisOff(short cardNum,short axis);
        [DllImport("gts.dll")]
        public static extern short GT_Stop(short cardNum,int mask,int option);
        [DllImport("gts.dll")]
        public static extern short GT_SetPrfPos(short cardNum,short profile,int prfPos);
        [DllImport("gts.dll")]
        public static extern short GT_SynchAxisPos(short cardNum,int mask);
        [DllImport("gts.dll")]
        public static extern short GT_ZeroPos(short cardNum,short axis,short count);

        [DllImport("gts.dll")]
        public static extern short GT_SetSoftLimit(short cardNum,short axis,int positive,int negative);
        [DllImport("gts.dll")]
        public static extern short GT_GetSoftLimit(short cardNum,short axis,out int pPositive,out int pNegative);
        [DllImport("gts.dll")]
        public static extern short GT_SetAxisBand(short cardNum,short axis,int band,int time);
        [DllImport("gts.dll")]
        public static extern short GT_GetAxisBand(short cardNum,short axis,out int pBand,out int pTime);
        [DllImport("gts.dll")]
        public static extern short GT_SetBacklash(short cardNum,short axis,int compValue,double compChangeValue,int compDir);
        [DllImport("gts.dll")]
        public static extern short GT_GetBacklash(short cardNum,short axis,out int pCompValue,out double pCompChangeValue,out int pCompDir);
        [DllImport("gts.dll")]
        public static extern short GT_SetLeadScrewComp(short cardNum,short axis,short n,int startPos,int lenPos,out int pCompPos,out int pCompNeg);
        [DllImport("gts.dll")]
        public static extern short GT_EnableLeadScrewComp(short cardNum,short axis,short mode);
        [DllImport("gts.dll")]
        public static extern short GT_GetCompensate(short cardNum,short axis, out double pPitchError, out double pCrossError, out double pBacklashError, out double pEncPos, out double pPrfPos);
        
        [DllImport("gts.dll")]
        public static extern short GT_EnableGantry(short cardNum,short gantryMaster,short gantrySlave,double masterKp,double slaveKp);
        [DllImport("gts.dll")]
        public static extern short GT_DisableGantry(short cardNum);
        [DllImport("gts.dll")]
        public static extern short GT_SetGantryErrLmt(short cardNum,int gantryErrLmt);
        [DllImport("gts.dll")]
        public static extern short GT_GetGantryErrLmt(short cardNum,out int pGantryErrLmt);
        [DllImport("gts.dll")]
        public static extern short GT_ZeroGantryPos(short cardNum,short gantryMaster,short gantrySlave);

        [DllImport("gts.dll")]
        public static extern short GT_GetPrfPos(short cardNum,short profile,out double pValue,short count,out uint pClock);
        [DllImport("gts.dll")]
        public static extern short GT_GetPrfVel(short cardNum,short profile,out double pValue,short count,out uint pClock);
        [DllImport("gts.dll")]
        public static extern short GT_GetPrfAcc(short cardNum,short profile,out double pValue,short count,out uint pClock);
        [DllImport("gts.dll")]
        public static extern short GT_GetPrfMode(short cardNum,short profile,out int pValue,short count,out uint pClock);

        [DllImport("gts.dll")]
        public static extern short GT_GetAxisPrfPos(short cardNum,short axis,out double pValue,short count,out uint pClock);
        [DllImport("gts.dll")]
        public static extern short GT_GetAxisPrfVel(short cardNum,short axis,out double pValue,short count,out uint pClock);
        [DllImport("gts.dll")]
        public static extern short GT_GetAxisPrfAcc(short cardNum,short axis,out double pValue,short count,out uint pClock);
        [DllImport("gts.dll")]
        public static extern short GT_GetAxisEncPos(short cardNum,short axis,out double pValue,short count,out uint pClock);
        [DllImport("gts.dll")]
        public static extern short GT_GetAxisEncVel(short cardNum,short axis,out double pValue,short count,out uint pClock);
        [DllImport("gts.dll")]
        public static extern short GT_GetAxisEncAcc(short cardNum,short axis,out double pValue,short count,out uint pClock);
        [DllImport("gts.dll")]
        public static extern short GT_GetAxisError(short cardNum,short axis,out double pValue,short count,out uint pClock);

        [DllImport("gts.dll")]
        public static extern short GT_SetLongVar(short cardNum,short index,int value);
        [DllImport("gts.dll")]
        public static extern short GT_GetLongVar(short cardNum,short index,out int pValue);
        [DllImport("gts.dll")]
        public static extern short GT_SetDoubleVar(short cardNum,short index,double pValue);
        [DllImport("gts.dll")]
        public static extern short GT_GetDoubleVar(short cardNum,short index, out double pValue);

        [DllImport("gts.dll")]
        public static extern short GT_SetControlFilter(short cardNum,short control,short index);
        [DllImport("gts.dll")]
        public static extern short GT_GetControlFilter(short cardNum,short control,out short pIndex);

        [DllImport("gts.dll")]
        public static extern short GT_SetPid(short cardNum,short control,short index,ref PID pPid);
        [DllImport("gts.dll")]
        public static extern short GT_GetPid(short cardNum,short control,short index,out PID pPid);

        [DllImport("gts.dll")]
        public static extern short GT_SetKvffFilter(short cardNum,short control,short index,short kvffFilterExp,double accMax);
        [DllImport("gts.dll")]
        public static extern short GT_GetKvffFilter(short cardNum,short control, short index, out short pKvffFilterExp, out double pAccMax);

        [DllImport("gts.dll")]
        public static extern short GT_Update(short cardNum,int mask);
        [DllImport("gts.dll")]
        public static extern short GT_SetPos(short cardNum,short profile,int pos);
        [DllImport("gts.dll")]
        public static extern short GT_GetPos(short cardNum,short profile,out int pPos);
        [DllImport("gts.dll")]
        public static extern short GT_SetVel(short cardNum,short profile,double vel);
        [DllImport("gts.dll")]
        public static extern short GT_GetVel(short cardNum,short profile,out double pVel);

        [DllImport("gts.dll")]
        public static extern short GT_PrfTrap(short cardNum,short profile);
        [DllImport("gts.dll")]
        public static extern short GT_SetTrapPrm(short cardNum,short profile,ref TRAP_PRM pPrm);
        [DllImport("gts.dll")]
        public static extern short GT_GetTrapPrm(short cardNum,short profile,out TRAP_PRM pPrm);

        [DllImport("gts.dll")]
        public static extern short GT_PrfJog(short cardNum,short profile);
        [DllImport("gts.dll")]
        public static extern short GT_SetJogPrm(short cardNum,short profile,ref JOG_PRM pPrm);
        [DllImport("gts.dll")]
        public static extern short GT_GetJogPrm(short cardNum,short profile,out JOG_PRM pPrm);

        [DllImport("gts.dll")]
        public static extern short GT_PrfPt(short cardNum,short profile,short mode);
        [DllImport("gts.dll")]
        public static extern short GT_SetPtLoop(short cardNum,short profile,int loop);
        [DllImport("gts.dll")]
        public static extern short GT_GetPtLoop(short cardNum,short profile,out int pLoop);
        [DllImport("gts.dll")]
        public static extern short GT_PtSpace(short cardNum,short profile,out short pSpace,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_PtData(short cardNum,short profile,double pos,int time,short type,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_PtDataWN(short cardNum,short profile,double pos,int time,short type,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_PtClear(short cardNum,short profile,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_PtStart(short cardNum,int mask,int option);
        [DllImport("gts.dll")]
        public static extern short GT_SetPtMemory(short cardNum,short profile,short memory);
        [DllImport("gts.dll")]
        public static extern short GT_GetPtMemory(short cardNum,short profile,out short pMemory);
        [DllImport("gts.dll")]
        public static extern short GT_PtGetSegNum(short cardNum,short profile, out int pSegNum);
        [DllImport("gts.dll")]
        public static extern short GT_SetPtPrecisionMode(short cardNum,short profile,short precisionMode);
        [DllImport("gts.dll")]
        public static extern short GT_GetPtPrecisionMode(short cardNum,short profile,out short pPrecisionMode);
        [DllImport("gts.dll")]
        public static extern short GT_SetPtVel(short cardNum,short profile,double velLast,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_SetPtLink(short cardNum,short profile,short fifo,short list);
        [DllImport("gts.dll")]
        public static extern short GT_GetPtLink(short cardNum,short profile,short fifo,out short pList);
        [DllImport("gts.dll")]
        public static extern short GT_PtDoBit(short cardNum,short profile,short doType,short index,short value,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_PtAo(short cardNum,short profile,short aoType,short index,double value,short fifo);

        [DllImport("gts.dll")]
        public static extern short GT_PrfGear(short cardNum,short profile,short dir);
        [DllImport("gts.dll")]
        public static extern short GT_SetGearMaster(short cardNum,short profile,short masterIndex,short masterType,short masterItem);
        [DllImport("gts.dll")]
        public static extern short GT_GetGearMaster(short cardNum,short profile,out short pMasterIndex,out short pMasterType,out short pMasterItem);
        [DllImport("gts.dll")]
        public static extern short GT_SetGearRatio(short cardNum,short profile,int masterEven,int slaveEven,int masterSlope);
        [DllImport("gts.dll")]
        public static extern short GT_GetGearRatio(short cardNum,short profile,out int pMasterEven,out int pSlaveEven,out int pMasterSlope);
        [DllImport("gts.dll")]
        public static extern short GT_GearStart(short cardNum,int mask);
        [DllImport("gts.dll")]
        public static extern short GT_SetGearEvent(short cardNum,short profile,short gearEvent,int startPara0,int startPara1);
        [DllImport("gts.dll")]
        public static extern short GT_GetGearEvent(short cardNum,short profile, out short pEvent,out int pStartPara0, out int pStartPara1);

        [DllImport("gts.dll")]
        public static extern short GT_PrfFollow(short cardNum,short profile,short dir);
        [DllImport("gts.dll")]
        public static extern short GT_SetFollowMaster(short cardNum,short profile,short masterIndex,short masterType,short masterItem);
        [DllImport("gts.dll")]
        public static extern short GT_GetFollowMaster(short cardNum,short profile,out short pMasterIndex,out short pMasterType,out short pMasterItem);
        [DllImport("gts.dll")]
        public static extern short GT_SetFollowLoop(short cardNum,short profile,int loop);
        [DllImport("gts.dll")]
        public static extern short GT_GetFollowLoop(short cardNum,short profile,out int pLoop);
        [DllImport("gts.dll")]
        public static extern short GT_SetFollowEvent(short cardNum,short profile,short followEvent,short masterDir,int pos);
        [DllImport("gts.dll")]
        public static extern short GT_GetFollowEvent(short cardNum,short profile,out short pFollowEvent,out short pMasterDir,out int pPos);
        [DllImport("gts.dll")]
        public static extern short GT_FollowSpace(short cardNum,short profile,out short pSpace,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_FollowData(short cardNum,short profile,int masterSegment,double slaveSegment,short type,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_FollowClear(short cardNum,short profile,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_FollowStart(short cardNum,int mask,int option);
        [DllImport("gts.dll")]
        public static extern short GT_FollowSwitch(short cardNum,int mask);
        [DllImport("gts.dll")]
        public static extern short GT_SetFollowMemory(short cardNum,short profile,short memory);
        [DllImport("gts.dll")]
        public static extern short GT_GetFollowMemory(short cardNum,short profile,out short memory);
        [DllImport("gts.dll")]
        public static extern short GT_GetFollowStatus(short cardNum,short profile, out short pFifoNum, out short pSwitchStatus);
        [DllImport("gts.dll")]
        public static extern short GT_SetFollowPhasing(short cardNum,short profile, short profilePhasing);
        [DllImport("gts.dll")]
        public static extern short GT_GetFollowPhasing(short cardNum,short profile, out short pProfilePhasing);

        [DllImport("gts.dll")]
        public static extern short GT_Compile(short cardNum,string pFileName, out COMPILE_INFO pWrongInfo);
        [DllImport("gts.dll")]
        public static extern short GT_Download(short cardNum,string pFileName);

        [DllImport("gts.dll")]
        public static extern short GT_GetFunId(short cardNum,string pFunName,out short pFunId);
        [DllImport("gts.dll")]
        public static extern short GT_Bind(short cardNum,short thread,short funId, short page);

        [DllImport("gts.dll")]
        public static extern short GT_RunThread(short cardNum,short thread);
        [DllImport("gts.dll")]
        public static extern short GT_StopThread(short cardNum,short thread);
        [DllImport("gts.dll")]
        public static extern short GT_PauseThread(short cardNum,short thread);

        [DllImport("gts.dll")]
        public static extern short GT_GetThreadSts(short cardNum,short thread,out THREAD_STS pThreadSts);

        [DllImport("gts.dll")]
        public static extern short GT_GetVarId(short cardNum,string pFunName,string pVarName,out VAR_INFO pVarInfo);
        [DllImport("gts.dll")]
        public static extern short GT_SetVarValue(short cardNum,short page,ref VAR_INFO pVarInfo,ref double pValue,short count);
        [DllImport("gts.dll")]
        public static extern short GT_GetVarValue(short cardNum,short page,ref VAR_INFO pVarInfo,out double pValue,short count);

		[DllImport("gts.dll")]
        public static extern short GT_SetCrdMapBase(short cardNum,short crd,short mapBase);
        [DllImport("gts.dll")]
        public static extern short GT_GetCrdMapBase(short cardNum,short crd,out short pMapBase);
        [DllImport("gts.dll")]
        public static extern short GT_SetCrdSmooth(short cardNum,short crd,ref CRD_SMOOTH pCrdSmooth);
        [DllImport("gts.dll")]
        public static extern short GT_GetCrdSmooth(short cardNum,short crd,out CRD_SMOOTH pCrdSmooth);
        [DllImport("gts.dll")]
        public static extern short GT_SetCrdJerk(short cardNum,short crd,double jerkMax);
        [DllImport("gts.dll")]
        public static extern short GT_GetCrdJerk(short cardNum,short crd,out double pJerkMax);
        [DllImport("gts.dll")]
        public static extern short GT_SetCrdPrm(short cardNum,short crd, ref CRD_PRM pCrdPrm);
        [DllImport("gts.dll")]
        public static extern short GT_GetCrdPrm(short cardNum,short crd,out CRD_PRM pCrdPrm);
        [DllImport("gts.dll")]
        public static extern short GT_SetArcAllowError(short cardNum,short crd,double error);
        [DllImport("gts.dll")]
        public static extern short GT_CrdSpace(short cardNum,short crd,out int pSpace,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_CrdData(short cardNum,short crd,System.IntPtr pCrdData,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_CrdDataCircle(short cardNum,short crd, ref CRD_DATA pCrdData, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXY(short cardNum,short crd, int x, int y, double synVel, double synAcc, double velEnd, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYZ(short cardNum,short crd, int x, int y, int z, double synVel, double synAcc, double velEnd, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYZA(short cardNum,short crd, int x, int y, int z, int a, double synVel, double synAcc, double velEnd, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYG0(short cardNum,short crd, int x, int y, double synVel, double synAcc, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYZG0(short cardNum,short crd, int x, int y, int z, double synVel, double synAcc, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYZAG0(short cardNum,short crd, int x, int y, int z, int a, double synVel, double synAcc, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcXYR(short cardNum,short crd, int x, int y, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcXYC(short cardNum,short crd, int x, int y, double xCenter, double yCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcYZR(short cardNum,short crd, int y, int z, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcYZC(short cardNum,short crd, int y, int z, double yCenter, double zCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcZXR(short cardNum,short crd, int z, int x, double radius, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcZXC(short cardNum,short crd, int z, int x, double zCenter, double xCenter, short circleDir, double synVel, double synAcc, double velEnd, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcXYZ(short cardNum,short crd,int x,int y,int z,double interX,double interY,double interZ,double synVel,double synAcc,double velEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYOverride2(short cardNum,short crd,int x,int y,double synVel,double synAcc,double velEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYZOverride2(short cardNum,short crd,int x,int y,int z,double synVel,double synAcc,double velEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYZAOverride2(short cardNum,short crd,int x,int y,int z,int a,double synVel,double synAcc,double velEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYG0Override2(short cardNum,short crd,int x,int y,double synVel,double synAcc,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYZG0Override2(short cardNum,short crd,int x,int y,int z,double synVel,double synAcc,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYZAG0Override2(short cardNum,short crd,int x,int y,int z,int a,double synVel,double synAcc,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcXYROverride2(short cardNum,short crd,int x,int y,double radius,short circleDir,double synVel,double synAcc,double velEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcXYCOverride2(short cardNum,short crd,int x,int y,double xCenter,double yCenter,short circleDir,double synVel,double synAcc,double velEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcYZROverride2(short cardNum,short crd,int y,int z,double radius,short circleDir,double synVel,double synAcc,double velEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcYZCOverride2(short cardNum,short crd,int y,int z,double yCenter,double zCenter,short circleDir,double synVel,double synAcc,double velEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcZXROverride2(short cardNum,short crd,int z,int x,double radius,short circleDir,double synVel,double synAcc,double velEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcZXCOverride2(short cardNum,short crd,int z,int x,double zCenter,double xCenter,short circleDir,double synVel,double synAcc,double velEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixXYRZ(short cardNum,short crd,int x,int y,int z,double radius,short circleDir,double synVel,double synAcc,double velEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixXYCZ(short cardNum,short crd,int x,int y,int z,double xCenter,double yCenter,short circleDir,double synVel,double synAcc,double velEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixYZRX(short cardNum,short crd,int x,int y,int z,double radius,short circleDir,double synVel,double synAcc,double velEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixYZCX(short cardNum,short crd,int x,int y,int z,double yCenter,double zCenter,short circleDir,double synVel,double synAcc,double velEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixZXRY(short cardNum,short crd,int x,int y,int z,double radius,short circleDir,double synVel,double synAcc,double velEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixZXCY(short cardNum,short crd,int x,int y,int z,double zCenter,double xCenter,short circleDir,double synVel,double synAcc,double velEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixXYRZOverride2(short cardNum,short crd,int x,int y,int z,double radius,short circleDir,double synVel,double synAcc,double velEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixXYCZOverride2(short cardNum,short crd,int x,int y,int z,double xCenter,double yCenter,short circleDir,double synVel,double synAcc,double velEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixYZRXOverride2(short cardNum,short crd,int x,int y,int z,double radius,short circleDir,double synVel,double synAcc,double velEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixYZCXOverride2(short cardNum,short crd,int x,int y,int z,double yCenter,double zCenter,short circleDir,double synVel,double synAcc,double velEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixZXRYOverride2(short cardNum,short crd,int x,int y,int z,double radius,short circleDir,double synVel,double synAcc,double velEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixZXCYOverride2(short cardNum,short crd,int x,int y,int z,double zCenter,double xCenter,short circleDir,double synVel,double synAcc,double velEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYWN(short cardNum,short crd,int x,int y,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYZWN(short cardNum,short crd,int x,int y,int z,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYZAWN(short cardNum,short crd,int x,int y,int z,int a,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYG0WN(short cardNum,short crd,int x,int y,double synVel,double synAcc,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYZG0WN(short cardNum,short crd,int x,int y,int z,double synVel,double synAcc,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYZAG0WN(short cardNum,short crd,int x,int y,int z,int a,double synVel,double synAcc,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcXYRWN(short cardNum,short crd,int x,int y,double radius,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcXYCWN(short cardNum,short crd,int x,int y,double xCenter,double yCenter,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcYZRWN(short cardNum,short crd,int y,int z,double radius,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcYZCWN(short cardNum,short crd,int y,int z,double yCenter,double zCenter,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcZXRWN(short cardNum,short crd,int z,int x,double radius,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcZXCWN(short cardNum,short crd,int z,int x,double zCenter,double xCenter,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcXYZWN(short cardNum,short crd,int x,int y,int z,double interX,double interY,double interZ,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYOverride2WN(short cardNum,short crd,int x,int y,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYZOverride2WN(short cardNum,short crd,int x,int y,int z,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYZAOverride2WN(short cardNum,short crd,int x,int y,int z,int a,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYG0Override2WN(short cardNum,short crd,int x,int y,double synVel,double synAcc,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYZG0Override2WN(short cardNum,short crd,int x,int y,int z,double synVel,double synAcc,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_LnXYZAG0Override2WN(short cardNum,short crd,int x,int y,int z,int a,double synVel,double synAcc,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcXYROverride2WN(short cardNum,short crd,int x,int y,double radius,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcXYCOverride2WN(short cardNum,short crd,int x,int y,double xCenter,double yCenter,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcYZROverride2WN(short cardNum,short crd,int y,int z,double radius,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcYZCOverride2WN(short cardNum,short crd,int y,int z,double yCenter,double zCenter,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcZXROverride2WN(short cardNum,short crd,int z,int x,double radius,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_ArcZXCOverride2WN(short cardNum,short crd,int z,int x,double zCenter,double xCenter,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixXYRZWN(short cardNum,short crd,int x,int y,int z,double radius,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixXYCZWN(short cardNum,short crd,int x,int y,int z,double xCenter,double yCenter,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixYZRXWN(short cardNum,short crd,int x,int y,int z,double radius,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixYZCXWN(short cardNum,short crd,int x,int y,int z,double yCenter,double zCenter,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixZXRYWN(short cardNum,short crd,int x,int y,int z,double radius,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixZXCYWN(short cardNum,short crd,int x,int y,int z,double zCenter,double xCenter,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixXYRZOverride2WN(short cardNum,short crd,int x,int y,int z,double radius,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixXYCZOverride2WN(short cardNum,short crd,int x,int y,int z,double xCenter,double yCenter,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixYZRXOverride2WN(short cardNum,short crd,int x,int y,int z,double radius,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixYZCXOverride2WN(short cardNum,short crd,int x,int y,int z,double yCenter,double zCenter,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixZXRYOverride2WN(short cardNum,short crd,int x,int y,int z,double radius,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_HelixZXCYOverride2WN(short cardNum,short crd,int x,int y,int z,double zCenter,double xCenter,short circleDir,double synVel,double synAcc,double velEnd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_BufTrend(short cardNum,short crd,uint trendSegNum,double trendDistance,double trendVelEnd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_BufIO(short cardNum,short crd, ushort doType, ushort doMask, ushort doValue, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_BufEnableDoBitPulse(short cardNum,short crd,short doType,short doIndex,ushort highLevelTime,ushort lowLevelTime,int pulseNum,short firstLevel,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_BufDisableDoBitPulse(short cardNum,short crd,short doType,short doIndex,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_BufDelay(short cardNum,short crd, ushort delayTime, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_BufComparePulse(short cardNum,short crd,short level,short outputType,short time,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_BufDA(short cardNum,short crd, short chn, short daValue, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_BufLmtsOn(short cardNum,short crd, short axis, short limitType, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_BufLmtsOff(short cardNum,short crd, short axis, short limitType, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_BufSetStopIo(short cardNum,short crd, short axis, short stopType, short inputType, short inputIndex, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_BufMove(short cardNum,short crd, short moveAxis, int pos, double vel, double acc, short modal, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_BufGear(short cardNum,short crd, short gearAxis, int pos, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_BufGearPercent(short cardNum,short crd,short gearAxis,int pos,short accPercent,short decPercent,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_BufStopMotion(short cardNum,short crd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_BufSetVarValue(short cardNum,short crd,short pageId,out VAR_INFO pVarInfo,double value,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_BufJumpNextSeg(short cardNum,short crd,short axis,short limitType,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_BufSynchPrfPos(short cardNum,short crd,short encoder,short profile,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_BufVirtualToActual(short cardNum,short crd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_BufSetLongVar(short cardNum,short crd,short index,int value,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_BufSetDoubleVar(short cardNum,short crd,short index,double value,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_CrdStart(short cardNum,short mask,short option);
        [DllImport("gts.dll")]
        public static extern short GT_CrdStartStep(short cardNum,short mask, short option);
        [DllImport("gts.dll")]
        public static extern short GT_CrdStepMode(short cardNum,short mask, short option);
        [DllImport("gts.dll")]
        public static extern short GT_SetOverride(short cardNum,short crd,double synVelRatio);
        [DllImport("gts.dll")]
        public static extern short GT_SetOverride2(short cardNum,short crd, double synVelRatio);
        [DllImport("gts.dll")]
        public static extern short GT_InitLookAhead(short cardNum,short crd,short fifo,double T,double accMax,short n,ref CRD_DATA pLookAheadBuf);
        [DllImport("gts.dll")]
        public static extern short GT_GetLookAheadSpace(short cardNum,short crd,out int pSpace,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_GetLookAheadSegCount(short cardNum,short crd,out int pSegCount,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_CrdClear(short cardNum,short crd,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_CrdStatus(short cardNum,short crd,out short pRun,out int pSegment,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_SetUserSegNum(short cardNum,short crd,int segNum,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_GetUserSegNum(short cardNum,short crd,out int pSegment,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_GetUserSegNumWN(short cardNum,short crd,out int pSegment,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_GetRemainderSegNum(short cardNum,short crd,out int pSegment,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_SetCrdStopDec(short cardNum,short crd,double decSmoothStop,double decAbruptStop);
        [DllImport("gts.dll")]
        public static extern short GT_GetCrdStopDec(short cardNum,short crd,out double pDecSmoothStop,out double pDecAbruptStop);
        [DllImport("gts.dll")]
        public static extern short GT_SetCrdLmtStopMode(short cardNum,short crd,short lmtStopMode);
        [DllImport("gts.dll")]
        public static extern short GT_GetCrdLmtStopMode(short cardNum,short crd,out short pLmtStopMode);
        [DllImport("gts.dll")]
        public static extern short GT_GetUserTargetVel(short cardNum,short crd,out double pTargetVel);
        [DllImport("gts.dll")]
        public static extern short GT_GetSegTargetPos(short cardNum,short crd,out int pTargetPos);
        [DllImport("gts.dll")]
        public static extern short GT_GetCrdPos(short cardNum,short crd,out double pPos);
        [DllImport("gts.dll")]
        public static extern short GT_GetCrdVel(short cardNum,short crd,out double pSynVel);
        [DllImport("gts.dll")]
        public static extern short GT_SetCrdSingleMaxVel(short cardNum,short crd,ref double pMaxVel);
        [DllImport("gts.dll")]
        public static extern short GT_GetCrdSingleMaxVel(short cardNum,short crd,out double pMaxVel);
        [DllImport("gts.dll")]
        public static extern short GT_GetCmdCount(short cardNum,short crd, out short pResult, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_BufLaserOn(short cardNum,short crd,short fifo,short channel);
        [DllImport("gts.dll")]
        public static extern short GT_BufLaserOff(short cardNum,short crd,short fifo,short channel);
        [DllImport("gts.dll")]
        public static extern short GT_BufLaserPrfCmd(short cardNum,short crd,double laserPower,short fifo,short channel);
        [DllImport("gts.dll")]
        public static extern short GT_BufLaserFollowRatio(short cardNum,short crd,double ratio,double minPower,double maxPower,short fifo,short channel);
        [DllImport("gts.dll")]
        public static extern short GT_BufLaserFollowMode(short cardNum,short crd,short source ,short fifo,short channel,double startPower );
        [DllImport("gts.dll")]
        public static extern short GT_BufLaserFollowOff(short cardNum,short crd,short fifo,short channel);
        [DllImport("gts.dll")]
        public static extern short GT_BufLaserFollowSpline(short cardNum,short crd,short tableId,double minPower,double maxPower,short fifo,short channel);

        [DllImport("gts.dll")]
        public static extern short GT_PrfPvt(short cardNum,short profile);
        [DllImport("gts.dll")]
        public static extern short GT_SetPvtLoop(short cardNum,short profile,int loop);
        [DllImport("gts.dll")]
        public static extern short GT_GetPvtLoop(short cardNum,short profile,out int pLoopCount,out int pLoop);
        [DllImport("gts.dll")]
        public static extern short GT_PvtStatus(short cardNum,short profile,out short pTableId,out double pTime,short count);
        [DllImport("gts.dll")]
        public static extern short GT_PvtStart(short cardNum,int mask);
        [DllImport("gts.dll")]
        public static extern short GT_PvtTableSelect(short cardNum,short profile,short tableId);

        [DllImport("gts.dll")]
        public static extern short GT_PvtTable(short cardNum,short tableId,int count,ref double pTime,ref double pPos,ref double pVel);
        [DllImport("gts.dll")]
        public static extern short GT_PvtTableEx(short cardNum,short tableId,int count,ref double pTime,ref double pPos,ref double pVelBegin,ref double pVelEnd);
        [DllImport("gts.dll")]
        public static extern short GT_PvtTableComplete(short cardNum,short tableId,int count,ref double pTime,ref double pPos,ref double pA,ref double pB,ref double pC,double velBegin,double velEnd);
        [DllImport("gts.dll")]
        public static extern short GT_PvtTablePercent(short cardNum,short tableId,int count,ref double pTime,ref double pPos,ref double pPercent,double velBegin);
        [DllImport("gts.dll")]
        public static extern short GT_PvtPercentCalculate(short cardNum,int n,ref double pTime,ref double pPos,ref double pPercent,double velBegin,ref double pVel);
        [DllImport("gts.dll")]
        public static extern short GT_PvtTableContinuous(short cardNum,short tableId,int count,ref double pPos,ref double pVel,ref double pPercent,ref double pVelMax,ref double pAcc,ref double pDec,double timeBegin);
        [DllImport("gts.dll")]
        public static extern short GT_PvtContinuousCalculate(short cardNum,int n,ref double pPos,ref double pVel,ref double pPercent,ref double pVelMax,ref double pAcc,ref double pDec,ref double pTime);
        [DllImport("gts.dll")]
        public static extern short GT_PvtTableMovePercent(short cardNum,short tableId, long distance, double vm, double acc, double pa1, double pa2, double dec, double pd1, double pd2, out double pVel, out double pAcc, out double pDec, out double pTime);
        [DllImport("gts.dll")]
        public static extern short GT_PvtTableMovePercentEx(short cardNum,short tableId,int distance,double vm,double acc,double pa1,double pa2,double ma,double dec,double pd1,double pd2,double md,out double pVel,out double pAcc,out double pDec,out double pTime);

        [DllImport("gts.dll")]
        public static extern short GT_HomeInit(short cardNum);
        [DllImport("gts.dll")]
        public static extern short GT_Home(short cardNum,short axis,int pos,double vel,double acc,int offset);
        [DllImport("gts.dll")]
        public static extern short GT_Index(short cardNum,short axis,int pos,int offset);
        [DllImport("gts.dll")]
        public static extern short GT_HomeStop(short cardNum,short axis,int pos,double vel,double acc);
        [DllImport("gts.dll")]
        public static extern short GT_HomeSts(short cardNum,short axis,out ushort pStatus);

        [DllImport("gts.dll")]
        public static extern short GT_HandwheelInit(short cardNum);
        [DllImport("gts.dll")]
        public static extern short GT_SetHandwheelStopDec(short cardNum,short slave,double decSmoothStop,double decAbruptStop);
        [DllImport("gts.dll")]
        public static extern short GT_StartHandwheel(short cardNum,short slave,short master,short masterEven,short slaveEven,short intervalTime,double acc,double dec,double vel,short stopWaitTime);
        [DllImport("gts.dll")]
        public static extern short GT_EndHandwheel(short cardNum,short slave);

        [DllImport("gts.dll")]
        public static extern short GT_SetTrigger(short cardNum,short i,ref TRIGGER pTrigger);
        [DllImport("gts.dll")]
        public static extern short GT_GetTrigger(short cardNum,short i,out TRIGGER pTrigger);
        [DllImport("gts.dll")]
        public static extern short GT_GetTriggerStatus(short cardNum,short i,out TRIGGER_STATUS pTriggerStatus,short count);
        [DllImport("gts.dll")]
        public static extern short GT_GetTriggerStatusEx(short cardNum,short i,out TRIGGER_STATUS_EX pTriggerStatusEx,short count);
        [DllImport("gts.dll")]
        public static extern short GT_ClearTriggerStatus(short cardNum,short i);

        [DllImport("gts.dll")]
        public static extern short GT_SetComparePort(short cardNum,short channel,short hsio0,short hsio1);

        [DllImport("gts.dll")]
        public static extern short GT_ComparePulse(short cardNum,short level,short outputType,short time);
        [DllImport("gts.dll")]
        public static extern short GT_CompareStop(short cardNum);
        [DllImport("gts.dll")]
        public static extern short GT_CompareStatus(short cardNum,out short pStatus,out int pCount);
        [DllImport("gts.dll")]
        public static extern short GT_CompareData(short cardNum,short encoder,short source,short pulseType,short startLevel,short time,int[] pBuf1,short count1,int[] pBuf2,short count2);
        [DllImport("gts.dll")]
        public static extern short GT_CompareLinear(short cardNum,short encoder,short channel,int startPos,int repeatTimes,int interval,short time,short source);
        [DllImport("gts.dll")]
        public static extern short GT_CompareContinuePulseMode(short cardNum,short mode, short count, short standTime);

        [DllImport("gts.dll")]
        public static extern short GT_SetEncResponseCheck(short cardNum,short control, short dacThreshold, double minEncVel, int time);
        [DllImport("gts.dll")]
        public static extern short GT_GetEncResponseCheck(short cardNum,short control, out short pDacThreshold, out double pMinEncVel, out int pTime);
        [DllImport("gts.dll")]
        public static extern short GT_EnableEncResponseCheck(short cardNum,short control);
        [DllImport("gts.dll")]
        public static extern short GT_DisableEncResponseCheck(short cardNum,short control);

        [DllImport("gts.dll")]
        public static extern short GT_2DCompareMode(short cardNum,short chn, short mode);
        [DllImport("gts.dll")]
        public static extern short GT_2DComparePulse(short cardNum,short chn, short level, short outputType, short time);
        [DllImport("gts.dll")]
        public static extern short GT_2DCompareStop(short cardNum,short chn);
        [DllImport("gts.dll")]
        public static extern short GT_2DCompareClear(short cardNum,short chn);
        [DllImport("gts.dll")]
        public static extern short GT_2DCompareStatus(short cardNum,short chn, out short pStatus, out int pCount, out short pFifo, out short pFifoCount, out short pBufCount);
        [DllImport("gts.dll")]
        public static extern short GT_2DCompareSetPrm(short cardNum,short chn, ref T2_D_COMPARE_PRM pPrm);
        [DllImport("gts.dll")]
        public static extern short GT_2DCompareData(short cardNum,short chn, short count, ref T2_D_COMPARE_DATA pBuf, short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_2DCompareStart(short cardNum,short chn);
        [DllImport("gts.dll")]
        public static extern short GT_2DCompareClearData(short cardNum,short chn);
        [DllImport("gts.dll")]
        public static extern short GT_2DCompareSetPreOutTime(short cardNum,short chn,double preOutputTime);

        [DllImport("gts.dll")]
        public static extern short GT_SetAxisMode(short cardNum,short axis, short mode);
        [DllImport("gts.dll")]
        public static extern short GT_GetAxisMode(short cardNum,short axis, out short pMode);
        [DllImport("gts.dll")]
        public static extern short GT_SetHSIOOpt(short cardNum,ushort value, short channel);
        [DllImport("gts.dll")]
        public static extern short GT_GetHSIOOpt(short cardNum,out ushort pValue, short channel);
        [DllImport("gts.dll")]
        public static extern short GT_LaserPowerMode(short cardNum,short laserPowerMode, double maxValue, double minValue, short channel, short delaymode);
        [DllImport("gts.dll")]
        public static extern short GT_LaserPrfCmd(short cardNum,double outputCmd, short channel);
        [DllImport("gts.dll")]
        public static extern short GT_LaserOutFrq(short cardNum,double outFrq, short channel);
        [DllImport("gts.dll")]
        public static extern short GT_SetPulseWidth(short cardNum,uint width, short channel);
        [DllImport("gts.dll")]
        public static extern short GT_SetWaitPulse(short cardNum,ushort mode, double waitPulseFrq, double waitPulseDuty, short channel);
        [DllImport("gts.dll")]
        public static extern short GT_SetPreVltg(short cardNum,ushort mode, double voltageValue, short channel);
        [DllImport("gts.dll")]
        public static extern short GT_SetLevelDelay(short cardNum,ushort offDelay, ushort onDelay, short channel);
        [DllImport("gts.dll")]
        public static extern short GT_EnaFPK(short cardNum,ushort time1, ushort time2, ushort laserOffDelay, short channel);
        [DllImport("gts.dll")]
        public static extern short GT_DisFPK(short cardNum,short channel);
        [DllImport("gts.dll")]
        public static extern short GT_SetLaserDisMode(short cardNum,short mode, short source, ref int pPos, ref double pScale, short channel);
        [DllImport("gts.dll")]
        public static extern short GT_SetLaserDisRatio(short cardNum,ref double pRatio, double minPower, double maxPower, short channel);
        [DllImport("gts.dll")]
        public static extern short GT_SetWaitPulseEx(short cardNum,ushort mode, double waitPulseFrq, double waitPulseDuty);
        [DllImport("gts.dll")]
        public static extern short GT_SetLaserMode(short cardNum,short mode);
        [DllImport("gts.dll")]
        public static extern short GT_SetLaserFollowSpline(short cardNum,short tableId,long n,ref double pX,ref double pY,double beginValue,double endValue,short channel);
        [DllImport("gts.dll")]
        public static extern short GT_GetLaserFollowSpline(short cardNum,short tableId,long n,out double pX,out double pY,out double pA,out double pB,out double pC,out long pCount,short channel);
        
        //ExtMdl
        [DllImport("gts.dll")]
        public static extern short GT_OpenExtMdl(short cardNum,string pDllName);
        [DllImport("gts.dll")]
        public static extern short GT_CloseExtMdl(short cardNum);
        [DllImport("gts.dll")]
        public static extern short GT_SwitchtoCardNoExtMdl(short cardNum,short card);
        [DllImport("gts.dll")]
        public static extern short GT_ResetExtMdl(short cardNum);
        [DllImport("gts.dll")]
        public static extern short GT_LoadExtConfig(short cardNum,string pFileName);
        [DllImport("gts.dll")]
        public static extern short GT_SetExtIoValue(short cardNum,short mdl,ushort value);
        [DllImport("gts.dll")]
        public static extern short GT_GetExtIoValue(short cardNum,short mdl,out ushort pValue);
        [DllImport("gts.dll")]
        public static extern short GT_SetExtIoBit(short cardNum,short mdl,short index,ushort value);
        [DllImport("gts.dll")]
        public static extern short GT_GetExtIoBit(short cardNum,short mdl,short index,out ushort pValue);
        [DllImport("gts.dll")]
        public static extern short GT_GetExtAdValue(short cardNum,short mdl,short chn,out ushort pValue);
        [DllImport("gts.dll")]
        public static extern short GT_GetExtAdVoltage(short cardNum,short mdl,short chn,out double pValue);
        [DllImport("gts.dll")]
        public static extern short GT_SetExtDaValue(short cardNum,short mdl,short chn,ushort value);
        [DllImport("gts.dll")]
        public static extern short GT_SetExtDaVoltage(short cardNum,short mdl,short chn,double value);
        [DllImport("gts.dll")]
        public static extern short GT_GetStsExtMdl(short cardNum,short mdl,short chn,out ushort pStatus);
        [DllImport("gts.dll")]
        public static extern short GT_GetExtDoValue(short cardNum,short mdl,out ushort pValue);
        [DllImport("gts.dll")]
        public static extern short GT_GetExtMdlMode(short cardNum,out short pMode);
        [DllImport("gts.dll")]
        public static extern short GT_SetExtMdlMode(short cardNum,short mode);
        [DllImport("gts.dll")]
        public static extern short GT_UploadConfig(short cardNum);
        [DllImport("gts.dll")]
        public static extern short GT_DownloadConfig(short cardNum);
        
        [DllImport("gts.dll")]
        public static extern short GT_GetUuid(short cardNum,out char pCode,short count);
				[DllImport("gts.dll")]
        public static extern short GT_SetUuid(short cardNum,ref char pCode,short count);

        //2D Compensate
        public struct COMPENSATE2_D_TABLE
        {      
            public short m_count1;
            public short m_count2;
            public int m_posBegin1;
            public int m_posBegin2;   
            public int m_step1;
            public int m_step2;
        } 
        public struct COMPENSATE2_D 
        {
	        public short m_enable;                                 
	        public short m_tableIndex;                              
	        public short m_axisType1;	
            public short m_axisType2;              
	        public short m_axisIndex1;
            public short m_axisIndex2;              
        } 
        [DllImport("gts.dll")]
        public static extern short GT_SetCompensate2DTable(short cardNum,short tableIndex,ref COMPENSATE2_D_TABLE pTable,ref int pData,short externComp);
        [DllImport("gts.dll")]
        public static extern short GT_GetCompensate2DTable(short cardNum,short tableIndex,out COMPENSATE2_D_TABLE pTable,out short pExternComp);
        [DllImport("gts.dll")]
        public static extern short GT_SetCompensate2D(short cardNum,short axis, ref COMPENSATE2_D pComp2D);
        [DllImport("gts.dll")]
        public static extern short GT_GetCompensate2D(short cardNum,short axis, out COMPENSATE2_D pComp2D);
        [DllImport("gts.dll")]
        public static extern short GT_GetCompensate2DValue(short cardNum,short axis, out double pValue);

        //Smart Home
        public const short m_c_HOME_STAGE_IDLE=0;
        public const short m_c_HOME_STAGE_START=1;
        public const short m_c_HOME_STAGE_ON_HOME_LIMIT_ESCAPE=2;
        public const short m_c_HOME_STAGE_SEARCH_LIMIT=10;
        public const short m_c_HOME_STAGE_SEARCH_LIMIT_STOP=11;
        public const short m_c_HOME_STAGE_SEARCH_LIMIT_ESCAPE = 13;
        public const short m_c_HOME_STAGE_SEARCH_LIMIT_RETURN=15;
        public const short m_c_HOME_STAGE_SEARCH_LIMIT_RETURN_STOP=16;
        public const short m_c_HOME_STAGE_SEARCH_HOME=20;
        public const short m_c_HOME_STAGE_SEARCH_HOME_STOP=22;
        public const short m_c_HOME_STAGE_SEARCH_HOME_RETURN=25;
        public const short m_c_HOME_STAGE_SEARCH_INDEX=30;
        public const short m_c_HOME_STAGE_SEARCH_GPI=40;
        public const short m_c_HOME_STAGE_SEARCH_GPI_RETURN=45;
        public const short m_c_HOME_STAGE_GO_HOME=80;
        public const short m_c_HOME_STAGE_END=100;
        public const short m_c_HOME_ERROR_NONE=0;
        public const short m_c_HOME_ERROR_NOT_TRAP_MODE=1;
        public const short m_c_HOME_ERROR_DISABLE=2;
        public const short m_c_HOME_ERROR_ALARM=3;
        public const short m_c_HOME_ERROR_STOP=4;
        public const short m_c_HOME_ERROR_STAGE=5;
        public const short m_c_HOME_ERROR_HOME_MODE=6;
        public const short m_c_HOME_ERROR_SET_CAPTURE_HOME=7;
        public const short m_c_HOME_ERROR_NO_HOME=8;
        public const short m_c_HOME_ERROR_SET_CAPTURE_INDEX=9;
        public const short m_c_HOME_ERROR_NO_INDEX=10;
        public const short m_c_HOME_MODE_LIMIT=10;
        public const short m_c_HOME_MODE_LIMIT_HOME=11;
        public const short m_c_HOME_MODE_LIMIT_INDEX=12;
        public const short m_c_HOME_MODE_LIMIT_HOME_INDEX=13;
        public const short m_c_HOME_MODE_HOME=20;
        public const short m_c_HOME_MODE_HOME_INDEX=22;
        public const short m_c_HOME_MODE_INDEX = 30;
        public const short m_c_HOME_MODE_FORCED_HOME=40;
        public const short m_c_HOME_MODE_FORCED_HOME_INDEX=41;
        
        public struct HOME_PRM
        {
	        public short m_mode;						
	        public short m_moveDir;					
	        public short m_indexDir;					
	        public short m_edge;					
	        public short m_triggerIndex;			
			public short m_pad11;
	        public short m_pad12;
            public short m_pad13;
	        public double m_velHigh;				
	        public double m_velLow;				
	        public double m_acc;					
	        public double m_dec;
	        public short m_smoothTime;
			public short m_pad21;
		    public short m_pad22;
            public short m_pad23;
	        public int m_homeOffset;				
	        public int m_searchHomeDistance;	
	        public int m_searchIndexDistance;	
	        public int m_escapeStep;			
            public int m_pad31;
            public int m_pad32;
            public int m_pad33;
        } 
        public struct HOME_STATUS
        {
	        public short m_run;
	        public short m_stage;
            public short m_error;
            public short m_pad1;
	        public int m_capturePos;
	        public int m_targetPos;
        }
        [DllImport("gts.dll")]
        public static extern short GT_GoHome(short cardNum,short axis, ref HOME_PRM pHomePrm);
        [DllImport("gts.dll")]
        public static extern short GT_GetHomePrm(short cardNum,short axis, out HOME_PRM pHomePrm);
        [DllImport("gts.dll")]
        public static extern short GT_GetHomeStatus(short cardNum,short axis, out HOME_STATUS pHomeStatus);

        //Extern Control
        public struct CONTROL_CONFIG_EX
        {
	        public short m_refType;
            public short m_refIndex;
            public short m_feedbackType;
            public short m_feedbackIndex;
            public int m_errorLimit;
            public short m_feedbackSmooth;
            public short m_controlSmooth;	
        }
        [DllImport("gts.dll")]
        public static extern short GT_SetControlConfigEx(short cardNum,short control, ref CONTROL_CONFIG_EX pControl);
        [DllImport("gts.dll")]
        public static extern short GT_GetControlConfigEx(short cardNum,short control, out CONTROL_CONFIG_EX pControl);

        //Adc filter
        public struct ADC_CONFIG
        {
	        public short m_active;
            public short m_reverse;
            public double m_a;
            public double m_b;
            public short m_filterMode;	
        }
        [DllImport("gts.dll")]
        public static extern short GT_SetAdcConfig(short cardNum,short adc, ref ADC_CONFIG pAdc);
        [DllImport("gts.dll")]
        public static extern short GT_GetAdcConfig(short cardNum,short adc, out ADC_CONFIG pAdc);
        [DllImport("gts.dll")]
        public static extern short GT_SetAdcFilterPrm(short cardNum,short adc, double k);
        [DllImport("gts.dll")]
        public static extern short GT_GetAdcFilterPrm(short cardNum,short adc, out double pk);

        //Superimposed
        [DllImport("gts.dll")]
        public static extern short GT_SetControlSuperimposed(short cardNum,short control, short superimposedType, short superimposedIndex);
        [DllImport("gts.dll")]
        public static extern short GT_GetControlSuperimposed(short cardNum,short control, out short pSuperimposedType, out short pSuperimposedIndex);

        ////////////////////
        [DllImport("gts.dll")]
        public static extern short GT_ZeroLaserOnTime(short cardNum,short channel);
        [DllImport("gts.dll")]
        public static extern short GT_GetLaserOnTime(short cardNum,short channel,out uint pTime);
        
        [DllImport("gts.dll")]
        public static extern short GT_SetProfileScale(short cardNum,short axis,int alpha,int beta);
        [DllImport("gts.dll")]
        public static extern short GT_GetProfileScale(short cardNum,short axis,out int pAlpha,out int pBeta);
        [DllImport("gts.dll")]
        public static extern short GT_SetEncoderScale(short cardNum,short encoder,int alpha,int beta);
        [DllImport("gts.dll")]
        public static extern short GT_GetEncoderScale(short cardNum,short encoder,out int pAlpha,out int pBeta);
        [DllImport("gts.dll")]
        public static extern short GT_MultiAxisOn(short cardNum,uint mask);
        [DllImport("gts.dll")]
        public static extern short GT_MultiAxisOff(short cardNum,uint mask);
        [DllImport("gts.dll")]
        public static extern short GT_SetAxisOnDelayTime(short cardNum,ushort ms);
        [DllImport("gts.dll")]
        public static extern short GT_GetAxisOnDelayTime(short cardNum,out ushort pMs);
        [DllImport("gts.dll")]
        public static extern short GT_SetLaserDisTable1D(short cardNum,short count,ref double pRatio,ref int pPos,double minPower,double maxPower,ref double pLimitPower,short channel);
        [DllImport("gts.dll")]
        public static extern short GT_SetLaserDisTable2D(short cardNum,short[] axisIndex,short[] count,ref double pRatio,ref int pXPos,ref int pYPos, 
							 																						double minPower,double maxPower,ref double pLimitPower,short channel);
        [DllImport("gts.dll")]
        public static extern short GT_SetLaserDisTable2DEx(short cardNum,short[] axisIndex,short[] count,ref double pRatio,int[] posBegin,int[] posStep, 
							   																						double minPower,double maxPower,ref double pLimitPower,short channel);
        [DllImport("gts.dll")]
        public static extern short GT_SetLaserCrdMap(short cardNum,short channel,short map);
        [DllImport("gts.dll")]
        public static extern short GT_GetLaserCrdMap(short cardNum,short channel,ref short pMap);
        
        //////////////////////////////////////////////////////////////////////////
				//AutoFocus
				//////////////////////////////////////////////////////////////////////////
        [DllImport("gts.dll")]
        public static extern short GT_AutoFocus(short cardNum,ushort mode,double kp,short reverse,short chanel);
        [DllImport("gts.dll")]
        public static extern short GT_SetAutoFocusRefVol(short cardNum,double refVol,double maxVol,double minVol,short chanel);
        [DllImport("gts.dll")]
        public static extern short GT_GetAutoFocusStatus(short cardNum,out ushort pStatus,short count);
        [DllImport("gts.dll")]
        public static extern short GT_ConfigAutoFocus(short cardNum,short chnAdc,short chanel);
        [DllImport("gts.dll")]
        public static extern short GT_SetAutoFocusAuxPrm(short cardNum,double kf,double kd,double limitKd,short chanel);
        
        
        [DllImport("gts.dll")]
        public static extern short GT_Delay(short cardNum,ushort time);
        [DllImport("gts.dll")]
        public static extern short GT_DelayHighPrecision(short cardNum,ushort time);
        
        [DllImport("gts.dll")]
        public static extern short GT_SetCrdBufferMode(short cardNum,short crd,short bufferMode,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_GetCrdBufferMode(short cardNum,short crd,out short pBufferMode,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_GetCrdSegmentTime(short cardNum,short crd,int segmentIndex,out double pSegmentTime,out int pSegmentNumber,short fifo);
        [DllImport("gts.dll")]
        public static extern short GT_GetCrdTime(short cardNum,short crd,out CRD_TIME pTime,short fifo);
        
        [DllImport("gts.dll")]
        public static extern short GT_SetLeadScrewLink(short cardNum,short axis,short link);
        [DllImport("gts.dll")]
        public static extern short GT_GetLeadScrewLink(short cardNum,short axis,out short pLink);

        //////////////////////////////////////////////////////////////////////////
        //Gantry
        //////////////////////////////////////////////////////////////////////////
        
        public const short m_c_GANTRY_MODE_NONE = -1;
        public const short m_c_GANTRY_MODE_OPEN_LOOP_GANTRY	= 1;
        public const short m_c_GANTRY_MODE_DECOUPLE_POSITION_LOOP = 2;

        [DllImport("gts.dll")]
        public static extern short GT_SetGantryMode(short cardNum,short group,short master,short slave,short mode,int syncErrorLimit);
        [DllImport("gts.dll")]
        public static extern short GT_GetGantryMode(short cardNum,short group, out short pMaster, out short pSlave, out short pMode, out int pSyncErrorLimit);
        [DllImport("gts.dll")]
        public static extern short GT_SetGantryPid(short cardNum,short group, ref PID pGantryPid, ref PID pYawPid);
        [DllImport("gts.dll")]
        public static extern short GT_GetGantryPid(short cardNum,short group, out PID pGantryPid, out PID pYawPid);
        [DllImport("gts.dll")]
        public static extern short GT_GantryAxisOn(short cardNum,short group);
        [DllImport("gts.dll")]
        public static extern short GT_GantryAxisOff(short cardNum,short group);
        [DllImport("gts.dll")]
        public static extern short GT_GantryHoming(short cardNum);
    }
}
