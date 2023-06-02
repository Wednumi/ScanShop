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
        }
    }
}
