using System;
using System.Globalization;
using Xamarin.Forms;

namespace SpectrumFees.Converters
{
    public class StringToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as string;
            if (String.IsNullOrEmpty(strValue))
            {
                return 0;
            }

            double result;
            if (Double.TryParse(strValue, out result))
            {
                return result;
            }

            return 0;
        }
    }
}
