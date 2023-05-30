using ScanShop.Mobile.Services;
using ScanShop.Shared.Dto.Account;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ScanShop.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private string _email;

        public string Email
        {
            get => _email;

            set
            {
                if (_email == value) return;

                _email = value;
                OnPropertyChanged();
            }
        }

        private string _password;

        public string Password
        {
            get => _password;

            set
            {
                if (_password == value) return;

                _password = value;
                OnPropertyChanged();
            }
        }

        private async void OnLoginClicked(object obj)
        {
            var jwtToken = await AuthenticateAndGetJwtToken(Email, Password);

            if (jwtToken != null)
            {
                var userId = jwtToken.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var bearerToken = jwtToken.RawData;
                await SecureStorage.SetAsync("UserId", userId);
                await SecureStorage.SetAsync("BearerToken", bearerToken);
                var httpClientService = DependencyService.Get<IHttpClientService>();
                await httpClientService.InitializeAsync();
                await Shell.Current.GoToAsync("//OrdersPage");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Authentication Failed", "Invalid username or password",
                    "OK");
            }
        }

        private async Task<JwtSecurityToken> AuthenticateAndGetJwtToken(string email, string password)
        {
            var signInCommand = new SignInCommandDto
            {
                Email = email,
                Password = password
            };

            try
            {
                var httpClientService = DependencyService.Get<IHttpClientService>();
                var endpoint = "api/Account/sign-in";
                var response = await httpClientService.PostAsync(endpoint, signInCommand);
                var responseContent = await httpClientService.ReadResponseAsync<string>(response);
                var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(responseContent);
                return jwtToken;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}