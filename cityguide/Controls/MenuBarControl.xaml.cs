using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace cityguide.Controls
{
    public partial class MenuBarControl : Grid
    {
        public MenuBarControl()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty CommandProperty =
BindableProperty.Create("Command", typeof(ICommand), typeof(MenuBarControl), null);
        
        public static readonly BindableProperty CommandParameterProperty =
          BindableProperty.Create("CommandParameter", typeof(object), typeof(MenuBarControl), null);


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



        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(CategoryBackgroundColor), typeof(Color), typeof(MenuBarControl));

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


        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MenuBarControl));

        public Color TextColor
        {
            get
            {
                return (Color)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
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
    }

   
}
