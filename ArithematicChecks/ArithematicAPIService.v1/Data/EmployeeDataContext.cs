using ArithematicAPIService.v1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArithematicAPIService.v1.Data
{
    public class EmployeeDataContext:DbContext
    {
        public EmployeeDataContext(DbContextOptions<EmployeeDataContext> options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
