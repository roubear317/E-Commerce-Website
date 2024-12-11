using E_Commerce.Core.Model;
using E_Commerce.Core.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_commerce.EF.Repos
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public Task<bool> DeleteBasketAsync(string Basketid)
        {
            return _database.KeyDeleteAsync(Basketid);
        }

        public async Task<CustomerBasket> GetBasketAsync(string Basketid)
        {
            var data = await _database.StringGetAsync(Basketid);

            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var created = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket),TimeSpan.FromDays(30));

            return await GetBasketAsync(basket.Id);
        }
    }
}
