using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace cityguide.Controls
{
    public partial class hyperlinklabel : Grid
    {
        public hyperlinklabel()
        {
            InitializeComponent();
        }


        public ICommand ClickCommand => new Command<string>((url) =>
        {
            Device.OpenUri(new System.Uri(url));
        });


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