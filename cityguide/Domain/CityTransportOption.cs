using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Xamarin.Forms;

namespace cityguide.Domain
{

    [Table("CityTransportOption")]
    public class CityTransportOption
    {
        public int CityTransportOptionID { get; set; }

        public string CityTransportTitle { get; set; }

        public string CityTransportSubTitle { get; set; }

        public string CityTransportDescription { get; set; }

        public string CityTransportMapImage { get; set; }

        public string CityTransportItemImage { get; set; }

        public string DisabilityDetail { get; set; }



    }
         

}
