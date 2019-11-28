using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace cityguide.Domain
{
    [Table("Neighbourhood")]
    public class Neighbourhood
    {
       public int NeighbourhoodID { get; set; }
       public string NeighbourhoodName { get; set; }

    }
}
