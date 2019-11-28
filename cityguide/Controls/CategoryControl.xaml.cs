using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace cityguide.Controls
{
    public partial class CategoryControl : Grid
    {
        public CategoryControl()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(CategoryControl));

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


        public static BindableProperty ImageProperty = BindableProperty.Create(
                                                        propertyName: "Image",
                                                        returnType: typeof(string),
                                                        declaringType: typeof(CategoryControl),
                                                        defaultValue: "",
                                                        defaultBindingMode: BindingMode.TwoWay,
                                                        propertyChanged: ImageSourcePropertyChanged);

        public string Image
        {
            get { return base.GetValue(ImageProperty).ToString(); }
            set { base.SetValue(ImageProperty, value); }
        }

        private static void ImageSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CategoryControl)bindable;
            control.image.Source = ImageSource.FromFile(newValue.ToString());
        }

        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(CategoryBackgroundColor), typeof(Color), typeof(CategoryControl));

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
        public static readonly BindableProperty CommandProperty =
                BindableProperty.Create(nameof(GetCategoryCommand), typeof(ICommand), typeof(CategoryControl), null);


        public ICommand GetCategoryCommand
        {
            get; set;
        }

       


    }
}