using MFS.Contract;
using MFS.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MFS.Infrastructure.Persistence
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MFSContext _context;
        private readonly DbSet<T> Entity;

        public Repository(MFSContext context)
        {
            _context = context;
            Entity = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return Entity.ToList();
        }

        public IEnumerable<T> GetExpression(Expression<Func<T, bool>> expression)
        {
            return Entity.Where(expression).ToList();
        }

        public IEnumerable<T> GetExpression(Expression<Func<T, bool>> expression, string IncludeClassName)
        {
            return Entity.Include(IncludeClassName).Where(expression).ToList();
        }

        public IEnumerable<T> GetExpression(Expression<Func<T, bool>> expression, string IncludeClassName1, string IncludeClassName2)
        {
            return Entity.Include(IncludeClassName1).Include(IncludeClassName2).Where(expression).ToList();
        }

        public T Insert(T entity)
        {
            return Entity.Add(entity).Entity;
        }

        public T Remove(T entity)
        {
            entity.IsDeleted = true;
            return Entity.Update(entity).Entity;
        }

        public T Update(T entity)
        {
            return Entity.Update(entity).Entity;
        }
    }
}
