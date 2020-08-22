using EMS.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.DLL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> CreateRepository<T>() where T : class;

        int Commit();

        object CreateRepository(Type type);
    }
}
