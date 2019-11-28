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
    public class CityEventsListViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public List<CityEventViewModel> allCityEvents { get; set; }

        public INavigation Navigation;



        public bool? isDIsabled { get; set; }

        public bool? isChildFriendly { get; set; }

        public bool? isFavourite { get; set; }



        public CityEventViewModel selectedCityEvent
        {


            get
            {
                return _selectedCityEvent;
            }


            set
            {
                _selectedCityEvent = value;

                if (_selectedCityEvent == null)
                    return;

                IDofSelectedCityEvent = _selectedCityEvent.CityEventID;

                _selectedCityEvent = null;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("selectedCityEvent"));
                }

                selectCityEventCommand.Execute(IDofSelectedCityEvent);
            }



        }
        private CityEventViewModel _selectedCityEvent { get; set; }

        private int IDofSelectedCityEvent { get; set; }


        public List<CityEvent> setListOfEvents(CityEventRepository repo)
        {
            return repo.GetAllCityEvents();
        }

        public CityEventRepository eventRepository { get; set; }

        public void SetCityEvents(List<CityEvent> cityEvents, bool? IsConnected = null)
        {
            allCityEvents = new List<CityEventViewModel>();
            
            foreach(var item in cityEvents)
            {
                CityEventViewModel cvm = new CityEventViewModel(this.Navigation, IsConnected);
        
                cvm.SetDetails( item);
                allCityEvents.Add(cvm);
            }

        }

        public CityEventsListViewModel(INavigation navigation)
        {
            
         Navigation = navigation;
         eventRepository = new CityEventRepository(new CityDBContext());
            _selectedCityEvent = null;
        
     

        }


        public ICommand selectCityEventCommand => new Command(async () => await LoadSelectedCityViewModel(IDofSelectedCityEvent));

        public async Task LoadSelectedCityViewModel(int id)

        {

          //  await Application.Current.MainPage.Navigation.PushAsync(new CityEventDetailView(id));
            await Navigation.PushAsync(new CityEventDetailView(id, Navigation));

        }

  

        public ICommand DisabledFilterCommand => new Command( () => SetDisabledFilter(this.eventRepository));

        public ICommand ChildFilterCommand => new Command(() => SetChildFilter(this.eventRepository));

        public ICommand FavouriteFilterCommand => new Command(() => SetFavouriteFilter(this.eventRepository));



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


           // PropertyChanged(this, new PropertyChangedEventArgs(v));
        }


        public void setFilters(CityEventRepository repository, bool? connected =null)
        {

            SetCityEvents(this.setListOfEvents(repository), connected);

            if (isDIsabled.HasValue == true)
                allCityEvents = allCityEvents.Where(b => b.DisabilityAccess == isDIsabled).ToList();

            if (isChildFriendly.HasValue == true)
                allCityEvents = allCityEvents.Where(c => c.ChildFriendly == isChildFriendly).ToList();

            if (isFavourite.HasValue == true)
                allCityEvents = allCityEvents.Where(c => c.CityEventFavourite == isFavourite).ToList();

            
           NotifyOnPropertyChanged(nameof(allCityEvents));
    
        }

        public void SetDisabledFilter(CityEventRepository repository, bool? connected=null)
        {
            if(isDIsabled == null)
            {
                isDIsabled = true;
            }
            else
            {
                isDIsabled = null;
            }

           setFilters(repository, connected);

            NotifyOnPropertyChanged("isDIsabled");


        }

        public void SetChildFilter(CityEventRepository repository, bool? connected =null)
        {
            if (isChildFriendly == null)
            {
                isChildFriendly = true;
            }
            else
            {
                isChildFriendly = null;
            }

            setFilters(repository, connected);
            NotifyOnPropertyChanged("isChildFriendly");
        }

        public void SetFavouriteFilter(CityEventRepository repository, bool? connected=null)
        {
            if (isFavourite == null)
            {
                isFavourite = true;
            }
            else
            {
                isFavourite = null;
            }

            setFilters(repository, connected);
            NotifyOnPropertyChanged("isFavourite");
        }




    }
}