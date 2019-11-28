using System;
using System.Collections.Generic;
using cityguide.ViewModels;
using Xamarin.Forms.Maps;

using Xamarin.Forms;
using cityguide.Domain;

namespace cityguide.View
{
    public partial class CitySiteDetailView : ContentPage
    {
        public CitySiteDetailView(int site)
        {
            InitializeComponent();

    
            CitySiteViewModel vm = new CitySiteViewModel(Navigation);
            vm.SetDetails(vm.getCityDetail(site, vm.repository));
            this.BindingContext = vm;
           
            setMap(vm.CitySiteMapCoordinates, vm.CitySiteName);

        }

        public void setMap(string coordinates, string CityEventName)
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
                Label = CityEventName
            };
            MyMap.Pins.Add(pin);

        }
    }


}
