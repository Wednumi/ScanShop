using ScanShop.Mobile.Views;
using System;
using Xamarin.Forms;
using ZXing;

namespace ScanShop.Mobile.ViewModels
{
    public class QRScanViewModel : BaseViewModel
    {
        public Command ScanCommand { get; set; }

        public QRScanViewModel()
        {
            ScanCommand = new Command(ProcessScanResult);
        }

        private void ProcessScanResult(object obj)
        {
            if (!(obj is Result result) || !Guid.TryParse(result.Text, out var orderId))
            {
                return;
            }

            Device.BeginInvokeOnMainThread(() =>
                Shell.Current.GoToAsync(
                    $"{nameof(OrderDetailPage)}?{nameof(OrderDetailViewModel.OrderId)}={orderId}"));
        }
    }
}