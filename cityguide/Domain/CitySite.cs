using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Xamarin.Forms;

namespace cityguide.Domain
{

    [Table("CitySite")]
    public class CitySite
    {
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

    }
          

}
