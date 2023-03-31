using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net_Web_API.model;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_Web_API.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
        }

        public DbSet<User> users {get; set;}
    }
}