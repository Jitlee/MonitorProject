
namespace MonitorSystem.Web.Servers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using MonitorSystem.Web.Moldes;


    // Implements application logic using the MS context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public partial class MonitorServers : LinqToEntitiesDomainService<MS>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_Control' query.
        public IQueryable<t_Control> GetT_Control()
        {
            return this.ObjectContext.t_Control;
        }

        public void InsertT_Control(t_Control t_Control)
        {
            if ((t_Control.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Control, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_Control.AddObject(t_Control);
            }
        }

        public void UpdateT_Control(t_Control currentt_Control)
        {
            this.ObjectContext.t_Control.AttachAsModified(currentt_Control, this.ChangeSet.GetOriginal(currentt_Control));
        }

        public void DeleteT_Control(t_Control t_Control)
        {
            if ((t_Control.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_Control.Attach(t_Control);
            }
            this.ObjectContext.t_Control.DeleteObject(t_Control);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_ControlProperty' query.
        public IQueryable<t_ControlProperty> GetT_ControlProperty()
        {
            return this.ObjectContext.t_ControlProperty;
        }

        public void InsertT_ControlProperty(t_ControlProperty t_ControlProperty)
        {
            if ((t_ControlProperty.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_ControlProperty, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_ControlProperty.AddObject(t_ControlProperty);
            }
        }

        public void UpdateT_ControlProperty(t_ControlProperty currentt_ControlProperty)
        {
            this.ObjectContext.t_ControlProperty.AttachAsModified(currentt_ControlProperty, this.ChangeSet.GetOriginal(currentt_ControlProperty));
        }

        public void DeleteT_ControlProperty(t_ControlProperty t_ControlProperty)
        {
            if ((t_ControlProperty.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_ControlProperty.Attach(t_ControlProperty);
            }
            this.ObjectContext.t_ControlProperty.DeleteObject(t_ControlProperty);
        }


        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_Element' query.
        public IQueryable<t_Element> GetT_Element()
        {
            return this.ObjectContext.t_Element;
        }

        public void InsertT_Element(t_Element t_Element)
        {
            if ((t_Element.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Element, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_Element.AddObject(t_Element);
            }
        }

        public void UpdateT_Element(t_Element currentt_Element)
        {
            this.ObjectContext.t_Element.AttachAsModified(currentt_Element, this.ChangeSet.GetOriginal(currentt_Element));
        }

        public void DeleteT_Element(t_Element t_Element)
        {
            if ((t_Element.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_Element.Attach(t_Element);
            }
            this.ObjectContext.t_Element.DeleteObject(t_Element);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_Element_Library' query.
        public IQueryable<t_Element_Library> GetT_Element_Library()
        {
            return this.ObjectContext.t_Element_Library;
        }

        public void InsertT_Element_Library(t_Element_Library t_Element_Library)
        {
            if ((t_Element_Library.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Element_Library, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_Element_Library.AddObject(t_Element_Library);
            }
        }

        public void UpdateT_Element_Library(t_Element_Library currentt_Element_Library)
        {
            this.ObjectContext.t_Element_Library.AttachAsModified(currentt_Element_Library, this.ChangeSet.GetOriginal(currentt_Element_Library));
        }

        public void DeleteT_Element_Library(t_Element_Library t_Element_Library)
        {
            if ((t_Element_Library.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_Element_Library.Attach(t_Element_Library);
            }
            this.ObjectContext.t_Element_Library.DeleteObject(t_Element_Library);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_ElementProperty' query.
        public IQueryable<t_ElementProperty> GetT_ElementProperty()
        {
            return this.ObjectContext.t_ElementProperty;
        }

        public void InsertT_ElementProperty(t_ElementProperty t_ElementProperty)
        {
            if ((t_ElementProperty.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_ElementProperty, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_ElementProperty.AddObject(t_ElementProperty);
            }
        }

        public void UpdateT_ElementProperty(t_ElementProperty currentt_ElementProperty)
        {
            this.ObjectContext.t_ElementProperty.AttachAsModified(currentt_ElementProperty, this.ChangeSet.GetOriginal(currentt_ElementProperty));
        }

        public void DeleteT_ElementProperty(t_ElementProperty t_ElementProperty)
        {
            if ((t_ElementProperty.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_ElementProperty.Attach(t_ElementProperty);
            }
            this.ObjectContext.t_ElementProperty.DeleteObject(t_ElementProperty);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_ElementProperty_Library' query.
        public IQueryable<t_ElementProperty_Library> GetT_ElementProperty_Library()
        {
            return this.ObjectContext.t_ElementProperty_Library;
        }

        public void InsertT_ElementProperty_Library(t_ElementProperty_Library t_ElementProperty_Library)
        {
            if ((t_ElementProperty_Library.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_ElementProperty_Library, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_ElementProperty_Library.AddObject(t_ElementProperty_Library);
            }
        }

        public void UpdateT_ElementProperty_Library(t_ElementProperty_Library currentt_ElementProperty_Library)
        {
            this.ObjectContext.t_ElementProperty_Library.AttachAsModified(currentt_ElementProperty_Library, this.ChangeSet.GetOriginal(currentt_ElementProperty_Library));
        }

        public void DeleteT_ElementProperty_Library(t_ElementProperty_Library t_ElementProperty_Library)
        {
            if ((t_ElementProperty_Library.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_ElementProperty_Library.Attach(t_ElementProperty_Library);
            }
            this.ObjectContext.t_ElementProperty_Library.DeleteObject(t_ElementProperty_Library);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_MonitorSystemParam' query.
        public IQueryable<t_MonitorSystemParam> GetT_MonitorSystemParam()
        {
            return this.ObjectContext.t_MonitorSystemParam;
        }

        public void InsertT_MonitorSystemParam(t_MonitorSystemParam t_MonitorSystemParam)
        {
            if ((t_MonitorSystemParam.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_MonitorSystemParam, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_MonitorSystemParam.AddObject(t_MonitorSystemParam);
            }
        }

        public void UpdateT_MonitorSystemParam(t_MonitorSystemParam currentt_MonitorSystemParam)
        {
            this.ObjectContext.t_MonitorSystemParam.AttachAsModified(currentt_MonitorSystemParam, this.ChangeSet.GetOriginal(currentt_MonitorSystemParam));
        }

        public void DeleteT_MonitorSystemParam(t_MonitorSystemParam t_MonitorSystemParam)
        {
            if ((t_MonitorSystemParam.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_MonitorSystemParam.Attach(t_MonitorSystemParam);
            }
            this.ObjectContext.t_MonitorSystemParam.DeleteObject(t_MonitorSystemParam);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_Screen' query.
        public IQueryable<t_Screen> GetT_Screen()
        {
            return this.ObjectContext.t_Screen;
        }

        public void InsertT_Screen(t_Screen t_Screen)
        {
            if ((t_Screen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Screen, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_Screen.AddObject(t_Screen);
            }
        }

        public void UpdateT_Screen(t_Screen currentt_Screen)
        {
            this.ObjectContext.t_Screen.AttachAsModified(currentt_Screen, this.ChangeSet.GetOriginal(currentt_Screen));
        }

        public void DeleteT_Screen(t_Screen t_Screen)
        {
            if ((t_Screen.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_Screen.Attach(t_Screen);
            }
            this.ObjectContext.t_Screen.DeleteObject(t_Screen);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_Screen_Library' query.
        public IQueryable<t_Screen_Library> GetT_Screen_Library()
        {
            return this.ObjectContext.t_Screen_Library;
        }

        public void InsertT_Screen_Library(t_Screen_Library t_Screen_Library)
        {
            if ((t_Screen_Library.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Screen_Library, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_Screen_Library.AddObject(t_Screen_Library);
            }
        }

        public void UpdateT_Screen_Library(t_Screen_Library currentt_Screen_Library)
        {
            this.ObjectContext.t_Screen_Library.AttachAsModified(currentt_Screen_Library, this.ChangeSet.GetOriginal(currentt_Screen_Library));
        }

        public void DeleteT_Screen_Library(t_Screen_Library t_Screen_Library)
        {
            if ((t_Screen_Library.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_Screen_Library.Attach(t_Screen_Library);
            }
            this.ObjectContext.t_Screen_Library.DeleteObject(t_Screen_Library);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_Sys_MainRealTimeSet' query.
        public IQueryable<t_Sys_MainRealTimeSet> GetT_Sys_MainRealTimeSet()
        {
            return this.ObjectContext.t_Sys_MainRealTimeSet;
        }

        public void InsertT_Sys_MainRealTimeSet(t_Sys_MainRealTimeSet t_Sys_MainRealTimeSet)
        {
            if ((t_Sys_MainRealTimeSet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Sys_MainRealTimeSet, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_Sys_MainRealTimeSet.AddObject(t_Sys_MainRealTimeSet);
            }
        }

        public void UpdateT_Sys_MainRealTimeSet(t_Sys_MainRealTimeSet currentt_Sys_MainRealTimeSet)
        {
            this.ObjectContext.t_Sys_MainRealTimeSet.AttachAsModified(currentt_Sys_MainRealTimeSet, this.ChangeSet.GetOriginal(currentt_Sys_MainRealTimeSet));
        }

        public void DeleteT_Sys_MainRealTimeSet(t_Sys_MainRealTimeSet t_Sys_MainRealTimeSet)
        {
            if ((t_Sys_MainRealTimeSet.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_Sys_MainRealTimeSet.Attach(t_Sys_MainRealTimeSet);
            }
            this.ObjectContext.t_Sys_MainRealTimeSet.DeleteObject(t_Sys_MainRealTimeSet);
        }
    

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_ScreenMonitorValue' query.
        public IQueryable<V_ScreenMonitorValue> GetV_ScreenMonitorValue()
        {
            return this.ObjectContext.V_ScreenMonitorValue;
        }

        public void InsertV_ScreenMonitorValue(V_ScreenMonitorValue v_ScreenMonitorValue)
        {
            if ((v_ScreenMonitorValue.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_ScreenMonitorValue, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_ScreenMonitorValue.AddObject(v_ScreenMonitorValue);
            }
        }

        public void UpdateV_ScreenMonitorValue(V_ScreenMonitorValue currentV_ScreenMonitorValue)
        {
            this.ObjectContext.V_ScreenMonitorValue.AttachAsModified(currentV_ScreenMonitorValue, this.ChangeSet.GetOriginal(currentV_ScreenMonitorValue));
        }

        public void DeleteV_ScreenMonitorValue(V_ScreenMonitorValue v_ScreenMonitorValue)
        {
            if ((v_ScreenMonitorValue.EntityState == EntityState.Detached))
            {
                this.ObjectContext.V_ScreenMonitorValue.Attach(v_ScreenMonitorValue);
            }
            this.ObjectContext.V_ScreenMonitorValue.DeleteObject(v_ScreenMonitorValue);
        }
    }
}


