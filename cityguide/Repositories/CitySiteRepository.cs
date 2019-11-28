using System;
using cityguide.Data;
using cityguide.Domain;
using System.Linq;
using System.Collections.Generic;

namespace cityguide.Repositories
{
    public class CitySiteRepository
    {

        private CityDBContext ctx { get; set; }

        public CitySiteRepository(CityDBContext _ctx)
        {
            ctx = _ctx;
        }

        public CitySite GetSiteByID(int id)
        {

                return ctx.CitySites.Where(a => a.CitySiteID == id).FirstOrDefault();


        }

        public virtual List<CitySite> GetAllCitySites()
        {

                return ctx.CitySites.ToList();


        }


        public void AddToFavourites(int id, bool isAdd)
        {

                CitySite mySite = ctx.CitySites.Where(a => a.CitySiteID == id).FirstOrDefault();

                if(isAdd == false)
                {
                    mySite.CitySiteFavourite = false;
                }
                else
                {
                    mySite.CitySiteFavourite = true;
                }

                ctx.SaveChanges();


        }

        public List<CitySite> GetAllCitySitesFiltered(bool? isDisabledFilter, bool? isChildFilter)
        {


                IEnumerable<CitySite> sites = new List<CitySite>();


                sites = ctx.CitySites;

                if (isDisabledFilter.HasValue == true)
                 sites = sites.Where(b => b.DisabilityAccess == isDisabledFilter);

                if (isChildFilter.HasValue == true)
                    sites = sites.Where(c => c.ChildFriendly == isChildFilter);

                return sites.ToList();



        }
    }
}
