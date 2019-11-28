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
using cityguide.Domain;
using cityguide.Repositories;
using cityguide.View;


namespace cityguide.ViewModels
{
    public class CityRestaurantsListViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public List<CityRestaurantViewModel> allCityRestaurants { get; set; }

        public INavigation Navigation;

       


        public bool? isDIsabled { get; set; }

        public bool? isChildFriendly { get; set; }

        public bool? isFavourite { get; set; }

        public bool? GlutenFree { get; set; }

        public bool? Halal { get; set; }

        public bool? Vegetarian { get; set; }

        public CityRestaurantViewModel selectedCityRestaurant
        {


            get
            {
                return _selectedCityRestaurant;
            }


            set
            {
                _selectedCityRestaurant = value;

                if (_selectedCityRestaurant == null)
                    return;

                IDOfSelectedCityRestaurant = _selectedCityRestaurant.CityRestaurantID;

                _selectedCityRestaurant = null;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("selectedCityRestaurant"));
                }

                selectCityRestaurantCommand.Execute(IDOfSelectedCityRestaurant);
            }



        }
        private CityRestaurantViewModel _selectedCityRestaurant { get; set; }

        private int IDOfSelectedCityRestaurant { get; set; }
    
        public void SetCityRestaurants(List<CityRestaurant> cityRestaurants, bool? isConnected = null)
        {
            allCityRestaurants = new List<CityRestaurantViewModel>();



            foreach(var item in cityRestaurants)
            {
                CityRestaurantViewModel cvm = new CityRestaurantViewModel(Navigation, isConnected);
                cvm.SetDetails(item);
                allCityRestaurants.Add(cvm);
            }

        }

        public CityRestaurantRepository restaurantRepository { get; set; }

        public List<CityRestaurant> returnCityRestaurants(CityRestaurantRepository repo)
        {
            return repo.GetAllCityRestaurants().ToList();
        }

        public CityRestaurantsListViewModel(INavigation navigation)
        {
            Navigation = navigation;
            _selectedCityRestaurant= null;
            restaurantRepository = new CityRestaurantRepository(new CityDBContext());



        }


        public ICommand selectCityRestaurantCommand => new Command(async () => await LoadSelectedCityViewModel(IDOfSelectedCityRestaurant));

        public async Task LoadSelectedCityViewModel(int id)

        {

            await Navigation.PushAsync(new CityRestaurantDetailView(id));

        }

  

        public ICommand DisabledFilterCommand => new Command( () => SetDisabledFilter(this.restaurantRepository));

        public ICommand ChildFilterCommand => new Command(() => SetChildFilter(this.restaurantRepository));

        public ICommand FavouriteFilterCommand => new Command(() => SetFavouriteFilter(this.restaurantRepository));
        public ICommand GlutenFreeCommand => new Command(() => SetGlutenFreeFilter(this.restaurantRepository));
        public ICommand HalalCommand => new Command(() => SetHalalFilter(this.restaurantRepository));
        public ICommand VegetarianCommand => new Command(() => SetVegetarianFilter(this.restaurantRepository));
       

        private void NotifyOnPropertyChanged(string v)
        {

            if (Application.Current != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
            else
            {

                //Its a unit test

            }
        }


        public void setFilters(CityRestaurantRepository repo, bool? isConn = null)
        {

            SetCityRestaurants(repo.GetAllCityRestaurants(), isConn);

            if (isDIsabled.HasValue == true)
                allCityRestaurants = allCityRestaurants.Where(b => b.DisabilityAccess == isDIsabled).ToList();

            if (isChildFriendly.HasValue == true)
                allCityRestaurants = allCityRestaurants.Where(c => c.ChildFriendly == isChildFriendly).ToList();

            if (isFavourite.HasValue == true)
                allCityRestaurants = allCityRestaurants.Where(c => c.CityRestaurantFavourite == isFavourite).ToList();

            if (Halal.HasValue == true)
                allCityRestaurants = allCityRestaurants.Where(c => c.Halal == Halal).ToList();


            if (Vegetarian.HasValue == true)
                allCityRestaurants = allCityRestaurants.Where(c => c.Vegetarian == Vegetarian).ToList();

            if (GlutenFree.HasValue == true)
                allCityRestaurants = allCityRestaurants.Where(c => c.GlutenFree == GlutenFree).ToList();

            if (DairyFree.HasValue == true)
                allCityRestaurants = allCityRestaurants.Where(c => c.DairyFree == DairyFree).ToList();

            if (Kosher.HasValue == true)
                allCityRestaurants = allCityRestaurants.Where(c => c.Kosher == Kosher).ToList();

            if (Vegan.HasValue == true)
                allCityRestaurants = allCityRestaurants.Where(c => c.Vegan == Vegan).ToList();

            NotifyOnPropertyChanged(nameof(allCityRestaurants));
    
        }

        public void SetDisabledFilter(CityRestaurantRepository repo, bool? isConn = null)
        {
            if(isDIsabled == null)
            {
                isDIsabled = true;
            }
            else
            {
                isDIsabled = null;
            }

            setFilters(repo, isConn);

            NotifyOnPropertyChanged("isDIsabled");


        }

        public void SetChildFilter(CityRestaurantRepository repo, bool? isConn = null)
        {
            if (isChildFriendly == null)
            {
                isChildFriendly = true;
            }
            else
            {
                isChildFriendly = null;
            }

            setFilters(repo, isConn);
            NotifyOnPropertyChanged("isChildFriendly");
        }

        public void SetFavouriteFilter(CityRestaurantRepository repo, bool? isConn = null)
        {
            if (isFavourite == null)
            {
                isFavourite = true;
            }
            else
            {
                isFavourite = null;
            }

            setFilters(repo, isConn);
            NotifyOnPropertyChanged("isFavourite");
        }


        public void SetGlutenFreeFilter(CityRestaurantRepository repo, bool? isConn = null)
        {
            if (GlutenFree == null)
            {
                GlutenFree = true;
            }
            else
            {
                GlutenFree = null;
            }

            setFilters(repo, isConn);
            NotifyOnPropertyChanged("GlutenFree");
        }

        public void SetHalalFilter(CityRestaurantRepository repo, bool? isConn = null)
        {
            if (Halal == null)
            {
                Halal = true;
            }
            else
            {
                Halal = null;
            }

            setFilters(repo, isConn);
            NotifyOnPropertyChanged("Halal");
        }

        public void SetVegetarianFilter(CityRestaurantRepository repo, bool? isConn = null)
        {
            if (Vegetarian == null)
            {
                Vegetarian = true;
            }
            else
            {
                Vegetarian = null;
            }

            setFilters(repo,isConn);
            NotifyOnPropertyChanged("Vegetarian");
        }

        public  bool? DairyFree { get; set; }
        public void SetDairyFreeFilter(CityRestaurantRepository repo, bool? isConn = null)
        {
            if (DairyFree == null)
            {
                DairyFree = true;
            }
            else
            {
                DairyFree = null;
            }

            setFilters(repo, isConn);
            NotifyOnPropertyChanged("DairyFree");
        }

        public bool? Kosher { get; set; }
        public void SetKosherFilter(CityRestaurantRepository repo, bool? isConn = null)
        {
            if (Kosher == null)
            {
                Kosher = true;
            }
            else
            {
                Kosher = null;
            }

            setFilters(repo, isConn);
            NotifyOnPropertyChanged("Kosher");
        }

        public bool? Vegan { get; set; }
        public void SetVeganFilter(CityRestaurantRepository repo, bool? isConn = null)
        {
            if (Vegan == null)
            {
                Vegan = true;
            }
            else
            {
                Vegan = null;
            }

            setFilters(repo, isConn);
            NotifyOnPropertyChanged("Vegan");
        }


    }
}