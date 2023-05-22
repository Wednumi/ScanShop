using ScanShop.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ScanShop.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}