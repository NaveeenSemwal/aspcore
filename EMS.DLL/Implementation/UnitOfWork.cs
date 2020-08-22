using EMS.DLL.Abstract;
using EMS.DLL.Implementation;
using EMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMS.DLL
{
    /// <summary>
    /// http://janholinka.net/Blog/Article/9#:~:text=Repository%20pattern%20is%20an%20abstraction,data%20layer%20to%20business%20layer.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<string, object> repositories;
        private readonly EmsDbContext emsDbContext;

      


        public UnitOfWork(EmsDbContext emsDbContext)
        {
            this.emsDbContext = emsDbContext;
        }

       

        public int Commit()
        {
            return emsDbContext.SaveChanges();
        }

        public void Dispose()
        {
            emsDbContext.Dispose();
        }

        /// <summary>
        /// http://csharpdocs.com/generic-repository-pattern-and-unit-of-work/
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>

        public IRepository<T> CreateRepository<T>() where T : class
        {
            var type = typeof(T).Name;

            if(repositories==null)
            {
                repositories = new Dictionary<string, object>();
            }
            if (!repositories.ContainsKey(type))
            {
                var repositoriesType = typeof(BaseRepository<>);

                var repositoryInstance = Activator.CreateInstance(repositoriesType.MakeGenericType(typeof(T)), emsDbContext);
                repositories.Add(type, repositoryInstance);
            }
            return (BaseRepository<T>)repositories[type];
        }

        public object CreateRepository(Type type)
        {

          var implementedRepository=   AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
               .Where(x => type.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).FirstOrDefault();

            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            if (!repositories.ContainsKey(type.Name))
            {
                var repositoryInstance = Activator.CreateInstance(implementedRepository, emsDbContext);
                repositories.Add(type.Name, repositoryInstance);
            }

            // add some other logic that changes instance
            return repositories[type.Name];
        }
    }
}
