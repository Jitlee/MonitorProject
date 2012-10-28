
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


    // 使用 MS 上下文实现应用程序逻辑。
    // TODO: 将应用程序逻辑添加到这些方法中或其他方法中。
    // TODO: 连接身份验证(Windows/ASP.NET Forms)并取消注释以下内容，以禁用匿名访问
    //还可考虑添加角色，以根据需要限制访问。
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public partial class MonitorServers : LinqToEntitiesDomainService<MS>
    {

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“t_Control”查询添加顺序。
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
            if ((t_Control.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Control, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.t_Control.Attach(t_Control);
                this.ObjectContext.t_Control.DeleteObject(t_Control);
            }
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“t_ControlProperty”查询添加顺序。
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
            if ((t_ControlProperty.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_ControlProperty, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.t_ControlProperty.Attach(t_ControlProperty);
                this.ObjectContext.t_ControlProperty.DeleteObject(t_ControlProperty);
            }
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“t_Element”查询添加顺序。
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
            if ((t_Element.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Element, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.t_Element.Attach(t_Element);
                this.ObjectContext.t_Element.DeleteObject(t_Element);
            }
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“t_Element_Library”查询添加顺序。
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
            if ((t_Element_Library.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Element_Library, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.t_Element_Library.Attach(t_Element_Library);
                this.ObjectContext.t_Element_Library.DeleteObject(t_Element_Library);
            }
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“t_Element_RealTimeLine”查询添加顺序。
        public IQueryable<t_Element_RealTimeLine> GetT_Element_RealTimeLine()
        {
            return this.ObjectContext.t_Element_RealTimeLine;
        }

        public void InsertT_Element_RealTimeLine(t_Element_RealTimeLine t_Element_RealTimeLine)
        {
            if ((t_Element_RealTimeLine.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Element_RealTimeLine, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_Element_RealTimeLine.AddObject(t_Element_RealTimeLine);
            }
        }

        public void UpdateT_Element_RealTimeLine(t_Element_RealTimeLine currentt_Element_RealTimeLine)
        {
            this.ObjectContext.t_Element_RealTimeLine.AttachAsModified(currentt_Element_RealTimeLine, this.ChangeSet.GetOriginal(currentt_Element_RealTimeLine));
        }

        public void DeleteT_Element_RealTimeLine(t_Element_RealTimeLine t_Element_RealTimeLine)
        {
            if ((t_Element_RealTimeLine.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Element_RealTimeLine, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.t_Element_RealTimeLine.Attach(t_Element_RealTimeLine);
                this.ObjectContext.t_Element_RealTimeLine.DeleteObject(t_Element_RealTimeLine);
            }
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“t_ElementProperty”查询添加顺序。
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
            if ((t_ElementProperty.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_ElementProperty, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.t_ElementProperty.Attach(t_ElementProperty);
                this.ObjectContext.t_ElementProperty.DeleteObject(t_ElementProperty);
            }
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“t_ElementProperty_Library”查询添加顺序。
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
            if ((t_ElementProperty_Library.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_ElementProperty_Library, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.t_ElementProperty_Library.Attach(t_ElementProperty_Library);
                this.ObjectContext.t_ElementProperty_Library.DeleteObject(t_ElementProperty_Library);
            }
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“GalleryClassification”查询添加顺序。
        public IQueryable<t_GalleryClassification> GetGalleryClassification()
        {
            return this.ObjectContext.GalleryClassification;
        }

        public void InsertT_GalleryClassification(t_GalleryClassification t_GalleryClassification)
        {
            if ((t_GalleryClassification.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_GalleryClassification, EntityState.Added);
            }
            else
            {
                this.ObjectContext.GalleryClassification.AddObject(t_GalleryClassification);
            }
        }

        public void UpdateT_GalleryClassification(t_GalleryClassification currentt_GalleryClassification)
        {
            this.ObjectContext.GalleryClassification.AttachAsModified(currentt_GalleryClassification, this.ChangeSet.GetOriginal(currentt_GalleryClassification));
        }

        public void DeleteT_GalleryClassification(t_GalleryClassification t_GalleryClassification)
        {
            if ((t_GalleryClassification.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_GalleryClassification, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.GalleryClassification.Attach(t_GalleryClassification);
                this.ObjectContext.GalleryClassification.DeleteObject(t_GalleryClassification);
            }
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“t_MonitorSystemParam”查询添加顺序。
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
            if ((t_MonitorSystemParam.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_MonitorSystemParam, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.t_MonitorSystemParam.Attach(t_MonitorSystemParam);
                this.ObjectContext.t_MonitorSystemParam.DeleteObject(t_MonitorSystemParam);
            }
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“t_Screen”查询添加顺序。
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
            if ((t_Screen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Screen, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.t_Screen.Attach(t_Screen);
                this.ObjectContext.t_Screen.DeleteObject(t_Screen);
            }
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“t_Screen_Library”查询添加顺序。
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
            if ((t_Screen_Library.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Screen_Library, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.t_Screen_Library.Attach(t_Screen_Library);
                this.ObjectContext.t_Screen_Library.DeleteObject(t_Screen_Library);
            }
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“t_Sys_MainRealTimeSet”查询添加顺序。
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
            if ((t_Sys_MainRealTimeSet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Sys_MainRealTimeSet, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.t_Sys_MainRealTimeSet.Attach(t_Sys_MainRealTimeSet);
                this.ObjectContext.t_Sys_MainRealTimeSet.DeleteObject(t_Sys_MainRealTimeSet);
            }
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“V_ScreenMonitorValue”查询添加顺序。
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
            if ((v_ScreenMonitorValue.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_ScreenMonitorValue, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_ScreenMonitorValue.Attach(v_ScreenMonitorValue);
                this.ObjectContext.V_ScreenMonitorValue.DeleteObject(v_ScreenMonitorValue);
            }
        }
    }
}


