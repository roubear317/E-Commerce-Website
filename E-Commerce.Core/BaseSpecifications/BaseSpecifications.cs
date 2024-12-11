using E_Commerce.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.BaseSpecifications
{
    public class BaseSpecifications<T> : ISpecificExpression<T> where T : class

    {
        public BaseSpecifications()
        {

        }
        public BaseSpecifications(Expression<Func<T, bool>> carteria)
        {
            Carteria = carteria;
        }
        public Expression<Func<T, bool>> Carteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy  { get; private set; }

        public Expression<Func<T, object>> OrderByDecending { get; private set; }
        protected void AddExpression (Expression<Func<T, object>> expression)
        {
            Includes.Add(expression);
        }

        protected void OrderExpression(Expression<Func<T, object>> orderBy)
        {
            OrderBy = orderBy;
        }


        protected void OrderExpressionByDecending(Expression<Func<T, object>> orderByDecinding)
        {
            OrderByDecending = orderByDecinding;
        }


    }
}
