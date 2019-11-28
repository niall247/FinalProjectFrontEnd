using System;
using System.Collections.Generic;
using cityguide.ViewModel;
using cityguide.Domain;

using Xamarin.Forms;

namespace cityguide.View
{
    public partial class AddReviewView : ContentPage
    {
        public AddReviewView(CityReview review, INavigation navigation)
        {
            InitializeComponent();

            ReviewViewModel vm = new ReviewViewModel(review, navigation);


            this.BindingContext = vm;

         //   this.
        }
    }
}
