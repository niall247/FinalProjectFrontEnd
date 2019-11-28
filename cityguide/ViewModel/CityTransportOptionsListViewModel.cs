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
    public class CityTransportOptionsListViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public List<CityTransportOptionViewModel> allCityTransports { get; set; }

        public INavigation Navigation;

       



        public CityTransportOptionViewModel selectedCityTransport
        {


            get
            {
                return _selectedCityTransport;
            }


            set
            {
                _selectedCityTransport = value;

                if (_selectedCityTransport == null)
                    return;

                IDOfSelectedTransport = selectedCityTransport.CityTransportOptionID;

                _selectedCityTransport = null;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("selectedCityTransport"));
                }

                selectCitySiteCommand.Execute(IDOfSelectedTransport);
            }



        }
        private CityTransportOptionViewModel _selectedCityTransport { get; set; }

        private int IDOfSelectedTransport { get; set; }

        public List<CityTransportOption> returnListOfoptions(CityTransportOptionRepository repo)
        {
            return repo.GetAllCityTransportOptions();
        }
    
        public void SetCityTransportOptions(List<CityTransportOption> myOptions, bool? IsConnected = null)
        {
            allCityTransports = new List<CityTransportOptionViewModel>();


            foreach(var item in myOptions)
            {
                CityTransportOptionViewModel cvm = new CityTransportOptionViewModel(Navigation, IsConnected);
                cvm.SetDetails(item);
                allCityTransports.Add(cvm);
            }

        }

        public CityTransportOptionRepository transportRepository { get; set; }

        public CityTransportOptionsListViewModel(INavigation navigation)
        {
            Navigation = navigation;
            _selectedCityTransport= null;
            transportRepository = new CityTransportOptionRepository(new CityDBContext());
    


        }


        public ICommand selectCitySiteCommand => new Command(async () => await LoadSelectedCityViewModel(IDOfSelectedTransport));

        public async Task LoadSelectedCityViewModel(int id)

        {

            await Navigation.PushAsync(new CityTransportOptionDetailView(id));

        }

  




        private void NotifyOnPropertyChanged(string v)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(v));
        }


       

       


    }
}