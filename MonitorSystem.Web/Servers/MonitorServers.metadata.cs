
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

    // The MetadataTypeAttribute identifies t_AlarmGroupMembersMetadata as the class
    // that carries additional metadata for the t_AlarmGroupMembers class.
    [MetadataTypeAttribute(typeof(t_AlarmGroupMembers.t_AlarmGroupMembersMetadata))]
    public partial class t_AlarmGroupMembers
    {

        // This class allows you to attach custom attributes to properties
        // of the t_AlarmGroupMembers class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_AlarmGroupMembersMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_AlarmGroupMembersMetadata()
            {
            }

            public Nullable<int> AlarmGroupsID { get; set; }

            public string Email { get; set; }

            public int ID { get; set; }

            public string MobileNo { get; set; }

            public string Name { get; set; }

            public Nullable<int> ProcessLevel { get; set; }

            public string Scheduling { get; set; }

            public Nullable<int> StationID { get; set; }

            public string TelNo { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_AlarmGroupsMetadata as the class
    // that carries additional metadata for the t_AlarmGroups class.
    [MetadataTypeAttribute(typeof(t_AlarmGroups.t_AlarmGroupsMetadata))]
    public partial class t_AlarmGroups
    {

        // This class allows you to attach custom attributes to properties
        // of the t_AlarmGroups class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_AlarmGroupsMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_AlarmGroupsMetadata()
            {
            }

            public int AlarmGroupsID { get; set; }

            public string GroupName { get; set; }

            public Nullable<int> StationID { get; set; }
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

    // The MetadataTypeAttribute identifies t_AlarmLevelSetMetadata as the class
    // that carries additional metadata for the t_AlarmLevelSet class.
    [MetadataTypeAttribute(typeof(t_AlarmLevelSet.t_AlarmLevelSetMetadata))]
    public partial class t_AlarmLevelSet
    {

        // This class allows you to attach custom attributes to properties
        // of the t_AlarmLevelSet class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_AlarmLevelSetMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_AlarmLevelSetMetadata()
            {
            }

            public int ID { get; set; }

            public string LevelName { get; set; }

            public int Priority { get; set; }

            public Nullable<int> UpInterval { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_AlarmLogMetadata as the class
    // that carries additional metadata for the t_AlarmLog class.
    [MetadataTypeAttribute(typeof(t_AlarmLog.t_AlarmLogMetadata))]
    public partial class t_AlarmLog
    {

        // This class allows you to attach custom attributes to properties
        // of the t_AlarmLog class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_AlarmLogMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_AlarmLogMetadata()
            {
            }

            public Nullable<int> AlarmLeftTime { get; set; }

            public Nullable<int> AlarmLevel { get; set; }

            public int AlarmLogID { get; set; }

            public string AlarmType { get; set; }

            public string Content { get; set; }

            public Nullable<int> DeviceID { get; set; }

            public string EventsName { get; set; }

            public Nullable<DateTime> HappenTime { get; set; }

            public Nullable<DateTime> LastTime { get; set; }

            public Nullable<double> MonitorValue { get; set; }

            public Nullable<int> OperateUserID { get; set; }

            public Nullable<int> PolicyID { get; set; }

            public Nullable<DateTime> RelieveTime { get; set; }

            public Nullable<int> StationID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_AlarmMethodMetadata as the class
    // that carries additional metadata for the t_AlarmMethod class.
    [MetadataTypeAttribute(typeof(t_AlarmMethod.t_AlarmMethodMetadata))]
    public partial class t_AlarmMethod
    {

        // This class allows you to attach custom attributes to properties
        // of the t_AlarmMethod class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_AlarmMethodMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_AlarmMethodMetadata()
            {
            }

            public int Id { get; set; }

            public string Name { get; set; }

            public Nullable<int> TargetId { get; set; }

            public string Type { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_AlarmPolicyMetadata as the class
    // that carries additional metadata for the t_AlarmPolicy class.
    [MetadataTypeAttribute(typeof(t_AlarmPolicy.t_AlarmPolicyMetadata))]
    public partial class t_AlarmPolicy
    {

        // This class allows you to attach custom attributes to properties
        // of the t_AlarmPolicy class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_AlarmPolicyMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_AlarmPolicyMetadata()
            {
            }

            public Nullable<int> AlarmLevel { get; set; }

            public Nullable<int> CurrentLevel { get; set; }

            public Nullable<int> DeviceTypeID { get; set; }

            public Nullable<int> FilterAlarmTimes { get; set; }

            public string PolicyContent { get; set; }

            public string PolicyFormula { get; set; }

            public int PolicyID { get; set; }

            public string PolicyName { get; set; }

            public Nullable<int> StationID { get; set; }

            public Nullable<int> TimeInterval { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_AlarmPolicyManagementMetadata as the class
    // that carries additional metadata for the t_AlarmPolicyManagement class.
    [MetadataTypeAttribute(typeof(t_AlarmPolicyManagement.t_AlarmPolicyManagementMetadata))]
    public partial class t_AlarmPolicyManagement
    {

        // This class allows you to attach custom attributes to properties
        // of the t_AlarmPolicyManagement class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_AlarmPolicyManagementMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_AlarmPolicyManagementMetadata()
            {
            }

            public string AlarmAudioFile { get; set; }

            public Nullable<int> AlarmfilterTimes { get; set; }

            public Nullable<int> AlarmLevel { get; set; }

            public int AlarmPolicyManagementID { get; set; }

            public string AlarmTarget { get; set; }

            public Nullable<int> AlarmTimes { get; set; }

            public Nullable<int> AlarmVerify { get; set; }

            public string AlarmWay { get; set; }

            public Nullable<int> DeviceChannelID { get; set; }

            public Nullable<int> DeviceID { get; set; }

            public Nullable<int> DeviceTypeID { get; set; }

            public string DisAlarmAudioFile { get; set; }

            public string EventID { get; set; }

            public Nullable<int> IsEnable { get; set; }

            public Nullable<int> IsEnableFrequency { get; set; }

            public Nullable<int> LightID { get; set; }

            public Nullable<int> MaxTiggerType { get; set; }

            public Nullable<double> MaxValue { get; set; }

            public Nullable<int> MinTiggerType { get; set; }

            public Nullable<double> MinValue { get; set; }

            public Nullable<int> ReleaseLightID { get; set; }

            public string SmsMsg { get; set; }

            public Nullable<int> StationID { get; set; }

            public Nullable<int> SwitchValue { get; set; }

            public Nullable<int> ValueType { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_AlarmPolicyTargetGroupMetadata as the class
    // that carries additional metadata for the t_AlarmPolicyTargetGroup class.
    [MetadataTypeAttribute(typeof(t_AlarmPolicyTargetGroup.t_AlarmPolicyTargetGroupMetadata))]
    public partial class t_AlarmPolicyTargetGroup
    {

        // This class allows you to attach custom attributes to properties
        // of the t_AlarmPolicyTargetGroup class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_AlarmPolicyTargetGroupMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_AlarmPolicyTargetGroupMetadata()
            {
            }

            public Nullable<int> AlarmGroupID { get; set; }

            public Nullable<int> AlarmPolicyID { get; set; }

            public string AlarmPolicyTarget { get; set; }

            public int AlarmPolicyTargetGroupID { get; set; }

            public Nullable<int> IsEnable { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_AlarmPolicyTargetGroupMunberMetadata as the class
    // that carries additional metadata for the t_AlarmPolicyTargetGroupMunber class.
    [MetadataTypeAttribute(typeof(t_AlarmPolicyTargetGroupMunber.t_AlarmPolicyTargetGroupMunberMetadata))]
    public partial class t_AlarmPolicyTargetGroupMunber
    {

        // This class allows you to attach custom attributes to properties
        // of the t_AlarmPolicyTargetGroupMunber class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_AlarmPolicyTargetGroupMunberMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_AlarmPolicyTargetGroupMunberMetadata()
            {
            }

            public Nullable<int> AlarmGroupID { get; set; }

            public Nullable<int> AlarmGroupMumber { get; set; }

            public Nullable<int> AlarmPolicyID { get; set; }

            public int AlarmPolicyTargetGroupMunberID { get; set; }

            public Nullable<int> IsEnable { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_AlarmTargetMetadata as the class
    // that carries additional metadata for the t_AlarmTarget class.
    [MetadataTypeAttribute(typeof(t_AlarmTarget.t_AlarmTargetMetadata))]
    public partial class t_AlarmTarget
    {

        // This class allows you to attach custom attributes to properties
        // of the t_AlarmTarget class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_AlarmTargetMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_AlarmTargetMetadata()
            {
            }

            public int Id { get; set; }

            public string MobileNo { get; set; }

            public string Name { get; set; }

            public Nullable<int> ParentId { get; set; }

            public string TelNo { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_AlarmTimeMetadata as the class
    // that carries additional metadata for the t_AlarmTime class.
    [MetadataTypeAttribute(typeof(t_AlarmTime.t_AlarmTimeMetadata))]
    public partial class t_AlarmTime
    {

        // This class allows you to attach custom attributes to properties
        // of the t_AlarmTime class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_AlarmTimeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_AlarmTimeMetadata()
            {
            }

            public string AlarmBeginTime { get; set; }

            public string AlarmEndTime { get; set; }

            public int AlarmTimeID { get; set; }

            public string AlarmTimeName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_AlramBindTimeMetadata as the class
    // that carries additional metadata for the t_AlramBindTime class.
    [MetadataTypeAttribute(typeof(t_AlramBindTime.t_AlramBindTimeMetadata))]
    public partial class t_AlramBindTime
    {

        // This class allows you to attach custom attributes to properties
        // of the t_AlramBindTime class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_AlramBindTimeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_AlramBindTimeMetadata()
            {
            }

            public Nullable<int> ChannelNo { get; set; }

            public Nullable<int> DeviceID { get; set; }

            public int ID { get; set; }

            public Nullable<int> IntervalTime { get; set; }

            public Nullable<int> StationID { get; set; }
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

    // The MetadataTypeAttribute identifies t_DeviceTypeMetadata as the class
    // that carries additional metadata for the t_DeviceType class.
    [MetadataTypeAttribute(typeof(t_DeviceType.t_DeviceTypeMetadata))]
    public partial class t_DeviceType
    {

        // This class allows you to attach custom attributes to properties
        // of the t_DeviceType class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_DeviceTypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_DeviceTypeMetadata()
            {
            }

            public int DeviceTypeID { get; set; }

            public string IP { get; set; }

            public string Param { get; set; }

            public string ParseDll { get; set; }

            public Nullable<int> SaveTimeInteval { get; set; }

            public Nullable<int> StationID { get; set; }

            public string TypeName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_DisarmTimeMetadata as the class
    // that carries additional metadata for the t_DisarmTime class.
    [MetadataTypeAttribute(typeof(t_DisarmTime.t_DisarmTimeMetadata))]
    public partial class t_DisarmTime
    {

        // This class allows you to attach custom attributes to properties
        // of the t_DisarmTime class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_DisarmTimeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_DisarmTimeMetadata()
            {
            }

            public string DisarmEndTime { get; set; }

            public int DisarmID { get; set; }

            public string DisarmName { get; set; }

            public string DisarmStartTime { get; set; }
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

    // The MetadataTypeAttribute identifies t_EventTypeMetadata as the class
    // that carries additional metadata for the t_EventType class.
    [MetadataTypeAttribute(typeof(t_EventType.t_EventTypeMetadata))]
    public partial class t_EventType
    {

        // This class allows you to attach custom attributes to properties
        // of the t_EventType class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_EventTypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_EventTypeMetadata()
            {
            }

            public string AlarmAudioFile { get; set; }

            public Nullable<int> AlarmLevel { get; set; }

            public string AlarmTarget { get; set; }

            public string AlarmWay { get; set; }

            public string DisAlarmAudioFile { get; set; }

            public int EventID { get; set; }

            public string EventName { get; set; }

            public Nullable<int> IsEnableFrequency { get; set; }

            public string SmsMsg { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_GenChannelTypeMetadata as the class
    // that carries additional metadata for the t_GenChannelType class.
    [MetadataTypeAttribute(typeof(t_GenChannelType.t_GenChannelTypeMetadata))]
    public partial class t_GenChannelType
    {

        // This class allows you to attach custom attributes to properties
        // of the t_GenChannelType class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_GenChannelTypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_GenChannelTypeMetadata()
            {
            }

            public string AdrCheck { get; set; }

            public string ChannelName { get; set; }

            public Nullable<int> ChannelNO { get; set; }

            public int DecID { get; set; }

            public string DecStr { get; set; }

            public int DeviceTypeID { get; set; }

            public string LenCheck { get; set; }

            public string OtherCheck { get; set; }

            public string Param { get; set; }

            public int SendStrID { get; set; }

            public string Value0Name { get; set; }

            public string Value1Name { get; set; }

            public Nullable<int> ValueType { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_GeneralDllMetadata as the class
    // that carries additional metadata for the t_GeneralDll class.
    [MetadataTypeAttribute(typeof(t_GeneralDll.t_GeneralDllMetadata))]
    public partial class t_GeneralDll
    {

        // This class allows you to attach custom attributes to properties
        // of the t_GeneralDll class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_GeneralDllMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_GeneralDllMetadata()
            {
            }

            public string Addr { get; set; }

            public string AnalyTemp { get; set; }

            public string ChannelName { get; set; }

            public Nullable<int> ChannelNo { get; set; }

            public Nullable<int> DeviceID { get; set; }

            public string DeviceName { get; set; }

            public Nullable<int> DeviceTypeID { get; set; }

            public Nullable<double> MonitorValue { get; set; }

            public Nullable<int> OrderType { get; set; }

            public Nullable<int> RetryTimes { get; set; }

            public Nullable<int> SendDelay { get; set; }

            public string SendStr { get; set; }

            public int SendStrID { get; set; }

            public string SendType { get; set; }

            public Nullable<int> StationID { get; set; }

            public string Unit { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_InspectionMetadata as the class
    // that carries additional metadata for the t_Inspection class.
    [MetadataTypeAttribute(typeof(t_Inspection.t_InspectionMetadata))]
    public partial class t_Inspection
    {

        // This class allows you to attach custom attributes to properties
        // of the t_Inspection class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_InspectionMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_InspectionMetadata()
            {
            }

            public string AlarmWay { get; set; }

            public Nullable<int> ChannelNO { get; set; }

            public Nullable<int> DeviceID { get; set; }

            public Nullable<int> DeviceTypeID { get; set; }

            public int InspectionID { get; set; }

            public string InspectionTime { get; set; }

            public string InspectionType { get; set; }

            public string PhoneMedia { get; set; }

            public string SmsEmail { get; set; }

            public Nullable<int> StationID { get; set; }

            public Nullable<int> ValueType { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_IPMonitor_RelationMetadata as the class
    // that carries additional metadata for the t_IPMonitor_Relation class.
    [MetadataTypeAttribute(typeof(t_IPMonitor_Relation.t_IPMonitor_RelationMetadata))]
    public partial class t_IPMonitor_Relation
    {

        // This class allows you to attach custom attributes to properties
        // of the t_IPMonitor_Relation class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_IPMonitor_RelationMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_IPMonitor_RelationMetadata()
            {
            }

            public int ChannelNO { get; set; }

            public int DeviceID { get; set; }

            public int DstDeviceID { get; set; }

            public string DstDeviceName { get; set; }

            public int ResultID { get; set; }

            public string ResultName { get; set; }

            public int StationID { get; set; }

            public int TaskID { get; set; }

            public int TaskImplementID { get; set; }

            public int TaskTypeID { get; set; }
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

    // The MetadataTypeAttribute identifies t_LightAlarmMetadata as the class
    // that carries additional metadata for the t_LightAlarm class.
    [MetadataTypeAttribute(typeof(t_LightAlarm.t_LightAlarmMetadata))]
    public partial class t_LightAlarm
    {

        // This class allows you to attach custom attributes to properties
        // of the t_LightAlarm class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_LightAlarmMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_LightAlarmMetadata()
            {
            }

            public Nullable<int> ChannelNO { get; set; }

            public Nullable<int> DeviceID { get; set; }

            public int LightID { get; set; }

            public string LightName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_LinkageSetMetadata as the class
    // that carries additional metadata for the t_LinkageSet class.
    [MetadataTypeAttribute(typeof(t_LinkageSet.t_LinkageSetMetadata))]
    public partial class t_LinkageSet
    {

        // This class allows you to attach custom attributes to properties
        // of the t_LinkageSet class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_LinkageSetMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_LinkageSetMetadata()
            {
            }

            public Nullable<int> ChannelNo { get; set; }

            public Nullable<int> DeviceID { get; set; }

            public int ID { get; set; }

            public Nullable<int> LinkageChannelNo { get; set; }

            public Nullable<int> LinkageDeviceID { get; set; }

            public Nullable<int> LinkageStationID { get; set; }

            public Nullable<int> StationID { get; set; }

            public Nullable<DateTime> TriggerValue { get; set; }

            public Nullable<int> ValueType { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_LinkElementMetadata as the class
    // that carries additional metadata for the t_LinkElement class.
    [MetadataTypeAttribute(typeof(t_LinkElement.t_LinkElementMetadata))]
    public partial class t_LinkElement
    {

        // This class allows you to attach custom attributes to properties
        // of the t_LinkElement class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_LinkElementMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_LinkElementMetadata()
            {
            }

            public Nullable<int> ChannelNO { get; set; }

            public string ComputeStr { get; set; }

            public Nullable<int> DeviceID { get; set; }

            public Nullable<int> EndElementID { get; set; }

            public Nullable<int> EndX { get; set; }

            public Nullable<int> EndY { get; set; }

            public string ForeColor { get; set; }

            public int LineID { get; set; }

            public string LineName { get; set; }

            public Nullable<int> LineStyle { get; set; }

            public Nullable<int> LineWidth { get; set; }

            public Nullable<int> ScreenID { get; set; }

            public Nullable<int> StartElementID { get; set; }

            public Nullable<int> StartX { get; set; }

            public Nullable<int> StartY { get; set; }

            public Nullable<int> StationID { get; set; }
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

            public Nullable<int> MonitorRefreshTime { get; set; }

            public string ServerIP { get; set; }

            public Nullable<int> ServerPort { get; set; }

            public int StartScreenID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_PolicyActionMapMetadata as the class
    // that carries additional metadata for the t_PolicyActionMap class.
    [MetadataTypeAttribute(typeof(t_PolicyActionMap.t_PolicyActionMapMetadata))]
    public partial class t_PolicyActionMap
    {

        // This class allows you to attach custom attributes to properties
        // of the t_PolicyActionMap class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_PolicyActionMapMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_PolicyActionMapMetadata()
            {
            }

            public string AlarmMethod { get; set; }

            public Nullable<int> AlarmTime { get; set; }

            public int Id { get; set; }

            public int PolicyID { get; set; }

            public string Target { get; set; }

            public string VoiceFile { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_PolicyDeviceMapMetadata as the class
    // that carries additional metadata for the t_PolicyDeviceMap class.
    [MetadataTypeAttribute(typeof(t_PolicyDeviceMap.t_PolicyDeviceMapMetadata))]
    public partial class t_PolicyDeviceMap
    {

        // This class allows you to attach custom attributes to properties
        // of the t_PolicyDeviceMap class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_PolicyDeviceMapMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_PolicyDeviceMapMetadata()
            {
            }

            public Nullable<int> AlarmLeftTime { get; set; }

            public Nullable<int> AlarmTime { get; set; }

            public int DeviceID { get; set; }

            public int PolicyID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_RelationActionMetadata as the class
    // that carries additional metadata for the t_RelationAction class.
    [MetadataTypeAttribute(typeof(t_RelationAction.t_RelationActionMetadata))]
    public partial class t_RelationAction
    {

        // This class allows you to attach custom attributes to properties
        // of the t_RelationAction class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_RelationActionMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_RelationActionMetadata()
            {
            }

            public string ActionDevParam { get; set; }

            public string ActionDevType { get; set; }

            public Nullable<int> DestChannelNo { get; set; }

            public Nullable<int> DestDeviceID { get; set; }

            public int ID { get; set; }

            public Nullable<int> SourceChannelNo { get; set; }

            public Nullable<int> SourceDeviceID { get; set; }

            public Nullable<double> StartValue { get; set; }

            public Nullable<int> StationId { get; set; }

            public Nullable<double> StopValue { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_SchedulingMetadata as the class
    // that carries additional metadata for the t_Scheduling class.
    [MetadataTypeAttribute(typeof(t_Scheduling.t_SchedulingMetadata))]
    public partial class t_Scheduling
    {

        // This class allows you to attach custom attributes to properties
        // of the t_Scheduling class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_SchedulingMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_SchedulingMetadata()
            {
            }

            public string EndTime { get; set; }

            public int Frequency { get; set; }

            public string FrequencyName { get; set; }

            public string StartTime { get; set; }
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

    // The MetadataTypeAttribute identifies t_ScreenShapeMetadata as the class
    // that carries additional metadata for the t_ScreenShape class.
    [MetadataTypeAttribute(typeof(t_ScreenShape.t_ScreenShapeMetadata))]
    public partial class t_ScreenShape
    {

        // This class allows you to attach custom attributes to properties
        // of the t_ScreenShape class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_ScreenShapeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_ScreenShapeMetadata()
            {
            }

            public int ID { get; set; }

            public int ScreenID { get; set; }

            public int ShapeID { get; set; }

            public string ShapeName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_SerialPortMetadata as the class
    // that carries additional metadata for the t_SerialPort class.
    [MetadataTypeAttribute(typeof(t_SerialPort.t_SerialPortMetadata))]
    public partial class t_SerialPort
    {

        // This class allows you to attach custom attributes to properties
        // of the t_SerialPort class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_SerialPortMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_SerialPortMetadata()
            {
            }

            public string CommunicationParam { get; set; }

            public Nullable<int> ScanInterval { get; set; }

            public int SerialPortID { get; set; }

            public string SerialPortName { get; set; }

            public Nullable<int> StationID { get; set; }

            public string StationName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_ShapeFieldMetadata as the class
    // that carries additional metadata for the t_ShapeField class.
    [MetadataTypeAttribute(typeof(t_ShapeField.t_ShapeFieldMetadata))]
    public partial class t_ShapeField
    {

        // This class allows you to attach custom attributes to properties
        // of the t_ShapeField class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_ShapeFieldMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_ShapeFieldMetadata()
            {
            }

            public string FieldName { get; set; }

            public string FieldValue { get; set; }

            public int ID { get; set; }

            public Nullable<int> SSID { get; set; }

            public Nullable<int> ValueType { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_ShapeScreenMetadata as the class
    // that carries additional metadata for the t_ShapeScreen class.
    [MetadataTypeAttribute(typeof(t_ShapeScreen.t_ShapeScreenMetadata))]
    public partial class t_ShapeScreen
    {

        // This class allows you to attach custom attributes to properties
        // of the t_ShapeScreen class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_ShapeScreenMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_ShapeScreenMetadata()
            {
            }

            public string ChildScreenID { get; set; }

            public int ID { get; set; }

            public int SSID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_SnmpGroupChanMetadata as the class
    // that carries additional metadata for the t_SnmpGroupChan class.
    [MetadataTypeAttribute(typeof(t_SnmpGroupChan.t_SnmpGroupChanMetadata))]
    public partial class t_SnmpGroupChan
    {

        // This class allows you to attach custom attributes to properties
        // of the t_SnmpGroupChan class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_SnmpGroupChanMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_SnmpGroupChanMetadata()
            {
            }

            public Nullable<int> ChannelNO { get; set; }

            public int DecID { get; set; }

            public Nullable<int> DeviceTypeID { get; set; }

            public Nullable<int> SendSnmpID { get; set; }

            public Nullable<int> SubChannelNO { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_SnmpRecvMetadata as the class
    // that carries additional metadata for the t_SnmpRecv class.
    [MetadataTypeAttribute(typeof(t_SnmpRecv.t_SnmpRecvMetadata))]
    public partial class t_SnmpRecv
    {

        // This class allows you to attach custom attributes to properties
        // of the t_SnmpRecv class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_SnmpRecvMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_SnmpRecvMetadata()
            {
            }

            public string ChannelName { get; set; }

            public Nullable<int> ChannelNO { get; set; }

            public string ComputeStr { get; set; }

            public int DecID { get; set; }

            public Nullable<int> DeviceTypeID { get; set; }

            public string GroupChanIndex { get; set; }

            public string Info { get; set; }

            public Nullable<int> IsGroupChan { get; set; }

            public string OID { get; set; }

            public string Param { get; set; }

            public Nullable<int> SendSnmpID { get; set; }

            public string Unit { get; set; }

            public Nullable<int> ValueType { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_SnmpSendMetadata as the class
    // that carries additional metadata for the t_SnmpSend class.
    [MetadataTypeAttribute(typeof(t_SnmpSend.t_SnmpSendMetadata))]
    public partial class t_SnmpSend
    {

        // This class allows you to attach custom attributes to properties
        // of the t_SnmpSend class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_SnmpSendMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_SnmpSendMetadata()
            {
            }

            public Nullable<int> DeviceTypeID { get; set; }

            public string FirstOID { get; set; }

            public string MethodType { get; set; }

            public string OID { get; set; }

            public Nullable<int> RetryTimes { get; set; }

            public Nullable<int> SendDelay { get; set; }

            public int SendSnmpID { get; set; }

            public string VersionNo { get; set; }
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

    // The MetadataTypeAttribute identifies t_TemplatesMetadata as the class
    // that carries additional metadata for the t_Templates class.
    [MetadataTypeAttribute(typeof(t_Templates.t_TemplatesMetadata))]
    public partial class t_Templates
    {

        // This class allows you to attach custom attributes to properties
        // of the t_Templates class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_TemplatesMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_TemplatesMetadata()
            {
            }

            public string AlarmLevel { get; set; }

            public int ID { get; set; }

            public string MaxValue { get; set; }

            public string MinValue { get; set; }

            public string SwitchValue { get; set; }

            public string TemplatesName { get; set; }

            public Nullable<int> ValueType { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_TimeLinkageMetadata as the class
    // that carries additional metadata for the t_TimeLinkage class.
    [MetadataTypeAttribute(typeof(t_TimeLinkage.t_TimeLinkageMetadata))]
    public partial class t_TimeLinkage
    {

        // This class allows you to attach custom attributes to properties
        // of the t_TimeLinkage class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_TimeLinkageMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_TimeLinkageMetadata()
            {
            }

            public Nullable<int> LinkageChannelNo { get; set; }

            public Nullable<int> LinkageDeviceID { get; set; }

            public int LinkageID { get; set; }

            public Nullable<int> LinkageStationID { get; set; }

            public string TriggerTime { get; set; }
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

    // The MetadataTypeAttribute identifies t_TmpValueGroupChanMetadata as the class
    // that carries additional metadata for the t_TmpValueGroupChan class.
    [MetadataTypeAttribute(typeof(t_TmpValueGroupChan.t_TmpValueGroupChanMetadata))]
    public partial class t_TmpValueGroupChan
    {

        // This class allows you to attach custom attributes to properties
        // of the t_TmpValueGroupChan class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_TmpValueGroupChanMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_TmpValueGroupChanMetadata()
            {
            }

            public int ChannelNO { get; set; }

            public int DeviceID { get; set; }

            public Nullable<int> Flag { get; set; }

            public Nullable<double> MonitorValue { get; set; }

            public int StationID { get; set; }

            public int SubChannelNO { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_TmpValueGroupChanOtherMetadata as the class
    // that carries additional metadata for the t_TmpValueGroupChanOther class.
    [MetadataTypeAttribute(typeof(t_TmpValueGroupChanOther.t_TmpValueGroupChanOtherMetadata))]
    public partial class t_TmpValueGroupChanOther
    {

        // This class allows you to attach custom attributes to properties
        // of the t_TmpValueGroupChanOther class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_TmpValueGroupChanOtherMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_TmpValueGroupChanOtherMetadata()
            {
            }

            public int ChannelNO { get; set; }

            public int DeviceID { get; set; }

            public Nullable<int> Flag { get; set; }

            public Nullable<double> MonitorValue { get; set; }

            public int StationID { get; set; }

            public int SubChannelNO { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_TmpValueOtherMetadata as the class
    // that carries additional metadata for the t_TmpValueOther class.
    [MetadataTypeAttribute(typeof(t_TmpValueOther.t_TmpValueOtherMetadata))]
    public partial class t_TmpValueOther
    {

        // This class allows you to attach custom attributes to properties
        // of the t_TmpValueOther class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_TmpValueOtherMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_TmpValueOtherMetadata()
            {
            }

            public Nullable<int> ChanenlSubNo { get; set; }

            public int ChannelNO { get; set; }

            public int DeviceID { get; set; }

            public Nullable<int> Flag { get; set; }

            public string MonitorValue { get; set; }

            public int StationID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_UserMetadata as the class
    // that carries additional metadata for the t_User class.
    [MetadataTypeAttribute(typeof(t_User.t_UserMetadata))]
    public partial class t_User
    {

        // This class allows you to attach custom attributes to properties
        // of the t_User class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_UserMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_UserMetadata()
            {
            }

            public int UserID { get; set; }

            public string UserName { get; set; }

            public string UserPSW { get; set; }

            public Nullable<int> UserType { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies t_WaibuMetadata as the class
    // that carries additional metadata for the t_Waibu class.
    [MetadataTypeAttribute(typeof(t_Waibu.t_WaibuMetadata))]
    public partial class t_Waibu
    {

        // This class allows you to attach custom attributes to properties
        // of the t_Waibu class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_WaibuMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private t_WaibuMetadata()
            {
            }

            public int WaibuID { get; set; }

            public string WaibuName { get; set; }

            public string WaibuParam { get; set; }

            public string WaibuPath { get; set; }
        }
    }
}
