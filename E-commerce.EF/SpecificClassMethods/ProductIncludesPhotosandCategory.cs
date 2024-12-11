using E_commerce.EF.Model;
using E_Commerce.Core.BaseSpecifications;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.EF.SpecificClassMethods
{
    public class ProductIncludesPhotosandCategory :BaseSpecifications<Product> 
    {

        public ProductIncludesPhotosandCategory(string sort,int? CategoryID) :
            base( x => !CategoryID.HasValue || x.CategoryId == CategoryID)
        {
            AddExpression(x=>x.category);

            AddExpression(x => x.photo);

            OrderExpression(x=>x.Name);


            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "PriceAsc":
                        OrderExpression(x => x.Price);
                        break;
                    case "PriceDec":
                       OrderExpressionByDecending(x => x.Price);
                        break;

                    default: OrderExpression(x => x.Name);
                        break;

                }
            }

        }

        public ProductIncludesPhotosandCategory(int id) : base(x=>x.Id==id)
        {

            AddExpression(x => x.category);

            AddExpression(x => x.photo);
        }


        public ProductIncludesPhotosandCategory(string name) :
            base(x => x.category.Name.ToLower() == name.ToLower())
        {

            AddExpression(x => x.category);

            AddExpression(x => x.photo);
        }

    }
}
