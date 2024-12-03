using Demo_Project_BLL.Interfaces;
using Demo_Project_DAL.Context;
using Demo_Project_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Project_BLL.Repositories
{
    public class DepartmentRepository : GenericRepository<Department> ,IDepartmentReposatory 
    {
        public DepartmentRepository(MVCAppDemoProjectDbContext dbContext) :base(dbContext)
        {
            
        }
    }
}
