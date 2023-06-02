using ScanShop.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace ScanShop.Mobile.Converters
{
    public class OrderItemProduct
    {
        public ProductDto Product { get; set; }
        public float Amount { get; set; }
    }

    public class OrderItemsListConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is IEnumerable<OrderItemDto> orderItems && values[1] is IEnumerable<ProductDto> products)
            {
                var orderItemDetails = orderItems.Join(
                    products,
                    orderItem => orderItem.ProductId,
                    product => product.Id,
                    (orderItem, product) => new OrderItemProduct
                    {
                        Product = product,
                        Amount = orderItem.Amount
                    }
                );
            
                return orderItemDetails.ToList();
            }

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}