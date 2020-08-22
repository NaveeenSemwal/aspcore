using EMS.BLL.Abstract;
using EMS.DLL;
using EMS.DLL.Abstract;
using EMS.DLL.Implementation;
using EMS.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.BLL.Implement
{
    /// <summary>
    /// https://garywoodfine.com/generic-repository-pattern-net-core/
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork unitOfWork;

        IEmployeeRepository employeeRepository = null;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

            employeeRepository = unitOfWork.CreateRepository(typeof(IEmployeeRepository)) as IEmployeeRepository;
        }

        public Employee Add(Employee employee)
        {
            
            unitOfWork.Commit();
            return employee;
        }

        public Employee Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            return employeeRepository.List();
        }

        public Employee GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
