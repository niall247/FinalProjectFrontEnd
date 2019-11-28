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
    public class CityRestaurantViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyOnPropertyChanged(string v)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(v));
        }


        public int BudgetID { get; set; }


        public bool isSelectedItem { get; set; }



        public CityRestaurant returnRestaurant(int cID, CityRestaurantRepository repository)
        {
            return repository.GetAllCityRestaurants()
                              .Where(a => a.CityRestaurantID == cID).FirstOrDefault();
        }


        public void SetDetails(CityRestaurant city)
        {


            CityRestaurantID = city.CityRestaurantID;
            CityRestaurantName = city.CityRestaurantName;
            CityRestaurantAddress = city.CityRestaurantAddress;
            CityRestaurantSubtext = city.CityRestaurantSubtext;
            CityRestaurantDescription = city.CityRestaurantDescription;
            CityRestaurantWebSite = city.CityRestaurantWebSite;
            CityRestaurantAddress = city.CityRestaurantAddress;
            CityRestaurantTelephone = city.CityRestaurantTelephone;
            CityRestaurantOpeningHours = city.CityRestaurantOpeningHours;
            NeighbourhoodID = city.NeighbourhoodID;
            CuisineID = city.CuisineID;
            BudgetID = city.BudgetID;
            TransportID = city.TransportID;
            DisabilityAccess = city.DisabilityAccess;
            ChildFriendly = city.ChildFriendly;
            CityRestaurantImageURL = city.CityRestaurantImageURL;
            DisabilityDetail = city.DisabilityDetail;
            ChildDetail = city.ChildDetail;
            DietaryDetail = city.DietaryDetail;
            GlutenFree = city.GlutenFree;
            DairyFree = city.DairyFree;
            Halal = city.Halal;
            Kosher = city.Kosher;
            Vegan = city.Vegan;
            Vegetarian = city.Vegetarian;
            CityRestaurantMapCoordinates = city.CityRestaurantMapCoordinates;
            CityRestaurantFavourite = city.CityRestaurantFavourite;
            TransportID = city.TransportID;

        }


        public bool isConnected()
        {
            var conn = Connectivity.NetworkAccess;
            if (conn == NetworkAccess.Internet)
            {
                return true;

            }
            else
            {
                return false;

            }

        }

        public INavigation Navigation;



        public CityRestaurantViewModel(INavigation navigation, bool? isConnect = null)
        {
            Navigation = navigation;
            repository = new CityRestaurantRepository(new Data.CityDBContext());
            neighbourrepo = new NeighbourhoodRepository();
            reviewRepository = new CityReviewRepository();

            if(isConnect == null)
            {
                isOnline = isConnected();
            }
            else
            {
                isOnline = (bool)isConnect;
            }

        }




        public ICommand GetReviewsCommand => new Command(() => GetReviews(), ()=>isOnline);

        public ICommand AddFavouritesCommand => new Command(() => AddToFavourites());

        public void AddToFavourites()
        {

            if(CityRestaurantFavourite == null )
            {
                CityRestaurantFavourite = true;

            }

            else if(CityRestaurantFavourite == true)
            {

                CityRestaurantFavourite = false;
          
            }


            else if (CityRestaurantFavourite == false)
            {

                CityRestaurantFavourite = true;
              
            }

            else
            {
                CityRestaurantFavourite = false;
          
            }

            repository.AddToFavourites(CityRestaurantID, (bool)CityRestaurantFavourite);
            NotifyOnPropertyChanged(nameof(CityRestaurantFavourite));
        
        }

        public  void GetReviews()
        {
            allReviewsForItem = null;

            allReviewsForItem = Task.Run(() => reviewRepository.GetReviews(CityRestaurantID, "Sites")).Result;
            NotifyOnPropertyChanged(nameof(allReviewsForItem));
        }


        public List<CityReview> allReviewsForItem { get; set; }


        private Dictionary<bool?, string> bools { get; set; }
        public CityRestaurantRepository repository { get; set; }
        public NeighbourhoodRepository neighbourrepo { get; set; }
        public CityReviewRepository reviewRepository { get; set; }


        public int CityRestaurantID { get; set; }

        public string CityRestaurantName { get; set; }

        public string CityRestaurantSubtext { get; set; }

        public string CityRestaurantDescription { get; set; }

        public string CityRestaurantWebSite { get; set; }

        public string CityRestaurantAddress { get; set; }
        public string CityRestaurantTelephone { get; set; }

        public string CityRestaurantOpeningHours { get; set; }

        public string CityRestaurantCost { get; set; }

        public int NeighbourhoodID { get; set; }

        public int CuisineID { get; set; }

        public int TransportID { get; set; }

        public int CityRestaurantCategoryID { get; set; }

        public bool? DisabilityAccess { get; set; }
        public bool? ChildFriendly { get; set; }


        public string CityRestaurantImageURL { get; set; }
        public string CityRestaurantMapCoordinates { get; set; }

        public bool? CityRestaurantFavourite { get; set; }
        public bool? Vegetarian { get; set; }
        public bool? Vegan { get; set; }
        public bool? GlutenFree { get; set; }
        public bool? DairyFree { get; set; }
        public bool? Halal { get; set; }
        public bool? Kosher { get; set; }
        public string DisabilityDetail { get; set; }

        public string ChildDetail { get; set; }

        public string DietaryDetail { get; set; }


        public bool isOnline { get; set; }

        public string NeighbourhoodName
        {
            get
            {
                return neighbourrepo.GetNeighbourhoodName(this.NeighbourhoodID);
            }
        }

       


        public ICommand addReviewCommand => new Command(async () => await AddReview(), () => isOnline);

        public async Task AddReview()

        {

            CityReview rev = new CityReview();
            rev.ReviewCategory = "Restaurants";
            rev.reviewItemID = CityRestaurantID;

            await Navigation.PushAsync(new AddReviewView(rev, Navigation));

        }

        public ImageSource CityRestaurantImageSource
        {

            get

            {           if(isOnline == true)
                         {
                                return ImageSource.FromUri(new Uri(CityRestaurantImageURL));
                        }
                        else
                {
                   


                    return ImageSource.FromFile("nocloud.jpg");
                }


            }



        }




    }

    }

