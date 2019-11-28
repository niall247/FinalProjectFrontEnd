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
    public class CitySitesListViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public List<CitySiteViewModel> allCitySites { get; set; }

        public INavigation Navigation;

       


        public bool? isDIsabled { get; set; }

        public bool? isChildFriendly { get; set; }

        public bool? isFavourite { get; set; }






        public CitySiteViewModel selectedCitySite
        {


            get
            {
                return _selectedCitySite;
            }


            set
            {
                _selectedCitySite = value;

                if (_selectedCitySite == null)
                    return;

                IDofSelectedCitySite = selectedCitySite.CitySiteID;

                _selectedCitySite = null;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("selectedCitySite"));
                }

                selectCitySiteCommand.Execute(IDofSelectedCitySite);
            }



        }

        public CitySiteRepository siteRepository { get; set; }

        private CitySiteViewModel _selectedCitySite { get; set; }


        public List<CitySite> returnCitySites(CitySiteRepository repo)
        {
            return repo.GetAllCitySites().ToList();
        }

        private int IDofSelectedCitySite { get; set; }
    
        public void SetCitySites(List<CitySite> citySites, bool? IsConnected = null)
        {
            allCitySites = new List<CitySiteViewModel>();

            foreach (var item in citySites)
            {
                CitySiteViewModel cvm = new CitySiteViewModel(Navigation,IsConnected);
                cvm.SetDetails(item);
                allCitySites.Add(cvm);
            }

        }

        public CitySitesListViewModel(INavigation navigation)
        {
            Navigation = navigation;
            _selectedCitySite= null;
            siteRepository = new CitySiteRepository(new CityDBContext()); 


        }


        public ICommand selectCitySiteCommand => new Command(async () => await LoadSelectedCityViewModel(IDofSelectedCitySite));

        public async Task LoadSelectedCityViewModel(int id)

        {

            await Navigation.PushAsync(new CitySiteDetailView(id));

        }

  

        public ICommand DisabledFilterCommand => new Command( () => SetDisabledFilter(this.siteRepository));

        public ICommand ChildFilterCommand => new Command(() => SetChildFilter(this.siteRepository));

        public ICommand FavouriteFilterCommand => new Command(() => SetFavouriteFilter(this.siteRepository));



        

   


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


        public void setFilters(CitySiteRepository repo, bool? IsConnected = null)
        {

            SetCitySites(returnCitySites(repo), IsConnected);

            if (isDIsabled.HasValue == true)
                allCitySites = allCitySites.Where(b => b.DisabilityAccess == isDIsabled).ToList();

            if (isChildFriendly.HasValue == true)
                allCitySites = allCitySites.Where(c => c.ChildFriendly == isChildFriendly).ToList();

            if (isFavourite.HasValue == true)
                allCitySites = allCitySites.Where(c => c.CitySiteFavourite == isFavourite).ToList();

         
            NotifyOnPropertyChanged(nameof(allCitySites));
    
        }

        public void SetDisabledFilter(CitySiteRepository repo, bool? IsConnected = null)
        {
            if(isDIsabled == null)
            {
                isDIsabled = true;
            }
            else
            {
                isDIsabled = null;
            }

            setFilters(repo, IsConnected);

            NotifyOnPropertyChanged("isDIsabled");


        }

        public void SetChildFilter(CitySiteRepository repo, bool? IsConnected = null)
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

        public void SetFavouriteFilter(CitySiteRepository repo, bool? IsConnected = null)
        {
            if (isFavourite == null)
            {
                isFavourite = true;
            }
            else
            {
                isFavourite = null;
            }

            setFilters(repo,IsConnected);
            NotifyOnPropertyChanged("isFavourite");
        }




    }
}