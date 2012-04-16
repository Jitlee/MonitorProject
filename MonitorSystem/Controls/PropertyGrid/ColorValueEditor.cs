using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MonitorSystem.Controls
{
    public class ColorValueEditor : ValueEditorBase
    {
        object currentValue;
        ColorPicker _colorPicker = new ColorPicker();

        public ColorValueEditor(PropertyGridLabel label, PropertyItem property)
            : base(label, property)
        {
        
            currentValue = property.Value;
            property.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(property_PropertyChanged);
            property.ValueError += new EventHandler<ExceptionEventArgs>(property_ValueError);

            this.Content = _colorPicker;
            _colorPicker.ColorChanged += colorPicker_ColorChanged;

            if (property.Value is SolidColorBrush)
            {
                _colorPicker.Color = (property.Value as SolidColorBrush).Color;
            }
        }

        void property_ValueError(object sender, ExceptionEventArgs e)
        {
            MessageBox.Show(e.EventException.Message);
        }
        void property_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Value")
            {
                currentValue = this.Property.Value;
                _colorPicker.Color = (this.Property.Value as SolidColorBrush).Color;
            }
        }

        private void colorPicker_ColorChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (_colorPicker != null)
            {
                currentValue = this.Property.Value = new SolidColorBrush(_colorPicker.Color);
            }
        }
    }
}
