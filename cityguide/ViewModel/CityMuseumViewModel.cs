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
    public class CityMuseumViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyOnPropertyChanged(string v)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(v));
        }





        public bool isSelectedItem { get; set; }


        public CityMuseum getCityDetail(int ceID, CityMuseumRepository repo)
        {
            return repo.GetAllCityMuseums()
                    .Where(a => a.CityMuseumID == ceID).FirstOrDefault();
        }




        public void SetDetails(CityMuseum museum)
        {



            CityMuseumID = museum.CityMuseumID;
            CityMuseumName = museum.CityMuseumName;
            CityMuseumSubtext = museum.CityMuseumSubtext;
            CityMuseumCost = museum.CityMuseumCost;
            CityMuseumAddress = museum.CityMuseumAddress;
            CityMuseumWebSite = museum.CityMuseumWebSite;
            CityMuseumTelephone = museum.CityMuseumTelephone;
            CityMuseumCategoryID = museum.CityMuseumCategoryID;
            CityMuseumDescription = museum.CityMuseumDescription;
            CityMuseumMapCoordinates = museum.CityMuseumMapCoordinates;
            DisabilityAccess = museum.DisabilityAccess;
            ChildFriendly = museum.ChildFriendly;
            ChildDetail = museum.ChildDetail;
            DisabilityDetail = museum.DisabilityDetail;
            CityMuseumImageURL = museum.CityMuseumImageURL;
            CityMuseumFavourite = museum.CityMuseumFavourite;
            NeighbourhoodID = museum.NeighbourhoodID;
            CityMuseumID = museum.CityMuseumID;
            TransportID = museum.TransportID;
        
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

        public CityMuseumViewModel(INavigation navigation, bool? IsConnected =null)
        {
            Navigation = navigation;
            repository = new CityMuseumRepository(new CityDBContext());
            neighbourrepo = new NeighbourhoodRepository();
            reviewRepository = new CityReviewRepository();
            if(IsConnected !=null)
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

            if(CityMuseumFavourite == null )
            {
                CityMuseumFavourite = true;

            }

            else if(CityMuseumFavourite == true)
            {

                CityMuseumFavourite = false;
          
            }


            else if (CityMuseumFavourite == false)
            {

                CityMuseumFavourite = true;
              
            }

            else
            {
                CityMuseumFavourite = false;
          
            }

            repository.AddToFavourites(CityMuseumID, (bool)CityMuseumFavourite);
            NotifyOnPropertyChanged(nameof(CityMuseumFavourite));
        
        }

        public  void GetReviews()
        {
            allReviewsForItem = null;

            allReviewsForItem = Task.Run(() => reviewRepository.GetReviews(CityMuseumID,"Museums")).Result;
            NotifyOnPropertyChanged(nameof(allReviewsForItem));
        }


        public List<CityReview> allReviewsForItem { get; set; }


        private Dictionary<bool?, string> bools { get; set; }
        public CityMuseumRepository repository { get; set; }
        public NeighbourhoodRepository neighbourrepo { get; set; }
        public CityReviewRepository reviewRepository { get; set; }


        public int CityMuseumID { get; set; }

        public string CityMuseumName { get; set; }

        public string CityMuseumSubtext { get; set; }

        public string CityMuseumDescription { get; set; }

        public string CityMuseumWebSite { get; set; }

        public string CityMuseumAddress { get; set; }
        public string CityMuseumTelephone { get; set; }

        public string CityMuseumCost { get; set; }

        public int NeighbourhoodID { get; set; }

        public int TransportID { get; set; }

        public int CityMuseumCategoryID { get; set; }

        public bool? DisabilityAccess { get; set; }
        public bool? ChildFriendly { get; set; }


        public string CityMuseumImageURL { get; set; }
        public string CityMuseumMapCoordinates { get; set; }

        public bool? CityMuseumFavourite { get; set; }

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
            rev.ReviewCategory = "Museums";
            rev.reviewItemID = CityMuseumID;

            await Navigation.PushAsync(new AddReviewView(rev, Navigation));

        }

        public ImageSource CityMuseumImageSource
        {

            get

            {           if(isOnline == true)
                         {
                                return ImageSource.FromUri(new Uri(CityMuseumImageURL));
                        }
                        else
                {
                   


                    return ImageSource.FromFile("nocloud.jpg");
                }


            }



        }




    }

    }

