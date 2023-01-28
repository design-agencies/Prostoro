using InteriorHubServer.Domain.Interfaces.Repositories;
using InteriorHubServer.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InteriorHubServer.Persistence.Repositories
{
    public abstract class GenericRepositoryBase<T> : IGenericRepository<T> where T : class
    {
        protected DataContext _context;
        public GenericRepositoryBase(DataContext context)
        {
            _context = context;
        }
        public IQueryable<T> FindAll(bool trackChanges = false) =>
            !trackChanges ? _context.Set<T>().AsNoTracking() : _context.Set<T>();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false) =>
            !trackChanges ? _context.Set<T>().Where(expression).AsNoTracking() : _context.Set<T>().Where(expression);
        public void Create(T entity) => _context.Set<T>().Add(entity);
        public void Update(T entity) => _context.Set<T>().Update(entity);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);
    }
}
