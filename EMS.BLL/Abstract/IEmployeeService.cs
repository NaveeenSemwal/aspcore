using EMS.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.BLL.Abstract
{
    public interface IEmployeeService
    {
        Employee GetById(int Id);
        IEnumerable<Employee> GetAll();
        Employee Add(Employee employee);
        Employee Update(Employee employee);
        Employee Delete(int Id);

    }
}
