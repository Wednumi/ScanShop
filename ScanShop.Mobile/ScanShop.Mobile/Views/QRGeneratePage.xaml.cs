using ScanShop.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScanShop.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRGeneratePage : ContentPage
    {
        public QRGeneratePage()
        {
            InitializeComponent();
            BindingContext = new QRGenerateViewModel();
        }
    }
}