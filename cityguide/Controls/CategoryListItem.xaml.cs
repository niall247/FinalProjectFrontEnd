using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace cityguide.Controls
{
    public partial class CategoryListItem : Grid
    {
        public CategoryListItem()
        {
            InitializeComponent();

            Console.WriteLine(ImageURL);
        }
        public static readonly BindableProperty CommandProperty =
        BindableProperty.Create("Command", typeof(ICommand), typeof(CategoryListItem), null);

        public static readonly BindableProperty CommandParameterProperty =
          BindableProperty.Create("CommandParameter", typeof(object), typeof(CategoryListItem), null);


        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }


        public static readonly BindableProperty ImageURLProperty = BindableProperty.Create(nameof(ImageURL), typeof(ImageSource), typeof(CategoryListItem));

        public ImageSource ImageURL
        {
            get

            {
                return (ImageSource)GetValue(ImageURLProperty);
            }
            set
            {
                SetValue(ImageURLProperty, value);

            }


            /*
            {
                //Console.WriteLine(GetValue(ImageURLProperty));
                // return (string)GetValue(ImageURLProperty);
            };
            set
            {

                //SetValue(ImageURLProperty, value);
            };
            */
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(CategoryListItem));

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

        public static readonly BindableProperty SubTextProperty = BindableProperty.Create(nameof(SubText), typeof(string), typeof(CategoryListItem));

        public string SubText
        {
            get
            {
                return (string)GetValue(SubTextProperty);
            }
            set
            {
                SetValue(SubTextProperty, value);
            }
        }





        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(CategoryBackgroundColor), typeof(Color), typeof(CategoryListItem));

        public Color CategoryBackgroundColor
        {
            get
            {
                return (Color)GetValue(ColorProperty);
            }
            set
            {
                SetValue(ColorProperty, value);
            }
        }


    }
}
