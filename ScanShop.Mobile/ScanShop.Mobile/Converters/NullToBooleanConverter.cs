using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ScanShop.Shared.Dto;
using Xamarin.Forms;

namespace ScanShop.Mobile.Converters
{
    public class NullToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}