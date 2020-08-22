using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EMS.DLL
{
    /// <summary>
    /// https://garywoodfine.com/generic-repository-pattern-net-core/#:~:text=DbContext%2Cwithin%20Entity%20Framework%20is%20an%20example%20of%20the,for%20DbContextto%20see%20how%20it%20all%20works%20together
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public  class BaseRepository<T> : IRepository<T> where T : class
    {

        private DbContext context;
        private DbSet<T> dbSet;

        public BaseRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }


        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public virtual T Get(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual IList<T> List()
        {
            return dbSet.ToList();
        }

        public IList<T> List(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();

        }
    }
}
