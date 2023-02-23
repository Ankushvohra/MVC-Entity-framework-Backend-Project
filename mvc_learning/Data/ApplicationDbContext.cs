using mvc_learning.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvc_learning.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext():base("cn")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}