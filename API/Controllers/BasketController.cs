using API.Dtos;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository,IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasketById(string id)
        {
            var basket =await _basketRepository.GetBasketAsync(id);
            return Ok(basket ?? new CustomerBasket(id));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBasket(CustomerBasketDto customerBasketDto)
        {
            return Ok(await _basketRepository.UpdateBasketAsync(_mapper.Map<CustomerBasketDto, CustomerBasket>(customerBasketDto)));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(string id)
        {
            return Ok(await _basketRepository.DeleteBasketAsync(id));
        }
    }
}
