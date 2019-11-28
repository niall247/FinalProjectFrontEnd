using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace cityguide.Domain
{
    [Table("CityShoppingCategory")]
    public class CityShoppingCategory
    {
       public int CityShoppingCategoryID { get; set; }
       public string CityShoppingCategoryName { get; set; }

    }
}
