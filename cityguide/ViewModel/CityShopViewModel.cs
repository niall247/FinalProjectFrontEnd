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
    public class CityShopViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyOnPropertyChanged(string v)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(v));
        }





        public bool isSelectedItem { get; set; }


       
       public CityShopping getSelectedShop(int id, CityShoppingRepository repo)
        {
            return repository.GetAllCityShops()
                                .Where(a => a.CityShoppingID == id).FirstOrDefault();
        }


        public void SetDetails(CityShopping city)
        {


            

            CityShopID = city.CityShoppingID;
            CityShopName = city.CityShoppingName;
            CityShopSubtext = city.CityShoppingSubtext;
            BudgetID = city.BudgetID;
            CityShopAddress = city.CityShoppingAddress;
            CityShopWebSite = city.CityShoppingWebSite;
            CityShopTelephone = city.CityShoppingTelephone;
            CityShopCategoryID = city.CityShoppingCategoryID;
            CityShopDescription = city.CityShoppingDescription;
            CityShopMapCoordinates = city.CityShoppingMapCoordinates;
            DisabilityAccess = city.DisabilityAccess;
            ChildFriendly = city.ChildFriendly;
            ChildDetail = city.ChildDetail;
            DisabilityDetail = city.DisabilityDetail;
            CityShopCategoryID = city.CityShoppingCategoryID;
            
            CityShopImageURL = city.CityShoppingImageURL;
            CityShopFavourite = city.CityShoppingFavourite;
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

        public CityShopViewModel(INavigation navigation, bool? isConn = null)
        {
            Navigation = navigation;
            repository = new CityShoppingRepository(new Data.CityDBContext());
            neighbourrepo = new NeighbourhoodRepository();
            reviewRepository = new CityReviewRepository();
            if(isConn != null)
            {
                isOnline = (bool)isConn;
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

            if(CityShopFavourite == null )
            {
                CityShopFavourite = true;

            }

            else if(CityShopFavourite == true)
            {

                CityShopFavourite = false;
          
            }


            else if (CityShopFavourite == false)
            {

                CityShopFavourite = true;
              
            }

            else
            {
                CityShopFavourite = false;
          
            }

            repository.AddToFavourites(CityShopID, (bool)CityShopFavourite);
            NotifyOnPropertyChanged(nameof(CityShopFavourite));
        
        }

        public  void GetReviews()
        {
            allReviewsForItem = null;

            allReviewsForItem = Task.Run(() => reviewRepository.GetReviews(CityShopID,"Sites")).Result;
            NotifyOnPropertyChanged(nameof(allReviewsForItem));
        }


        public List<CityReview> allReviewsForItem { get; set; }


        private Dictionary<bool?, string> bools { get; set; }
        public CityShoppingRepository repository { get; set; }
        public NeighbourhoodRepository neighbourrepo { get; set; }
        public CityReviewRepository reviewRepository { get; set; }


        public int CityShopID { get; set; }

        public string CityShopName { get; set; }

        public string CityShopSubtext { get; set; }

        public string CityShopDescription { get; set; }

        public string CityShopWebSite { get; set; }

        public string CityShopAddress { get; set; }
        public string CityShopTelephone { get; set; }

        public int BudgetID { get; set; }

        public int NeighbourhoodID { get; set; }

        public int TransportID { get; set; }

        public int CityShopCategoryID { get; set; }

        public bool? DisabilityAccess { get; set; }
        public bool? ChildFriendly { get; set; }


        public string CityShopImageURL { get; set; }
        public string CityShopMapCoordinates { get; set; }

        public bool? CityShopFavourite { get; set; }

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
            rev.reviewItemID = CityShopID;

            await Navigation.PushAsync(new AddReviewView(rev, Navigation));

        }

        public ImageSource CityShopImageSource
        {

            get

            {           if(isOnline == true)
                         {
                                return ImageSource.FromUri(new Uri(CityShopImageURL));
                        }
                        else
                {
                   


                    return ImageSource.FromFile("nocloud.jpg");
                }


            }



        }




    }

    }

