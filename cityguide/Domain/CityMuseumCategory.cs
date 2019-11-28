using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace cityguide.Domain
{
    [Table("CityMuseumCategory")]
    public class CityMuseumCategory
    {
       public int CityMuseumCategoryID { get; set; }
       public string CityMuseumCategoryName { get; set; }

    }
}
