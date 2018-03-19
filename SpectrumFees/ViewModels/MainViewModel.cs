using System;
using Xamarin.Forms;
using SpectrumFees.Pages;

namespace SpectrumFees.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private SimpleCalculationViewModel _simpleCalculation;
        public SimpleCalculationViewModel SimpleCalculation
        {
            get => _simpleCalculation;
            set
            {
                _simpleCalculation = value;
                NotifyPropertyChanged();
            }
        }

        private bool _busy;
        public bool Busy
        {
            get => _busy;
            set
            {
                _busy = value;
                NotifyPropertyChanged();
                DoSimpleCalculationCommand.ChangeCanExecute();
            }
        }

        public MainViewModel()
        {
            DoSimpleCalculationCommand = new Command(DoSimpleCalculation, () => !Busy);
        }

        public Command DoSimpleCalculationCommand { get; }
        private async void DoSimpleCalculation()
        {
            Busy = true;
            FreeResources();
            SimpleCalculation = new SimpleCalculationViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new SimpleCalculationPage());
            Busy = false;
        }

        private void FreeResources()
        {
            SimpleCalculation = null;
        }
    }
}
