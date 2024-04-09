using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository ProductRepo , IMapper mapper)
        {
            _productRepo = ProductRepo;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ListAllAsync([FromQuery]string? sort , [FromQuery] int? brandId , [FromQuery] int? typeId,[FromQuery] int? pageNumber,[FromQuery] int? pageSize)
        {
            var Products =await _productRepo.GetAllAsync(sort, brandId, typeId, pageNumber, pageSize);
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        Products = Products.OrderBy(x => x.Price).ToList();
                        break;
                    case "priceDesc":
                        Products = Products.OrderByDescending(x => x.Price).ToList();
                        break;
                    default:
                        return BadRequest(" 400 , sort => you must choose between priceAsc , priceDesc");

                }
            }
            return Ok(_mapper.Map<IEnumerable<Product>,IEnumerable<ProductDto>>(Products));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var Product = await _productRepo.FindByIdAsync(id);
            return Ok(Product is not null? _mapper.Map<Product, ProductDto>(Product) : NotFound(new ApiResponse(404)));
        }
    }
}
