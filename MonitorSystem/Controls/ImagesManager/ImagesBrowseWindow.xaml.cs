using System;
using System.Windows;
using System.Windows.Controls;
using MonitorSystem.Web.Servers;

namespace MonitorSystem.Controls.ImagesManager
{
    public partial class ImagesBrowseWindow : ChildWindow
    {
        private Action<FileModel> _callback;
        public ImagesBrowseWindow(Action<FileModel> callback)
        {
            _callback = callback;
            InitializeComponent();
            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, EventArgs e)
        {
            this.Loaded -= OnLoaded;
            this.DataContext = new ImagesBrowseViewModel() { Callback = _callback };
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

