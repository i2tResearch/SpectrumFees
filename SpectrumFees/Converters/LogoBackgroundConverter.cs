using System;
using System.Globalization;
using Xamarin.Forms;

namespace SpectrumFees.Converters
{
    public class LogoBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = value == parameter ? "OrangeColor" : "GrayColor";
            return Application.Current.Resources[color];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
