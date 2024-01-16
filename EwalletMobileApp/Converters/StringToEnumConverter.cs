using EwalletMobileApp.Enums;
using System.Globalization;

namespace EwalletMobileApp.Converters
{
    public class StringToEnumConverter : IValueConverter
    {
        //from object to UI
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var categoryValue = (Category?)value;

            if (categoryValue is null)
            {
                return "Other";
            }

            return categoryValue switch
            {
                Category.Food => "Food",
                Category.Shopping => "Shopping",
                Category.Transportation => "Transportation",
                Category.Entertainment => "Entertainment",
                Category.Travel => "Travel",
                Category.Savings => "Savings",
                Category.Health => "Health",
                Category.Housing => "Housing",
                Category.Education => "Education",
                Category.Utilities => "Utilities",
                Category.Other => "Other",
                _ => "Other",
            };

        }

        //from UI to object
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var stringValue = (string?)value;

            if (string.IsNullOrEmpty(stringValue))
            {
                return Category.Other;
            }

            return stringValue switch
            {
                "Food" => Category.Food,
                "Shopping" => Category.Shopping,
                "Transportation" => Category.Transportation,
                "Entertainment" => Category.Entertainment,
                "Travel" => Category.Travel,
                "Savings" => Category.Savings,
                "Health" => Category.Health,
                "Housing" => Category.Housing,
                "Education" => Category.Education,
                "Utilities" => Category.Utilities,
                "Other" => Category.Other,
                _ => Category.Other,
            };

        }
    }
}
