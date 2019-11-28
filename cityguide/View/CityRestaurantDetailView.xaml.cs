using System;
using System.Collections.Generic;
using cityguide.ViewModels;
using Xamarin.Forms.Maps;

using Xamarin.Forms;

namespace cityguide.View
{
    public partial class CityRestaurantDetailView : ContentPage
    {
        public CityRestaurantDetailView(int id)
        {
            InitializeComponent();

            CityRestaurantViewModel vm = new CityRestaurantViewModel(Navigation);
            vm.SetDetails(vm.returnRestaurant(id, vm.repository));
            this.BindingContext = vm;
            setMap(vm.CityRestaurantMapCoordinates, vm.CityRestaurantName);

        }

        public void setMap(string coordinates, string CityRestaurantName)
        {


            string[] splitcoords = coordinates.Split(',');

            double lng = Convert.ToDouble(splitcoords[1]);

            double lat = Convert.ToDouble(splitcoords[0]);

            MyMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(
            new Position(lat, lng), Distance.FromMeters(500)));


            var pin = new Pin()
            {
                Position = new Position(lat, lng),
                Label = CityRestaurantName
            };
            MyMap.Pins.Add(pin);

        }
    }
}
