﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using MonitorSystem.Web.Servers;
using System.ServiceModel.DomainServices.Client;
using MonitorSystem.Web.Moldes;
using System.Windows.Media.Imaging;
using MonitorSystem.Property;
using System.Collections;

namespace MonitorSystem
{
    public class ScreenArgs:  EventArgs
    {
        t_Screen _Screen;
        /// <summary>
        /// 场景对象 
        /// </summary>
        public t_Screen Screen
        {
            get { return _Screen; }
            set { _Screen = value; }
        }
    }

   

    public partial class PropertyMain : UserControl
    {
        MonitorServers _DataContext = new MonitorServers();
        public static PropertyMain Instance;
        public PropertyMain()
        {
            InitializeComponent();
            LoadScrent();
            Instance = this;
        }

        #region 事件
        public event EventHandler ChangeScreen;
        /// <summary>
        /// 改变选中场景
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnChangeScreen(ScreenArgs args)
        {
             if (ChangeScreen != null)
            {
                ChangeScreen(this, args);
            }
        }
        #endregion

        public t_Control GetSelected()
        {
            if (accordion.SelectedIndex == 0)
            {
                return (tpControls.Content as ListBox).SelectedItem as t_Control;
            }
            else if (accordion.SelectedIndex == 1)
            {
                return (ztControls.Content as ListBox).SelectedItem as t_Control;
            }
            else if (accordion.SelectedIndex == 2)
            {
                return (ggControls.Content as ListBox).SelectedItem as t_Control;
            }
            return null;
        }

        #region  控件
        private void LoadControl()
        {
            _DataContext.Load(_DataContext.GetT_ControlQuery(), DataLoadComplet, null);
        }
        private void DataLoadComplet(LoadOperation<t_Control> results)
        {
            if (results.HasError)
            {
                MessageBox.Show(results.Error.Message);
                return;
            }
            tpControls.DataContext = results.Entities.Where(t => t.ControlType == 1);
            ztControls.DataContext = results.Entities.Where(t => t.ControlType == 2);
            ggControls.DataContext = results.Entities.Where(t => t.ControlType == 3);

        }
        #endregion

        public void ChangeSize(double Height, double Width)
        {
            //if (Height > 370)
            //{
            //    tpControls.Width = accordion.Width = Width;//组件宽度
            //}
        }
        #region 场景
        #region 加载场景
        private void LoadScrent()
        {
            _DataContext.Load(_DataContext.GetT_ScreenQuery(), DataLoadComplet, null);
        }
        List<t_Screen> listScreen = new List<t_Screen>();
        /// <summary>
        /// 加载场景,完成后，加载控件
        /// </summary>
        /// <param name="results"></param>
        private void DataLoadComplet(LoadOperation<t_Screen> results)
        {
            if (results.HasError)
            {
                MessageBox.Show(results.Error.Message);
                return;
            }
            listScreen.Clear();
            foreach (t_Screen obj in results.Entities)
            {
                listScreen.Add(obj);
            }
            BoindTree();
            //加载控件
            LoadControl();
        }

        private void BoindTree()
        {
            List<t_Screen> listRoot = listScreen.Where(a => a.ParentScreenID == 0).ToList();
            t_Screen tsroot = new t_Screen();
            tsroot.ScreenID = 0;
            tsroot.ScreenName = "所有场景";
            TreeViewItem RootItem = CreateTreeItem(tsroot);
            tvScreen.Items.Add(RootItem);

            foreach (t_Screen obj in listRoot)
            {
                TreeViewItem tvi = CreateTreeItem(obj);
                bindChild(tvi, obj);
                RootItem.Items.Add(tvi);
            }
        }

        /// <summary>
        /// 加载子集
        /// </summary>
        /// <param name="root"></param>
        /// <param name="m_obj"></param>
        private void bindChild(TreeViewItem root, t_Screen m_obj)
        {
            List<t_Screen> listRoot = listScreen.Where(a => a.ParentScreenID == m_obj.ScreenID).ToList();
            foreach (t_Screen obj in listRoot)
            {
                TreeViewItem tvi = CreateTreeItem(obj);
                bindChild(tvi, obj);
                root.Items.Add(tvi);
            }
        }
        private TreeViewItem CreateTreeItem(t_Screen m_obj)
        {
            TreeViewItem tvi = new TreeViewItem();
            tvi.Header = m_obj.ScreenName;
            tvi.MouseRightButtonDown += new MouseButtonEventHandler(tvi_MouseRightButtonDown);
            
            tvi.Tag = m_obj;
            return tvi;
        }
        #endregion

