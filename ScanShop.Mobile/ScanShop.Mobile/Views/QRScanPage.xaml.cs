using ScanShop.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScanShop.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRScanPage : ContentPage
    {
        public QRScanPage()
        {
            InitializeComponent();
            BindingContext = new QRScanViewModel();
        }
    }
}