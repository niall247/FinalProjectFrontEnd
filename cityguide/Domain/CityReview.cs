using System;
namespace cityguide.Domain
{
    public class CityReview
    {
       
        public int reviewID { get; set; }
        public string ReviewCategory { get; set; }
        public int reviewItemID { get; set; }
        public string reviewRating { get; set; }
        public string reviewText { get; set; }

    }
}
