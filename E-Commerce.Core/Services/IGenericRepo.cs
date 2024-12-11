using E_Commerce.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Services
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id );

      



        Task<T> GetEntityBySpec(ISpecificExpression<T> spec);


        Task <IEnumerable<T>> GetListOfEntityBySpec(ISpecificExpression<T> spec);

    }
}
