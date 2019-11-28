using System;
using System.Collections.Generic;
using cityguide.ViewModels;

using Xamarin.Forms;

namespace cityguide.View
{
    public partial class CategoriesView : ContentPage
    {
        public CategoriesView()
        {
            InitializeComponent();

            var vm = new CategoriesViewModel(Navigation);

            NavigationPage.SetHasNavigationBar(this, true);
            this.BindingContext = vm;

        }
    }
}
