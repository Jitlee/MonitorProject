
namespace MonitorSystem.Web.Moldes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


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
