﻿using ScanShop.Mobile.Services;
using ScanShop.Shared.Dto;
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
        private bool _isAdmin;
        
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

        public bool IsAdmin
        {
            get => _isAdmin;
            private set => SetProperty(ref _isAdmin, value);
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        private async void OnLogoutClicked()
        {
            SecureStorage.RemoveAll();
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private async Task ExecuteLoadUserInfoCommand()
        {
            IsBusy = true;

            try
            {
                var userService = DependencyService.Get<IUserService>();
                User = await userService.GetCurrentUserAsync();
                IsAdmin = userService.IsAdmin;
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