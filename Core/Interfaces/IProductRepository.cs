using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepository 
    {
         Task<IReadOnlyList<Product>> GetAllAsync(string? sort, int? brandId, int? typeId, int? pageNumber, int? pageSize);
         Task<Product?> FindByIdAsync(int Id);

    }
}
