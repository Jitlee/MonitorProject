
namespace MonitorSystem.Web.Moldes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


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
}
