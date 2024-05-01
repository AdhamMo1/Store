using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T?> FindByIdAsync(int Id);

        void Add(T Entity);

        void Update(T Entity);

        bool Delete(int Id);
    }
}
