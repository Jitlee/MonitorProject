﻿using System;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using MonitorSystem.Controls.ImagesManager;
using MonitorSystem.Gallery;
using MonitorSystem.MonitorSystemGlobal;
using MonitorSystem.Web.Moldes;

namespace MonitorSystem.Controls
{
    public partial class GalleryControl : UserControl
    {
        public static GalleryControl Instance { get; private set; }
        public GalleryControl()
        {
            InitializeComponent();

            this.Loaded += GalleryControl_Loaded;

            var createCommand = new DelegateCommand<t_Control>(Create);
            GalleryListBox.SetValue(MouseDoubleClick.CommandProperty, createCommand);
            Instance = this;
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

                var pointer = new Pointer();
                pointer.Height = 93d;
                pointer.Width = 93d;
                this.GalleryListBox.Items.Add(new ListBoxItem() { Content= pointer, Height = 100d, Width= 100d });

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
            if (null != tControl)
            {
                LoadScreen._instance.CreateControl(LoadScreen._instance.csScreen, tControl, 150, 150, 0, 0);
            }
        }

        private void GalleryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GalleryListBox.SelectedIndex < 1)
            {
                LoadScreen.UnAddElementModel();
            }
            else
            {
                PropertyMain.Instance.ResetSelected();
                LoadScreen.AddElementModel();
            }
        }

        public t_Control GetSelected()
        {
            return (GalleryListBox.SelectedItem as ListBoxItem).DataContext as t_Control;
        }

        public void ResetSelected()
        {
            if (GalleryListBox.Items.Count > 0)
            {
                GalleryListBox.SelectedIndex = 0;
            }
        }
    }
}
