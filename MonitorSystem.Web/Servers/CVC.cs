using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorSystem.Web.Servers
{
    public partial class CV
    {
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
        /// <summary>
        /// 获取指定站点、设备、通道的值
        /// </summary>
        /// <param name="iP1"></param>
        /// <param name="iP2"></param>
        /// <param name="iP3"></param>
        /// <param name="fResult"></param>
        public void GetChanncelValue(int iP1, int iP2, int iP3, out float fResult)
        {
            var v = from f in ObjectContext.t_TmpValue where f.StationID == iP1 && f.DeviceID == iP2 && f.ChannelNO == iP3 select f;
            if (v.Count() > 0)
                fResult = float.Parse(v.First().MonitorValue.Value.ToString());
            else
                fResult = -1.0f;
        }

    }
}