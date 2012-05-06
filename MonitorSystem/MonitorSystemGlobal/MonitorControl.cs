using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using MonitorSystem.Web.Moldes;
using System.Collections.ObjectModel;

namespace MonitorSystem.MonitorSystemGlobal
{
    public abstract partial class MonitorControl : UserControl
    {
        public bool IsDesignMode { get { return null != AdornerLayer; } }
        protected Adorner AdornerLayer { get; set; }
        public abstract void DesignMode();
        public abstract void UnDesignMode();
        public abstract object GetRootControl();

        public abstract event EventHandler Selected;
        public t_Element ScreenElement { get; set; }

        /// <summary>
        /// 控件自定义属性列表,控件值
        /// </summary>
        public List<t_ElementProperty> ListElementProp{ get; set; }
        /// <summary>
        /// 设置控件自定义属性值
        /// </summary>
        public abstract void SetPropertyValue();

        public abstract void SetCommonPropertyValue();

        /// <summary>
        /// 控件状态，新添加的，或以保存的
        /// </summary>
        public ElementSate ElementState;

        public void SetAttrByName(string name, object value)
        {
            if (ListElementProp == null)
                return;
            foreach (t_ElementProperty ep in ListElementProp)
            {
                if (ep.PropertyName.Trim().ToUpper() == name.Trim().ToUpper())
                {
                    ep.PropertyValue = value.ToString();
                    break;
                }
            }
        }

        

        private  string[] m_BrowsableProperties = new string[] { "Left", "Top", "Width", "Height", "FontFamily", "FontSize", "Translate", "Foreground" };

        public abstract string[] BrowsableProperties { set; get; }
        //{
        //    get { return m_BrowsableProperties; }
        //    set { m_BrowsableProperties = value; }
        //}

        


        public double Translate
        {
            get { return (double)GetValue(OpacityProperty) * 100d; }
            set { SetValue(OpacityProperty, value / 100d); }
        }

        public double Left
        {
            get { return (double)GetValue(Canvas.LeftProperty); }
            set { SetValue(Canvas.LeftProperty, value); AdornerLayer.SetValue(Canvas.LeftProperty, value); }
        }

        public double Top
        {
            get { return (double)GetValue(Canvas.TopProperty); }
            set { SetValue(Canvas.TopProperty, value); AdornerLayer.SetValue(Canvas.TopProperty, value); }
        }

        public MonitorControl()
        {
            SetValue(FontFamilyProperty, new FontFamily("宋体"));
            SetValue(ForegroundProperty, new SolidColorBrush(Colors.Black));
        }

        #region 设置值
        protected float m_fValue;//通道值
        protected float[] m_fValueArray;
        //设置元素的值
        public virtual void SetChannelValue(float fValue)
        {
            m_fValue = fValue;
        }

        //设置元素的值(数组)
        public virtual void SetChannelValue(float[] fValueArray)
        {
            m_fValueArray = fValueArray;
        }

        //设置元素的值(数组)
        public virtual void SetChannelValue(float fPosition, float fValueArray)
        {
            //m_fValueArray = fValueArray;
        }
        #endregion
    }

    public enum ElementSate
    {
        New, Save
    }

    public static class StringExtent
    {
        public static string Clone(this string src)
        {
            return string.Copy(src);
        }
    }

    #region 监组组态的共公数据结构

    //public class ControlPropertyObj
    //{
    //    public int PropertyNo;
    //    public string PropertyName;
    //    public string DefaultValue;
    //    public string Caption;
    //    public int ControlID;
    //}

    //public class UserObj
    //{
    //    public int UserID;
    //    public string UserPSW;
    //    public string UserName;
    //    public int UserType;
    //}

    //public class ControlObj
    //{
    //    public int ControlID;
    //    public string ControlName;
    //    public int ControlType;
    //    public string ImageURL;
    //    public string ControlTypeName;
    //    public string ControlCaption;
    //    public IList<ControlPropertyObj> m_listProperty = new List<ControlPropertyObj>();//控件的所有属性
    //}

