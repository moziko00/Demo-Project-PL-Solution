using Demo_Project_DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Project_DAL.Context
{
    public class MVCAppDemoProjectDbContext : DbContext
    {
        public MVCAppDemoProjectDbContext(DbContextOptions<MVCAppDemoProjectDbContext> options) : base(options) { }
         

        //public MVCAppDemoProjectDbContext(DbContextOptions<MVCAppDemoProjectDbContext> options) : base(options)
        //{

        //}
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
