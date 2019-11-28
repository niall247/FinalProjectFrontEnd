using System;
using System.Collections.Generic;
using cityguide.ViewModels;

using Xamarin.Forms;

namespace cityguide.View
{
    public partial class CityTransportOptionsListview : ContentPage
    {
        public CityTransportOptionsListview()
        {
            InitializeComponent();
            CityTransportOptionsListViewModel vm = new CityTransportOptionsListViewModel(Navigation);
            vm.SetCityTransportOptions(vm.returnListOfoptions(vm.transportRepository));
            this.BindingContext = vm;
        }
    }
}
