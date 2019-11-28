using System;
using System.Globalization;
using Xamarin.Forms;

namespace cityguide.Converters
{
    public class ButtonSetConverter : IValueConverter
    {
        public ButtonSetConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            bool? item = (bool?)value;

            switch(value)
            {
                case true:
                    return (Color)Application.Current.Resources["HotOrange"];
                case false:
                    return (Color)Application.Current.Resources["AzureBlue"];
                default:
                    return (Color)Application.Current.Resources["AzureBlue"];



            }


           

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
