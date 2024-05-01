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
        public virtual void Add(T Entity)
        {
            _context.Set<T>().Add(Entity);
        }

        public virtual bool Delete(int Id)
        {
            var entity = _context.Set<T>().Find(Id);
            if(entity is null)
            {
                return false;
            }
            _context.Set<T>().Remove(entity);
            return true;
            
        }

        public virtual async Task<T?> FindByIdAsync(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual void Update(T Entity)
        {
            _context.Set<T>().Attach(Entity);
            _context.Entry(Entity).State = EntityState.Modified;
        }
    }
}
