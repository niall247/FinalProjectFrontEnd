using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Xamarin.Forms;

namespace cityguide.Domain
{

    [Table("CityRestaurant")]
    public class CityRestaurant
    {
      
        public int CityRestaurantID { get; set; }

        public string CityRestaurantName { get; set; }

        public string CityRestaurantSubtext { get; set; }

        public string CityRestaurantDescription { get; set; }
   
        public string CityRestaurantWebSite { get; set; }

        public string CityRestaurantAddress { get; set; }
        public string CityRestaurantTelephone { get; set; }

        public string CityRestaurantOpeningHours { get; set; }

    

        public int NeighbourhoodID { get; set; }

        public int CuisineID { get; set; }

        public int BudgetID { get; set; }

        public int TransportID { get; set; }

     

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

    }
           

}
