using System;
using cityguide.Data;
using cityguide.Domain;
using System.Linq;
using System.Collections.Generic;

namespace cityguide.Repositories
{
    public class CityRestaurantRepository
    {
        private CityDBContext ctx { get; set; }

        public CityRestaurantRepository(CityDBContext _ctx)
        {
            ctx = _ctx;
        
        }


        public CityRestaurant GetRestaurantByID(int id)
        {
          
                return ctx.CityRestaurants.Where(a => a.CityRestaurantID == id).FirstOrDefault();
           

        }

        public virtual List<CityRestaurant> GetAllCityRestaurants()
        {

                return ctx.CityRestaurants.ToList();
           

        }
      

        public void AddToFavourites(int id, bool isAdd)
        {

                CityRestaurant myRestaurant = ctx.CityRestaurants.Where(a => a.CityRestaurantID == id).FirstOrDefault();

                if(isAdd == false)
                {
                    myRestaurant.CityRestaurantFavourite = false;
                }
                else
                {
                    myRestaurant.CityRestaurantFavourite = true;
                }

                ctx.SaveChanges();


        }

        public List<CityRestaurant> GetAllCityRestaurantsFiltered(bool? isDisabledFilter, bool? isChildFilter, bool? Vegan, bool? Kosher, bool? GlutenFree, bool? DairyFree, bool? Vegetarian , bool? Halal)
        {

                IEnumerable<CityRestaurant> rests = new List<CityRestaurant>();


                rests = ctx.CityRestaurants;

                if (isDisabledFilter.HasValue == true)
                 rests = rests.Where(b => b.DisabilityAccess == isDisabledFilter);

                if (isChildFilter.HasValue == true)
                    rests = rests.Where(c => c.ChildFriendly == isChildFilter);

                if (Vegan.HasValue == true)
                    rests = rests.Where(c => c.Vegan == Vegan);

                if (Vegetarian.HasValue == true)
                    rests = rests.Where(c => c.Vegetarian == Vegetarian);

                if (Kosher.HasValue == true)
                    rests = rests.Where(c => c.Kosher == Kosher);


                if (GlutenFree.HasValue == true)
                    rests = rests.Where(c => c.GlutenFree == GlutenFree);

                if (DairyFree.HasValue == true)
                    rests = rests.Where(c => c.DairyFree == DairyFree);

                if (Halal.HasValue == true)
                    rests = rests.Where(c => c.Halal == Halal);

                return rests.ToList();

          

        }
    }
}
