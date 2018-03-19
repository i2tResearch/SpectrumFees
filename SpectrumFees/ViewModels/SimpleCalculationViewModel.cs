using System;

namespace SpectrumFees.ViewModels
{
    public class SimpleCalculationViewModel : BindableBase
    {
        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                NotifyPropertyChanged();
            }
        }

        public SimpleCalculationViewModel()
        {
            Text = "Simple calculation";
        }
    }
}
