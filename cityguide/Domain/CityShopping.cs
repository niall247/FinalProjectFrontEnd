using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Xamarin.Forms;

namespace cityguide.Domain
{

    [Table("CityShopping")]
    public class CityShopping
    {
        public int CityShoppingID { get; set; }

        public string CityShoppingName { get; set; }

        public string CityShoppingSubtext { get; set; }

        public string CityShoppingDescription { get; set; }
   
        public string CityShoppingWebSite { get; set; }

        public string CityShoppingAddress { get; set; }
        public string CityShoppingTelephone { get; set; }

        public int BudgetID { get; set; }

        public int NeighbourhoodID { get; set; }

        public int TransportID { get; set; }

        public int CityShoppingCategoryID { get; set; }

        public bool? DisabilityAccess { get; set; }
        public bool? ChildFriendly { get; set; }


        public string CityShoppingImageURL { get; set; }
        public string CityShoppingMapCoordinates { get; set; }

        public bool? CityShoppingFavourite { get; set; }

        public string DisabilityDetail { get; set; }

        public string ChildDetail { get; set; }

    }
           

}
