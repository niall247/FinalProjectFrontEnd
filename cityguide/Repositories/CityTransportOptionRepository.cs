using System;
using cityguide.Data;
using cityguide.Domain;
using System.Linq;
using System.Collections.Generic;

namespace cityguide.Repositories
{
    public class CityTransportOptionRepository
    {

        CityDBContext ctx { get; set; }

        public CityTransportOptionRepository(CityDBContext _ctx)
        {
            ctx = _ctx;
        }

        public CityTransportOption GetCityTransportOptionbyID(int id)
        {
            
                return ctx.CityTransportOptions.Where(a => a.CityTransportOptionID == id).FirstOrDefault();
            

        }

        public virtual List<CityTransportOption> GetAllCityTransportOptions()
        {
            
                return ctx.CityTransportOptions.ToList();

        }


       
    }
}
