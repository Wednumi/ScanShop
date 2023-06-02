using ScanShop.Mobile.ViewModels;
using Xamarin.Forms;

namespace ScanShop.Mobile.Views
{
    public partial class OrderDetailPage : ContentPage
    {
        public OrderDetailPage()
        {
            InitializeComponent();
            BindingContext = new OrderDetailViewModel();
        }
    }
}