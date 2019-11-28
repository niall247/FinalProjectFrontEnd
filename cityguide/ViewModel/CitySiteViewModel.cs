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
    public class CitySiteViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyOnPropertyChanged(string v)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(v));
        }





        public bool isSelectedItem { get; set; }


       
       


        public void SetDetails(CitySite city)
        {


            CitySiteID = city.CitySiteID;
            CitySiteName = city.CitySiteName;
            CitySiteSubtext = city.CitySiteSubtext;
            CitySiteCost = city.CitySiteCost;
            CitySiteAddress = city.CitySiteAddress;
            CitySiteWebSite = city.CitySiteWebSite;
            CitySiteTelephone = city.CitySiteTelephone;
            CitySiteCategoryID = city.CitySiteCategoryID;
            CitySiteDescription = city.CitySiteDescription;
            CitySiteMapCoordinates = city.CitySiteMapCoordinates;
            DisabilityAccess = city.DisabilityAccess;
            ChildFriendly = city.ChildFriendly;
            ChildDetail = city.ChildDetail;
            DisabilityDetail = city.DisabilityDetail;

            CitySiteImageURL = city.CitySiteImageURL;
            CitySiteFavourite = city.CitySiteFavourite;
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

        public CitySite getCityDetail(int ceID, CitySiteRepository repo)
        {
            return repo.GetAllCitySites()
                    .Where(a => a.CitySiteID == ceID).FirstOrDefault();
        }

        public INavigation Navigation;

        public CitySiteViewModel(INavigation navigation, bool? IsConnected = null)
        {
            Navigation = navigation;
            repository = new CitySiteRepository(new Data.CityDBContext());
            neighbourrepo = new NeighbourhoodRepository();
            reviewRepository = new CityReviewRepository();

            if(IsConnected != null)
            {
                isOnline = (bool)IsConnected;
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

            if(CitySiteFavourite == null )
            {
                CitySiteFavourite = true;

            }

            else if(CitySiteFavourite == true)
            {

                CitySiteFavourite = false;
          
            }


            else if (CitySiteFavourite == false)
            {

                CitySiteFavourite = true;
              
            }

            else
            {
                CitySiteFavourite = false;
          
            }

            repository.AddToFavourites(CitySiteID, (bool)CitySiteFavourite);
            NotifyOnPropertyChanged(nameof(CitySiteFavourite));
        
        }

        public  void GetReviews()
        {
            allReviewsForItem = null;

            allReviewsForItem = Task.Run(() => reviewRepository.GetReviews(CitySiteID,"Sites")).Result;
            NotifyOnPropertyChanged(nameof(allReviewsForItem));
        }


        public List<CityReview> allReviewsForItem { get; set; }


        private Dictionary<bool?, string> bools { get; set; }
        public CitySiteRepository repository { get; set; }
        public NeighbourhoodRepository neighbourrepo { get; set; }
        public CityReviewRepository reviewRepository { get; set; }


        public int CitySiteID { get; set; }

        public string CitySiteName { get; set; }

        public string CitySiteSubtext { get; set; }

        public string CitySiteDescription { get; set; }

        public string CitySiteWebSite { get; set; }

        public string CitySiteAddress { get; set; }
        public string CitySiteTelephone { get; set; }

        public string CitySiteCost { get; set; }

        public int NeighbourhoodID { get; set; }

        public int TransportID { get; set; }

        public int CitySiteCategoryID { get; set; }

        public bool? DisabilityAccess { get; set; }
        public bool? ChildFriendly { get; set; }


        public string CitySiteImageURL { get; set; }
        public string CitySiteMapCoordinates { get; set; }

        public bool? CitySiteFavourite { get; set; }

        public string DisabilityDetail { get; set; }

        public string ChildDetail { get; set; }


       


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
            rev.ReviewCategory = "Sites";
            rev.reviewItemID = CitySiteID;

            await Navigation.PushAsync(new AddReviewView(rev, Navigation));

        }

        public ImageSource CitySiteImageSource
        {

            get

            {           if(isOnline == true)
                         {
                                return ImageSource.FromUri(new Uri(CitySiteImageURL));
                        }
                        else
                {
                   


                    return ImageSource.FromFile("nocloud.jpg");
                }


            }



        }




    }

    }

