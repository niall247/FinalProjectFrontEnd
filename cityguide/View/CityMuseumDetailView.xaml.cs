using System;
using System.Collections.Generic;
using cityguide.ViewModels;
using Xamarin.Forms.Maps;

using Xamarin.Forms;

namespace cityguide.View
{
    public partial class CityMuseumDetailView : ContentPage
    {
        public CityMuseumDetailView(int museumID)
        {
            InitializeComponent();
            CityMuseumViewModel vm = new CityMuseumViewModel(Navigation);
            vm.SetDetails(vm.getCityDetail(museumID,vm.repository));
            this.BindingContext = vm;
            setMap(vm.CityMuseumMapCoordinates, vm.CityMuseumName);
        }

        public void setMap(string coordinates, string CityMuseumName)
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
                Label = CityMuseumName
            };
            MyMap.Pins.Add(pin);

        }
    }
}
