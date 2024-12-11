using E_Commerce.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Services
{
    public interface IBasketRepository
    {
        public Task<CustomerBasket> GetBasketAsync(string Basketid);

        public Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);


        public Task<bool> DeleteBasketAsync(string Basketid);

      





    }
}
