using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Specifications
{
    public  interface ISpecificExpression<T> where T : class
    {
        public Expression<Func<T,bool>> Carteria { get;  }


        public List<Expression<Func<T,object>>> Includes { get; }    

        public Expression<Func<T,object>> OrderBy { get; }


        public Expression<Func<T, object>> OrderByDecending { get; }
    }
}
