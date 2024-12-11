using E_Commerce.Core.Model;
using E_Commerce.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : BaseController
    {
        private readonly IBasketRepository _basket;

        public BasketController(IBasketRepository basket)
        {
            _basket = basket;
        }


        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {


            var basket = await _basket.GetBasketAsync(id);


            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var UpdatedBasket = await _basket.UpdateBasketAsync(basket);

            return Ok(UpdatedBasket);   


        }

        [HttpDelete]

        public async Task DeleteBasketAsync(string id)
        {


            await _basket.DeleteBasketAsync(id);    
        }





    }
}
