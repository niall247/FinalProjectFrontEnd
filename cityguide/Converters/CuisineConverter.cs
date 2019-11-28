using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;
using cityguide.Repositories;


namespace cityguide.Converters
{
    public class CuisineConverter : IValueConverter
    {

       


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            CuisineRepository repo = new CuisineRepository(new Data.CityDBContext());


            return repo.GetCuisineName((int)value);




        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
