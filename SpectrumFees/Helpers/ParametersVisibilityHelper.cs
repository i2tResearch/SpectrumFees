using System;
using System.Linq;

namespace SpectrumFees.Helpers
{
    public class ParametersVisibilityHelper
    {
        private static string[] mobileParameters = new string[] { "Occupancy", "CellFactor" };
        private static string[] mvdsParameters = new string[] { "Occupancy", "PowerFactor", "SiteFactor" };
        private static string[] broadcastParameters = new string[] { "Occupancy", "PowerFactor", "WeightFactor" };
        private static string[] mwp2pParameters = new string[] { "Occupancy", "ServiceFactor", "DirectionFactor" };
        private static string[] pmrParameters = new string[] { };

        private static string[] GetCompareArray(string service)
        {
            switch (service)
            {
                case Constants.Mobile:
                    return mobileParameters;
                case Constants.MVDS:
                    return mvdsParameters;
                case Constants.Broadcast:
                    return broadcastParameters;
                case Constants.MWP2P:
                    return mwp2pParameters;
                case Constants.PMR:
                    return pmrParameters;
                default:
                    return new string[] { };
            }
        }

        public static bool ShouldBeVisible(string service, string parameter)
        {
            return GetCompareArray(service).Contains(parameter);
        }
    }
}
