

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
            this.LoadItems(new object[] { "宋体", "楷体", "黑体", "仿宋", "微软正黑体", "细明体", "微软雅黑" });
        }
    }
}
