using System;
using System.Globalization;
using Xamarin.Forms;
using SpectrumFees.Helpers;

namespace SpectrumFees.Converters
{
    public class ParametersVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ParametersVisibilityHelper.ShouldBeVisible(value as string, parameter as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
