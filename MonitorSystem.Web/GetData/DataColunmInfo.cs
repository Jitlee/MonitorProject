using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for DataColunmInfo
/// </summary>
[DataContract]
public class DataColumnInfo
{
	[DataMember]
	public string ColumnName { get; set; }

	[DataMember]
	public string ColumnTitle { get; set; }

	[DataMember]
	public string DataTypeName { get; set; }

	[DataMember]
	public bool IsRequired { get; set; }

	[DataMember]
	public bool IsKey { get; set; }

	[DataMember]
	public bool IsReadOnly { get; set; }

	[DataMember]
	public int DisplayIndex { get; set; }

	[DataMember]
	public string EditControlType { get; set; }

	[DataMember]
	public int MaxLength { get; set; }
}
