using System;
using System.Globalization;
using System.Linq;
using SpectrumFees.Helpers;
using Xamarin.Forms;

namespace SpectrumFees.Converters
{
    public class ParametersVisibilityConverter : IValueConverter
    {

        private string[] mobile = new string[] { "Occupancy", "CellFactor" };
        private string[] mvds = new string[] { "Occupancy", "PowerFactor", "SiteFactor" };
        private string[] broadcast = new string[] { "Occupancy", "PowerFactor", "WeightFactor" };
        private string[] mwp2p = new string[] { "Occupancy", "ServiceFactor", "DirectionFactor" };
        private string[] pmr = new string[] { };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string service = (string)value;
            string strParam = (string)parameter;
            return GetCompareArray(service).Contains(strParam);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private string[] GetCompareArray(string service)
        {
            switch (service)
            {
                case Constants.Mobile:
                    return mobile;
                case Constants.MVDS:
                    return mvds;
                case Constants.Broadcast:
                    return broadcast;
                case Constants.MWP2P:
                    return mwp2p;
                case Constants.PMR:
                    return pmr;
                default:
                    return new string[] { };
            }
        }
    }
}
