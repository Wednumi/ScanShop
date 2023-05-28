using ScanShop.Mobile.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ScanShop.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            MainPage = new AppShell();

            if (string.IsNullOrEmpty(SecureStorage.GetAsync("BearerToken").Result))
            {
                Shell.Current.GoToAsync("//LoginPage");
            }
            else
            {
                var bearerToken = SecureStorage.GetAsync("BearerToken");
                var httpClientService = DependencyService.Get<IHttpClientService>();
                httpClientService.SetBearerToken(bearerToken.Result);
                Shell.Current.GoToAsync("//OrdersPage");
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}