using ScanShop.Mobile.Services;
using ScanShop.Mobile.Views;
using ScanShop.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScanShop.Mobile.ViewModels
{
    public class OrdersViewModel : BaseViewModel
    {
        private OrderDto _selectedOrder;

        public ObservableCollection<OrderDto> Orders { get; }
        public ObservableCollection<ProductDto> Products { get; }
        public Command LoadOrdersCommand { get; }
        public Command<OrderDto> OrderTapped { get; }

        public OrdersViewModel()
        {
            Title = "Orders";
            Orders = new ObservableCollection<OrderDto>();
            Products = new ObservableCollection<ProductDto>();
            LoadOrdersCommand = new Command(async () => await ExecuteLoadOrdersCommand());
            OrderTapped = new Command<OrderDto>(OnOrderSelected);
        }

        private async Task ExecuteLoadOrdersCommand()
        {
            IsBusy = true;

            try
            {
                Products.Clear();
                var endpoint = "api/Product/all";
                var products = await GetDtoEnumerable<ProductDto>(endpoint);
                foreach (var product in products)
                {
                    Products.Add(product);
                }

                Orders.Clear();
                endpoint = "api/Order/all-without-checkout";
                var orders = await GetDtoEnumerable<OrderDto>(endpoint);
                foreach (var order in orders)
                {
                    Orders.Add(order);
                }
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

        private async Task<IEnumerable<T>> GetDtoEnumerable<T>(string endpoint)
        {
            var httpClientService =  DependencyService.Get<IHttpClientService>();
            var response = await httpClientService.GetAsync(endpoint);
            return await httpClientService.ReadResponseAsync<IEnumerable<T>>(response);
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedOrderDto = null;
        }

        public OrderDto SelectedOrderDto
        {
            get => _selectedOrder;
            set
            {
                SetProperty(ref _selectedOrder, value);
                OnOrderSelected(value);
            }
        }

        private async void OnOrderSelected(OrderDto order)
        {
            if (order == null)
            {
                return;
            }

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync(
                $"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={order.Id}");
        }
    }
}