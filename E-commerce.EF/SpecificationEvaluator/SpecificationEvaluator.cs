using E_Commerce.Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.EF.SpecificationEvaluator
{
   public class SpecificationEvaluator<T> where T : class
    {
       public  static IQueryable<T> GetQuery(IQueryable<T> query,ISpecificExpression<T> spec)
        {
            var Query = query;

            if(query != null)
            {
                if (spec.Carteria != null) 
                {
                    Query = Query.Where(spec.Carteria);
                }

                if (spec.OrderBy != null)
                {
                    Query = Query.OrderBy(spec.OrderBy);
                }

                if (spec.OrderByDecending != null)
                {
                    Query = Query.OrderByDescending(spec.OrderByDecending);
                }





            }

            Query = spec.Includes.Aggregate(Query, (current, include) => current.Include(include));

           

            return Query;
        }






    }
}
