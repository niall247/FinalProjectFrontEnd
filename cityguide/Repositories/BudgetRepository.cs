using System;
using cityguide.Data;
using cityguide.Domain;
using System.Linq;
using System.Collections.Generic;

namespace cityguide.Repositories
{
    public class BudgetRepository
    {

        private CityDBContext _ctx { get; set; }

        public BudgetRepository(CityDBContext ctx)
        {
           
            _ctx = ctx;
        }


        public string GetBudgetName(int id)
        {
            using (_ctx)
            //using (CityDBContext ctx = new CityDBContext())
            {
                return _ctx.Budgets
                .Where(a => a.BudgetID == id)
                    .Select(b => b.BudgetName).FirstOrDefault();
            }

        }


    }
}
