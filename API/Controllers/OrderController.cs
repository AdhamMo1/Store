using API.Dtos;
using API.Errors;
using API.Extentions;
using AutoMapper;
using Core.Interfaces;
using Core.Models.OrderAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepo,IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Order>> CreateOrder (OrderDto orderDto)
        {
            var email = HttpContext.User.RetriveEmail();
            var address=_mapper.Map<AddressDto,Address>(orderDto.Address);
            var order =await _orderRepo.CreateOrderAsync(email, orderDto.DeliveryMethodId, orderDto.BasketId, address);
            if(order == null)
            {
                return BadRequest(new ApiResponse(400,"Failed while create order"));
            }
            return order;
        }
    }
}