    //public class ElementPropertyObj
    //{
    //    public int PropertyNo;
    //    public string PropertyValue;
    //    public string PropertyName;
    //    public string Caption;
    //    public int m_State;//0,没修改过,1修改过
    //    public int ElementID;
    //}
    //public class ElementObj
    //{
    //    public int ElementID;
    //    public int ScreenID;
    //    public int Width;
    //    public int Height;
    //    public int ScreenX;
    //    public int ScreenY;
    //    // 2009-7-27
    //    public string ChildScreenID;
    //    public string TxtInfo;
    //    public string ImageURL;
    //    public string ForeColor;
    //    public string BackColor;
    //    // 2008-11-30:
    //    public int Transparent;
    //    // 2009-4-20
    //    public int oldX;
    //    public int oldY;

    //    //2011-3-7 xxy增加
    //    public int Method;
    //    public float MinFloat;
    //    public float MaxFloat;
    //    public int SerialNum;
    //    public float TotalLength;
    //    //2011-5-30: zeng   
    //    public int LevelNo;
    //    // 2011-12-7:
    //    public string ComputeStr;

    //    public string Font;
    //    public string ElementName;
    //    public IList<ElementPropertyObj> m_listProperty = new List<ElementPropertyObj>();
    //    public int DeviceID;
    //    public int ChannelNo;
    //    //父类Control的属性,都入到这
    //    public int ControlID;
    //    public string ControlName;
    //    public string ControlCaption;
    //    public int ControlType;
    //    public MonitorControl m_MonitorControl;//界面显示，对应的控件实体

    //    public int m_State;//0,没修改,1：修改,2:添加,3,删除

    //    public static int STATE_NONE = 0;
    //    public static int STATE_MODIFY = 1;
    //    public static int STATE_ADD = 2;
    //    public static int STATE_DELETE = 3;

    //    public static int CONTROLTYPE_TP = 1;//拓朴控件
    //    public static int CONTROLTYPE_MONITOR = 2;//组态控件
    //    public static int CONTROLTYPE_COMMON = 3;//组态控件

    //    //public int m_IsShowContextMenu = false;

    //    //深度复制
    //    public static ElementObj ElementObjClone(ElementObj oldElement)
    //    {
    //        ElementObj newElement = new ElementObj();
    //        //newElement.ElementID = oldElement.ElementID;
    //        newElement.ScreenID = oldElement.ScreenID;
    //        newElement.Width = oldElement.Width;
    //        newElement.Height = oldElement.Height;
    //        newElement.ScreenX = oldElement.ScreenX;
    //        newElement.ScreenY = oldElement.ScreenY;
    //        newElement.ChildScreenID = oldElement.ChildScreenID;
    //        newElement.TxtInfo = oldElement.TxtInfo.Clone().ToString();
    //        newElement.ImageURL = oldElement.ImageURL.Clone().ToString();
    //        newElement.Font = oldElement.Font.Clone().ToString();
    //        newElement.ForeColor = oldElement.ForeColor.Clone().ToString();
    //        newElement.BackColor = oldElement.BackColor.Clone().ToString();

    //        // 2008-11-30:
    //        newElement.Transparent = oldElement.Transparent;

    //        newElement.ElementName = oldElement.ElementName;
    //        newElement.DeviceID = oldElement.DeviceID;
    //        newElement.ChannelNo = oldElement.ChannelNo;
    //        //父类Control的属性,都入到这
    //        newElement.ControlID = oldElement.ControlID;
    //        newElement.ControlName = oldElement.ControlName.Clone().ToString();
    //        newElement.ControlType = oldElement.ControlType;

    //        foreach (ElementPropertyObj pObj in oldElement.m_listProperty)
    //        {
    //            ElementPropertyObj newProperty = new ElementPropertyObj();
    //            newProperty.m_State = ElementObj.STATE_ADD;
    //            newProperty.PropertyName = pObj.PropertyName.Clone().ToString();
    //            newProperty.PropertyNo = pObj.PropertyNo;

