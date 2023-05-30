using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ScanShop.Mobile.Services;
using ScanShop.Shared.Dto.User;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ScanShop.Mobile.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public UserDto User { get; set; }
        public Command LogoutCommand { get; }
        public Command LoadUserInfoCommand { get; }

        public ProfileViewModel()
        {
            LogoutCommand = new Command(OnLogoutClicked);
            LoadUserInfoCommand = new Command(async () => await ExecuteLoadUserInfoCommand());
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
                User = await GetUserInfoAsync();
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

        private async Task<UserDto> GetUserInfoAsync()
        {
            var getUserInfoQuery = new GetUserInfoQueryDto
            {
                UserId = Guid.Parse(await SecureStorage.GetAsync("UserId"))
            };
            var httpClientService = DependencyService.Get<IHttpClientService>();
            var endpoint = "api/User/info";
            var response = await httpClientService.PostAsync(endpoint, getUserInfoQuery);
            return await httpClientService.ReadResponseAsync<UserDto>(response);
        }
    }
}