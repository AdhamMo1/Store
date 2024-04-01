using API.Dtos;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
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
        public async Task<IActionResult> ListAllAsync()
        {
            var Products = await _productRepo.GetAllAsync();
                
            return Ok(_mapper.Map<IEnumerable<Product>,IEnumerable<ProductDto>>(Products));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var Product = await _productRepo.FindByIdAsync(id);
            return Ok(Product is not null? _mapper.Map<Product, ProductDto>(Product) : NotFound());
        }
    }
}
