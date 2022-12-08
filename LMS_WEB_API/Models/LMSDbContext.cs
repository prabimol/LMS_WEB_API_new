using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_WEB_API.Models
{
    public class LMSDbContext : DbContext
    {
        public LMSDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveDetails> LeaveDetails { get; set; }
    }
}
