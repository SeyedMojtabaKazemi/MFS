using MFS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MFS.Application.Interfaces.Common
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetExpression(Expression<Func<T, bool>> expression);
        int Insert(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
