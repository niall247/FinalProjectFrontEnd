using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace cityguide.Domain

    {[Table("Cuisine")]
    public class Cuisine
    {

        public int CuisineID {get;set;}
        public string CuisineName {get;set;}

    }
}
