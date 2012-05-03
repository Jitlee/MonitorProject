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
using System.Collections.ObjectModel;

/// <summary>
/// Summary description for DataTableInfo
/// </summary>
[DataContract]
public class DataTableInfo
{
	[DataMember]
	public string TableName { get; set; }

	[DataMember]
	public ObservableCollection<DataColumnInfo> Columns { get; set; }

}
