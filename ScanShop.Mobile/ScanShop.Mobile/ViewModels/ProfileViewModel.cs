using ScanShop.Mobile.Services;
using ScanShop.Shared.Dto.User;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ScanShop.Mobile.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private UserDto _user;

        public Command LogoutCommand { get; }
        public Command LoadUserInfoCommand { get; }

        public ProfileViewModel()
        {
            LogoutCommand = new Command(OnLogoutClicked);
            LoadUserInfoCommand = new Command(async () => await ExecuteLoadUserInfoCommand());
        }

        public UserDto User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        private async void OnLogoutClicked()
        {
            SecureStorage.Remove("BearerToken");
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private async Task ExecuteLoadUserInfoCommand()
        {
            IsBusy = true;

            try
            {
                var userService = DependencyService.Get<IUserService>();
                User = await userService.GetCurrentUserAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}