using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EntityFrameworkFirstApp
{
    class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
    }

    class EfCoreOrganizationDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=EfCoreOrganization;Trusted_Connection=True");
        }

        public DbSet<Department> Department { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
