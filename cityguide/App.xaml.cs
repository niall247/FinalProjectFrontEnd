using System;
using Xamarin.Forms;
using cityguide.Domain;
using Xamarin.Forms.Xaml;
using cityguide.Repositories;
using cityguide.View;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace cityguide
{
    public partial class App : Application
    {
        public static string dbPathToSave { get; set; }

        public App(string dbPath)
        {
            InitializeComponent();

            dbPathToSave = dbPath;

           
                

            MainPage = new TabPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
