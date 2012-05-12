
namespace MonitorSystem.Web.Moldes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies V_ScreenMonitorValueMetadata as the class
    // that carries additional metadata for the V_ScreenMonitorValue class.
    [MetadataTypeAttribute(typeof(V_ScreenMonitorValue.V_ScreenMonitorValueMetadata))]
    public partial class V_ScreenMonitorValue
    {

        // This class allows you to attach custom attributes to properties
        // of the V_ScreenMonitorValue class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_ScreenMonitorValueMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_ScreenMonitorValueMetadata()
            {
            }

            public Nullable<int> ChanenlSubNo { get; set; }

            public int ChannelNo { get; set; }

            public string ComputeStr { get; set; }

            public int DeviceID { get; set; }

            public Nullable<int> flag { get; set; }

            public Nullable<double> MonitorValue { get; set; }

            public Nullable<int> ScreenID { get; set; }

            public int StationID { get; set; }
        }
    }
}
