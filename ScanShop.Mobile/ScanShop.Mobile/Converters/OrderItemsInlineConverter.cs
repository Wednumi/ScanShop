using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ScanShop.Shared.Dto;
using Xamarin.Forms;

namespace ScanShop.Mobile.Converters
{
    public class OrderItemsInlineConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is IEnumerable<OrderItemDto> orderItems && values[1] is IEnumerable<ProductDto> products)
            {
                var matchingProducts = products.Join(
                    orderItems,
                    product => product.Id,
                    orderItem => orderItem.ProductId,
                    (product, orderItem) => product
                );
                return string.Join(", ", matchingProducts.Select(product => product.Title));
            }

            return string.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}