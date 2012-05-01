
namespace MonitorSystem.Web.Moldes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies t_AlarmActionMetadata as the class
    // that carries additional metadata for the t_AlarmAction class.
    [MetadataTypeAttribute(typeof(t_AlarmAction.t_AlarmActionMetadata))]
    public partial class t_AlarmAction
    {

        // This class allows you to attach custom attributes to properties
        // of the t_AlarmAction class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_AlarmActionMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_AlarmActionMetadata()
            {
            }

            public string ActionCommand { get; set; }

            public int ActionID { get; set; }

            public string ActionModule { get; set; }

            public string ActionName { get; set; }

            public string ActionParam { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_AlarmGroupMetadata as the class
    // that carries additional metadata for the t_AlarmGroup class.
    [MetadataTypeAttribute(typeof(t_AlarmGroup.t_AlarmGroupMetadata))]
    public partial class t_AlarmGroup
    {

        // This class allows you to attach custom attributes to properties
        // of the t_AlarmGroup class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_AlarmGroupMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_AlarmGroupMetadata()
            {
            }

            public int Id { get; set; }

            public string MethodId { get; set; }

            public string MethodName { get; set; }

            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_AlarmLevelMetadata as the class
    // that carries additional metadata for the t_AlarmLevel class.
    [MetadataTypeAttribute(typeof(t_AlarmLevel.t_AlarmLevelMetadata))]
    public partial class t_AlarmLevel
    {

        // This class allows you to attach custom attributes to properties
        // of the t_AlarmLevel class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_AlarmLevelMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_AlarmLevelMetadata()
            {
            }

            public Nullable<int> AlarmInteval { get; set; }

            public int AlarmLevelID { get; set; }

            public string LevelName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_ChannelMetadata as the class
    // that carries additional metadata for the t_Channel class.
    [MetadataTypeAttribute(typeof(t_Channel.t_ChannelMetadata))]
    public partial class t_Channel
    {

        // This class allows you to attach custom attributes to properties
        // of the t_Channel class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_ChannelMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_ChannelMetadata()
            {
            }

            public string ChannelName { get; set; }

            public int ChannelNo { get; set; }

            public string ChannelParam { get; set; }

            public Nullable<double> CurrentValue { get; set; }

            public int DeviceID { get; set; }

            public string Value0_Name { get; set; }

            public string Value1_Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_ChannelHistoryValueMetadata as the class
    // that carries additional metadata for the t_ChannelHistoryValue class.
    [MetadataTypeAttribute(typeof(t_ChannelHistoryValue.t_ChannelHistoryValueMetadata))]
    public partial class t_ChannelHistoryValue
    {

        // This class allows you to attach custom attributes to properties
        // of the t_ChannelHistoryValue class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_ChannelHistoryValueMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_ChannelHistoryValueMetadata()
            {
            }

            public int ChannelNo { get; set; }

            public int DataID { get; set; }

            public int DeviceID { get; set; }

            public Nullable<DateTime> MonitorTime { get; set; }

            public Nullable<double> MonitorValue { get; set; }

            public Nullable<int> StationID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_ChannelHistoryValuetempMetadata as the class
    // that carries additional metadata for the t_ChannelHistoryValuetemp class.
    [MetadataTypeAttribute(typeof(t_ChannelHistoryValuetemp.t_ChannelHistoryValuetempMetadata))]
    public partial class t_ChannelHistoryValuetemp
    {

        // This class allows you to attach custom attributes to properties
        // of the t_ChannelHistoryValuetemp class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_ChannelHistoryValuetempMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_ChannelHistoryValuetempMetadata()
            {
            }

            public Nullable<int> ChanenlSubNo { get; set; }

            public int ChannelNo { get; set; }

            public int DataID { get; set; }

            public int DeviceID { get; set; }

            public string Info { get; set; }

            public Nullable<DateTime> MonitorTime { get; set; }

            public Nullable<double> MonitorValue { get; set; }

            public Nullable<int> StationID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_ChannelTypeMetadata as the class
    // that carries additional metadata for the t_ChannelType class.
    [MetadataTypeAttribute(typeof(t_ChannelType.t_ChannelTypeMetadata))]
    public partial class t_ChannelType
    {

        // This class allows you to attach custom attributes to properties
        // of the t_ChannelType class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_ChannelTypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_ChannelTypeMetadata()
            {
            }

            public int ChannelNo { get; set; }

            public string ChannelTypeName { get; set; }

            public int DeviceTypeID { get; set; }

            public string OperateCommand { get; set; }

            public string OperateParam { get; set; }

            public string Unit { get; set; }

            public string Value0_Name { get; set; }

            public string Value1_Name { get; set; }

            public Nullable<int> ValueType { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_ControlMetadata as the class
    // that carries additional metadata for the t_Control class.
    [MetadataTypeAttribute(typeof(t_Control.t_ControlMetadata))]
    public partial class t_Control
    {

        // This class allows you to attach custom attributes to properties
        // of the t_Control class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_ControlMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_ControlMetadata()
            {
            }

            public string ControlCaption { get; set; }

            public int ControlID { get; set; }

            public string ControlName { get; set; }

            public Nullable<int> ControlType { get; set; }

            public string ControlTypeName { get; set; }

            public string ImageURL { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_ControlPropertyMetadata as the class
    // that carries additional metadata for the t_ControlProperty class.
    [MetadataTypeAttribute(typeof(t_ControlProperty.t_ControlPropertyMetadata))]
    public partial class t_ControlProperty
    {

        // This class allows you to attach custom attributes to properties
        // of the t_ControlProperty class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_ControlPropertyMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_ControlPropertyMetadata()
            {
            }

            public string Caption { get; set; }

            public int ControlID { get; set; }

            public string DefaultValue { get; set; }

            public string PropertyName { get; set; }

            public int PropertyNo { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_DeviceMetadata as the class
    // that carries additional metadata for the t_Device class.
    [MetadataTypeAttribute(typeof(t_Device.t_DeviceMetadata))]
    public partial class t_Device
    {

        // This class allows you to attach custom attributes to properties
        // of the t_Device class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_DeviceMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_DeviceMetadata()
            {
            }

            public Nullable<int> CommunicateID { get; set; }

            public Nullable<int> CommunicateType { get; set; }

            public int DeviceID { get; set; }

            public string DeviceName { get; set; }

            public Nullable<int> DeviceTypeID { get; set; }

            public Nullable<int> Enable { get; set; }

            public string IP { get; set; }

            public string Password { get; set; }

            public Nullable<int> Port { get; set; }

            public Nullable<int> StationID { get; set; }

            public string StationName { get; set; }

            public string SubAddr { get; set; }

            public string UserId { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_ElementMetadata as the class
    // that carries additional metadata for the t_Element class.
    [MetadataTypeAttribute(typeof(t_Element.t_ElementMetadata))]
    public partial class t_Element
    {

        // This class allows you to attach custom attributes to properties
        // of the t_Element class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_ElementMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_ElementMetadata()
            {
            }

            public string BackColor { get; set; }

            public Nullable<int> ChannelNo { get; set; }

            public string ChildScreenID { get; set; }

            public string ComputeStr { get; set; }

            public Nullable<int> ControlID { get; set; }

            public Nullable<int> DeviceID { get; set; }

            public int ElementID { get; set; }

            public string ElementName { get; set; }

            public string Font { get; set; }

            public string ForeColor { get; set; }

            public Nullable<int> Height { get; set; }

            public string ImageURL { get; set; }

            public Nullable<int> LevelNo { get; set; }

            public Nullable<double> MaxFloat { get; set; }

            public Nullable<int> Method { get; set; }

            public Nullable<double> MinFloat { get; set; }

            public Nullable<int> oldX { get; set; }

            public Nullable<int> oldY { get; set; }

            public Nullable<int> ScreenID { get; set; }

            public Nullable<int> ScreenX { get; set; }

            public Nullable<int> ScreenY { get; set; }

            public Nullable<int> SerialNum { get; set; }

            public Nullable<double> TotalLength { get; set; }

            public Nullable<int> Transparent { get; set; }

            public string TxtInfo { get; set; }

            public Nullable<int> Width { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_Element_LibraryMetadata as the class
    // that carries additional metadata for the t_Element_Library class.
    [MetadataTypeAttribute(typeof(t_Element_Library.t_Element_LibraryMetadata))]
    public partial class t_Element_Library
    {

        // This class allows you to attach custom attributes to properties
        // of the t_Element_Library class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_Element_LibraryMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_Element_LibraryMetadata()
            {
            }

            public string BackColor { get; set; }

            public Nullable<int> ChannelNo { get; set; }

            public string ChildScreenID { get; set; }

            public Nullable<int> ControlID { get; set; }

            public Nullable<int> DeviceID { get; set; }

            public int ElementID { get; set; }

            public string ElementName { get; set; }

            public string Font { get; set; }

            public string ForeColor { get; set; }

            public Nullable<int> Height { get; set; }

            public string ImageURL { get; set; }

            public Nullable<double> MaxFloat { get; set; }

            public Nullable<int> Method { get; set; }

            public Nullable<double> MinFloat { get; set; }

            public Nullable<int> oldX { get; set; }

            public Nullable<int> oldY { get; set; }

            public int ScreenID { get; set; }

            public Nullable<int> ScreenX { get; set; }

            public Nullable<int> ScreenY { get; set; }

            public Nullable<int> SerialNum { get; set; }

            public Nullable<double> TotalLength { get; set; }

            public Nullable<int> Transparent { get; set; }

            public string TxtInfo { get; set; }

            public Nullable<int> Width { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_ElementPropertyMetadata as the class
    // that carries additional metadata for the t_ElementProperty class.
    [MetadataTypeAttribute(typeof(t_ElementProperty.t_ElementPropertyMetadata))]
    public partial class t_ElementProperty
    {

        // This class allows you to attach custom attributes to properties
        // of the t_ElementProperty class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_ElementPropertyMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_ElementPropertyMetadata()
            {
            }

            public string Caption { get; set; }

            public int ElementID { get; set; }

            public string PropertyName { get; set; }

            public int PropertyNo { get; set; }

            public string PropertyValue { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_ElementProperty_LibraryMetadata as the class
    // that carries additional metadata for the t_ElementProperty_Library class.
    [MetadataTypeAttribute(typeof(t_ElementProperty_Library.t_ElementProperty_LibraryMetadata))]
    public partial class t_ElementProperty_Library
    {

        // This class allows you to attach custom attributes to properties
        // of the t_ElementProperty_Library class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_ElementProperty_LibraryMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_ElementProperty_LibraryMetadata()
            {
            }

            public string Caption { get; set; }

            public int ElementID { get; set; }

            public string PropertyName { get; set; }

            public int PropertyNo { get; set; }

            public string PropertyValue { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_KeyWordMetadata as the class
    // that carries additional metadata for the t_KeyWord class.
    [MetadataTypeAttribute(typeof(t_KeyWord.t_KeyWordMetadata))]
    public partial class t_KeyWord
    {

        // This class allows you to attach custom attributes to properties
        // of the t_KeyWord class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_KeyWordMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_KeyWordMetadata()
            {
            }

            public Nullable<int> IsCustomize { get; set; }

            public string KeyWord { get; set; }

            public int KeyWordID { get; set; }

            public string KeyWordName { get; set; }

            public string Replace { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_MainteMetadata as the class
    // that carries additional metadata for the t_Mainte class.
    [MetadataTypeAttribute(typeof(t_Mainte.t_MainteMetadata))]
    public partial class t_Mainte
    {

        // This class allows you to attach custom attributes to properties
        // of the t_Mainte class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_MainteMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_MainteMetadata()
            {
            }

            public string ContentMainte { get; set; }

            public Nullable<int> DeviceID { get; set; }

            public string Duty { get; set; }

            public int ID { get; set; }

            public string MainteName { get; set; }

            public Nullable<DateTime> MainteTime { get; set; }

            public Nullable<int> StationID { get; set; }

            public Nullable<int> ValueType { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_MonitorServerParamMetadata as the class
    // that carries additional metadata for the t_MonitorServerParam class.
    [MetadataTypeAttribute(typeof(t_MonitorServerParam.t_MonitorServerParamMetadata))]
    public partial class t_MonitorServerParam
    {

        // This class allows you to attach custom attributes to properties
        // of the t_MonitorServerParam class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_MonitorServerParamMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_MonitorServerParamMetadata()
            {
            }

            public Nullable<int> IsCheck { get; set; }

            public Nullable<int> IsSmsCheck { get; set; }

            public string Param { get; set; }

            public string ParamAddr { get; set; }

            public int ParamID { get; set; }

            public string ParamName { get; set; }

            public Nullable<int> StationID { get; set; }

            public string StationName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_MonitorSystemParamMetadata as the class
    // that carries additional metadata for the t_MonitorSystemParam class.
    [MetadataTypeAttribute(typeof(t_MonitorSystemParam.t_MonitorSystemParamMetadata))]
    public partial class t_MonitorSystemParam
    {

        // This class allows you to attach custom attributes to properties
        // of the t_MonitorSystemParam class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_MonitorSystemParamMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_MonitorSystemParamMetadata()
            {
            }

            public Nullable<int> AlarmLogTime { get; set; }

            public Nullable<int> Door_Com { get; set; }

            public string Door_Sysid { get; set; }

            public Nullable<int> HaveDoor { get; set; }

            public int ID { get; set; }

            public Nullable<int> MonitorRefreshTime { get; set; }

            public string ServerIP { get; set; }

            public Nullable<int> ServerPort { get; set; }

            public int StartScreenID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_ScreenMetadata as the class
    // that carries additional metadata for the t_Screen class.
    [MetadataTypeAttribute(typeof(t_Screen.t_ScreenMetadata))]
    public partial class t_Screen
    {

        // This class allows you to attach custom attributes to properties
        // of the t_Screen class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_ScreenMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_ScreenMetadata()
            {
            }

            public Nullable<int> Flag { get; set; }

            public string ImageURL { get; set; }

            public Nullable<int> ParentScreenID { get; set; }

            public int ScreenID { get; set; }

            public string ScreenName { get; set; }

            public Nullable<int> StationID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_Screen_LibraryMetadata as the class
    // that carries additional metadata for the t_Screen_Library class.
    [MetadataTypeAttribute(typeof(t_Screen_Library.t_Screen_LibraryMetadata))]
    public partial class t_Screen_Library
    {

        // This class allows you to attach custom attributes to properties
        // of the t_Screen_Library class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_Screen_LibraryMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_Screen_LibraryMetadata()
            {
            }

            public string ImageURL { get; set; }

            public Nullable<int> ParentScreenID { get; set; }

            public int ScreenID { get; set; }

            public string ScreenName { get; set; }

            public Nullable<int> StationID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_StationMetadata as the class
    // that carries additional metadata for the t_Station class.
    [MetadataTypeAttribute(typeof(t_Station.t_StationMetadata))]
    public partial class t_Station
    {

        // This class allows you to attach custom attributes to properties
        // of the t_Station class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_StationMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_StationMetadata()
            {
            }

            public Nullable<int> HistoryPort { get; set; }

            public string IP { get; set; }

            public Nullable<int> Port { get; set; }

            public int StationID { get; set; }

            public string StationName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_Sys_MainRealTimeSetMetadata as the class
    // that carries additional metadata for the t_Sys_MainRealTimeSet class.
    [MetadataTypeAttribute(typeof(t_Sys_MainRealTimeSet.t_Sys_MainRealTimeSetMetadata))]
    public partial class t_Sys_MainRealTimeSet
    {

        // This class allows you to attach custom attributes to properties
        // of the t_Sys_MainRealTimeSet class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_Sys_MainRealTimeSetMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_Sys_MainRealTimeSetMetadata()
            {
            }

            public Nullable<double> ChanenlSubNo { get; set; }

            public int ChannelNO { get; set; }

            public int DeviceID { get; set; }

            public double GridHeight { get; set; }

            public int ID { get; set; }

            public int StationID { get; set; }

            public double Ylower { get; set; }

            public double YmaxValue { get; set; }

            public double YminValue { get; set; }

            public double Yupper { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_TmpValueMetadata as the class
    // that carries additional metadata for the t_TmpValue class.
    [MetadataTypeAttribute(typeof(t_TmpValue.t_TmpValueMetadata))]
    public partial class t_TmpValue
    {

        // This class allows you to attach custom attributes to properties
        // of the t_TmpValue class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_TmpValueMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_TmpValueMetadata()
            {
            }

            public Nullable<int> ChanenlSubNo { get; set; }

            public int ChannelNO { get; set; }

            public int DeviceID { get; set; }

            public Nullable<int> Flag { get; set; }

            public Nullable<double> MonitorValue { get; set; }

            public int StationID { get; set; }
        }
    }
}
