using System;
using System.Globalization;
using Xamarin.Forms;

namespace cityguide.Converters
{
    public class BooleanConverter : IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            bool? item = (bool?)value;

            switch (value)
            {
                case true:
                    return (string) "Yes";
                case false:
                    return (string)"No";
                default:
                    return (string)"No";



            }




        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
