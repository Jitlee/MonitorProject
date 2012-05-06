using System.Windows;
using System.Windows.Media;

namespace SL4PopupMenu
{
	//[StyleTypedProperty(Property = "ItemContainerStyle", StyleTargetType = typeof(PopupMenuSeparator))]
	public class PopupMenuSeparator : PopupMenuItem
	{
		public PopupMenuSeparator()
			: base(null, null, true)
		{
			//this.DefaultStyleKey = typeof(PopupMenuSeparator);
			HorizontalSeparatorVisibility = Visibility.Visible;
			IsEnabled = false;
			CloseOnClick = false;

			Color endColor = SeparatorEndColor;
			if (endColor.A + 10 <= 255)
				endColor.A += 10;

			HorizontalSeparatorBrush = PopupMenuUtils.MakeColorGradient(SeparatorStartColor, endColor, 90);
		}
	}
}