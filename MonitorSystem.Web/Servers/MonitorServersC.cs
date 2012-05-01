using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using MonitorSystem.Web.Moldes;

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
    }
}