        TreeViewItem TreeItemRightItem;
        private void tvi_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (TreeItemRightItem == null)
            {
                TreeItemRightItem = (TreeViewItem)sender;
            }
        }

        #region 双击加载场景，但事件不触发
        //private int ClickNumber = 0;
        //private bool IsClick = false;
        //private DateTime _startTime;
        //protected void tvi_MouseLeftButtonUp(object sender, MouseEventArgs e)
        //{
        //    if (IsClick)//处理双击
        //    {
        //        TimeSpan t = DateTime.Now - _startTime;
        //        if (t.Minutes == 0 && t.Seconds == 0 && t.Milliseconds < 500)
        //        {
        //            ClickNumber++;
        //        }
        //        else
        //        {
        //            IsClick = false;
        //            ClickNumber = 0;
        //        }
        //        if (ClickNumber == 2)
        //        {
        //            IsClick = false;
        //            ClickNumber = 0;
        //            //显示信息
        //            MessageBox.Show("");
        //        }
        //    }
        //}
        //protected void tvi_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (IsClick)
        //    {
        //        TimeSpan t = DateTime.Now - _startTime;
        //        if (t.Minutes == 0 && t.Seconds == 0 && t.Milliseconds < 500)
        //        {
        //            _startTime = DateTime.Now;
        //        }
        //        else
        //        {
        //            _startTime = DateTime.Now;
        //            ClickNumber = 0;
        //        }
        //    }
        //    else
        //    {
        //        IsClick = true;
        //        _startTime = DateTime.Now;
        //        ClickNumber = 0;
        //    }
        //}
        #endregion

        #region 菜单
        /// <summary>
        /// 加载的时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mymenu_Loaded(object sender, RoutedEventArgs e)
        {
            TreeViewItem SelectItem;
            SelectItem = (TreeViewItem)tvScreen.SelectedItem;
            if (SelectItem == null || TreeItemRightItem == null)
            {
                mymenu.IsOpen = false;
                TreeItemRightItem = null;
                return;
            }
            if (SelectItem != TreeItemRightItem)
            {
                mymenu.IsOpen = false;
                TreeItemRightItem = null;
                return;
            }
            t_Screen m_obj = (t_Screen)TreeItemRightItem.Tag;
            EnableMenu(true);
            if (m_obj.ScreenID == 0)
            {
                EnableMenu(false);
            }

        }
        private void EnableMenu(bool Enable)
        {
            miEdit.IsEnabled = Enable;
            miDelete.IsEnabled = Enable;
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            t_Screen m_obj = (t_Screen)TreeItemRightItem.Tag;
            switch (menuItem.Name)
            {
                case "miAdd":
                    ScreenEdit msadd = new ScreenEdit(m_obj,OpType.Add);
                    msadd.EditComplete += (eee,ee) => {
                        tvScreen.Items.Clear();
                        LoadScrent();
                    };
                    msadd.Show();
                    break;
                case "miEdit":
                    ScreenEdit msadEdit = new ScreenEdit(m_obj, OpType.Alert);
                    TreeViewItem editItem = TreeItemRightItem;
                    msadEdit.EditComplete += (msender, eargs) =>
                    {
                        ScreenEditArgs mobj = (ScreenEditArgs)eargs;
                        editItem.Header = mobj.Screen.ScreenName;
                        editItem.Tag = mobj.Screen;
                    };
                    msadEdit.Show();
                    break;
                case "miDelete":
                    _DataContext.t_Screens.Remove(m_obj);
                    _DataContext.SubmitChanges(SubmitCompleted, TreeItemRightItem);
                    break;
                case "miOpen":
                    ScreenArgs args=new ScreenArgs();
                    args.Screen=m_obj;
                    OnChangeScreen(args);
                    break;
            }
        }

        private void SubmitCompleted(SubmitOperation result)
        {
            if (!result.HasError
                && null != result.UserState)
            {
                TreeViewItem DeleteItem = result.UserState as TreeViewItem;
                if (DeleteItem != null)
                {
                    TreeViewItem mobj = (TreeViewItem)DeleteItem.Parent;
                    mobj.Items.Remove(DeleteItem);
                }
            }
        }

        private void mymenu_Unloaded(object sender, RoutedEventArgs e)
        {
            TreeItemRightItem = null;
        }
        #endregion
        #endregion

        #region 属性

        #endregion

    }
}

