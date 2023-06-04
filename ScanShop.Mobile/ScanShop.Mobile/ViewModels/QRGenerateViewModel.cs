using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ScanShop.Mobile.ViewModels
{
    [QueryProperty(nameof(QRGenValue), nameof(QRGenValue))]
    public class QRGenerateViewModel : BaseViewModel
    {
        private string _qrGenValue;
        private int _qrSize;
        private const double QrSizePercentage = 80;

        public Command GoBackCommand { get; }

        public QRGenerateViewModel()
        {
            GoBackCommand = new Command(OnGoBackClicked);
            var pageWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
            var qrSizeFraction = QrSizePercentage / 100;
            _qrSize = Convert.ToInt32(Math.Round(pageWidth * qrSizeFraction));
        }

        public string QRGenValue
        {
            get => _qrGenValue;
            set
            {
                if (value == _qrGenValue)
                {
                    return;
                }
                _qrGenValue = value;
                OnPropertyChanged();
            }
        }

        public int QRSize
        {
            get => _qrSize;
            set
            {
                if (value == _qrSize)
                {
                    return;
                }
                _qrSize = value;
                OnPropertyChanged();
            }
        }

        private async void OnGoBackClicked()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
