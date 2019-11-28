using System;
using System.Collections.Generic;
using cityguide.ViewModels;

using Xamarin.Forms;

namespace cityguide.View
{
    public partial class CityEventsListView : ContentPage
    {
        public CityEventsListView()
        {
            InitializeComponent();


            CityEventsListViewModel  vm = new CityEventsListViewModel(Navigation);
             vm.SetCityEvents(vm.setListOfEvents(vm.eventRepository));
             this.BindingContext = vm;
        }


        protected override void OnAppearing()
        {

            CityEventsListViewModel vm = new CityEventsListViewModel(Navigation);
            vm.SetCityEvents(vm.setListOfEvents(vm.eventRepository));
            this.BindingContext = vm;

        }
    }
}
