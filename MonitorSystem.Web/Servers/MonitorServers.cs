
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
        // To support paging you will need to add ordering to the 't_AlarmAction' query.
        public IQueryable<t_AlarmAction> GetT_AlarmAction()
        {
            return this.ObjectContext.t_AlarmAction;
        }

        public void InsertT_AlarmAction(t_AlarmAction t_AlarmAction)
        {
            if ((t_AlarmAction.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_AlarmAction, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_AlarmAction.AddObject(t_AlarmAction);
            }
        }

        public void UpdateT_AlarmAction(t_AlarmAction currentt_AlarmAction)
        {
            this.ObjectContext.t_AlarmAction.AttachAsModified(currentt_AlarmAction, this.ChangeSet.GetOriginal(currentt_AlarmAction));
        }

        public void DeleteT_AlarmAction(t_AlarmAction t_AlarmAction)
        {
            if ((t_AlarmAction.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_AlarmAction.Attach(t_AlarmAction);
            }
            this.ObjectContext.t_AlarmAction.DeleteObject(t_AlarmAction);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_AlarmGroup' query.
        public IQueryable<t_AlarmGroup> GetT_AlarmGroup()
        {
            return this.ObjectContext.t_AlarmGroup;
        }

        public void InsertT_AlarmGroup(t_AlarmGroup t_AlarmGroup)
        {
            if ((t_AlarmGroup.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_AlarmGroup, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_AlarmGroup.AddObject(t_AlarmGroup);
            }
        }

        public void UpdateT_AlarmGroup(t_AlarmGroup currentt_AlarmGroup)
        {
            this.ObjectContext.t_AlarmGroup.AttachAsModified(currentt_AlarmGroup, this.ChangeSet.GetOriginal(currentt_AlarmGroup));
        }

        public void DeleteT_AlarmGroup(t_AlarmGroup t_AlarmGroup)
        {
            if ((t_AlarmGroup.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_AlarmGroup.Attach(t_AlarmGroup);
            }
            this.ObjectContext.t_AlarmGroup.DeleteObject(t_AlarmGroup);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_AlarmLevel' query.
        public IQueryable<t_AlarmLevel> GetT_AlarmLevel()
        {
            return this.ObjectContext.t_AlarmLevel;
        }

        public void InsertT_AlarmLevel(t_AlarmLevel t_AlarmLevel)
        {
            if ((t_AlarmLevel.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_AlarmLevel, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_AlarmLevel.AddObject(t_AlarmLevel);
            }
        }

        public void UpdateT_AlarmLevel(t_AlarmLevel currentt_AlarmLevel)
        {
            this.ObjectContext.t_AlarmLevel.AttachAsModified(currentt_AlarmLevel, this.ChangeSet.GetOriginal(currentt_AlarmLevel));
        }

        public void DeleteT_AlarmLevel(t_AlarmLevel t_AlarmLevel)
        {
            if ((t_AlarmLevel.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_AlarmLevel.Attach(t_AlarmLevel);
            }
            this.ObjectContext.t_AlarmLevel.DeleteObject(t_AlarmLevel);
        }

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
        // To support paging you will need to add ordering to the 't_ChannelHistoryValue' query.
        public IQueryable<t_ChannelHistoryValue> GetT_ChannelHistoryValue()
        {
            return this.ObjectContext.t_ChannelHistoryValue;
        }

        public void InsertT_ChannelHistoryValue(t_ChannelHistoryValue t_ChannelHistoryValue)
        {
            if ((t_ChannelHistoryValue.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_ChannelHistoryValue, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_ChannelHistoryValue.AddObject(t_ChannelHistoryValue);
            }
        }

        public void UpdateT_ChannelHistoryValue(t_ChannelHistoryValue currentt_ChannelHistoryValue)
        {
            this.ObjectContext.t_ChannelHistoryValue.AttachAsModified(currentt_ChannelHistoryValue, this.ChangeSet.GetOriginal(currentt_ChannelHistoryValue));
        }

        public void DeleteT_ChannelHistoryValue(t_ChannelHistoryValue t_ChannelHistoryValue)
        {
            if ((t_ChannelHistoryValue.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_ChannelHistoryValue.Attach(t_ChannelHistoryValue);
            }
            this.ObjectContext.t_ChannelHistoryValue.DeleteObject(t_ChannelHistoryValue);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_ChannelHistoryValuetemp' query.
        public IQueryable<t_ChannelHistoryValuetemp> GetT_ChannelHistoryValuetemp()
        {
            return this.ObjectContext.t_ChannelHistoryValuetemp;
        }

        public void InsertT_ChannelHistoryValuetemp(t_ChannelHistoryValuetemp t_ChannelHistoryValuetemp)
        {
            if ((t_ChannelHistoryValuetemp.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_ChannelHistoryValuetemp, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_ChannelHistoryValuetemp.AddObject(t_ChannelHistoryValuetemp);
            }
        }

        public void UpdateT_ChannelHistoryValuetemp(t_ChannelHistoryValuetemp currentt_ChannelHistoryValuetemp)
        {
            this.ObjectContext.t_ChannelHistoryValuetemp.AttachAsModified(currentt_ChannelHistoryValuetemp, this.ChangeSet.GetOriginal(currentt_ChannelHistoryValuetemp));
        }

        public void DeleteT_ChannelHistoryValuetemp(t_ChannelHistoryValuetemp t_ChannelHistoryValuetemp)
        {
            if ((t_ChannelHistoryValuetemp.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_ChannelHistoryValuetemp.Attach(t_ChannelHistoryValuetemp);
            }
            this.ObjectContext.t_ChannelHistoryValuetemp.DeleteObject(t_ChannelHistoryValuetemp);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_ChannelType' query.
        public IQueryable<t_ChannelType> GetT_ChannelType()
        {
            return this.ObjectContext.t_ChannelType;
        }

        public void InsertT_ChannelType(t_ChannelType t_ChannelType)
        {
            if ((t_ChannelType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_ChannelType, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_ChannelType.AddObject(t_ChannelType);
            }
        }

        public void UpdateT_ChannelType(t_ChannelType currentt_ChannelType)
        {
            this.ObjectContext.t_ChannelType.AttachAsModified(currentt_ChannelType, this.ChangeSet.GetOriginal(currentt_ChannelType));
        }

        public void DeleteT_ChannelType(t_ChannelType t_ChannelType)
        {
            if ((t_ChannelType.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_ChannelType.Attach(t_ChannelType);
            }
            this.ObjectContext.t_ChannelType.DeleteObject(t_ChannelType);
        }

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
        // To support paging you will need to add ordering to the 't_KeyWord' query.
        public IQueryable<t_KeyWord> GetT_KeyWord()
        {
            return this.ObjectContext.t_KeyWord;
        }

        public void InsertT_KeyWord(t_KeyWord t_KeyWord)
        {
            if ((t_KeyWord.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_KeyWord, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_KeyWord.AddObject(t_KeyWord);
            }
        }

        public void UpdateT_KeyWord(t_KeyWord currentt_KeyWord)
        {
            this.ObjectContext.t_KeyWord.AttachAsModified(currentt_KeyWord, this.ChangeSet.GetOriginal(currentt_KeyWord));
        }

        public void DeleteT_KeyWord(t_KeyWord t_KeyWord)
        {
            if ((t_KeyWord.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_KeyWord.Attach(t_KeyWord);
            }
            this.ObjectContext.t_KeyWord.DeleteObject(t_KeyWord);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_Mainte' query.
        public IQueryable<t_Mainte> GetT_Mainte()
        {
            return this.ObjectContext.t_Mainte;
        }

        public void InsertT_Mainte(t_Mainte t_Mainte)
        {
            if ((t_Mainte.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Mainte, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_Mainte.AddObject(t_Mainte);
            }
        }

        public void UpdateT_Mainte(t_Mainte currentt_Mainte)
        {
            this.ObjectContext.t_Mainte.AttachAsModified(currentt_Mainte, this.ChangeSet.GetOriginal(currentt_Mainte));
        }

        public void DeleteT_Mainte(t_Mainte t_Mainte)
        {
            if ((t_Mainte.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_Mainte.Attach(t_Mainte);
            }
            this.ObjectContext.t_Mainte.DeleteObject(t_Mainte);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_MonitorServerParam' query.
        public IQueryable<t_MonitorServerParam> GetT_MonitorServerParam()
        {
            return this.ObjectContext.t_MonitorServerParam;
        }

        public void InsertT_MonitorServerParam(t_MonitorServerParam t_MonitorServerParam)
        {
            if ((t_MonitorServerParam.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_MonitorServerParam, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_MonitorServerParam.AddObject(t_MonitorServerParam);
            }
        }

        public void UpdateT_MonitorServerParam(t_MonitorServerParam currentt_MonitorServerParam)
        {
            this.ObjectContext.t_MonitorServerParam.AttachAsModified(currentt_MonitorServerParam, this.ChangeSet.GetOriginal(currentt_MonitorServerParam));
        }

        public void DeleteT_MonitorServerParam(t_MonitorServerParam t_MonitorServerParam)
        {
            if ((t_MonitorServerParam.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_MonitorServerParam.Attach(t_MonitorServerParam);
            }
            this.ObjectContext.t_MonitorServerParam.DeleteObject(t_MonitorServerParam);
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


