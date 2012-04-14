
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
        // To support paging you will need to add ordering to the 't_AlarmGroupMembers' query.
        public IQueryable<t_AlarmGroupMembers> GetT_AlarmGroupMembers()
        {
            return this.ObjectContext.t_AlarmGroupMembers;
        }

        public void InsertT_AlarmGroupMembers(t_AlarmGroupMembers t_AlarmGroupMembers)
        {
            if ((t_AlarmGroupMembers.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_AlarmGroupMembers, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_AlarmGroupMembers.AddObject(t_AlarmGroupMembers);
            }
        }

        public void UpdateT_AlarmGroupMembers(t_AlarmGroupMembers currentt_AlarmGroupMembers)
        {
            this.ObjectContext.t_AlarmGroupMembers.AttachAsModified(currentt_AlarmGroupMembers, this.ChangeSet.GetOriginal(currentt_AlarmGroupMembers));
        }

        public void DeleteT_AlarmGroupMembers(t_AlarmGroupMembers t_AlarmGroupMembers)
        {
            if ((t_AlarmGroupMembers.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_AlarmGroupMembers.Attach(t_AlarmGroupMembers);
            }
            this.ObjectContext.t_AlarmGroupMembers.DeleteObject(t_AlarmGroupMembers);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_AlarmGroups' query.
        public IQueryable<t_AlarmGroups> GetT_AlarmGroups()
        {
            return this.ObjectContext.t_AlarmGroups;
        }

        public void InsertT_AlarmGroups(t_AlarmGroups t_AlarmGroups)
        {
            if ((t_AlarmGroups.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_AlarmGroups, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_AlarmGroups.AddObject(t_AlarmGroups);
            }
        }

        public void UpdateT_AlarmGroups(t_AlarmGroups currentt_AlarmGroups)
        {
            this.ObjectContext.t_AlarmGroups.AttachAsModified(currentt_AlarmGroups, this.ChangeSet.GetOriginal(currentt_AlarmGroups));
        }

        public void DeleteT_AlarmGroups(t_AlarmGroups t_AlarmGroups)
        {
            if ((t_AlarmGroups.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_AlarmGroups.Attach(t_AlarmGroups);
            }
            this.ObjectContext.t_AlarmGroups.DeleteObject(t_AlarmGroups);
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
        // To support paging you will need to add ordering to the 't_AlarmLevelSet' query.
        public IQueryable<t_AlarmLevelSet> GetT_AlarmLevelSet()
        {
            return this.ObjectContext.t_AlarmLevelSet;
        }

        public void InsertT_AlarmLevelSet(t_AlarmLevelSet t_AlarmLevelSet)
        {
            if ((t_AlarmLevelSet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_AlarmLevelSet, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_AlarmLevelSet.AddObject(t_AlarmLevelSet);
            }
        }

        public void UpdateT_AlarmLevelSet(t_AlarmLevelSet currentt_AlarmLevelSet)
        {
            this.ObjectContext.t_AlarmLevelSet.AttachAsModified(currentt_AlarmLevelSet, this.ChangeSet.GetOriginal(currentt_AlarmLevelSet));
        }

        public void DeleteT_AlarmLevelSet(t_AlarmLevelSet t_AlarmLevelSet)
        {
            if ((t_AlarmLevelSet.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_AlarmLevelSet.Attach(t_AlarmLevelSet);
            }
            this.ObjectContext.t_AlarmLevelSet.DeleteObject(t_AlarmLevelSet);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_AlarmLog' query.
        public IQueryable<t_AlarmLog> GetT_AlarmLog()
        {
            return this.ObjectContext.t_AlarmLog;
        }

        public void InsertT_AlarmLog(t_AlarmLog t_AlarmLog)
        {
            if ((t_AlarmLog.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_AlarmLog, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_AlarmLog.AddObject(t_AlarmLog);
            }
        }

        public void UpdateT_AlarmLog(t_AlarmLog currentt_AlarmLog)
        {
            this.ObjectContext.t_AlarmLog.AttachAsModified(currentt_AlarmLog, this.ChangeSet.GetOriginal(currentt_AlarmLog));
        }

        public void DeleteT_AlarmLog(t_AlarmLog t_AlarmLog)
        {
            if ((t_AlarmLog.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_AlarmLog.Attach(t_AlarmLog);
            }
            this.ObjectContext.t_AlarmLog.DeleteObject(t_AlarmLog);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_AlarmMethod' query.
        public IQueryable<t_AlarmMethod> GetT_AlarmMethod()
        {
            return this.ObjectContext.t_AlarmMethod;
        }

        public void InsertT_AlarmMethod(t_AlarmMethod t_AlarmMethod)
        {
            if ((t_AlarmMethod.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_AlarmMethod, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_AlarmMethod.AddObject(t_AlarmMethod);
            }
        }

        public void UpdateT_AlarmMethod(t_AlarmMethod currentt_AlarmMethod)
        {
            this.ObjectContext.t_AlarmMethod.AttachAsModified(currentt_AlarmMethod, this.ChangeSet.GetOriginal(currentt_AlarmMethod));
        }

        public void DeleteT_AlarmMethod(t_AlarmMethod t_AlarmMethod)
        {
            if ((t_AlarmMethod.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_AlarmMethod.Attach(t_AlarmMethod);
            }
            this.ObjectContext.t_AlarmMethod.DeleteObject(t_AlarmMethod);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_AlarmPolicy' query.
        public IQueryable<t_AlarmPolicy> GetT_AlarmPolicy()
        {
            return this.ObjectContext.t_AlarmPolicy;
        }

        public void InsertT_AlarmPolicy(t_AlarmPolicy t_AlarmPolicy)
        {
            if ((t_AlarmPolicy.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_AlarmPolicy, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_AlarmPolicy.AddObject(t_AlarmPolicy);
            }
        }

        public void UpdateT_AlarmPolicy(t_AlarmPolicy currentt_AlarmPolicy)
        {
            this.ObjectContext.t_AlarmPolicy.AttachAsModified(currentt_AlarmPolicy, this.ChangeSet.GetOriginal(currentt_AlarmPolicy));
        }

        public void DeleteT_AlarmPolicy(t_AlarmPolicy t_AlarmPolicy)
        {
            if ((t_AlarmPolicy.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_AlarmPolicy.Attach(t_AlarmPolicy);
            }
            this.ObjectContext.t_AlarmPolicy.DeleteObject(t_AlarmPolicy);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_AlarmPolicyManagement' query.
        public IQueryable<t_AlarmPolicyManagement> GetT_AlarmPolicyManagement()
        {
            return this.ObjectContext.t_AlarmPolicyManagement;
        }

        public void InsertT_AlarmPolicyManagement(t_AlarmPolicyManagement t_AlarmPolicyManagement)
        {
            if ((t_AlarmPolicyManagement.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_AlarmPolicyManagement, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_AlarmPolicyManagement.AddObject(t_AlarmPolicyManagement);
            }
        }

        public void UpdateT_AlarmPolicyManagement(t_AlarmPolicyManagement currentt_AlarmPolicyManagement)
        {
            this.ObjectContext.t_AlarmPolicyManagement.AttachAsModified(currentt_AlarmPolicyManagement, this.ChangeSet.GetOriginal(currentt_AlarmPolicyManagement));
        }

        public void DeleteT_AlarmPolicyManagement(t_AlarmPolicyManagement t_AlarmPolicyManagement)
        {
            if ((t_AlarmPolicyManagement.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_AlarmPolicyManagement.Attach(t_AlarmPolicyManagement);
            }
            this.ObjectContext.t_AlarmPolicyManagement.DeleteObject(t_AlarmPolicyManagement);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_AlarmPolicyTargetGroup' query.
        public IQueryable<t_AlarmPolicyTargetGroup> GetT_AlarmPolicyTargetGroup()
        {
            return this.ObjectContext.t_AlarmPolicyTargetGroup;
        }

        public void InsertT_AlarmPolicyTargetGroup(t_AlarmPolicyTargetGroup t_AlarmPolicyTargetGroup)
        {
            if ((t_AlarmPolicyTargetGroup.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_AlarmPolicyTargetGroup, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_AlarmPolicyTargetGroup.AddObject(t_AlarmPolicyTargetGroup);
            }
        }

        public void UpdateT_AlarmPolicyTargetGroup(t_AlarmPolicyTargetGroup currentt_AlarmPolicyTargetGroup)
        {
            this.ObjectContext.t_AlarmPolicyTargetGroup.AttachAsModified(currentt_AlarmPolicyTargetGroup, this.ChangeSet.GetOriginal(currentt_AlarmPolicyTargetGroup));
        }

        public void DeleteT_AlarmPolicyTargetGroup(t_AlarmPolicyTargetGroup t_AlarmPolicyTargetGroup)
        {
            if ((t_AlarmPolicyTargetGroup.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_AlarmPolicyTargetGroup.Attach(t_AlarmPolicyTargetGroup);
            }
            this.ObjectContext.t_AlarmPolicyTargetGroup.DeleteObject(t_AlarmPolicyTargetGroup);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_AlarmPolicyTargetGroupMunber' query.
        public IQueryable<t_AlarmPolicyTargetGroupMunber> GetT_AlarmPolicyTargetGroupMunber()
        {
            return this.ObjectContext.t_AlarmPolicyTargetGroupMunber;
        }

        public void InsertT_AlarmPolicyTargetGroupMunber(t_AlarmPolicyTargetGroupMunber t_AlarmPolicyTargetGroupMunber)
        {
            if ((t_AlarmPolicyTargetGroupMunber.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_AlarmPolicyTargetGroupMunber, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_AlarmPolicyTargetGroupMunber.AddObject(t_AlarmPolicyTargetGroupMunber);
            }
        }

        public void UpdateT_AlarmPolicyTargetGroupMunber(t_AlarmPolicyTargetGroupMunber currentt_AlarmPolicyTargetGroupMunber)
        {
            this.ObjectContext.t_AlarmPolicyTargetGroupMunber.AttachAsModified(currentt_AlarmPolicyTargetGroupMunber, this.ChangeSet.GetOriginal(currentt_AlarmPolicyTargetGroupMunber));
        }

        public void DeleteT_AlarmPolicyTargetGroupMunber(t_AlarmPolicyTargetGroupMunber t_AlarmPolicyTargetGroupMunber)
        {
            if ((t_AlarmPolicyTargetGroupMunber.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_AlarmPolicyTargetGroupMunber.Attach(t_AlarmPolicyTargetGroupMunber);
            }
            this.ObjectContext.t_AlarmPolicyTargetGroupMunber.DeleteObject(t_AlarmPolicyTargetGroupMunber);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_AlarmTarget' query.
        public IQueryable<t_AlarmTarget> GetT_AlarmTarget()
        {
            return this.ObjectContext.t_AlarmTarget;
        }

        public void InsertT_AlarmTarget(t_AlarmTarget t_AlarmTarget)
        {
            if ((t_AlarmTarget.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_AlarmTarget, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_AlarmTarget.AddObject(t_AlarmTarget);
            }
        }

        public void UpdateT_AlarmTarget(t_AlarmTarget currentt_AlarmTarget)
        {
            this.ObjectContext.t_AlarmTarget.AttachAsModified(currentt_AlarmTarget, this.ChangeSet.GetOriginal(currentt_AlarmTarget));
        }

        public void DeleteT_AlarmTarget(t_AlarmTarget t_AlarmTarget)
        {
            if ((t_AlarmTarget.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_AlarmTarget.Attach(t_AlarmTarget);
            }
            this.ObjectContext.t_AlarmTarget.DeleteObject(t_AlarmTarget);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_AlarmTime' query.
        public IQueryable<t_AlarmTime> GetT_AlarmTime()
        {
            return this.ObjectContext.t_AlarmTime;
        }

        public void InsertT_AlarmTime(t_AlarmTime t_AlarmTime)
        {
            if ((t_AlarmTime.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_AlarmTime, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_AlarmTime.AddObject(t_AlarmTime);
            }
        }

        public void UpdateT_AlarmTime(t_AlarmTime currentt_AlarmTime)
        {
            this.ObjectContext.t_AlarmTime.AttachAsModified(currentt_AlarmTime, this.ChangeSet.GetOriginal(currentt_AlarmTime));
        }

        public void DeleteT_AlarmTime(t_AlarmTime t_AlarmTime)
        {
            if ((t_AlarmTime.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_AlarmTime.Attach(t_AlarmTime);
            }
            this.ObjectContext.t_AlarmTime.DeleteObject(t_AlarmTime);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_AlramBindTime' query.
        public IQueryable<t_AlramBindTime> GetT_AlramBindTime()
        {
            return this.ObjectContext.t_AlramBindTime;
        }

        public void InsertT_AlramBindTime(t_AlramBindTime t_AlramBindTime)
        {
            if ((t_AlramBindTime.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_AlramBindTime, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_AlramBindTime.AddObject(t_AlramBindTime);
            }
        }

        public void UpdateT_AlramBindTime(t_AlramBindTime currentt_AlramBindTime)
        {
            this.ObjectContext.t_AlramBindTime.AttachAsModified(currentt_AlramBindTime, this.ChangeSet.GetOriginal(currentt_AlramBindTime));
        }

        public void DeleteT_AlramBindTime(t_AlramBindTime t_AlramBindTime)
        {
            if ((t_AlramBindTime.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_AlramBindTime.Attach(t_AlramBindTime);
            }
            this.ObjectContext.t_AlramBindTime.DeleteObject(t_AlramBindTime);
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
        // To support paging you will need to add ordering to the 't_DeviceType' query.
        public IQueryable<t_DeviceType> GetT_DeviceType()
        {
            return this.ObjectContext.t_DeviceType;
        }

        public void InsertT_DeviceType(t_DeviceType t_DeviceType)
        {
            if ((t_DeviceType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_DeviceType, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_DeviceType.AddObject(t_DeviceType);
            }
        }

        public void UpdateT_DeviceType(t_DeviceType currentt_DeviceType)
        {
            this.ObjectContext.t_DeviceType.AttachAsModified(currentt_DeviceType, this.ChangeSet.GetOriginal(currentt_DeviceType));
        }

        public void DeleteT_DeviceType(t_DeviceType t_DeviceType)
        {
            if ((t_DeviceType.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_DeviceType.Attach(t_DeviceType);
            }
            this.ObjectContext.t_DeviceType.DeleteObject(t_DeviceType);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_DisarmTime' query.
        public IQueryable<t_DisarmTime> GetT_DisarmTime()
        {
            return this.ObjectContext.t_DisarmTime;
        }

        public void InsertT_DisarmTime(t_DisarmTime t_DisarmTime)
        {
            if ((t_DisarmTime.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_DisarmTime, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_DisarmTime.AddObject(t_DisarmTime);
            }
        }

        public void UpdateT_DisarmTime(t_DisarmTime currentt_DisarmTime)
        {
            this.ObjectContext.t_DisarmTime.AttachAsModified(currentt_DisarmTime, this.ChangeSet.GetOriginal(currentt_DisarmTime));
        }

        public void DeleteT_DisarmTime(t_DisarmTime t_DisarmTime)
        {
            if ((t_DisarmTime.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_DisarmTime.Attach(t_DisarmTime);
            }
            this.ObjectContext.t_DisarmTime.DeleteObject(t_DisarmTime);
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
        // To support paging you will need to add ordering to the 't_EventType' query.
        public IQueryable<t_EventType> GetT_EventType()
        {
            return this.ObjectContext.t_EventType;
        }

        public void InsertT_EventType(t_EventType t_EventType)
        {
            if ((t_EventType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_EventType, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_EventType.AddObject(t_EventType);
            }
        }

        public void UpdateT_EventType(t_EventType currentt_EventType)
        {
            this.ObjectContext.t_EventType.AttachAsModified(currentt_EventType, this.ChangeSet.GetOriginal(currentt_EventType));
        }

        public void DeleteT_EventType(t_EventType t_EventType)
        {
            if ((t_EventType.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_EventType.Attach(t_EventType);
            }
            this.ObjectContext.t_EventType.DeleteObject(t_EventType);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_GenChannelType' query.
        public IQueryable<t_GenChannelType> GetT_GenChannelType()
        {
            return this.ObjectContext.t_GenChannelType;
        }

        public void InsertT_GenChannelType(t_GenChannelType t_GenChannelType)
        {
            if ((t_GenChannelType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_GenChannelType, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_GenChannelType.AddObject(t_GenChannelType);
            }
        }

        public void UpdateT_GenChannelType(t_GenChannelType currentt_GenChannelType)
        {
            this.ObjectContext.t_GenChannelType.AttachAsModified(currentt_GenChannelType, this.ChangeSet.GetOriginal(currentt_GenChannelType));
        }

        public void DeleteT_GenChannelType(t_GenChannelType t_GenChannelType)
        {
            if ((t_GenChannelType.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_GenChannelType.Attach(t_GenChannelType);
            }
            this.ObjectContext.t_GenChannelType.DeleteObject(t_GenChannelType);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_GeneralDll' query.
        public IQueryable<t_GeneralDll> GetT_GeneralDll()
        {
            return this.ObjectContext.t_GeneralDll;
        }

        public void InsertT_GeneralDll(t_GeneralDll t_GeneralDll)
        {
            if ((t_GeneralDll.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_GeneralDll, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_GeneralDll.AddObject(t_GeneralDll);
            }
        }

        public void UpdateT_GeneralDll(t_GeneralDll currentt_GeneralDll)
        {
            this.ObjectContext.t_GeneralDll.AttachAsModified(currentt_GeneralDll, this.ChangeSet.GetOriginal(currentt_GeneralDll));
        }

        public void DeleteT_GeneralDll(t_GeneralDll t_GeneralDll)
        {
            if ((t_GeneralDll.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_GeneralDll.Attach(t_GeneralDll);
            }
            this.ObjectContext.t_GeneralDll.DeleteObject(t_GeneralDll);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_Inspection' query.
        public IQueryable<t_Inspection> GetT_Inspection()
        {
            return this.ObjectContext.t_Inspection;
        }

        public void InsertT_Inspection(t_Inspection t_Inspection)
        {
            if ((t_Inspection.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Inspection, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_Inspection.AddObject(t_Inspection);
            }
        }

        public void UpdateT_Inspection(t_Inspection currentt_Inspection)
        {
            this.ObjectContext.t_Inspection.AttachAsModified(currentt_Inspection, this.ChangeSet.GetOriginal(currentt_Inspection));
        }

        public void DeleteT_Inspection(t_Inspection t_Inspection)
        {
            if ((t_Inspection.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_Inspection.Attach(t_Inspection);
            }
            this.ObjectContext.t_Inspection.DeleteObject(t_Inspection);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_IPMonitor_Relation' query.
        public IQueryable<t_IPMonitor_Relation> GetT_IPMonitor_Relation()
        {
            return this.ObjectContext.t_IPMonitor_Relation;
        }

        public void InsertT_IPMonitor_Relation(t_IPMonitor_Relation t_IPMonitor_Relation)
        {
            if ((t_IPMonitor_Relation.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_IPMonitor_Relation, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_IPMonitor_Relation.AddObject(t_IPMonitor_Relation);
            }
        }

        public void UpdateT_IPMonitor_Relation(t_IPMonitor_Relation currentt_IPMonitor_Relation)
        {
            this.ObjectContext.t_IPMonitor_Relation.AttachAsModified(currentt_IPMonitor_Relation, this.ChangeSet.GetOriginal(currentt_IPMonitor_Relation));
        }

        public void DeleteT_IPMonitor_Relation(t_IPMonitor_Relation t_IPMonitor_Relation)
        {
            if ((t_IPMonitor_Relation.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_IPMonitor_Relation.Attach(t_IPMonitor_Relation);
            }
            this.ObjectContext.t_IPMonitor_Relation.DeleteObject(t_IPMonitor_Relation);
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
        // To support paging you will need to add ordering to the 't_LightAlarm' query.
        public IQueryable<t_LightAlarm> GetT_LightAlarm()
        {
            return this.ObjectContext.t_LightAlarm;
        }

        public void InsertT_LightAlarm(t_LightAlarm t_LightAlarm)
        {
            if ((t_LightAlarm.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_LightAlarm, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_LightAlarm.AddObject(t_LightAlarm);
            }
        }

        public void UpdateT_LightAlarm(t_LightAlarm currentt_LightAlarm)
        {
            this.ObjectContext.t_LightAlarm.AttachAsModified(currentt_LightAlarm, this.ChangeSet.GetOriginal(currentt_LightAlarm));
        }

        public void DeleteT_LightAlarm(t_LightAlarm t_LightAlarm)
        {
            if ((t_LightAlarm.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_LightAlarm.Attach(t_LightAlarm);
            }
            this.ObjectContext.t_LightAlarm.DeleteObject(t_LightAlarm);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_LinkageSet' query.
        public IQueryable<t_LinkageSet> GetT_LinkageSet()
        {
            return this.ObjectContext.t_LinkageSet;
        }

        public void InsertT_LinkageSet(t_LinkageSet t_LinkageSet)
        {
            if ((t_LinkageSet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_LinkageSet, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_LinkageSet.AddObject(t_LinkageSet);
            }
        }

        public void UpdateT_LinkageSet(t_LinkageSet currentt_LinkageSet)
        {
            this.ObjectContext.t_LinkageSet.AttachAsModified(currentt_LinkageSet, this.ChangeSet.GetOriginal(currentt_LinkageSet));
        }

        public void DeleteT_LinkageSet(t_LinkageSet t_LinkageSet)
        {
            if ((t_LinkageSet.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_LinkageSet.Attach(t_LinkageSet);
            }
            this.ObjectContext.t_LinkageSet.DeleteObject(t_LinkageSet);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_LinkElement' query.
        public IQueryable<t_LinkElement> GetT_LinkElement()
        {
            return this.ObjectContext.t_LinkElement;
        }

        public void InsertT_LinkElement(t_LinkElement t_LinkElement)
        {
            if ((t_LinkElement.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_LinkElement, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_LinkElement.AddObject(t_LinkElement);
            }
        }

        public void UpdateT_LinkElement(t_LinkElement currentt_LinkElement)
        {
            this.ObjectContext.t_LinkElement.AttachAsModified(currentt_LinkElement, this.ChangeSet.GetOriginal(currentt_LinkElement));
        }

        public void DeleteT_LinkElement(t_LinkElement t_LinkElement)
        {
            if ((t_LinkElement.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_LinkElement.Attach(t_LinkElement);
            }
            this.ObjectContext.t_LinkElement.DeleteObject(t_LinkElement);
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
        // To support paging you will need to add ordering to the 't_PolicyActionMap' query.
        public IQueryable<t_PolicyActionMap> GetT_PolicyActionMap()
        {
            return this.ObjectContext.t_PolicyActionMap;
        }

        public void InsertT_PolicyActionMap(t_PolicyActionMap t_PolicyActionMap)
        {
            if ((t_PolicyActionMap.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_PolicyActionMap, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_PolicyActionMap.AddObject(t_PolicyActionMap);
            }
        }

        public void UpdateT_PolicyActionMap(t_PolicyActionMap currentt_PolicyActionMap)
        {
            this.ObjectContext.t_PolicyActionMap.AttachAsModified(currentt_PolicyActionMap, this.ChangeSet.GetOriginal(currentt_PolicyActionMap));
        }

        public void DeleteT_PolicyActionMap(t_PolicyActionMap t_PolicyActionMap)
        {
            if ((t_PolicyActionMap.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_PolicyActionMap.Attach(t_PolicyActionMap);
            }
            this.ObjectContext.t_PolicyActionMap.DeleteObject(t_PolicyActionMap);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_PolicyDeviceMap' query.
        public IQueryable<t_PolicyDeviceMap> GetT_PolicyDeviceMap()
        {
            return this.ObjectContext.t_PolicyDeviceMap;
        }

        public void InsertT_PolicyDeviceMap(t_PolicyDeviceMap t_PolicyDeviceMap)
        {
            if ((t_PolicyDeviceMap.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_PolicyDeviceMap, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_PolicyDeviceMap.AddObject(t_PolicyDeviceMap);
            }
        }

        public void UpdateT_PolicyDeviceMap(t_PolicyDeviceMap currentt_PolicyDeviceMap)
        {
            this.ObjectContext.t_PolicyDeviceMap.AttachAsModified(currentt_PolicyDeviceMap, this.ChangeSet.GetOriginal(currentt_PolicyDeviceMap));
        }

        public void DeleteT_PolicyDeviceMap(t_PolicyDeviceMap t_PolicyDeviceMap)
        {
            if ((t_PolicyDeviceMap.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_PolicyDeviceMap.Attach(t_PolicyDeviceMap);
            }
            this.ObjectContext.t_PolicyDeviceMap.DeleteObject(t_PolicyDeviceMap);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_RelationAction' query.
        public IQueryable<t_RelationAction> GetT_RelationAction()
        {
            return this.ObjectContext.t_RelationAction;
        }

        public void InsertT_RelationAction(t_RelationAction t_RelationAction)
        {
            if ((t_RelationAction.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_RelationAction, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_RelationAction.AddObject(t_RelationAction);
            }
        }

        public void UpdateT_RelationAction(t_RelationAction currentt_RelationAction)
        {
            this.ObjectContext.t_RelationAction.AttachAsModified(currentt_RelationAction, this.ChangeSet.GetOriginal(currentt_RelationAction));
        }

        public void DeleteT_RelationAction(t_RelationAction t_RelationAction)
        {
            if ((t_RelationAction.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_RelationAction.Attach(t_RelationAction);
            }
            this.ObjectContext.t_RelationAction.DeleteObject(t_RelationAction);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_Scheduling' query.
        public IQueryable<t_Scheduling> GetT_Scheduling()
        {
            return this.ObjectContext.t_Scheduling;
        }

        public void InsertT_Scheduling(t_Scheduling t_Scheduling)
        {
            if ((t_Scheduling.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Scheduling, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_Scheduling.AddObject(t_Scheduling);
            }
        }

        public void UpdateT_Scheduling(t_Scheduling currentt_Scheduling)
        {
            this.ObjectContext.t_Scheduling.AttachAsModified(currentt_Scheduling, this.ChangeSet.GetOriginal(currentt_Scheduling));
        }

        public void DeleteT_Scheduling(t_Scheduling t_Scheduling)
        {
            if ((t_Scheduling.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_Scheduling.Attach(t_Scheduling);
            }
            this.ObjectContext.t_Scheduling.DeleteObject(t_Scheduling);
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
        // To support paging you will need to add ordering to the 't_ScreenShape' query.
        public IQueryable<t_ScreenShape> GetT_ScreenShape()
        {
            return this.ObjectContext.t_ScreenShape;
        }

        public void InsertT_ScreenShape(t_ScreenShape t_ScreenShape)
        {
            if ((t_ScreenShape.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_ScreenShape, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_ScreenShape.AddObject(t_ScreenShape);
            }
        }

        public void UpdateT_ScreenShape(t_ScreenShape currentt_ScreenShape)
        {
            this.ObjectContext.t_ScreenShape.AttachAsModified(currentt_ScreenShape, this.ChangeSet.GetOriginal(currentt_ScreenShape));
        }

        public void DeleteT_ScreenShape(t_ScreenShape t_ScreenShape)
        {
            if ((t_ScreenShape.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_ScreenShape.Attach(t_ScreenShape);
            }
            this.ObjectContext.t_ScreenShape.DeleteObject(t_ScreenShape);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_SerialPort' query.
        public IQueryable<t_SerialPort> GetT_SerialPort()
        {
            return this.ObjectContext.t_SerialPort;
        }

        public void InsertT_SerialPort(t_SerialPort t_SerialPort)
        {
            if ((t_SerialPort.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_SerialPort, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_SerialPort.AddObject(t_SerialPort);
            }
        }

        public void UpdateT_SerialPort(t_SerialPort currentt_SerialPort)
        {
            this.ObjectContext.t_SerialPort.AttachAsModified(currentt_SerialPort, this.ChangeSet.GetOriginal(currentt_SerialPort));
        }

        public void DeleteT_SerialPort(t_SerialPort t_SerialPort)
        {
            if ((t_SerialPort.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_SerialPort.Attach(t_SerialPort);
            }
            this.ObjectContext.t_SerialPort.DeleteObject(t_SerialPort);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_ShapeField' query.
        public IQueryable<t_ShapeField> GetT_ShapeField()
        {
            return this.ObjectContext.t_ShapeField;
        }

        public void InsertT_ShapeField(t_ShapeField t_ShapeField)
        {
            if ((t_ShapeField.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_ShapeField, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_ShapeField.AddObject(t_ShapeField);
            }
        }

        public void UpdateT_ShapeField(t_ShapeField currentt_ShapeField)
        {
            this.ObjectContext.t_ShapeField.AttachAsModified(currentt_ShapeField, this.ChangeSet.GetOriginal(currentt_ShapeField));
        }

        public void DeleteT_ShapeField(t_ShapeField t_ShapeField)
        {
            if ((t_ShapeField.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_ShapeField.Attach(t_ShapeField);
            }
            this.ObjectContext.t_ShapeField.DeleteObject(t_ShapeField);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_ShapeScreen' query.
        public IQueryable<t_ShapeScreen> GetT_ShapeScreen()
        {
            return this.ObjectContext.t_ShapeScreen;
        }

        public void InsertT_ShapeScreen(t_ShapeScreen t_ShapeScreen)
        {
            if ((t_ShapeScreen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_ShapeScreen, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_ShapeScreen.AddObject(t_ShapeScreen);
            }
        }

        public void UpdateT_ShapeScreen(t_ShapeScreen currentt_ShapeScreen)
        {
            this.ObjectContext.t_ShapeScreen.AttachAsModified(currentt_ShapeScreen, this.ChangeSet.GetOriginal(currentt_ShapeScreen));
        }

        public void DeleteT_ShapeScreen(t_ShapeScreen t_ShapeScreen)
        {
            if ((t_ShapeScreen.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_ShapeScreen.Attach(t_ShapeScreen);
            }
            this.ObjectContext.t_ShapeScreen.DeleteObject(t_ShapeScreen);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_SnmpGroupChan' query.
        public IQueryable<t_SnmpGroupChan> GetT_SnmpGroupChan()
        {
            return this.ObjectContext.t_SnmpGroupChan;
        }

        public void InsertT_SnmpGroupChan(t_SnmpGroupChan t_SnmpGroupChan)
        {
            if ((t_SnmpGroupChan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_SnmpGroupChan, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_SnmpGroupChan.AddObject(t_SnmpGroupChan);
            }
        }

        public void UpdateT_SnmpGroupChan(t_SnmpGroupChan currentt_SnmpGroupChan)
        {
            this.ObjectContext.t_SnmpGroupChan.AttachAsModified(currentt_SnmpGroupChan, this.ChangeSet.GetOriginal(currentt_SnmpGroupChan));
        }

        public void DeleteT_SnmpGroupChan(t_SnmpGroupChan t_SnmpGroupChan)
        {
            if ((t_SnmpGroupChan.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_SnmpGroupChan.Attach(t_SnmpGroupChan);
            }
            this.ObjectContext.t_SnmpGroupChan.DeleteObject(t_SnmpGroupChan);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_SnmpRecv' query.
        public IQueryable<t_SnmpRecv> GetT_SnmpRecv()
        {
            return this.ObjectContext.t_SnmpRecv;
        }

        public void InsertT_SnmpRecv(t_SnmpRecv t_SnmpRecv)
        {
            if ((t_SnmpRecv.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_SnmpRecv, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_SnmpRecv.AddObject(t_SnmpRecv);
            }
        }

        public void UpdateT_SnmpRecv(t_SnmpRecv currentt_SnmpRecv)
        {
            this.ObjectContext.t_SnmpRecv.AttachAsModified(currentt_SnmpRecv, this.ChangeSet.GetOriginal(currentt_SnmpRecv));
        }

        public void DeleteT_SnmpRecv(t_SnmpRecv t_SnmpRecv)
        {
            if ((t_SnmpRecv.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_SnmpRecv.Attach(t_SnmpRecv);
            }
            this.ObjectContext.t_SnmpRecv.DeleteObject(t_SnmpRecv);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_SnmpSend' query.
        public IQueryable<t_SnmpSend> GetT_SnmpSend()
        {
            return this.ObjectContext.t_SnmpSend;
        }

        public void InsertT_SnmpSend(t_SnmpSend t_SnmpSend)
        {
            if ((t_SnmpSend.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_SnmpSend, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_SnmpSend.AddObject(t_SnmpSend);
            }
        }

        public void UpdateT_SnmpSend(t_SnmpSend currentt_SnmpSend)
        {
            this.ObjectContext.t_SnmpSend.AttachAsModified(currentt_SnmpSend, this.ChangeSet.GetOriginal(currentt_SnmpSend));
        }

        public void DeleteT_SnmpSend(t_SnmpSend t_SnmpSend)
        {
            if ((t_SnmpSend.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_SnmpSend.Attach(t_SnmpSend);
            }
            this.ObjectContext.t_SnmpSend.DeleteObject(t_SnmpSend);
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
        // To support paging you will need to add ordering to the 't_Templates' query.
        public IQueryable<t_Templates> GetT_Templates()
        {
            return this.ObjectContext.t_Templates;
        }

        public void InsertT_Templates(t_Templates t_Templates)
        {
            if ((t_Templates.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Templates, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_Templates.AddObject(t_Templates);
            }
        }

        public void UpdateT_Templates(t_Templates currentt_Templates)
        {
            this.ObjectContext.t_Templates.AttachAsModified(currentt_Templates, this.ChangeSet.GetOriginal(currentt_Templates));
        }

        public void DeleteT_Templates(t_Templates t_Templates)
        {
            if ((t_Templates.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_Templates.Attach(t_Templates);
            }
            this.ObjectContext.t_Templates.DeleteObject(t_Templates);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_TimeLinkage' query.
        public IQueryable<t_TimeLinkage> GetT_TimeLinkage()
        {
            return this.ObjectContext.t_TimeLinkage;
        }

        public void InsertT_TimeLinkage(t_TimeLinkage t_TimeLinkage)
        {
            if ((t_TimeLinkage.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_TimeLinkage, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_TimeLinkage.AddObject(t_TimeLinkage);
            }
        }

        public void UpdateT_TimeLinkage(t_TimeLinkage currentt_TimeLinkage)
        {
            this.ObjectContext.t_TimeLinkage.AttachAsModified(currentt_TimeLinkage, this.ChangeSet.GetOriginal(currentt_TimeLinkage));
        }

        public void DeleteT_TimeLinkage(t_TimeLinkage t_TimeLinkage)
        {
            if ((t_TimeLinkage.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_TimeLinkage.Attach(t_TimeLinkage);
            }
            this.ObjectContext.t_TimeLinkage.DeleteObject(t_TimeLinkage);
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
        // To support paging you will need to add ordering to the 't_TmpValueGroupChan' query.
        public IQueryable<t_TmpValueGroupChan> GetT_TmpValueGroupChan()
        {
            return this.ObjectContext.t_TmpValueGroupChan;
        }

        public void InsertT_TmpValueGroupChan(t_TmpValueGroupChan t_TmpValueGroupChan)
        {
            if ((t_TmpValueGroupChan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_TmpValueGroupChan, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_TmpValueGroupChan.AddObject(t_TmpValueGroupChan);
            }
        }

        public void UpdateT_TmpValueGroupChan(t_TmpValueGroupChan currentt_TmpValueGroupChan)
        {
            this.ObjectContext.t_TmpValueGroupChan.AttachAsModified(currentt_TmpValueGroupChan, this.ChangeSet.GetOriginal(currentt_TmpValueGroupChan));
        }

        public void DeleteT_TmpValueGroupChan(t_TmpValueGroupChan t_TmpValueGroupChan)
        {
            if ((t_TmpValueGroupChan.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_TmpValueGroupChan.Attach(t_TmpValueGroupChan);
            }
            this.ObjectContext.t_TmpValueGroupChan.DeleteObject(t_TmpValueGroupChan);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_TmpValueGroupChanOther' query.
        public IQueryable<t_TmpValueGroupChanOther> GetT_TmpValueGroupChanOther()
        {
            return this.ObjectContext.t_TmpValueGroupChanOther;
        }

        public void InsertT_TmpValueGroupChanOther(t_TmpValueGroupChanOther t_TmpValueGroupChanOther)
        {
            if ((t_TmpValueGroupChanOther.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_TmpValueGroupChanOther, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_TmpValueGroupChanOther.AddObject(t_TmpValueGroupChanOther);
            }
        }

        public void UpdateT_TmpValueGroupChanOther(t_TmpValueGroupChanOther currentt_TmpValueGroupChanOther)
        {
            this.ObjectContext.t_TmpValueGroupChanOther.AttachAsModified(currentt_TmpValueGroupChanOther, this.ChangeSet.GetOriginal(currentt_TmpValueGroupChanOther));
        }

        public void DeleteT_TmpValueGroupChanOther(t_TmpValueGroupChanOther t_TmpValueGroupChanOther)
        {
            if ((t_TmpValueGroupChanOther.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_TmpValueGroupChanOther.Attach(t_TmpValueGroupChanOther);
            }
            this.ObjectContext.t_TmpValueGroupChanOther.DeleteObject(t_TmpValueGroupChanOther);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_TmpValueOther' query.
        public IQueryable<t_TmpValueOther> GetT_TmpValueOther()
        {
            return this.ObjectContext.t_TmpValueOther;
        }

        public void InsertT_TmpValueOther(t_TmpValueOther t_TmpValueOther)
        {
            if ((t_TmpValueOther.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_TmpValueOther, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_TmpValueOther.AddObject(t_TmpValueOther);
            }
        }

        public void UpdateT_TmpValueOther(t_TmpValueOther currentt_TmpValueOther)
        {
            this.ObjectContext.t_TmpValueOther.AttachAsModified(currentt_TmpValueOther, this.ChangeSet.GetOriginal(currentt_TmpValueOther));
        }

        public void DeleteT_TmpValueOther(t_TmpValueOther t_TmpValueOther)
        {
            if ((t_TmpValueOther.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_TmpValueOther.Attach(t_TmpValueOther);
            }
            this.ObjectContext.t_TmpValueOther.DeleteObject(t_TmpValueOther);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_User' query.
        public IQueryable<t_User> GetT_User()
        {
            return this.ObjectContext.t_User;
        }

        public void InsertT_User(t_User t_User)
        {
            if ((t_User.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_User, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_User.AddObject(t_User);
            }
        }

        public void UpdateT_User(t_User currentt_User)
        {
            this.ObjectContext.t_User.AttachAsModified(currentt_User, this.ChangeSet.GetOriginal(currentt_User));
        }

        public void DeleteT_User(t_User t_User)
        {
            if ((t_User.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_User.Attach(t_User);
            }
            this.ObjectContext.t_User.DeleteObject(t_User);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 't_Waibu' query.
        public IQueryable<t_Waibu> GetT_Waibu()
        {
            return this.ObjectContext.t_Waibu;
        }

        public void InsertT_Waibu(t_Waibu t_Waibu)
        {
            if ((t_Waibu.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Waibu, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_Waibu.AddObject(t_Waibu);
            }
        }

        public void UpdateT_Waibu(t_Waibu currentt_Waibu)
        {
            this.ObjectContext.t_Waibu.AttachAsModified(currentt_Waibu, this.ChangeSet.GetOriginal(currentt_Waibu));
        }

        public void DeleteT_Waibu(t_Waibu t_Waibu)
        {
            if ((t_Waibu.EntityState == EntityState.Detached))
            {
                this.ObjectContext.t_Waibu.Attach(t_Waibu);
            }
            this.ObjectContext.t_Waibu.DeleteObject(t_Waibu);
        }
    }
}


