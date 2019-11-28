using System;
using cityguide.Data;
using cityguide.Domain;
using System.Linq;
using System.Collections.Generic;

namespace cityguide.Repositories
{
    public class CityMuseumCategoryRepository
    {
        private CityDBContext ctx { get; set; }

       public CityMuseumCategoryRepository(CityDBContext _ctx)
        {
               ctx = _ctx;     
        }


        public string GetMuseumCategory(int id)
        {

                return ctx.CityMuseumCategories
                .Where(a => a.CityMuseumCategoryID == id)
                .Select(b => b.CityMuseumCategoryName).FirstOrDefault();

        }


    }
}