    //            newProperty.Caption = pObj.Caption;
    //            newProperty.PropertyValue = pObj.PropertyValue.Clone().ToString();
    //            newProperty.ElementID = newElement.ElementID;
    //            newElement.m_listProperty.Add(newProperty);

    //        }
    //        return newElement;
    //    }

    //    //从控件生成元素
    //    //public static ElementObj CreateByControl(ControlObj myControlObj)
    //    //{

    //    //    ElementObj newElement = new ElementObj();
    //    //    newElement.ElementID = 0;
    //    //    newElement.ScreenID = 0;
    //    //    newElement.Width = 20;
    //    //    newElement.Height = 20;
    //    //    newElement.ScreenX = 0;
    //    //    newElement.ScreenY = 0;
    //    //    // 2009-7-27
    //    //    newElement.ChildScreenID = "0";
    //    //    newElement.TxtInfo = "";
    //    //    newElement.ForeColor = "RGB(0,0,0)";
    //    //    newElement.BackColor = "RGB(0,0,0)";
    //    //    // 2008-11-30:
    //    //    newElement.Transparent = 0;

    //    //    newElement.ImageURL = myControlObj.ImageURL;
    //    //    newElement.Font = "宋体";
    //    //    newElement.ElementName = myControlObj.ControlName;
    //    //    newElement.DeviceID = -1;
    //    //    newElement.ChannelNo = -1;
    //    //    //父类Control的属性,都入到这
    //    //    newElement.ControlID = myControlObj.ControlID;
    //    //    newElement.ControlName = myControlObj.ControlName;
    //    //    newElement.ControlType = myControlObj.ControlType;

    //    //    foreach (ControlPropertyObj pObj in myControlObj.m_listProperty)
    //    //    {
    //    //        ElementPropertyObj newProperty = new ElementPropertyObj();
    //    //        newProperty.m_State = ElementObj.STATE_ADD;
    //    //        newProperty.PropertyName = pObj.PropertyName;
    //    //        newProperty.PropertyNo = pObj.PropertyNo;
    //    //        newProperty.ElementID = newElement.ElementID;
    //    //        newProperty.PropertyValue = pObj.DefaultValue;
    //    //        newProperty.Caption = pObj.Caption;
    //    //        newElement.m_listProperty.Add(newProperty);
    //    //    }
    //    //    return newElement;
    //    //}
    //    //设置状态
    //    //public void SetState(int newState)
    //    //{
    //    //    if (this.m_State == ElementObj.STATE_DELETE) return;
    //    //    if (this.m_State == ElementObj.STATE_ADD && newState == STATE_MODIFY)
    //    //        return;

    //    //    this.m_State = newState;

    //    //    //if (newState == 2 && this.m_State == 1) return;//添加时不要转换到修改
    //    //    //this.m_State = newState;

    //    //}
    //}

    /// <summary>
    /// 2009-10-13
    /// </summary>
    //public class StationObj
    //{
    //    public int StationID;
    //    public string StationName;
    //    public string IP;
    //    public int Port;
    //}

    //public class ScreenObj
    //{
    //    private int m_ScreenID;

    //    public int ScreenID
    //    {
    //        get { return m_ScreenID; }
    //        set { m_ScreenID = value; }
    //    }
    //    public int ParentScreenID;
    //    private string m_ScreenName;

    //    public string ScreenName
    //    {
    //        get { return m_ScreenName; }
    //        set { m_ScreenName = value; }
    //    }
    //    public string ImageURL;
    //    public int StationID;
    //    public IList<ElementObj> m_listElement = new List<ElementObj>();//本场景的所有元素
    //}
    #endregion

    #region 别一些共公数据(配置程序时)
    public class AlarmLogObj
    {
        public int StationID;
        public string EventsName;
        public int AlarmLogID;
        public string DeviceName;
        public string Content;
        public DateTime HappenTime;
        public string RelieveTime;
        public string UserName;
        public int AlarmLevel;
        public int DeviceID;
        public float MonitorValue;
        public int OperateUserID;
        public string LastTime;
        // 2011-10-11
        public string AlarmType;
    }

