
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


    // Implements application logic using the ControlValue context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public partial class CV : LinqToEntitiesDomainService<ControlValue>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_Channel' query.
        public IQueryable<t_Channel> GetT_Channel()
        {
            return this.ObjectContext.t_Channel;
        }

        public void InsertT_Channel(t_Channel t_Channel)
        {
            if ((t_Channel.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Channel, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_Channel.AddObject(t_Channel);
            }
        }

        public void UpdateT_Channel(t_Channel currentt_Channel)
        {
            this.ObjectContext.t_Channel.AttachAsModified(currentt_Channel, this.ChangeSet.GetOriginal(currentt_Channel));
        }

        public void DeleteT_Channel(t_Channel t_Channel)
        {
            if ((t_Channel.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_Channel.Attach(t_Channel);
            }
            this.ObjectContext.t_Channel.DeleteObject(t_Channel);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_Device' query.
        public IQueryable<t_Device> GetT_Device()
        {
            return this.ObjectContext.t_Device;
        }

        public void InsertT_Device(t_Device t_Device)
        {
            if ((t_Device.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Device, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_Device.AddObject(t_Device);
            }
        }

        public void UpdateT_Device(t_Device currentt_Device)
        {
            this.ObjectContext.t_Device.AttachAsModified(currentt_Device, this.ChangeSet.GetOriginal(currentt_Device));
        }

        public void DeleteT_Device(t_Device t_Device)
        {
            if ((t_Device.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_Device.Attach(t_Device);
            }
            this.ObjectContext.t_Device.DeleteObject(t_Device);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_Station' query.
        public IQueryable<t_Station> GetT_Station()
        {
            return this.ObjectContext.t_Station;
        }

        public void InsertT_Station(t_Station t_Station)
        {
            if ((t_Station.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Station, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_Station.AddObject(t_Station);
            }
        }

        public void UpdateT_Station(t_Station currentt_Station)
        {
            this.ObjectContext.t_Station.AttachAsModified(currentt_Station, this.ChangeSet.GetOriginal(currentt_Station));
        }

        public void DeleteT_Station(t_Station t_Station)
        {
            if ((t_Station.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_Station.Attach(t_Station);
            }
            this.ObjectContext.t_Station.DeleteObject(t_Station);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_TmpValue' query.
        public IQueryable<t_TmpValue> GetT_TmpValue()
        {
            return this.ObjectContext.t_TmpValue;
        }

        public void InsertT_TmpValue(t_TmpValue t_TmpValue)
        {
            if ((t_TmpValue.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_TmpValue, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_TmpValue.AddObject(t_TmpValue);
            }
        }

        public void UpdateT_TmpValue(t_TmpValue currentt_TmpValue)
        {
            this.ObjectContext.t_TmpValue.AttachAsModified(currentt_TmpValue, this.ChangeSet.GetOriginal(currentt_TmpValue));
        }

        public void DeleteT_TmpValue(t_TmpValue t_TmpValue)
        {
            if ((t_TmpValue.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_TmpValue.Attach(t_TmpValue);
            }
            this.ObjectContext.t_TmpValue.DeleteObject(t_TmpValue);
        }

     

      
    }
}


