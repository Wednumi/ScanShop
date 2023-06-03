using ScanShop.Mobile.Views;
using Xamarin.Forms;

namespace ScanShop.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(OrderDetailPage), typeof(OrderDetailPage));
            Routing.RegisterRoute(nameof(QRGeneratePage), typeof(QRGeneratePage));
            Routing.RegisterRoute(nameof(QRScanPage), typeof(QRScanPage));
        }
    }
}
