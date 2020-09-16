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

        protected internal new void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;port=5432;user id=service_account;password=service;database=employee_db;pooling=true");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
