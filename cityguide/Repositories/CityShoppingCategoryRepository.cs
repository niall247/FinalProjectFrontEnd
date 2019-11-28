using System;
using cityguide.Data;
using cityguide.Domain;
using System.Linq;
using System.Collections.Generic;

namespace cityguide.Repositories
{
    public class CityShoppingCategoryRepository
    {
        public string GetShoppingCategory(int id)
        {
            using (CityDBContext ctx = new CityDBContext())
            {
                return ctx.CityShoppingCategories
                .Where(a => a.CityShoppingCategoryID == id)
                    .Select(b => b.CityShoppingCategoryName).FirstOrDefault();
            }

        }


    }
}
