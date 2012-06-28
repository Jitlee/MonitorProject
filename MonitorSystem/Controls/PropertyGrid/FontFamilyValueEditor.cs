

namespace MonitorSystem.Controls
{
    using System.Windows.Controls;
    using System.Windows;

    public class FontFamilyValueEditor : ComboBoxEditorBase
    {
        public FontFamilyValueEditor(PropertyGridLabel label, PropertyItem property)
            : base(label, property)
        {
        }
        public override void InitializeCombo()
        {
            this.LoadItems(new object[] { "隶书", "幼圆", "舒体", "姚体", 
            "楷体", "宋体", "中宋", "仿宋", "彩云", "琥珀", "行楷", "新魏", "细黑"});
        }
    }
}
