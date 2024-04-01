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
        public override async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            return await _context.Products.Include(x=>x.ProductType).Include(x=>x.ProductBrand).ToListAsync();
        }
        public override async Task<Product?> FindByIdAsync(int Id)
        {
            return await _context.Products.Include(x=>x.ProductType).Include(x=> x.ProductBrand).Where(x=>x.Id == Id).FirstOrDefaultAsync();
        }

    }
}
