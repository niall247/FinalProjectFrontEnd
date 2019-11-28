using System;
using cityguide.Data;
using cityguide.Domain;
using System.Linq;
using System.Collections.Generic;

namespace cityguide.Repositories
{
    public class NeighbourhoodRepository
    {
        public string GetNeighbourhoodName(int id)
        {
            using (CityDBContext ctx = new CityDBContext())
            {
                return ctx.Neighbourhoods
                .Where(a => a.NeighbourhoodID == id)
                    .Select(b => b.NeighbourhoodName).FirstOrDefault();
            }

        }

        public List<CityEvent> GetAllCityEvents()
        {
            using (CityDBContext ctx = new CityDBContext())
            {
                return ctx.CityEvents.ToList();
            }

        }


        public List<CityEvent> GetAllCityEventsFiltered(bool? isDisabledFilter, bool? isChildFilter)
        {
            using (CityDBContext ctx = new CityDBContext())
            {

                IEnumerable<CityEvent> events = new List<CityEvent>();


                events = ctx.CityEvents;

                if (isDisabledFilter.HasValue == true)
                 events =  events.Where(b => b.DisabilityAccess == isDisabledFilter);

                if (isChildFilter.HasValue == true)
                    events = events.Where(c => c.ChildFriendly == isChildFilter);

                return events.ToList();

            }

        }
    }
}
