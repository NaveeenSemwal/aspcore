using EMS.DLL.Abstract;
using EMS.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EMS.DLL.Implementation
{
    /// <summary>
    /// https://www.youtube.com/watch?v=DpLQYVErKm8&t=15s
    /// https://www.youtube.com/watch?v=HHaCTg0kTbAd
    /// </summary>
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly EmsDbContext context;

        public EmployeeRepository(EmsDbContext context) : base(context)
        {
            this.context = context;
        }

        public void Print()
        {
            throw new NotImplementedException();
        }

        // TODO : Use proc here and use procedure.
        public override Employee Get(int id)
        {
            return context.Employees.FromSqlRaw("spGetAllEmployees").FirstOrDefault(a => a.EmployeeId == id);
        }

        /// <summary>
        /// Create this proc and add parameters
        /// </summary>
        /// <param name="entity"></param>
        public override void Insert(Employee entity)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@name", entity.Name);
            param[0] = new SqlParameter("@email", entity.Email);
            param[0] = new SqlParameter("@departmentId", entity.DepartmentId);

            context.Database.ExecuteSqlRaw("spInsertUpdateEmployee", param);
        }

        public override IList<Employee> List()
        {
            //var employees = context.Employees.FromSqlRaw("spGetAllEmployees").ToList();

            return context.Employees.Include(x => x.Department).ToList();
        }
    }
}
