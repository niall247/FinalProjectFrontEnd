using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Xamarin.Forms;

namespace cityguide.Domain
{

    [Table("CityEvent")]
    public class CityEvent
    {
        public int CityEventID { get; set; }

        public string CityEventName { get; set; }

        public string CityEventSubtext { get; set; }

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

        public string DisabilityDetail { get; set; }

        public string ChildDetail { get; set; }

    }
           // public UriImageSource imageSourceURI 
            //{
           // get;set;

            //}

            
               // return new UriImageSource()
                //{
                //   Uri = new Uri(CityEventImageURL);
      


   //} 

}
