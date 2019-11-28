using System;
using System.Collections.Generic;
using cityguide.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace cityguide.View
{
    public partial class CityEventDetailView : ContentPage
    {
        public CityEventDetailView(int cityEventID, INavigation navigation)
        {
            InitializeComponent();
           // CityEventViewModel vm = new CityEventViewModel(cityEventID, Navigation);

            CityEventViewModel vm = new CityEventViewModel(navigation, null);
            vm.SetDetails(vm.getCityDetail(cityEventID,vm.repository));
            this.BindingContext = vm;

            
            setMap(vm.CityEventMapCoordinates, vm.CityEventName);
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
