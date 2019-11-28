using System;
using System.Collections.Generic;
using cityguide.Repositories;
using cityguide.ViewModels;

using Xamarin.Forms;

namespace cityguide.View
{
    public partial class CitySitesListView : ContentPage
    {
        public CitySitesListView()
        {
            InitializeComponent();

            CitySitesListViewModel vm = new CitySitesListViewModel(Navigation);

            CitySiteRepository siteRepository = new CitySiteRepository(new Data.CityDBContext());

            vm.SetCitySites(siteRepository.GetAllCitySites(),true);
            this.BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            CitySitesListViewModel vm = new CitySitesListViewModel(Navigation);

            CitySiteRepository siteRepository = new CitySiteRepository(new Data.CityDBContext());

            vm.SetCitySites(siteRepository.GetAllCitySites(), true);
            this.BindingContext = vm;

        }
    }
}
