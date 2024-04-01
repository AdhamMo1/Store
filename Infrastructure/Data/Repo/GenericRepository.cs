using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public virtual Task<bool> AddAsync(T Entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T?> FindByIdAsync(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual bool Update(T Entity)
        {
            throw new NotImplementedException();
        }
    }
}
