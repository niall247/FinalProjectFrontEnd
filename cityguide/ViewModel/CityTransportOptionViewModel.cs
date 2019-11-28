using System;
using cityguide.Domain;
using cityguide.Repositories;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using cityguide.View;
using Xamarin.Essentials;


namespace cityguide.ViewModels
{
    public class CityTransportOptionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyOnPropertyChanged(string v)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(v));
        }





        public bool isSelectedItem { get; set; }


       
       
        public CityTransportOption GetCityTransportOption(int id, CityTransportOptionRepository city)
        {
           return  repository.GetAllCityTransportOptions()
                                .Where(a => a.CityTransportOptionID == id).FirstOrDefault();
        }

        public void SetDetails(CityTransportOption city)
        {


            CityTransportOptionID = city.CityTransportOptionID;
            CityTransportTitle = city.CityTransportTitle;
            CityTransportDescription = city.CityTransportDescription;
            CityTransportMapImage = city.CityTransportMapImage;
            CityTransportItemImage = city.CityTransportItemImage;
            CityTransportSubTitle = city.CityTransportSubTitle;
            DisabilityDetail = city.DisabilityDetail;

    }


        public bool isConnected()
        {
            var conn = Connectivity.NetworkAccess;
            if(conn == NetworkAccess.Internet)
            {
                return true;

            }
            else
            {
                return false;

            }

        }

        public INavigation Navigation;

        public CityTransportOptionViewModel(INavigation navigation, bool? isConn  = null)
        {
            Navigation = navigation;
            repository = new CityTransportOptionRepository(new Data.CityDBContext());

            if(isConn == null)
            {
                isOnline = isConnected();
            }
            else
            {
                isOnline = (bool)isConn;
            }
           

        }


       


       
      


      


        private Dictionary<bool?, string> bools { get; set; }
        public CityTransportOptionRepository repository { get; set; }



        public int CityTransportOptionID { get; set; }

        public string CityTransportTitle{ get; set; }

        public string CityTransportSubTitle { get; set; }

        public string CityTransportDescription { get; set; }

        public string CityTransportMapImage { get; set; }

        public string CityTransportItemImage { get; set; }

        public string DisabilityDetail { get; set; }





        public bool isOnline { get; set; }


        public ICommand OpenImageCommand => new Command(async () => await OpenImageInWindow());


        public async Task OpenImageInWindow()
        {
            await Navigation.PushAsync(new ImageView(CityTransportMapImage, Navigation));
        }

        public ImageSource CityTransportMapURL
        {

            get

            {           if(isOnline == true)
                         {
                                return ImageSource.FromUri(new Uri(CityTransportMapImage));
                        }
                        else
                {
                   


                    return ImageSource.FromFile("nocloud.jpg");
                }


            }



        }

        public ImageSource CityTransportItemURL
        {

            get

            {
                if (isOnline == true)
                {
                    return ImageSource.FromUri(new Uri(CityTransportItemImage));
                }
                else
                {



                    return ImageSource.FromFile("nocloud.jpg");
                }


            }



        }




    }

    }

