using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasketById(string id)
        {
            var basket =await _basketRepository.GetBasketAsync(id);
            return Ok(basket ?? new CustomerBasket(id));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBasket(CustomerBasket customerBasket)
        {
            
            return Ok(await _basketRepository.UpdateBasketAsync(customerBasket));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(string id)
        {
            return Ok(await _basketRepository.DeleteBasketAsync(id));
        }
    }
}
