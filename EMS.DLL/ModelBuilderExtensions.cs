using EMS.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.DLL
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Department>().HasData(
               new Department { DepartmentId = 1, Name = "Hamlet" },
               new Department { DepartmentId = 2, Name = "King Lear" },
               new Department { DepartmentId = 3, Name = "Othello" }
           );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    Name = "William",
                    Email = "Shakespeare",
                    DepartmentId = 1
                }
            );


        }
    }
}
