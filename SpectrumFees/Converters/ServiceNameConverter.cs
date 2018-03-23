using System;
using System.Globalization;
using Xamarin.Forms;

namespace SpectrumFees.Converters
{
    public class ServiceNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? string.Empty : Application.Current.Resources[(string)value];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
