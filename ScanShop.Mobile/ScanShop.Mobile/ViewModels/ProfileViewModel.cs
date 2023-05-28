using Xamarin.Essentials;
using Xamarin.Forms;

namespace ScanShop.Mobile.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public Command LogoutCommand { get; }

        public ProfileViewModel()
        {
            LogoutCommand = new Command(OnLogoutClicked);
        }

        private async void OnLogoutClicked(object obj)
        {
            SecureStorage.Remove("BearerToken");
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}