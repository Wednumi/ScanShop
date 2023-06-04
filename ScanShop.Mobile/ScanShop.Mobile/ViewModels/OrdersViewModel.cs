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
                var httpClientService =  DependencyService.Get<IHttpClientService>();
                var userService =  DependencyService.Get<IUserService>();

                Products.Clear();
                var endpoint = "api/Product/all";
                var products = await httpClientService.GetFromJsonAsync<IEnumerable<ProductDto>>(endpoint);
                foreach (var product in products)
                {
                    Products.Add(product);
                }

                Orders.Clear();
                endpoint = userService.IsAdmin ? "api/Order/all-without-checkout" : "api/Order/user-orders";
                var orders = await httpClientService.GetFromJsonAsync<IEnumerable<OrderDto>>(endpoint);
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

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedOrder = null;
        }

        public OrderDto SelectedOrder
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

            await Shell.Current.GoToAsync(
                $"{nameof(OrderDetailPage)}?{nameof(OrderDetailViewModel.OrderId)}={order.Id}");
        }
    }
}