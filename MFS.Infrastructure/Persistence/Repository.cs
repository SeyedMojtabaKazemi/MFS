using MFS.Application.Interfaces;
using MFS.Application.Interfaces.Common;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly MFSContext _context;
        private readonly DbSet<T> Entity;

        public Repository(MFSContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        public int Insert(T entity)
        {
            Entity.Add(entity);
            _unitOfWork.SaveChange();
            return entity.Id;
        }

        public void Remove(T entity)
        {
            entity.IsDeleted = true;
            Entity.Update(entity);
            _unitOfWork.SaveChange();
        }

        public void Update(T entity)
        {
            Entity.Update(entity);
            _unitOfWork.SaveChange();
        }
    }
}
