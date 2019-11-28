using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace cityguide.Controls
{
    public partial class informationLabel : Grid
    {
        public informationLabel()
        {
            InitializeComponent();
        }



        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(informationLabel));

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public static readonly BindableProperty ItemTextProperty = BindableProperty.Create(nameof(ItemText), typeof(string), typeof(informationLabel));

        public string ItemText
        {
            get
            {
                return (string)GetValue(ItemTextProperty);
            }
            set
            {
                SetValue(ItemTextProperty, value);
            }
        }
    }
}