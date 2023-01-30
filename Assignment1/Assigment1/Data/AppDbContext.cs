using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assigment1.Models;
using Microsoft.EntityFrameworkCore;

namespace Assigment1.Data
{
    public class AppDbContext : DbContext
    {
        private readonly AppDbContext _db;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        
    }
}