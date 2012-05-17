using System;
using System.Windows;
using System.Windows.Controls;
using MonitorSystem.Web.Servers;

namespace MonitorSystem.Controls.ImagesManager
{
    public partial class ImagesBrowseWindow : ChildWindow
    {
        private Action<FileModel> _callback;
        private string _path;
        public ImagesBrowseWindow(Action<FileModel> callback, string path = "")
        {
            _callback = callback;
            _path = path;
            InitializeComponent();
            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, EventArgs e)
        {
            this.Loaded -= OnLoaded;
            this.DataContext = new ImagesBrowseViewModel(_callback, _path);
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

