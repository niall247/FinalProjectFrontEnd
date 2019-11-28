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
    public class CityShopsListViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public List<CityShopViewModel> allCityShoppings { get; set; }

        public INavigation Navigation;

       


        public bool? isDIsabled { get; set; }

        public bool? isChildFriendly { get; set; }

        public bool? isFavourite { get; set; }



        public CityShopViewModel selectedCityShopping
        {


            get
            {
                return _selectedCityShopping;
            }


            set
            {
                _selectedCityShopping = value;

                if (_selectedCityShopping == null)
                    return;

                IDofSelectedCityShopping = selectedCityShopping.CityShopID;

                _selectedCityShopping = null;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("selectedCityShopping"));
                }

                selectCityShoppingCommand.Execute(IDofSelectedCityShopping);
            }



        }
        private CityShopViewModel _selectedCityShopping { get; set; }

        private int IDofSelectedCityShopping { get; set; }
    
        public void SetCityShoppings(List<CityShopping> shops, bool? isConnected = null)
        {
            allCityShoppings = new List<CityShopViewModel>();

            foreach(var item in shops)
            {
                CityShopViewModel cvm = new CityShopViewModel(Navigation, isConnected);
                cvm.SetDetails(item);
                allCityShoppings.Add(cvm);
            }

        }

        public List<CityShopping> returnCityShops(CityShoppingRepository repo)
        {
            return repo.GetAllCityShops().ToList();
        }

        public CityShopsListViewModel(INavigation navigation)
        {
            Navigation = navigation;
            _selectedCityShopping= null;
            cityShoppingRepository = new CityShoppingRepository(new CityDBContext());
          


        }

        


        public ICommand selectCityShoppingCommand => new Command(async () => await LoadSelectedCityViewModel(IDofSelectedCityShopping));

        public async Task LoadSelectedCityViewModel(int id)

        {

            await Navigation.PushAsync(new CityShopDetailView(id));

        }


        public CityShoppingRepository cityShoppingRepository { get; set; }

        public ICommand DisabledFilterCommand => new Command( () => SetDisabledFilter(this.cityShoppingRepository));

        public ICommand ChildFilterCommand => new Command(() => SetChildFilter(this.cityShoppingRepository));

        public ICommand FavouriteFilterCommand => new Command(() => SetFavouriteFilter(this.cityShoppingRepository));



     

   


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


        public void setFilters(CityShoppingRepository repo, bool? isConnected  = null)
        {

            SetCityShoppings(returnCityShops(repo), isConnected);

            if (isDIsabled.HasValue == true)
                allCityShoppings = allCityShoppings.Where(b => b.DisabilityAccess == isDIsabled).ToList();

            if (isChildFriendly.HasValue == true)
                allCityShoppings = allCityShoppings.Where(c => c.ChildFriendly == isChildFriendly).ToList();

            if (isFavourite.HasValue == true)
                allCityShoppings = allCityShoppings.Where(c => c.CityShopFavourite == isFavourite).ToList();

         
            NotifyOnPropertyChanged(nameof(allCityShoppings));
    
        }

        public void SetDisabledFilter(CityShoppingRepository repo, bool? isConnected = null)
        {
            if(isDIsabled == null)
            {
                isDIsabled = true;
            }
            else
            {
                isDIsabled = null;
            }

            setFilters(repo, isConnected);

            NotifyOnPropertyChanged("isDIsabled");


        }

        public void SetChildFilter(CityShoppingRepository repo, bool? isConnected = null)
        {
            if (isChildFriendly == null)
            {
                isChildFriendly = true;
            }
            else
            {
                isChildFriendly = null;
            }

            setFilters(repo, isConnected);
            NotifyOnPropertyChanged("isChildFriendly");
        }

        public void SetFavouriteFilter(CityShoppingRepository repo, bool? isConnected = null)
        {
            if (isFavourite == null)
            {
                isFavourite = true;
            }
            else
            {
                isFavourite = null;
            }

            setFilters(repo, isConnected);
            NotifyOnPropertyChanged("isFavourite");
        }




    }
}