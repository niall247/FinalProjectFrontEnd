using System;
using cityguide.Data;
using cityguide.Domain;
using System.Linq;
using System.Collections.Generic;

namespace cityguide.Repositories
{
    public class CityShoppingRepository
    {
        private CityDBContext ctx { get; set; }


        public CityShoppingRepository(CityDBContext _ctx)
        {
            ctx = _ctx;
        }

        public CityShopping GetSiteByID(int id)
        {
            
                return ctx.CityShops.Where(a => a.CityShoppingID == id).FirstOrDefault();
            

        }

        public virtual List<CityShopping> GetAllCityShops()
        {
            
                return ctx.CityShops.ToList();
            

        }


        public void AddToFavourites(int id, bool isAdd)
        {
            
                CityShopping mySite = ctx.CityShops.Where(a => a.CityShoppingID == id).FirstOrDefault();

                if(isAdd == false)
                {
                    mySite.CityShoppingFavourite = false;
                }
                else
                {
                    mySite.CityShoppingFavourite = true;
                }

                ctx.SaveChanges();
            

        }

        public List<CityShopping> GetAllCityShopsFiltered(bool? isDisabledFilter, bool? isChildFilter)
        {
            
                IEnumerable<CityShopping> sites = new List<CityShopping>();


                sites = ctx.CityShops;

                if (isDisabledFilter.HasValue == true)
                 sites = sites.Where(b => b.DisabilityAccess == isDisabledFilter);

                if (isChildFilter.HasValue == true)
                    sites = sites.Where(c => c.ChildFriendly == isChildFilter);

                return sites.ToList();

            }

        
    }
}
