using ScanShop.Mobile.ViewModels;
using Xamarin.Forms;

namespace ScanShop.Mobile.Views
{
    public partial class OrdersPage : ContentPage
    {
        OrdersViewModel _viewModel;

        public OrdersPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new OrdersViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}