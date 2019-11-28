using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace cityguide.View
{
    public partial class ImageView : ContentPage
    {
        public ImageView(string ImageToShow, INavigation navigation)
        {
            InitializeComponent();
            this.MyImage.Source = ImageToShow;
        }
    }
}
