﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MonitorSystem.Controls;
using MonitorSystem.Property;
using MonitorSystem.Web.Moldes;
using MonitorSystem.Web.Servers;

namespace MonitorSystem
{
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
            ListBox listBox = null;
            if (accordion.SelectedIndex == 0)
            {
                listBox = tpListBox;
            }
            else if (accordion.SelectedIndex == 1)
            {
                listBox = ztListBox;
            }
            else if (accordion.SelectedIndex == 2)
            {
                listBox = ggListBox;
            }
            if (null != listBox && listBox.SelectedIndex > 0)
            {
                return listBox.SelectedItem as t_Control;
            }
            return null;
        }

        public void ResetSelected()
        {
            if (null != tpListBox && tpListBox.Items.Count > 0)
            {
                tpListBox.SelectedIndex = 0;
            }
            if (null != ztListBox && ztListBox.Items.Count > 0)
            {
                ztListBox.SelectedIndex = 0;
            }
            if (null != ggListBox && ggListBox.Items.Count > 0)
            {
                ggListBox.SelectedIndex = 0;
            }
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
            var tp =  results.Entities.Where(t => t.ControlType == 1).ToList();
            tp.Insert(0, new t_Control() { ControlID = -1, ControlCaption = "指针", ControlName = "指针", ImageURL = "point.jpg" });
            tpListBox.ItemsSource = tp;
            tpListBox.SelectedIndex = 0;

            var zt = results.Entities.Where(t => t.ControlType == 2).ToList();
            zt.Insert(0, new t_Control() { ControlID = -1, ControlCaption = "指针", ControlName = "指针", ImageURL = "point.jpg" });
            ztListBox.ItemsSource = zt;
            ztListBox.SelectedIndex = 0;

            var gg = results.Entities.Where(t => t.ControlType == 3).ToList();
            gg.Insert(0, new t_Control() { ControlID = -1, ControlCaption = "指针", ControlName = "指针", ImageURL = "point.jpg" });
            ggListBox.ItemsSource = gg;
            ggListBox.SelectedIndex = 0;

        }
        #endregion

        public void ChangeSize(double Height, double Width)
        {
        }

        #region 场景
        #region 加载场景
        private void LoadScrent()
        {
            _DataContext.Load(_DataContext.GetT_ScreenQuery(), DataLoadComplet, null);
        }
        public static List<t_Screen> listScreen = new List<t_Screen>();
        /// <summary>
        /// 加载场景,完成后，加载控件
        /// </summary>
        /// <param name="results"></param>
        private void DataLoadComplet(LoadOperation<t_Screen> results)
        {
            if (results.HasError)
            {                
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
            miDelete.Visibility = Visibility.Visible;           
            if (SelectItem.Items.Count >0)
            {                
                miDelete.Visibility = Visibility.Collapsed;               
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
                        LoadScreen._instance.InitScreenList();
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

                        LoadScreen._instance.SetScreenImg(mobj.Screen);
                        //修改DataContext
                       var v= LoadScreen._DataContext.t_Screens.Where(a => a.ScreenID== mobj.Screen.ScreenID);

                       if (v.Count() > 0)
                       {
                           t_Screen m_screen = v.First();
                           m_screen.ImageURL = mobj.Screen.ImageURL;
                           m_screen.ScreenID = mobj.Screen.ScreenID;
                           m_screen.ScreenName = mobj.Screen.ScreenName;
                       }
                       LoadScreen._instance.InitScreenList();
                    };
                    msadEdit.Show();
                    break;
                case "miDelete":
                    if (LoadScreen._instance.MainPage == m_obj)
                    {
                        MessageBox.Show("不能删除默认场景，请先设置其他场景为默认场景后再来删除!");
                    }
                    else
                    {
                        _DataContext.t_Screens.Remove(m_obj);
                        _DataContext.SubmitChanges(SubmitCompleted, TreeItemRightItem);
                    }
                    break;
                case "miOpen":
                    LoadScreen.Load(m_obj);
                    //ScreenArgs args=new ScreenArgs();
                    //args.Screen=m_obj;
                    //OnChangeScreen(args);
                    break;
                case "miCopy":
                    ScreenCopy m_Copy = new ScreenCopy();
                    m_Copy.oldScreen = m_obj;
                    m_Copy.Show();
                    break;
                case "miSetDeftult":
                    LoadScreen._DataContext.t_MonitorSystemParams.First().StartScreenID = m_obj.ScreenID;
                    LoadScreen._DataContext.SubmitChanges();
                    break;
            }
        }

        private void SetDefultScreen()
        {
           
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

                LoadScreen._instance.InitScreenList();

                LoadScreen.Load(LoadScreen._instance.MainPage);
                //LoadScreen._instance.AllSencesMenuScriptItem.Items.Remove(
            }
        }

        private void mymenu_Unloaded(object sender, RoutedEventArgs e)
        {
            TreeItemRightItem = null;
        }
        #endregion


        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.Parent is FloatPanel)
            {
                (this.Parent as FloatPanel).Title = (tabControl1.SelectedItem as TabItem).Header.ToString();
            }
            ResetSelected();
        }
        #endregion

        private void Control_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListBox).SelectedIndex < 1)
            {
                LoadScreen._instance.UnAddElementModel();
            }
            else
            {
                GalleryControl.Instance.ResetSelected();
                LoadScreen._instance.AddElementModel();
            }
        }
    }


    public class ScreenArgs : EventArgs
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

   

}

