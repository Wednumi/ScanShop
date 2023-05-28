using ScanShop.Mobile.Services;
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

            var httpClientService = DependencyService.Get<IHttpClientService>();
            httpClientService.InitializeAsync();
            Shell.Current.GoToAsync(httpClientService.IsAuthenticated() ? "//OrdersPage" : "//LoginPage");
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