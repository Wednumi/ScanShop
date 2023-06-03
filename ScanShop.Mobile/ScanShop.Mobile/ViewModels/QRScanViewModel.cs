using ScanShop.Mobile.Services;
using System;
using Xamarin.Forms;
using ZXing;

namespace ScanShop.Mobile.ViewModels
{
    public class QRScanViewModel : BaseViewModel
    {
        private bool _isScanning;
        public Command ScanCommand { get; set; }

        public QRScanViewModel()
        {
            _isScanning = true;
            ScanCommand = new Command(ProcessScanResult);
        }

        public bool IsScanning
        {
            get => _isScanning;
            set => SetProperty(ref _isScanning, value);
        }

        private async void ProcessScanResult(object obj)
        {
            if (!(obj is Result result) || !Guid.TryParse(result.Text, out var orderId))
            {
                return;
            }

            IsScanning = false;

            try
            {
                var httpClientService = DependencyService.Get<IHttpClientService>();
                var endpoint = $"api/Order/checkout?id={orderId}";
                await httpClientService.PutAsync(endpoint, string.Empty);
                Device.BeginInvokeOnMainThread(async () => 
                    await Application.Current.MainPage.DisplayAlert("QR scan successful",
                    "The order is checked out successfully.", "OK"));
            }
            catch (Exception)
            {
                Device.BeginInvokeOnMainThread(async () => 
                    await Application.Current.MainPage.DisplayAlert("QR scan failed",
                    "There was an error with processing the QR-code.", "OK"));
            }
            finally
            {
                IsScanning = true;
            }
        }
    }
}