using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EMS.DLL
{
    public interface IRepository<T> : IDisposable where T : class
    {
        T Get(int id);
        IList<T> List();
        IList<T> List(Expression<Func<T, bool>> expression);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
