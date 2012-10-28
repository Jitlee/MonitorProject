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

        public IQueryable<t_ElementProperty> GetScreenElementProperty(int ScreenID)
        {
          //var v=  from f in ObjectContext.t_ElementProperty from c in ObjectContext.t_Element 
          //        where  c.ElementID==f.ElementID && c.ScreenID ==ScreenID select f;
          //return v;
            return ObjectContext.P_GetElementPropertiesByScreenID(ScreenID).AsQueryable();
        }

        public void CopyScreenElement(int newScreenID,int oldScreen)
        {
            ObjectContext.P_CopyScreen(newScreenID, oldScreen);
        }

        /// <summary>
        /// 根据Screenid查询当前场景下元素的值
        /// </summary>
        /// <param name="mScreenID"></param>
        /// <returns></returns>
        public List<V_ScreenMonitorValue> GetScreenMonitorValue(int mScreenID)
        {
            var v = from f in ObjectContext.V_ScreenMonitorValue where f.ScreenID == mScreenID select f;
            List<V_ScreenMonitorValue> eValue = v.ToList();

            foreach (V_ScreenMonitorValue obj in eValue)
            {
                if (!string.IsNullOrEmpty(obj.ComputeStr))
                {
                    Paser p = new Paser();
                    string s = p.Execute("", obj.ComputeStr.Trim());
                    if (!string.IsNullOrEmpty(s))
                    {
                        float fValue;
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
       

        /// <summary>
        /// 列新TextBox Change事件值
        /// </summary>
        /// <param name="mMonitorValue"></param>
        /// <param name="mStationID"></param>
        /// <param name="mDeviceID"></param>
        /// <param name="mChannelNo"></param>
        /// <param name="mElemetID"></param>
        /// <returns></returns>
        //public bool ChangeInputTextBoxValue(string mMonitorValue, int mStationID, int mDeviceID, int mChannelNo
        //    ,int mElemetID)
        //{
        //    //更新t_ChannelHistoryValue
        //    var v = from f in ObjectContext.t_ChannelHistoryValue
        //            where f.StationID == mStationID
        //                && f.DeviceID == mDeviceID && f.ChannelNo == mChannelNo
        //            select f;

        //    if (v.Count() > 0)
        //    {
        //        foreach (var vobj in v)
        //        {
        //            vobj.MonitorValue = Convert.ToDouble(mMonitorValue);
        //        }
        //    }
            
        //    //更新t_ElementProperty
        //    var vp= from fp in ObjectContext.t_ElementProperty where fp.ElementID== mElemetID select fp;
        //    if (vp.Count() > 0)
        //    {
        //        var vpObj = vp.First();
        //        vpObj.PropertyValue = mMonitorValue;
        //    }

        //    ObjectContext.SaveChanges();
        //    return true;
        //}

        /// <summary>
        /// 根据场景ID获取 元素列表
        /// </summary>
        /// <param name="screenID"></param>
        /// <returns></returns>
        public IQueryable<t_Element> GetT_ElementsByScreenID(int screenID)
        {
            return this.ObjectContext.P_GetElementsByScreenID(screenID).AsQueryable();
        }

        /// <summary>
        /// 获取图库分类
        /// </summary>
        /// <returns></returns>
        public IQueryable<t_GalleryClassification> GetT_GalleryClassification()
        {
            return this.ObjectContext.GalleryClassification;
        }

        /// <summary>
        /// 根据 control type 查询控件 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IQueryable<t_Control> GetT_ControlByType(int type)
        {
            return this.ObjectContext.t_Control.Where(t => t.ControlType == type);
        }

    }

    
}