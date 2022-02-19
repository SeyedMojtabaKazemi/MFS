using MFS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MFS.Contract
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetExpression(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetExpression(Expression<Func<T, bool>> expression, string IncludeClassName);
        IEnumerable<T> GetExpression(Expression<Func<T, bool>> expression, string IncludeClassName1, string IncludeClassName2);
        T Insert(T entity);
        T Update(T entity);
        T Remove(T entity);
    }
}
