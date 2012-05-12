﻿
namespace MonitorSystem.Controls
{
	#region Using Directives
	using System;
	using System.ComponentModel;
	using System.Linq;
	using System.Reflection;
	using MonitorSystem.Controls.Converters;
	#endregion

	#region PropertyItem
	/// <summary>
	/// PropertyItem hold a reference to an individual property in the propertygrid
	/// </summary>
	public sealed class PropertyItem : INotifyPropertyChanged
	{
		#region Events
		/// <summary>
		/// Event raised when an error is encountered attempting to set the Value
		/// </summary>
		public event EventHandler<ExceptionEventArgs> ValueError;
		/// <summary>
		/// Raises the ValueError event
		/// </summary>
		/// <param name="ex">The exception</param>
		private void OnValueError(Exception ex)
		{
			if (null != ValueError)
				ValueError(this, new ExceptionEventArgs(ex));
		}
		#endregion

		#region Fields
		private PropertyInfo _propertyInfo;
		private object _instance;
		private bool _readOnly = false;
		#endregion

		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="instance"></param>
		/// <param name="property"></param>
		public PropertyItem(object instance, object value, PropertyInfo property, bool readOnly)
		{
			_instance = instance;
			_propertyInfo = property;
			_value = value;
			_readOnly = readOnly;

			if (instance is INotifyPropertyChanged)
				((INotifyPropertyChanged)instance).PropertyChanged += new PropertyChangedEventHandler(PropertyItem_PropertyChanged);
		}

		void PropertyItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == this.Name)
				Value = _propertyInfo.GetValue(_instance, null);
		}
		#endregion

		#region Properties

		public string Name
		{
			get { return _propertyInfo.Name; }
		}

		public string DisplayName
		{
			get
			{
				if (string.IsNullOrEmpty(_displayName))
				{
					DisplayNameAttribute attr = GetAttribute<DisplayNameAttribute>(_propertyInfo);
					_displayName = (attr != null) ? attr.DisplayName : Name;
				}

				return _displayName;
			}
		} private string _displayName;

        public string Description
        {
            get
            {
                if (string.IsNullOrEmpty(_description))
                {
                    DescriptionAttribute attr = GetAttribute<DescriptionAttribute>(_propertyInfo);
                    _description = (attr != null) ? attr.Description : Name;
                }

                return _description;
            }
        } private string _description;

		public string Category
		{
			get
			{
				if (string.IsNullOrEmpty(_category))
				{
					CategoryAttribute attr = GetAttribute<CategoryAttribute>(_propertyInfo);
                    if (attr != null && !string.IsNullOrEmpty(attr.Category))
                        _category = attr.Category;
                    // Modify by AB in 2012-04-15
                    else if (new[] { "Width", "Height", "Left", "Top" }.Contains(_propertyInfo.Name))
                        _category = "布局";
                    else if (new[] { "FontFamily", "FontSize", "Foreground" }.Contains(_propertyInfo.Name))
                        _category = "外观";
                    else
                        _category = "杂项";
                    // end modify
				}
				return this._category;
			}
		} private string _category;

		public object Value
		{
			get { return _value; }
			set
			{
				if (_value == value) return;
				object originalValue = _value;
				_value = value;
				try
				{
					Type propertyType = this._propertyInfo.PropertyType;
					if (((propertyType == typeof(object)) || ((value == null) && propertyType.IsClass)) || ((value != null) && propertyType.IsAssignableFrom(value.GetType())))
					{
						_propertyInfo.SetValue(_instance, value, (BindingFlags.NonPublic | BindingFlags.Public), null, null, null);
						OnPropertyChanged("Value");
					}
					else
					{
						try
						{
							if (propertyType.IsEnum)
							{
								object val = Enum.Parse(_propertyInfo.PropertyType, value.ToString(), false);
								_propertyInfo.SetValue(_instance, val, (BindingFlags.NonPublic | BindingFlags.Public), null, null, null);
								OnPropertyChanged("Value");
							}
							else
							{
								TypeConverter tc = TypeConverterHelper.GetConverter(propertyType);
								if (tc != null)
								{
									object convertedValue = tc.ConvertFrom(value);
									_propertyInfo.SetValue(_instance, convertedValue, null);
									OnPropertyChanged("Value");
								}
								else
								{
									// try direct setting as a string...
									_propertyInfo.SetValue(_instance, value.ToString(), (BindingFlags.NonPublic | BindingFlags.Public), null, null, null);
									OnPropertyChanged("Value");
								}
							}
						}
						catch (Exception ex)
						{
							_value = originalValue;
							OnPropertyChanged("Value");
							OnValueError(ex);
						}
					}
				}
				catch (MethodAccessException mex)
				{
					_value = originalValue;
					_readOnly = true;
					OnPropertyChanged("Value");
					OnPropertyChanged("CanWrite");
					OnValueError(mex);
				}
			}
		} private object _value;

		public Type PropertyType
		{
			get { return _propertyInfo.PropertyType; }
		}

		public bool CanWrite
		{
			get { return _propertyInfo.CanWrite && !_readOnly; }
		}

		public bool ReadOnly
		{
			get { return _readOnly; }
			internal set { _readOnly = value; }
		}

		#endregion

		#region Helpers
		public static T GetAttribute<T>(PropertyInfo propertyInfo)
		{
			var attributes = propertyInfo.GetCustomAttributes(typeof(T), true);
			return (attributes.Length > 0) ? attributes.OfType<T>().First() : default(T);
		}
		public T GetAttribute<T>()
		{
			return GetAttribute<T>(_propertyInfo);
		}
		#endregion

		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			if (string.IsNullOrEmpty(propertyName)) throw new ArgumentNullException("propertyName");
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion
	}
	#endregion
}
