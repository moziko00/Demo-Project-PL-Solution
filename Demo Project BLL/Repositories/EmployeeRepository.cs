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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeReposatory
    {
        public EmployeeRepository(MVCAppDemoProjectDbContext dbContext) :base(dbContext)
        {
            
        }
        public IQueryable<Employee> GetEmployeeByDepartmentName(string departmentName)
        {
            throw new NotImplementedException();
        }

    }
}
