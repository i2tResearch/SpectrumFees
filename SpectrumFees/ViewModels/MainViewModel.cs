using System;
using Xamarin.Forms;
using SpectrumFees.Helpers;

namespace SpectrumFees.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private double? _bandwidth;
        public double? Bandwidth
        {
            get => _bandwidth;
            set
            {
                _bandwidth = value;
                NotifyPropertyChanged();
            }
        }

        private double? _occupancy;
        public double? Occupancy
        {
            get => _occupancy;
            set
            {
                _occupancy = value;
                NotifyPropertyChanged();
            }
        }

        private double? _cellFactor;
        public double? CellFactor
        {
            get => _cellFactor;
            set
            {
                _cellFactor = value;
                NotifyPropertyChanged();
            }
        }

        private double? _powerFactor;
        public double? PowerFactor
        {
            get => _powerFactor;
            set
            {
                _powerFactor = value;
                NotifyPropertyChanged();
            }
        }

        private double? _siteFactor;
        public double? SiteFactor
        {
            get => _siteFactor;
            set
            {
                _siteFactor = value;
                NotifyPropertyChanged();
            }
        }

        private double? _weightFactor;
        public double? WeightFactor
        {
            get => _weightFactor;
            set
            {
                _weightFactor = value;
                NotifyPropertyChanged();
            }
        }

        private double? _serviceFactor;
        public double? ServiceFactor
        {
            get => _serviceFactor;
            set
            {
                _serviceFactor = value;
                NotifyPropertyChanged();
            }
        }

        private double? _directionFactor;
        public double? DirectionFactor
        {
            get => _directionFactor;
            set
            {
                _directionFactor = value;
                NotifyPropertyChanged();
            }
        }

        private double? _fixedPowerFactor;
        public double? FixedPowerFactor
        {
            get => _fixedPowerFactor;
            set
            {
                _fixedPowerFactor = value;
                NotifyPropertyChanged();
            }
        }

        private double? _mobilePowerFactor;
        public double? MobilePowerFactor
        {
            get => _mobilePowerFactor;
            set
            {
                _mobilePowerFactor = value;
                NotifyPropertyChanged();
            }
        }

        private double? _portablePowerFactor;
        public double? PortablePowerFactor
        {
            get => _portablePowerFactor;
            set
            {
                _portablePowerFactor = value;
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

        private double? _result;
        public double? Result
        {
            get => _result;
            set
            {
                _result = value;
                NotifyPropertyChanged();
            }
        }

        public MainViewModel()
        {
            SetServiceCommand = new Command<string>(SetService);
            CalculateResultCommand = new Command(CalculateResult);
        }

        public Command<string> SetServiceCommand { get; }
        private void SetService(string service)
        {
            Bandwidth = null;
            Occupancy = null;
            CellFactor = null;
            PowerFactor = null;
            SiteFactor = null;
            WeightFactor = null;
            ServiceFactor = null;
            DirectionFactor = null;
            FixedPowerFactor = null;
            MobilePowerFactor = null;
            PortablePowerFactor = null;
            Result = null;

            SelectedService = service;
        }

        public Command CalculateResultCommand { get; }
        private void CalculateResult()
        {
            var cin = GetCongestionFactor();
            var bw = Bandwidth ?? 0;
            var kp = GetKp(SelectedService) ?? 0;
            Result = cin * bw * kp;
        }

        private double GetCongestionFactor()
        {
            if (Occupancy != null)
            {
                return 0.5 * Math.Exp(2.2 * (double)Occupancy / 100);
            }

            return 0;
        }

        private double? GetKp(string service)
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

        private double? GetKpMobile() => CellFactor;
        private double? GetKpMVDS() => PowerFactor * SiteFactor;
        private double? GetKpBroadcast() => WeightFactor * PowerFactor;
        private double? GetKpMWP2P() => ServiceFactor * DirectionFactor;
        private double? GetKpPMR() => FixedPowerFactor + MobilePowerFactor + PortablePowerFactor;
    }
}
