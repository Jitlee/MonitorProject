
namespace MonitorSystem.Web.Moldes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // MetadataTypeAttribute 将 t_ControlMetadata 标识为类
    //，以携带 t_Control 类的其他元数据。
    [MetadataTypeAttribute(typeof(t_Control.t_ControlMetadata))]
    public partial class t_Control
    {

        // 通过此类可将自定义特性附加到
        //t_Control 类的属性。
        //
        // 例如，下面的代码将 Xyz 属性标记为
        //必需属性并指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_ControlMetadata
        {

            // 元数据类不会实例化。
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

    // MetadataTypeAttribute 将 t_ControlPropertyMetadata 标识为类
    //，以携带 t_ControlProperty 类的其他元数据。
    [MetadataTypeAttribute(typeof(t_ControlProperty.t_ControlPropertyMetadata))]
    public partial class t_ControlProperty
    {

        // 通过此类可将自定义特性附加到
        //t_ControlProperty 类的属性。
        //
        // 例如，下面的代码将 Xyz 属性标记为
        //必需属性并指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_ControlPropertyMetadata
        {

            // 元数据类不会实例化。
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

    // MetadataTypeAttribute 将 t_ElementMetadata 标识为类
    //，以携带 t_Element 类的其他元数据。
    [MetadataTypeAttribute(typeof(t_Element.t_ElementMetadata))]
    public partial class t_Element
    {

        // 通过此类可将自定义特性附加到
        //t_Element 类的属性。
        //
        // 例如，下面的代码将 Xyz 属性标记为
        //必需属性并指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_ElementMetadata
        {

            // 元数据类不会实例化。
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

    // MetadataTypeAttribute 将 t_Element_LibraryMetadata 标识为类
    //，以携带 t_Element_Library 类的其他元数据。
    [MetadataTypeAttribute(typeof(t_Element_Library.t_Element_LibraryMetadata))]
    public partial class t_Element_Library
    {

        // 通过此类可将自定义特性附加到
        //t_Element_Library 类的属性。
        //
        // 例如，下面的代码将 Xyz 属性标记为
        //必需属性并指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_Element_LibraryMetadata
        {

            // 元数据类不会实例化。
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

    // MetadataTypeAttribute 将 t_Element_RealTimeLineMetadata 标识为类
    //，以携带 t_Element_RealTimeLine 类的其他元数据。
    [MetadataTypeAttribute(typeof(t_Element_RealTimeLine.t_Element_RealTimeLineMetadata))]
    public partial class t_Element_RealTimeLine
    {

        // 通过此类可将自定义特性附加到
        //t_Element_RealTimeLine 类的属性。
        //
        // 例如，下面的代码将 Xyz 属性标记为
        //必需属性并指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_Element_RealTimeLineMetadata
        {

            // 元数据类不会实例化。
            private t_Element_RealTimeLineMetadata()
            {
            }

            public Nullable<int> ChannelNo { get; set; }

            public string ComputeStr { get; set; }

            public Nullable<int> DeviceID { get; set; }

            public int ElementID { get; set; }

            public string ID { get; set; }

            public string LineColor { get; set; }

            public string LineCYZQLent { get; set; }

            public string LineCYZQType { get; set; }

            public Nullable<int> LineCZ { get; set; }

            public string LineName { get; set; }

            public Nullable<int> LinePointBJ { get; set; }

            public Nullable<int> LineShowType { get; set; }

            public Nullable<int> LineStyle { get; set; }

            public int LineType { get; set; }

            public string MaxValue { get; set; }

            public string MinValue { get; set; }

            public int ScreenID { get; set; }

            public string ShowFormat { get; set; }

            public int TimeLen { get; set; }

            public string TimeLenType { get; set; }

            public int ValueDecimal { get; set; }
        }
    }

    // MetadataTypeAttribute 将 t_ElementPropertyMetadata 标识为类
    //，以携带 t_ElementProperty 类的其他元数据。
    [MetadataTypeAttribute(typeof(t_ElementProperty.t_ElementPropertyMetadata))]
    public partial class t_ElementProperty
    {

        // 通过此类可将自定义特性附加到
        //t_ElementProperty 类的属性。
        //
        // 例如，下面的代码将 Xyz 属性标记为
        //必需属性并指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_ElementPropertyMetadata
        {

            // 元数据类不会实例化。
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

    // MetadataTypeAttribute 将 t_ElementProperty_LibraryMetadata 标识为类
    //，以携带 t_ElementProperty_Library 类的其他元数据。
    [MetadataTypeAttribute(typeof(t_ElementProperty_Library.t_ElementProperty_LibraryMetadata))]
    public partial class t_ElementProperty_Library
    {

        // 通过此类可将自定义特性附加到
        //t_ElementProperty_Library 类的属性。
        //
        // 例如，下面的代码将 Xyz 属性标记为
        //必需属性并指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_ElementProperty_LibraryMetadata
        {

            // 元数据类不会实例化。
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

    // MetadataTypeAttribute 将 t_GalleryClassificationMetadata 标识为类
    //，以携带 t_GalleryClassification 类的其他元数据。
    [MetadataTypeAttribute(typeof(t_GalleryClassification.t_GalleryClassificationMetadata))]
    public partial class t_GalleryClassification
    {

        // 通过此类可将自定义特性附加到
        //t_GalleryClassification 类的属性。
        //
        // 例如，下面的代码将 Xyz 属性标记为
        //必需属性并指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_GalleryClassificationMetadata
        {

            // 元数据类不会实例化。
            private t_GalleryClassificationMetadata()
            {
            }

            public string Description { get; set; }

            public int Id { get; set; }

            public string Name { get; set; }

            public int Sort { get; set; }
        }
    }

    // MetadataTypeAttribute 将 t_MonitorSystemParamMetadata 标识为类
    //，以携带 t_MonitorSystemParam 类的其他元数据。
    [MetadataTypeAttribute(typeof(t_MonitorSystemParam.t_MonitorSystemParamMetadata))]
    public partial class t_MonitorSystemParam
    {

        // 通过此类可将自定义特性附加到
        //t_MonitorSystemParam 类的属性。
        //
        // 例如，下面的代码将 Xyz 属性标记为
        //必需属性并指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_MonitorSystemParamMetadata
        {

            // 元数据类不会实例化。
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

    // MetadataTypeAttribute 将 t_ScreenMetadata 标识为类
    //，以携带 t_Screen 类的其他元数据。
    [MetadataTypeAttribute(typeof(t_Screen.t_ScreenMetadata))]
    public partial class t_Screen
    {

        // 通过此类可将自定义特性附加到
        //t_Screen 类的属性。
        //
        // 例如，下面的代码将 Xyz 属性标记为
        //必需属性并指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_ScreenMetadata
        {

            // 元数据类不会实例化。
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

    // MetadataTypeAttribute 将 t_Screen_LibraryMetadata 标识为类
    //，以携带 t_Screen_Library 类的其他元数据。
    [MetadataTypeAttribute(typeof(t_Screen_Library.t_Screen_LibraryMetadata))]
    public partial class t_Screen_Library
    {

        // 通过此类可将自定义特性附加到
        //t_Screen_Library 类的属性。
        //
        // 例如，下面的代码将 Xyz 属性标记为
        //必需属性并指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_Screen_LibraryMetadata
        {

            // 元数据类不会实例化。
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

    // MetadataTypeAttribute 将 t_Sys_MainRealTimeSetMetadata 标识为类
    //，以携带 t_Sys_MainRealTimeSet 类的其他元数据。
    [MetadataTypeAttribute(typeof(t_Sys_MainRealTimeSet.t_Sys_MainRealTimeSetMetadata))]
    public partial class t_Sys_MainRealTimeSet
    {

        // 通过此类可将自定义特性附加到
        //t_Sys_MainRealTimeSet 类的属性。
        //
        // 例如，下面的代码将 Xyz 属性标记为
        //必需属性并指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class t_Sys_MainRealTimeSetMetadata
        {

            // 元数据类不会实例化。
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
}
