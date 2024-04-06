using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repo
{
    public class ProductRepo : GenericRepository<Product> , IProductRepository
    {
        public ProductRepo(AppDbContext context) : base(context)
        {
        }
        public override async Task<IReadOnlyList<Product>> GetAllAsync( string? sort, int? brandId, int? typeId, int? pageNumber, int? pageSize)
        {
            var Products = await _context.Products.Include(x => x.ProductType).Include(x => x.ProductBrand).ToListAsync();
            
            if (brandId is not null)
            {
                Products = Products.Where(x => x.ProductBrandId == brandId).ToList();
            }
            if (typeId is not null)
            {
                Products = Products.Where(x => x.ProductTypeId == typeId).ToList();
            }
            if(pageNumber is not null && pageSize is not null)
            {
                Products = Products.Skip((int)((pageNumber - 1) * pageSize)).Take((int)pageSize).ToList();
            }
            return Products;
        }
        public override async Task<Product?> FindByIdAsync(int Id)
        {
            return await _context.Products.Include(x=>x.ProductType).Include(x=> x.ProductBrand).Where(x=>x.Id == Id).FirstOrDefaultAsync();
        }

    }
}
