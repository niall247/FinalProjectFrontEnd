using System;
using System.Collections.Generic;
using cityguide.ViewModels;
using Xamarin.Forms.Maps;


using Xamarin.Forms;

namespace cityguide.View
{
    public partial class CityShopDetailView : ContentPage
    {
        public CityShopDetailView(int shopid)
        {
            InitializeComponent();

             CityShopViewModel vm = new CityShopViewModel(Navigation);
            vm.SetDetails(vm.getSelectedShop(shopid, vm.repository));
            this.BindingContext = vm;
            setMap(vm.CityShopMapCoordinates, vm.CityShopName);
        }

        public void setMap(string coordinates, string CityShopName)
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
                Label = CityShopName
            };
            MyMap.Pins.Add(pin);

        }
    }
}
