﻿using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;
using cityguide.Repositories;


namespace cityguide.Converters
{
    public class ShopCategoriesConverter : IValueConverter
    {

       


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            CityShoppingCategoryRepository  repo = new CityShoppingCategoryRepository();


            return repo.GetShoppingCategory((int)value);




        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
