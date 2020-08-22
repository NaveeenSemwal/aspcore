using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Entity
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
