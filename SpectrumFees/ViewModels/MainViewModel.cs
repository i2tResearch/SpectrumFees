using System;
using Xamarin.Forms;
using SpectrumFees.Helpers;

namespace SpectrumFees.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private double _occupancy = 0;
        public double Occupancy
        {
            get => _occupancy;
            set
            {
                _occupancy = value;
                NotifyPropertyChanged();
            }
        }

        private double _cellFactor = 0;
        public double CellFactor
        {
            get => _cellFactor;
            set
            {
                _cellFactor = value;
                NotifyPropertyChanged();
            }
        }

        private double _powerFactor = 0;
        public double PowerFactor
        {
            get => _powerFactor;
            set
            {
                _powerFactor = value;
                NotifyPropertyChanged();
            }
        }

        private double _siteFactor = 0;
        public double SiteFactor
        {
            get => _siteFactor;
            set
            {
                _siteFactor = value;
                NotifyPropertyChanged();
            }
        }

        private double _weightFactor = 0;
        public double WeightFactor
        {
            get => _weightFactor;
            set
            {
                _weightFactor = value;
                NotifyPropertyChanged();
            }
        }

        private double _serviceFactor = 0;
        public double ServiceFactor
        {
            get => _serviceFactor;
            set
            {
                _serviceFactor = value;
                NotifyPropertyChanged();
            }
        }

        private double _directionFactor = 0;
        public double DirectionFactor
        {
            get => _directionFactor;
            set
            {
                _directionFactor = value;
                NotifyPropertyChanged();
            }
        }

        private string _selectedService;
        public string SelectedService
        {
            get => _selectedService;
            set
            {
                _selectedService = value;
                NotifyPropertyChanged();
            }
        }

        public MainViewModel()
        {
            SetServiceCommand = new Command<string>(SetService);
        }

        public Command<string> SetServiceCommand { get; }
        private void SetService(string service)
        {
            Occupancy = 0;
            CellFactor = 0;
            PowerFactor = 0;
            SiteFactor = 0;
            WeightFactor = 0;
            ServiceFactor = 0;
            DirectionFactor = 0;

            SelectedService = service;
        }

        private double GetCongestionFactor() => 0.5 * Math.Exp(2.2 * Occupancy);

        private double GetKp(string service)
        {
            switch (service)
            {
                case Constants.Mobile:
                    return GetKpMobile();
                case Constants.MVDS:
                    return GetKpMVDS();
                case Constants.Broadcast:
                    return GetKpBroadcast();
                case Constants.MWP2P:
                    return GetKpMWP2P();
                case Constants.PMR:
                    return GetKpPMR();
                default:
                    return 0;
            }
        }

        private double GetKpMobile() => CellFactor;
        private double GetKpMVDS() => PowerFactor * SiteFactor;
        private double GetKpBroadcast() => WeightFactor * PowerFactor;
        private double GetKpMWP2P() => ServiceFactor * DirectionFactor;
        private double GetKpPMR()
        {
            return 0;
        }
    }
}
