using Microsoft.EntityFrameworkCore;
using Ninja.Mocking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ninja.Mocking
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }


}
