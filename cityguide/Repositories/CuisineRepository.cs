using System;
using cityguide.Data;
using cityguide.Domain;
using System.Linq;
using System.Collections.Generic;

namespace cityguide.Repositories
{
    public class CuisineRepository
    {

        private CityDBContext _ctx { get; set; }

        public CuisineRepository(CityDBContext ctx)
        {

            _ctx = ctx;
        }

        public string GetCuisineName(int id)
        {
            
                return _ctx.Cuisines
                .Where(a => a.CuisineID == id)
                    .Select(b => b.CuisineName).FirstOrDefault();
            

        }


    }
}