    public class AlarmActionObj
    {
        public int nActionID;
        public string strActionModule;
        public string strActionCommand;
        public string strActionParam;
        public string strActionName;
    }

    public class PolicyAction
    {
        public int PolicyID;
        public int Id;
        public string AlarmMethod;
        public string VoiceFile;
        public string Target;
        public string AlarmTime;

        public int AlarmLevel;
    }

    public class AlarmTimeObj
    {
        public int AlarmTimeID;
        public string AlarmTimeName;
        public string AlarmBeginTime;
        public string AlarmEndTime;
    }


    public class AlarmPolciyObj
    {
        public int nPolicyID;
        public string strPolicyName;
        public string strPolicyContent;
        public int nAlarmLevel;
        public int nDeviceTypeID;
        public IList<int> PolicyDeviceMap = new List<int>();
        // public string strPolicyDistribute;
        public int nStationID;
        // public string strPolicyAction;
        // public IList<int> PolicyActionMap = new List<int>();
        public IList<PolicyAction> PolicyActionMap = new List<PolicyAction>();

        public string strPolicyFormula;
        public int nTimeInterval = 6;
    }

    public class ChannelTypeObj
    {
        public int nDeviceTypeID;
        public int nChannelNo;
        public string strChannelTypeName;
        public string strOperateCommand;
        public string strOperateParam;
        public int nValueType;
        public string strValue0_Name;
        public string strValue1_Name;

    }

    public class DeviceMoubusType
    {
        public int nStationID;
        public string nStationName;
        public int nDeviceID;
        public int nDeviceTypeID;
        public string nDeviceName;
        public int nCommunicate;
        public int? nChannelNo;
        public string nChannelName;
        public string nAddr;
        public string nSendStr;
        public int? nOrderType;
        public string nAnalyTemp;
        public int? nSendDelay;
        public string nSendType;
        public int? nRetryTimes;
        public float nMonitorValue;
        public string nUnit;
        public int LenCheck;
    }

    // 2011-9-15::SNMP相关
    public class Snmp_Send
    {
        public int SendDelay;
        public int RetryTimes;
        public string OID;
        public string MethodType;
        public string VersionNo;
        public int DeviceTypID;

    }

    public class Snmp_Recv
    {
        public int DeviceTypID;
        public int SendSnmpID;
        public int ChannnelNO;
        public string ChannelName;
        public string OID;
        public string ValueType;
        public string Unit;
        public string Param;
        public string Info;
        public string ComputeStr;
    }

    public class DeviceTypeObj
    {

        public int nDeviceTypeID;
        public int SaveTimeInteval;//设备采集的时间间隔  
        public int DeviceTypeID
        {
            get { return nDeviceTypeID; }
            set { nDeviceTypeID = value; }
        }
        public string strTypeName;

        public string TypeName
        {
            get { return strTypeName; }
            set { strTypeName = value; }
        }
        //2011-1-4曾巍  添加ip,param
        public string ip;

        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }
        public string param;

        public string Param
        {
            get { return param; }
            set { param = value; }
        }
        //2011-2-21曾巍  添加stationid
        public int stationid;

        public int StationID
        {
            get { return stationid; }
            set { stationid = value; }
        }

