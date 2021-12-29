using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Tumblro
{
    class StringGMTToLocalConverter:IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return DateTime.Parse((string)value).ToLocalTime();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}
