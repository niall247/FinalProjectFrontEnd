using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;
using cityguide.Repositories;
using cityguide.Data;


namespace cityguide.Converters
{
    public class BudgetConverter : IValueConverter
    {

       


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            BudgetRepository  repo = new BudgetRepository(new CityDBContext());


            return repo.GetBudgetName((int)value);




        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
