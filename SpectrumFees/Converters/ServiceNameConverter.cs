using System;
using System.Globalization;
using Xamarin.Forms;
using SpectrumFees.Helpers;

namespace SpectrumFees.Converters
{
    public class ServiceNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var service = (string)value;

            switch (service)
            {
                case Constants.Mobile:
                    return "Móvil";
                case Constants.MVDS:
                    return "MVDS";
                case Constants.Broadcast:
                    return "Radiodifusión (TV y radio FM)";
                case Constants.MWP2P:
                    return "Enlaces de Microondas (P2P)";
                case Constants.PMR:
                    return "Radio Móvil Privada (PMR)";
                default:
                    return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