        public string strParseDLL;
        public IList<int> PolicyDevicTypeeMap = new List<int>();
        public IList<PolicyAction> PolicyActionMap = new List<PolicyAction>();
    }

    public class SerialPortObj
    {
        public int nSerialPortID;

        public int SerialPortID
        {
            get { return nSerialPortID; }
            set { nSerialPortID = value; }
        }
        public string strSerialPortName;

        public string SerialPortName
        {
            get { return strSerialPortName; }
            set { strSerialPortName = value; }
        }
        public string strCommunicationParam;
        public int nScanInterval;
        public int stationID;
        public int StationID
        {
            get { return stationID; }
            set { stationID = value; }
        }
        public string stationName;
        public string StationName
        {
            get { return stationName; }
            set { stationName = value; }
        }
    }

    //对象类
    public class DeviceObj
    {
        public int nDeviceID;

        public int DeviceID
        {
            get { return nDeviceID; }
            set { nDeviceID = value; }
        }
        public string strDeviceName;

        public string DeviceName
        {
            get { return strDeviceName; }
            set { strDeviceName = value; }
        }
        public int nStationID;
        public int nCommunicateType;
        public int nCommunicateID;
        public string strSubAddr;
        public int nDeviceTypeID;
        public string strParseDLL;
        public string strTypeName;

        public string UserId;
    }

    //在combo中用get set
    public class ChannelObj
    {
        public int nDeviceID;
        public int nChannelNo;
        public string strChannelParam;
        public int ChannelNo
        {
            get { return nChannelNo; }
            set { nChannelNo = value; }
        }
        public string strChannelName;

        public string ChannelName
        {
            get { return strChannelName; }
            set { strChannelName = value; }
        }
        public string strOperateCommand;
        public string strOperateParam;
        public int nValueType;
        public string strValue0_Name;
        public string strValue1_Name;
        public string strChannelTypeName;
        public int nDeviceTypeID;
        public float fCurrentValue;
    }



    public class DevcieDetailObj
    {
        public DeviceObj m_DeviceObj;
        public IList<ChannelObj> m_listChannelObj = new List<ChannelObj>();

    }

    public class SchedulingObj
    {
        public int Frequency;
        public string FrequencyName;
        public string StartTime;
        public string EndTime;
        public int StationID;
    }
    public class AlarmGroupsObj
    {
        public int ID;
        public int AlarmGroupsID;
        public string GroupName;
        public int StationID;
    }
    public class AlarmGroupsMemberObj
    {
        public int ID;
        public int AlarmGroupsID;
        public string Name;
        public string MobileNo;
        public string TelNo;
        public string Email;
        public int Scheduling;
        public int ProcessLevel;
        public int StationID;
    }
    public class AlarmLevelSetObj
    {
        public int ID;
        public string LevelName;
        public string Priority;
        public string UpInterval;
        public int StationID;
    }
    public class LinkageSetObj
    {
        public int ID;
        public int StationID;
        public int DeviceID;
        public int ChannelNo;
        public int ValueType;
        public float MaxTriggerValue;
        public float MinTriggerValue;
        public int SwitchTriggerValue;
        public int LinkageStationID;
        public int LinkageDeviveID;
        public int LinkageChannelNo;
        public float LinkageMaxValue;
        public float LinkagMinValue;
        public int LinkageSwitchValue;
    }
    public class LinkageTimeSetObj
    {
        public int ID;
        public int LinkageID;
        public int LinkageStationID;
        public string TriggerTime;
        public int LinkageDeviceID;
        public int LinkageChannelNo;
    }
    public class AlramBindTimeObj
    {
        public int ID;
        public int StationID;
        public int DeviceID;
        public int ChannelNo;
        public int IntervalTime;
    }
    public class MainteObj
    {
        public int ID;
        public int DeviceID;
        public int StationID;
        public string ContentMainte;
        public string MainteName;
        public int ValueType;
        public string MainteTime;
        public string Duty;
    }
    public class GroupsObj
    {
        public int AlarmGroupsID;
        public string GroupName;
        public int StationID;
    }
    public class GenChannelTypeObj
    {
        public int nDecID;
        public int nDeviceTypeID;
        public int nSendStrID;
        public string nDecStr;
        public int nChannelNO;
        public string nChannelName;
        public int nValueType;
        public string nParam;
        public string nValue0Name;
        public string nValue1Name;
        public string nUnit;
    }

    // 2011-9-23
    public class SnmpChannelTypeObj
    {
        public int nDecID;
        public int nDeviceTypeID;
        public int SendSnmpID;
        public string OID;
        public int nChannelNO;
        public string nChannelName;
        public int nValueType;
        public string nParam;
        public string nUnit;
    }
    #endregion

    #region 系统参数

    public class MonitorSystemParam
    {
        public static int StartScreenID = 0;
        // 2009-10-7
        public static bool AutoStartVideo = false;
        public static int VideoScreenID = 0;
        public static int AlarmLogShowLine = 10;
        public static int AlarmLogTime = 5;
        public static int MonitorRefreshTime = 5;
        public static int ServerPort = 0;
        public static String ServerIP = "";
        // 2011-11-04
        public static int ControlPort = 0;

        public static string Door_Sysid = "01";
        public static int Door_Com = 1;
        public static int HaveDoor = 0;

        // 最大报警层次数，报警时依次从1报到AlarmMaxLevel
        public static int AlarmMaxLevel = 1;

        public static int UserID = 1;
        public static string PSW = "";

        // 2011-2-17::增加网络调试日志
        public static int NetDebug = 0;

        public static int g_srcScreenX = 1024;
        public static int g_srcSscreenY = 768;


        public static int g_dstScreenX = 1024;
        public static int g_dstSscreenY = 768;

        // 2011-10-12
        public static int g_curUserType = -1;
        // 2011-10-19:
        public static int g_IsLog = 0;


    }

    public class MonitorSystemConfig
    {
        public static string SplashScreen = "";
        public static string CompanyName = "";
        public static string SoftwareName = "";
        public static string SoftwareVersion = "";
        public static string SoftwareDescription = "";
        public static string SoftwareState = "";
        public static string connString = "";
        public static string dbType = "";
        public static string mysqlconnString = "";
    }


    public class SystemConfigManager
    {
        public void GetSystemConfig()
        {
            // Modify by ab in 2012-04-12
            // TODO : 
            var xmlPath = new Uri(App.Current.Host.Source, "../SystemConfig.xml").ToString();

            #region unused code
            ////string xmlPath = "..\\..\\Design\\SystemConfig.xml";
            //string xmlPath = "\\SystemConfig.xml";
            //xmlPath = Environment.SystemDirectory.ToString() + xmlPath;
            //XmlDocument m_xml = new XmlDocument();
            //XmlTextReader m_reader = new XmlTextReader(xmlPath);

            //m_xml.Load(m_reader);
            ////ControlObj m_obj = new ControlObj();

            //// MonitorSystemConfig m_config = new MonitorSystemConfig();
            //XmlNode parent = m_xml.ChildNodes[1];
            //XmlNode splash = parent.ChildNodes[0];
            //MonitorSystemConfig.SplashScreen = splash.InnerText;
            //XmlNode software = parent.ChildNodes[1];
            //XmlNode company = software.ChildNodes[0];
            //XmlNode companyname = company.ChildNodes[0];
            //MonitorSystemConfig.CompanyName = companyname.InnerText;
            //XmlNode version = software.ChildNodes[1];
            //XmlNode name = software.ChildNodes[2];
            //XmlNode description = software.ChildNodes[3];
            //XmlNode state = software.ChildNodes[4];
            //MonitorSystemConfig.SoftwareVersion = version.InnerText;
            //MonitorSystemConfig.SoftwareName = name.InnerText;
            //MonitorSystemConfig.SoftwareDescription = description.InnerText;
            //MonitorSystemConfig.SoftwareState = state.InnerText;

            //XmlNode conn = parent.ChildNodes[2];
            //// 2011-10-17::修改读取配置文件格式
            //if (parent.ChildNodes.Count > 5)
            //{
            //    XmlNode tmpconn = parent.ChildNodes[5];
            //    if (tmpconn.Name.IndexOf("connSystem") > -1)
            //        conn = tmpconn;
            //}
            //MonitorSystemConfig.connString = conn.InnerText;

            //XmlNode db = parent.ChildNodes[3];
            //if (db == null)
            //{
            //    MessageBox.Show("请将V4.5以上的SystemConfig.xml文件放到系统system32目录下!", "错误!");
            //    return;
            //}
            //else
            //    MonitorSystemConfig.dbType = db.InnerText;

            //XmlNode mysql = parent.ChildNodes[4];
            //MonitorSystemConfig.mysqlconnString = mysql.InnerText;
            ////return m_config;  
            #endregion
            // end modify
        }
    }
    #endregion

    #region 网络通信的指令

    public static class NetCommandType
    {
        public const int NC_GET_CHANNEL = 0x20;//请求通道值
        public const int NC_ACK_CHANNEL = 0x21; //返回通道值
        public const int NC_CONTROL_CHANNEL = 0x22; //控制通道

        public const int NC_GET_ALL_HISTORY = 0x30; //所有通道的历史值
        public const int NC_ACK_HISTORY = 0x31; //返回历史值


        public const int NC_SET_CHANNEL = 0x40; //设置通道值
        public const int NC_ACK_SET_CHANNEL = 0x41;//设置回应

        public const int NC_ACK_ALARM = 0x50;//设置回应
    }

    //单个通道内容
    public struct tagChannel
    {
        public Int32 nDeviceID;
        public Int32 nChannelNo;
        public Int32 nTime;
        public float fValue;
    }

    //多个通道参数指令
    public struct tagChannelCommand
    {
        public byte cType;
        public Int32 nStationID;
        public Int32 nScreenID;
        public Int32 nCount;
        public IList<tagChannel> listCMD;

    }


    //ascii码指令
    public struct tagTextCommand
    {
        public byte cType;
        public Int32 nStationID;
        public string m_text;
    }

    public struct tagControlCMD
    {
        public Int32 nDeviceID;
        public Int32 nChannelNo;
        public Int32 cmdtype;
        public Int32 cmdparam;
    };

    #endregion

    #region 报警设置相关数据结构

    public class TargetData
    {
        public int Id;
        public string Name;
        public string MobileNo;
        public string TelNo;
        public int ParentId;
    }

    public class AlarmMethod
    {
        public int Id;
        public string Name;
        public string Type;
        public int TargetId;
    }

    public class AlarmGroupStruct
    {
        public int Id;
        public string Name;
        public string MethodId;
        public string MethodName;

    }

    #endregion

    #region 服务器参数结构
    public class ServerParam
    {
        public string smsComPort;
        public string smsComPortSetting;
        public string stationId;
        public int saveInterval;
        public int listenPort;
        public string smstype;
        public string smsCenterNo;
        public int stationID;
        public string stationName;
        public string nremoteip;
        public string nremotereport;
        public int IsCheck;
        public int IsSmsCheck;
    }
    #endregion

    #region 联动相关数据结构

    public class RelationAction
    {
        public Int32 StationId = -1;
        public IList<RelationActionEach> rel = new List<RelationActionEach>();
    }

    public class RelationActionEach
    {
        public Int32 ID = -1;

        public Int32 SourceDeviceID = -1;  // 联动源设备
        public Int32 SourceChannelNo = -1; // 联动源通道
        public float StartValue = 0.0f; // 联动开始动作的值
        public float StopValue = 0.0f;  // 联动结束动作的值

        public float LastValue = -2; // 


        public string ActionDevType = "video"; // 联动目的设备类型，暂时只支持视频设备,即video
        public string ActionDevParam = "start"; // 联动动作参数

        public Int32 DestDeviceID = -1;  // 联动目的设备
        public Int32 DestChannelNo = -1; // 联动目的通道

        // 2010-11-15
        public DateTime RecingTime = DateTime.Now;

        // Modify by ab in 2012-04-12
        // public System.Threading.Mutex mutex = new System.Threading.Mutex(false);
        public System.Threading.AutoResetEvent mutex = new System.Threading.AutoResetEvent(false);
        // end modify
        public bool IsRecing = false;
    }
    #endregion

    #region 公共实用函数

    public class UtilTool
    {
        public static string GetExecutePath()
        {
            // Modify by ab in 2012-04-12
            return new Uri(Application.Current.Host.Source, "../").ToString();
            //string s = Application.Current.Host.;
            //int idx = s.LastIndexOf('\\');
            //if (idx > -1)
            //{
            //    s = s.Substring(0, idx + 1);
            //}
            //string path = s;
            //return path;
            // end Modify
        }
    }

    #endregion
}
