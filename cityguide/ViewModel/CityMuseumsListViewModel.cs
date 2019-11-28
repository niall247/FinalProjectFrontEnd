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
    public class CityMuseumsListViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public List<CityMuseumViewModel> allCityMuseums { get; set; }

        public INavigation Navigation;

       


        public bool? isDIsabled { get; set; }

        public bool? isChildFriendly { get; set; }

        public bool? isFavourite { get; set; }



        public CityMuseumViewModel selectedCityMuseum
        {


            get
            {
                return _selectedCityMuseum;
            }


            set
            {
                _selectedCityMuseum = value;

                if (_selectedCityMuseum == null)
                    return;

                IDofSelectedCityMuseum = selectedCityMuseum.CityMuseumID;

                _selectedCityMuseum = null;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("selectedCityMuseum"));
                }

                selectCityMuseumCommand.Execute(IDofSelectedCityMuseum);
            }



        }

        

        private CityMuseumViewModel _selectedCityMuseum { get; set; }

        private int IDofSelectedCityMuseum { get; set; }
    
        public void SetCityMuseums(List<CityMuseum> cityMuseums, bool? isConnected = null)
        {
            allCityMuseums = new List<CityMuseumViewModel>();


            foreach(var item in cityMuseums)
            {
                CityMuseumViewModel cvm = new CityMuseumViewModel(Navigation, isConnected);
                cvm.SetDetails(item);
                allCityMuseums.Add(cvm);
            }

        }

        public CityMuseumsListViewModel(INavigation navigation)
        {
            Navigation = navigation;
            _selectedCityMuseum= null;
            repository = new CityMuseumRepository(new CityDBContext());
           


        }

        public CityMuseumRepository repository { get; set; }

        public List<CityMuseum> returnCityMuseums(CityMuseumRepository repo)
        {
            return repo.GetAllCityMuseums().ToList();
        }


        public ICommand selectCityMuseumCommand => new Command(async () => await LoadSelectedCityViewModel(IDofSelectedCityMuseum));

        public async Task LoadSelectedCityViewModel(int id)

        {

            await Navigation.PushAsync(new CityMuseumDetailView(id));

        }

  

        public ICommand DisabledFilterCommand => new Command( () => SetDisabledFilter(this.repository));

        public ICommand ChildFilterCommand => new Command(() => SetChildFilter(this.repository));

        public ICommand FavouriteFilterCommand => new Command(() => SetFavouriteFilter(this.repository));



        

   


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


        public void setFilters(CityMuseumRepository repo, bool? isConn =null)
        {

            SetCityMuseums(this.returnCityMuseums(repo), isConn);

            if (isDIsabled.HasValue == true)
                allCityMuseums = allCityMuseums.Where(b => b.DisabilityAccess == isDIsabled).ToList();

            if (isChildFriendly.HasValue == true)
                allCityMuseums = allCityMuseums.Where(c => c.ChildFriendly == isChildFriendly).ToList();

            if (isFavourite.HasValue == true)
                allCityMuseums = allCityMuseums.Where(c => c.CityMuseumFavourite == isFavourite).ToList();

         
            NotifyOnPropertyChanged(nameof(allCityMuseums));
    
        }

        public void SetDisabledFilter(CityMuseumRepository repo, bool? IsConnected = null)
        {
            if(isDIsabled == null)
            {
                isDIsabled = true;
            }
            else
            {
                isDIsabled = null;
            }

            setFilters(repo,IsConnected);

            NotifyOnPropertyChanged("isDIsabled");


        }

        public void SetChildFilter(CityMuseumRepository repo, bool? IsConnected = null)
        {
            if (isChildFriendly == null)
            {
                isChildFriendly = true;
            }
            else
            {
                isChildFriendly = null;
            }

            setFilters(repo, IsConnected);
            NotifyOnPropertyChanged("isChildFriendly");
        }

        public void SetFavouriteFilter(CityMuseumRepository repo, bool? IsConnected = null)
        {
            if (isFavourite == null)
            {
                isFavourite = true;
            }
            else
            {
                isFavourite = null;
            }

            setFilters(repo, IsConnected);
            NotifyOnPropertyChanged("isFavourite");
        }




    }
}