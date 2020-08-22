using EMS.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.DLL.Abstract
{
    // https://www.youtube.com/watch?v=qJmEI2LtXIY&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=49
    public interface IEmployeeRepository : IRepository<Employee>
    {
        //Employee GetById(int Id);
        //IEnumerable<Employee> GetAll();
        //Employee Add(Employee employee);
        //Employee Update(Employee employee);
        //Employee Delete(int Id);

        void Print();

    }
}
