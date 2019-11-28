using System;
using System.Collections.Generic;

using Xamarin.Forms;
using cityguide.ViewModels;

namespace cityguide.View
{
    public partial class CityTransportOptionDetailView : ContentPage
    {
        public CityTransportOptionDetailView(int IdOfOption)
        {
            InitializeComponent();
            CityTransportOptionViewModel vm = new CityTransportOptionViewModel(Navigation);
            vm.SetDetails(vm.GetCityTransportOption(IdOfOption, vm.repository));

            this.BindingContext = vm;
        }
    }
}
