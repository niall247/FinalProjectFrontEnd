using System;
using cityguide.Data;
using cityguide.Domain;
using System.Linq;
using System.Collections.Generic;

namespace cityguide.Repositories
{
    public class CityEventRepository
    {

        private CityDBContext ctx { get; set; }


        public CityEventRepository(CityDBContext _ctx)
        {


           ctx = _ctx;     



        }
        public CityEvent GetEventByID(int id)
        {

                return ctx.CityEvents.Where(a => a.CityEventID == id).FirstOrDefault();


        }

        public virtual List<CityEvent> GetAllCityEvents()
        {

                return ctx.CityEvents.ToList();


        }


        public void AddToFavourites(int id, bool isAdd)
        {

                CityEvent myEvent = ctx.CityEvents.Where(a => a.CityEventID == id).FirstOrDefault();

                if(isAdd == false)
                {
                    myEvent.CityEventFavourite = false;
                }
                else
                {
                    myEvent.CityEventFavourite = true;
                }

                ctx.SaveChanges();


        }

        public List<CityEvent> GetAllCityEventsFiltered(bool? isDisabledFilter, bool? isChildFilter)
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
