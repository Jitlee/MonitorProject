﻿using System;
using System.ComponentModel;
using System.Globalization;

namespace MonitorSystem.Controls.Converters
{
	public class BooleanConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return ((sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType));
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				string str = ((string)value).Trim();
				try
				{
					return Common.ConvertToBool(str);
				}
				catch (FormatException exception)
				{
					throw new FormatException(string.Format("Unable to convert {0} - {1}", (string)value, "Boolean"), exception);
				}
			}
			return base.ConvertFrom(context, culture, value);
		}
	}
}
