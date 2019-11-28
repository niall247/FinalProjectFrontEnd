using System;
using System.Collections.Generic;
using cityguide.ViewModels;
using Xamarin.Forms;

namespace cityguide.View
{
    public partial class CityShopListView : ContentPage
    {
        public CityShopListView()
        {
            InitializeComponent();

            CityShopsListViewModel vm = new CityShopsListViewModel(Navigation);
            vm.SetCityShoppings(vm.returnCityShops(vm.cityShoppingRepository));
            this.BindingContext = vm;
        }
    }
}
