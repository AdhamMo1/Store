using Core.Models;
namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        IProductRepository Products { get; }
        Task<int> Complete();
    }
}