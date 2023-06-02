using ScanShop.Mobile.Services;
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
        
        public OrderDetailViewModel()
        {
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
    }
}
