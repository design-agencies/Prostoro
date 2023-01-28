using System.Linq.Expressions;
namespace InteriorHubServer.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> FindAll(bool trackChanges = false);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
