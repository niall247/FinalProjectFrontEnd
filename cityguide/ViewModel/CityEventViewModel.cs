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
using cityguide.Data;

namespace cityguide.ViewModels
{
    public class CityEventViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyOnPropertyChanged(string v)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(v));
        }





        public bool isSelectedItem { get; set; }


       
       public CityEvent getCityDetail(int ceID, CityEventRepository repo)
        {
           return  repo.GetAllCityEvents()
                   .Where(a => a.CityEventID == ceID).FirstOrDefault();
        }


        public void SetDetails(CityEvent city)
        {


            CityEventID = city.CityEventID;
            CityEventName = city.CityEventName;
            CityEventSubtext = city.CityEventSubtext;
            CityEventCost = city.CityEventCost;
            CityEventAddress = city.CityEventAddress;
            CityEventWebSite = city.CityEventWebSite;
            CityEventStartDate = city.CityEventStartDate;
            CityEventTelephone = city.CityEventTelephone;
            CityEventCategoryID = city.CityEventCategoryID;
            CityEventDescription = city.CityEventDescription;
            CityEventMapCoordinates = city.CityEventMapCoordinates;
            DisabilityAccess = city.DisabilityAccess;
            ChildFriendly = city.ChildFriendly;
            ChildDetail = city.ChildDetail;
            DisabilityDetail = city.DisabilityDetail;
            DisabilityAccess = city.DisabilityAccess;
            CityEventEndDate = city.CityEventEndDate;
            CityEventImageURL = city.CityEventImageURL;
            CityEventFavourite = city.CityEventFavourite;
            NeighbourhoodID = city.NeighbourhoodID;
            TransportID = city.TransportID;

        

           

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

        public CityEventViewModel(INavigation navigation, bool? connectLive)
        {
           
            Navigation = navigation;
            repository = new CityEventRepository(new CityDBContext());
            neighbourrepo = new NeighbourhoodRepository();
            reviewRepository = new CityReviewRepository();

            if(connectLive.HasValue)
            {
                isOnline = (bool)connectLive;
            }
            else
            {
                isOnline = isConnected();
            }
            
           
            

        }


       

        public ICommand GetReviewsCommand => new Command(() => GetReviews());

        public ICommand AddFavouritesCommand => new Command(() => AddToFavourites());

        public void AddToFavourites()
        {

            if(CityEventFavourite == null )
            {
                CityEventFavourite = true;

            }

            else if(CityEventFavourite == true)
            {

                CityEventFavourite = false;
          
            }


            else if (CityEventFavourite == false)
            {

                CityEventFavourite = true;
              
            }

            else
            {
                CityEventFavourite = false;
          
            }

            repository.AddToFavourites(CityEventID, (bool)CityEventFavourite);
            NotifyOnPropertyChanged(nameof(CityEventFavourite));
        
        }

        public  void GetReviews()
        {
            allReviewsForItem = null;

            allReviewsForItem = Task.Run(() => reviewRepository.GetReviews(CityEventID,"Events")).Result;
            NotifyOnPropertyChanged(nameof(allReviewsForItem));
        }


        public List<CityReview> allReviewsForItem { get; set; }


        private Dictionary<bool?, string> bools { get; set; }
        public CityEventRepository repository { get; set; }
        public NeighbourhoodRepository neighbourrepo { get; set; }
        public CityReviewRepository reviewRepository { get; set; }


        public string DisabilityDetail { get; set; }
        public string ChildDetail { get; set; }

        public int CityEventID { get; set; }
        public string CityEventSubtext { get; set; }
        public string CityEventName { get; set; }
        public string CityEventDescription { get; set; }
        public int CityEventStartDate { get; set; }
        public int CityEventEndDate { get; set; }
        public string CityEventWebSite { get; set; }

        public string CityEventAddress { get; set; }
        public string CityEventTelephone { get; set; }

        public string CityEventCost { get; set; }

        public int NeighbourhoodID { get; set; }

        public int TransportID { get; set; }

        public int CityEventCategoryID { get; set; }

        public bool? DisabilityAccess { get; set; }
        public bool? ChildFriendly { get; set; }

        public string CityEventImageURL { get; set; }
        public string CityEventMapCoordinates { get; set; }

        public bool? CityEventFavourite { get; set; }


        public string EventTimings
        { 
        get
            {

                string startdate = JulianToDateTime(CityEventStartDate).ToString();
                string enddate = JulianToDateTime(CityEventEndDate).ToString();
                return startdate + Environment.NewLine + " To " +  enddate;
            
            }


        }




        string JulianToDateTime(int julianDate)
        {
            int day = julianDate % 1000;
            int year = ((julianDate - day) / 1000) + 2000;
            var date1 = new DateTime(year, 1, 1);
            DateTime result = date1.AddDays(day - 1);

            return result.ToString("dd-MMM-yyyy");
        }

       


        public bool isOnline { get; set; }

        public string NeighbourhoodName
        {
            get
            {
                return neighbourrepo.GetNeighbourhoodName(this.NeighbourhoodID);
            }
        }

        public ICommand addReviewCommand => new Command(async () => await AddReview());

        public async Task AddReview()

        {

            CityReview rev = new CityReview();
            rev.ReviewCategory = "Events";
            rev.reviewItemID = CityEventID;

            await Navigation.PushAsync(new AddReviewView(rev, Navigation));

        }

        public ImageSource CityEventImageSource
        {

            get

            {           if(isOnline == true)
                         {
                                return ImageSource.FromUri(new Uri(CityEventImageURL));
                        }
                        else
                {
                   


                    return ImageSource.FromFile("nocloud.jpg");
                }


            }



        }




    }

    }

