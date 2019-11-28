using System;
using System.Collections.Generic;

using Xamarin.Forms;
using cityguide.ViewModels;

namespace cityguide.View
{
    public partial class CityMuseumsListView : ContentPage
    {
        public CityMuseumsListView()
        {
            InitializeComponent();

            CityMuseumsListViewModel vm = new CityMuseumsListViewModel(Navigation);
            vm.SetCityMuseums(vm.returnCityMuseums(vm.repository));
            this.BindingContext = vm;
        }

        protected override void OnAppearing()
        {

            CityMuseumsListViewModel vm = new CityMuseumsListViewModel(Navigation);
            vm.SetCityMuseums(vm.returnCityMuseums(vm.repository));
            this.BindingContext = vm;

        }
    }
}
