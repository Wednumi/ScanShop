using ScanShop.Mobile.Services;
using ScanShop.Mobile.Views;
using ScanShop.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace ScanShop.Mobile.ViewModels
{
    [QueryProperty(nameof(OrderId), nameof(OrderId))]
    public class OrderDetailViewModel : BaseViewModel
    {
        private string _orderId;
        private OrderDto _order;
        private bool _isAdmin;

        public Command GoToQRGenCommand { get; }
        public Command MarkAsPackedCommand { get; }

        public OrderDetailViewModel()
        {
            GoToQRGenCommand = new Command(OnGoToQRGenClicked);
            MarkAsPackedCommand = new Command(OnMarkAsPackedClicked);
            Title = "Order Details";
            Products = new ObservableCollection<ProductDto>();
        }

        public string OrderId
        {
            get => _orderId;
            set
            {
                _orderId = value;
                LoadOrder(value);
            }
        }

        public bool IsAdmin
        {
            get => _isAdmin;
            private set => SetProperty(ref _isAdmin, value);
        }

        public OrderDto Order
        {
            get => _order;
            set => SetProperty(ref _order, value);
        }

        public ObservableCollection<ProductDto> Products { get; set; }

        public async void LoadOrder(string orderId)
        {
            try
            {
                var userService = DependencyService.Get<IUserService>();
                IsAdmin = userService.IsAdmin;

                var httpClientService =  DependencyService.Get<IHttpClientService>();

                Products.Clear();
                var endpoint = "api/Product/all";
                var products = await httpClientService.GetFromJsonAsync<IEnumerable<ProductDto>>(endpoint);
                foreach (var product in products)
                {
                    Products.Add(product);
                }

                endpoint = "api/Order/by-id";
                Order = await httpClientService.GetFromJsonAsync<OrderDto>(endpoint, "id=" + orderId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async void OnGoToQRGenClicked()
        {
            await Shell.Current.GoToAsync(
                $"{nameof(QRGeneratePage)}?{nameof(QRGenerateViewModel.QRGenValue)}={OrderId}");
        }

        private async void OnMarkAsPackedClicked()
        {
            try
            {
                var httpClientService = DependencyService.Get<IHttpClientService>();
                var endpoint = "api/Order/pack";
                await httpClientService.PutAsync(endpoint, "id=" + OrderId);
                await Application.Current.MainPage.DisplayAlert("Order packing", "The order is marked as packed successfully!", "OK");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Order not packed", "There was an error with processing the order.", "OK");
            }
        }
    }
}
