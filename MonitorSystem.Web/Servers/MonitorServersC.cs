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

        //

        public List<V_ScreenMonitorValue> GetScreenMonitorValue(int mScreenID)
        {
            var v = from f in ObjectContext.V_ScreenMonitorValue where f.ScreenID == mScreenID select f;
            List<V_ScreenMonitorValue> eValue = v.ToList();

            foreach (V_ScreenMonitorValue obj in eValue)
            {
                if (!string.IsNullOrEmpty(obj.ComputeStr.Trim()))
                {
                    Paser p = new Paser();
                    string s = p.Execute("", obj.ComputeStr.Trim());
                    if (!string.IsNullOrEmpty(s))
                    {
                        float fValue ;
                        if (float.TryParse(s, out fValue))
                        {
                            obj.MonitorValue = fValue;
                        }
                        else
                        {
                            obj.MonitorValue = -1.0f;
                        }
                    }
                    else
                    {
                        obj.MonitorValue = -1.0f;
                    }
                }
            }

            return eValue;
        }

        public void GetChanncelValue(int iP1, int iP2, int iP3, out float fResult)
        {
            var v = from f in ObjectContext.t_TmpValue where f.StationID == iP1 && f.DeviceID == iP2 && f.ChannelNO == iP3 select f;
            if (v.Count() > 0)
                fResult =float.Parse( v.First().MonitorValue.Value.ToString());
            else
                fResult = -1.0f;
        }
     
    }

    
}