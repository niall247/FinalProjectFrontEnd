using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using cityguide.Data;
//using cityguide.Models;
using Xamarin.Forms;
//using Xamarin.Forms.Maps;


namespace App1.ViewModels
{
    public class RestaurantsListViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        /*

        public List<RestaurantDetail> allRestaurants { get; set; }

        private RestaurantDetail _selectedRestaurant { get; set; }

        private int IDofSelectedRestaurant { get; set; }

        public INavigation Navigation { get; set; }

        public RestaurantsListViewModel(INavigation navigation)
        {
            Navigation = navigation;
            _selectedRestaurant = null;
            setDetails();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void setDetails()
        {

           // CityDatabase db = new CityDatabase();


            allRestaurants = db.GetRestaurantDetails().ToList();


        }

        public RestaurantDetail selectedRestaurant
        {
            get
            {
                return _selectedRestaurant;
            }
            set
            {
                _selectedRestaurant = value;

                if (_selectedRestaurant == null)
                    return;

                IDofSelectedRestaurant = _selectedRestaurant.RestaurantDetailID;

                _selectedRestaurant = null;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("selectedRestaurant"));
                }
                selectRestaurantCommand.Execute(IDofSelectedRestaurant);



            }
        }



        public ICommand selectRestaurantCommand => new Command(async () => await LoadSelectedRestaurantViewModel(IDofSelectedRestaurant));

        public async Task LoadSelectedRestaurantViewModel(int id)

        {


            await Navigation.PushAsync(new RestaurantDetailView(id));

        }


            */
    }
}