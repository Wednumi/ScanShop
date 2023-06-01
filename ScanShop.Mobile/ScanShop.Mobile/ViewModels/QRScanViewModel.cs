using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZXing;

namespace ScanShop.Mobile.ViewModels
{
    public class QRScanViewModel : BaseViewModel
    {
        public Command ScanCommand { get; set; }

        private string _QRScanText = "Scan the QR code";

        public QRScanViewModel()
        {
            ScanCommand = new Command(ProcessScanResult);
        }

        public string QRScanText
        {
            get => _QRScanText;
            set
            {
                if (value == _QRScanText)
                    return;
                _QRScanText = value;
                OnPropertyChanged();
            }
        }

        private void ProcessScanResult(object obj)
        {
            var result = obj as ZXing.Result;
            QRScanText = result?.Text ?? string.Empty;
        }
    }
}