using System;
using System.Collections.Generic;
using App1.ViewModels;

using Xamarin.Forms;

namespace cityguide.View
{
    public partial class RestaurantListView : ContentPage
    {
        public RestaurantListView()
        {
            InitializeComponent();
            myListView.SelectedItem = null;

           // RestaurantsListViewModel vm = new RestaurantsListViewModel(Navigation);
           // this.BindingContext = vm;


        }


    }
}