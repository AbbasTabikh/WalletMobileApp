using EwalletMobileApp.Enums;
using System.Globalization;

namespace EwalletMobileApp.Converters
{
    internal class EnumToStringConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value?.ToString();
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is null)
                return Category.Other;

            return Enum.Parse(targetType, value.ToString());
        }
    }
}
