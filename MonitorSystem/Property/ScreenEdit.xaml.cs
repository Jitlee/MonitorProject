using System;
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
using MonitorSystem.Web.Moldes;
using MonitorSystem.Web.Servers;
using System.ServiceModel.DomainServices.Client;
using MonitorSystem.Controls.ImagesManager;

namespace MonitorSystem.Property
{
    
    public class ScreenEditArgs : EventArgs
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

        OpType _Ptype;
        /// <summary>
        /// 操作类型
        /// </summary>
        public OpType Ptype
        {
            get { return _Ptype; }
            set { _Ptype = value; }
        }
    }



    public partial class ScreenEdit : ChildWindow, IEditBase
    {

        MonitorServers _DataContext = LoadScreen._DataContext;
        CV _DataCV = LoadScreen._DataCV;

        #region 事件
        /// <summary>
        /// 编辑完成事件
        /// </summary>
        public event EventHandler EditComplete;
        protected virtual void OnShapeChanged(ScreenEditArgs e)
        {
            if (EditComplete != null)
            {
                EditComplete(this, e);
            }
        }
        #endregion
        #region 变量
        /// <summary>
        /// 添加时，表示父对象
        /// 修改时表示当前对象 
        /// </summary>
        t_Screen Scree;
        OpType optype;
        #endregion
        public ScreenEdit(t_Screen t_Scr, OpType moptype)
        {
            InitializeComponent();

            Scree = t_Scr;
            if (moptype == OpType.Alert)
            {
                txtName.Text = t_Scr.ScreenName;
                txtImage.Text = t_Scr.ImageURL;
            }
            optype = moptype;
            BindSite();
            
        }
       
       

        private void BindSite()
        {
            _DataCV.Load(_DataCV.GetT_StationQuery(), LoadStationCompleted 
                , null);
            
        }

        private void LoadStationCompleted(LoadOperation<t_Station> result)
        {
            if (result.HasError)
            {
                MessageBox.Show("加载数据出错！");
                return;
            }
            //comboBox1.ItemsSource = result.Entities;
            foreach (t_Station ts in result.Entities)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = ts.StationName;
                item.Tag = ts.StationID;
                if (optype ==OpType.Alert && Scree.StationID == ts.StationID)
                    item.IsSelected = true;
                cbScreen.Items.Add(item);
            }
        }
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (cbScreen.SelectedItem == null)
            {
                MessageBox.Show("请选择站点！");
                return;
            }
            if (optype == OpType.Add)
            {
                t_Screen mobj = new t_Screen();
                mobj.ScreenName = txtName.Text;
                mobj.ImageURL = txtImage.Text;
                mobj.StationID = int.Parse(((ComboBoxItem)cbScreen.SelectedItem).Tag.ToString());
                mobj.ParentScreenID = Scree.ScreenID;

                _DataContext.t_Screens.Add(mobj);
                _DataContext.SubmitChanges(SubmitCompleted, mobj);
            }
            else
            {
                _DataContext.Load(_DataContext.GetT_ScreenQuery().Where(a=>a.ScreenID ==Scree.ScreenID), 
                    LoadScreenComplete, null);
            }
           // this.DialogResult = true;
        }
        private void SubmitCompleted(SubmitOperation result)
        {
            if (result.HasError)
            {
                MessageBox.Show(result.Error.Message,"出错啦！",MessageBoxButton.OK);
                return;
            }
            if (result.UserState == null)
            {
                MessageBox.Show(result.Error.Message, "程序未知异常！", MessageBoxButton.OK);
                return;
            }
            ScreenEditArgs e = new ScreenEditArgs();
            e.Ptype = optype;
            e.Screen =(t_Screen)result.UserState;
            OnShapeChanged( e);

            this.DialogResult = true;
        }

        private void LoadScreenComplete(LoadOperation<t_Screen> Result)
        {
            if (Result.HasError)
            {
                MessageBox.Show(Result.Error.Message);
                return;
            }

            t_Screen mobj = Result.Entities.First();
            mobj.ScreenName = txtName.Text;
            mobj.ImageURL = txtImage.Text;
            mobj.StationID = int.Parse(((ComboBoxItem)cbScreen.SelectedItem).Tag.ToString());
            _DataContext.SubmitChanges(SubmitCompleted, mobj);
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void BrowseImage_Click(object sender, RoutedEventArgs e)
        {
            new ImagesBrowseWindow(ImageSelection_Changed, "ImageMap", true).Show();
        }

        private void ImageSelection_Changed(FileModel file)
        {
            txtImage.Text = file.Name;
        }
    }
}

