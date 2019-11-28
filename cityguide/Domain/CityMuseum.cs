using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Xamarin.Forms;

namespace cityguide.Domain
{

    [Table("CityMuseum")]
    public class CityMuseum
    {
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

    }
        

}
