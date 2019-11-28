using System;
using cityguide.Data;
using cityguide.Domain;
using System.Linq;
using System.Collections.Generic;

namespace cityguide.Repositories
{
    public class CityMuseumRepository
    {

        private CityDBContext ctx { get; set; }

        public CityMuseumRepository(CityDBContext _ctx)
        {


            ctx = _ctx;



        }

        public CityMuseum GetMuseumByID(int id)
        {

                return ctx.CityMuseums.Where(a => a.CityMuseumID == id).FirstOrDefault();


        }

        public virtual List<CityMuseum> GetAllCityMuseums()
        {

                return ctx.CityMuseums.ToList();
           

        }


        public void AddToFavourites(int id, bool isAdd)
        {

                CityMuseum mySite = ctx.CityMuseums.Where(a => a.CityMuseumID == id).FirstOrDefault();

                if(isAdd == false)
                {
                    mySite.CityMuseumFavourite = false;
                }
                else
                {
                    mySite.CityMuseumFavourite = true;
                }

                ctx.SaveChanges();
           

        }

        public List<CityMuseum> GetAllCityMuseumsFiltered(bool? isDisabledFilter, bool? isChildFilter)
        {
           

                IEnumerable<CityMuseum> museums = new List<CityMuseum>();


                museums = ctx.CityMuseums;

                if (isDisabledFilter.HasValue == true)
                    museums = museums.Where(b => b.DisabilityAccess == isDisabledFilter);

                if (isChildFilter.HasValue == true)
                    museums = museums.Where(c => c.ChildFriendly == isChildFilter);

                return museums.ToList();



        }
    }
}
