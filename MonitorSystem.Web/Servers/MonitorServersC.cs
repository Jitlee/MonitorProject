using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using MonitorSystem.Web.Moldes;
using System.IO;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.ServiceModel;

namespace MonitorSystem.Web.Servers
{
    public partial class MonitorServers
    {

       

        public IEnumerable<t_ElementProperty> GetScreenElementProperty(int ScreenID)
        {
          var v=  from f in ObjectContext.t_ElementProperty from c in ObjectContext.t_Element 
                  where  c.ElementID==f.ElementID && c.ScreenID ==ScreenID select f;
          return v;
        }

        public double SelectNewValue(int SatationID, int DeiceID, int ChancelID)
        {
            var v = from f in ObjectContext.t_TmpValue
                    where f.StationID == SatationID
                        && f.DeviceID == DeiceID && f.ChannelNO == ChancelID
                    select f.MonitorValue;

            if (v.Count() > 0)
                return v.First().Value;
            return -999;
        }

        [OperationContract]
        public int GetDataSetData(string StrConn, string SQL)
        {
            try
            {
                //DataSet ds = GetDataSet(StrConn, SQL);
                //ServiceError = null;
                //return DataSetData.FromDataSet(ds);
            }
            catch (Exception ex)
            {
                //ServiceError = new CustomException(ex);
            }
            return 1;
        }

       
        //public string GetStringXmlValue()
        //{

        //    MemoryStream ms = null;
        //    XmlTextWriter XmlWt = null;
            
        //    ms = new MemoryStream();
        //    //根据ms实例化XmlWt
        //    XmlWt = new XmlTextWriter(ms, Encoding.Unicode);
        //    DataTable dt = new DataTable();
        //    //查询数据
        //    DataSet ds = new DataSet();
        //    string StrConn = "server=.;database=GDK_BCM;uid=sa;pwd=sa";
        //    SqlConnection Conn = new SqlConnection(StrConn);
        //    string strSql = "select * from t_Station";

        //    string dataname = "Appl_Info";

        //    SqlDataAdapter da = new SqlDataAdapter(strSql, Conn);
        //    Conn.Open();
        //    da.Fill(ds);
        //    Conn.Close();
        //    Conn.Dispose();

        //    if (ds != null && ds.Tables.Count > 0)
        //    {
        //        dt = ds.Tables[0];
        //        //dt.WriteXml(XmlWt);
               
        //        int count = (int)ms.Length;
        //        byte[] temp = new byte[count];
        //        ms.Seek(0, SeekOrigin.Begin);
        //        ms.Read(temp, 0, count);

        //        //返回Unicode编码的文本
        //        UnicodeEncoding ucode = new UnicodeEncoding();
        //        string returnValue = ucode.GetString(temp).Trim();
                
        //        return returnValue;
        //    }
        //    return string.Empty;
        //}
    }

    
}