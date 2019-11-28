using System;
using System.Collections.Generic;
using cityguide.ViewModels;

using Xamarin.Forms;

namespace cityguide.View
{
    public partial class CityRestaurantsListView : ContentPage
    {
        public CityRestaurantsListView()
        {
            InitializeComponent();

            CityRestaurantsListViewModel vm = new CityRestaurantsListViewModel(Navigation);
            vm.SetCityRestaurants(vm.restaurantRepository.GetAllCityRestaurants());
            this.BindingContext = vm;
        }
    }
}
