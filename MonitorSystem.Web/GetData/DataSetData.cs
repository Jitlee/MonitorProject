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
using System.Xml;
using System.Collections.ObjectModel;
using System.Text;
using System.IO;
using System.ServiceModel.DomainServices.Hosting;

namespace MonitorSystem.Web.Servers
{
    [EnableClientAccess()]
    public class DataSetData
    {
        [DataMember]
        public ObservableCollection<DataTableInfo> Tables { get; set; }
        [DataMember]
        public string DataXML { get; set; }

        public static DataSetData FromDataSet(DataSet ds)
        {
            DataSetData dsd = new DataSetData();
            dsd.Tables = new ObservableCollection<DataTableInfo>();
            foreach (DataTable t in ds.Tables)
            {
                DataTableInfo tableInfo = new DataTableInfo { TableName = t.TableName };
                dsd.Tables.Add(tableInfo);
                tableInfo.Columns = new ObservableCollection<DataColumnInfo>();
                foreach (DataColumn c in t.Columns)
                {
                    DataColumnInfo col = new DataColumnInfo { ColumnName = c.ColumnName, ColumnTitle = c.ColumnName, DataTypeName = c.DataType.FullName, MaxLength = c.MaxLength, IsKey = c.Unique, IsReadOnly = (c.Unique || c.ReadOnly), IsRequired = !c.AllowDBNull };
                    if (c.DataType == typeof(System.Guid))
                    {
                        col.IsReadOnly = true;
                        col.DisplayIndex = -1;
                    }
                    tableInfo.Columns.Add(col);
                }
            }
            dsd.DataXML = ds.GetXml();
            return dsd;
        }

        public static DataSet ToDataSet(DataSetData dsd)
        {
            DataSet ds = new DataSet();
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(dsd.DataXML);
            MemoryStream stream = new MemoryStream(byteArray);
            XmlReader reader = new XmlTextReader(stream);
            ds.ReadXml(reader);
            XDocument xd = XDocument.Parse(dsd.DataXML);
            foreach (DataTable dt in ds.Tables)
            {
                var rs = from row in xd.Descendants(dt.TableName)
                         select row;

                int i = 0;
                foreach (var r in rs)
                {
                    DataRowState state = (DataRowState)Enum.Parse(typeof(DataRowState), r.Attribute("RowState").Value);
                    DataRow dr = dt.Rows[i];
                    dr.AcceptChanges();
                    if (state == DataRowState.Deleted)
                        dr.Delete();
                    else if (state == DataRowState.Added)
                        dr.SetAdded();
                    else if (state == DataRowState.Modified)
                        dr.SetModified();
                    i++;
                }
            }
            return ds;
        }
    }




}