using ScanShop.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ScanShop.Mobile.ViewModels
{
    public class QRGenerateViewModel : BaseViewModel
    {
        private string _QRGenValue = "Hello World!";
        private int _QRSize = Convert.ToInt32(Math.Round(DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density * QRSizePercentage / 100));
        private const float QRSizePercentage = 80;

        public Command GoBackCommand { get; }

        public QRGenerateViewModel()
        {
            GoBackCommand = new Command(OnGoBackClicked);
        }

        public string QRGenValue
        {
            get => _QRGenValue;
            set
            {
                if (value == _QRGenValue)
                    return;
                _QRGenValue = value;
                OnPropertyChanged();
            }
        }

        public int QRSize
        {
            get => _QRSize;
            set
            {
                if (value == _QRSize)
                    return;
                _QRSize = value;
                OnPropertyChanged();
            }
        }

        private async void OnGoBackClicked()
        {
            await Shell.Current.GoToAsync("//ProfilePage");
        }
    }
}
