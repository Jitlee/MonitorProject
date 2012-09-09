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
using System.ServiceModel.DomainServices.Client;
using MonitorSystem.Web.Moldes;
using System.Threading;
using MonitorSystem.Controls.ImagesManager;
using MonitorSystem.MonitorSystemGlobal;
using System.Reflection;

namespace MonitorSystem.Controls
{
    public partial class GalleryControl : UserControl
    {
        public GalleryControl()
        {
            InitializeComponent();

            this.Loaded += GalleryControl_Loaded;

            var createCommand = new DelegateCommand<t_Control>(Create);
            GalleryListBox.SetValue(MouseDoubleClick.CommandProperty, createCommand);
        }

        private void GalleryControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadScreen._DataContext.Load(LoadScreen._DataContext.GetT_GalleryClassificationQuery(), GetT_GalleryClassificationQueryCallback, null);
        }

        private void GetT_GalleryClassificationQueryCallback(LoadOperation<t_GalleryClassification> result)
        {
            if (!result.HasError)
            {
                this.GalleryClassificationListBox.ItemsSource = result.Entities;
            }
        }

        private void GalleryClassificationListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GalleryClassificationListBox.SelectedIndex == -1)
            {
                this.GalleryListBox.ItemsSource = null;
                return;
            }
            LoadingBusyIndicator.IsBusy = true;
            var galleryClassification = GalleryClassificationListBox.SelectedItem as t_GalleryClassification;
            if(null != galleryClassification)
            {
                LoadScreen._DataContext.Load(LoadScreen._DataContext.GetT_ControlByTypeQuery(galleryClassification.Id), GetT_ControlByTypeQueryCallback, null);
            }
        }

        private void GetT_ControlByTypeQueryCallback(LoadOperation<t_Control> result)
        {
            LoadingBusyIndicator.IsBusy = false;
            if (!result.HasError)
            {
                //this.GalleryListBox.ItemsSource = result.Entities;
                this.GalleryListBox.Items.Clear();
                foreach (var t in result.Entities)
                {
                    var item = new ListBoxItem();
                    item.DataContext = t;
                    try
                    {
                        if (!string.IsNullOrEmpty(t.ImageURL))
                        {
                            var instance = Activator.CreateInstance(Type.GetType(t.ImageURL));
                            var control = instance as FrameworkElement;
                            if (null != control)
                            {
                                control.Height = 93d;
                                control.Width = 93d;
                                item.Content = control;
                            }
                            else
                            {
                                item.Content = new TextBlock() { Text = t.ControlName, TextTrimming = TextTrimming.WordEllipsis };
                            }
                        }
                        else
                        {
                            item.Content = new TextBlock() { Text = t.ControlName, TextTrimming = TextTrimming.WordEllipsis };
                        }
                    }
                    catch
                    {
                        item.Content = new TextBlock() { Text = t.ControlName, TextTrimming = TextTrimming.WordEllipsis };
                    }
                    item.Height = 100d;
                    item.Width = 100d;
                    this.GalleryListBox.Items.Add(item);
                }
            }
        }

        private void Create(t_Control tControl)
        {
            LoadScreen._instance.CreateControl(tControl, 150, 150, 0, 0);
        }
    }
}
