using Demo_Project_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Project_BLL.Interfaces
{
    public interface IEmployeeReposatory : IGenericRepository<Employee>
    {
        IQueryable <Employee> GetEmployeeByDepartmentName(string departmentName);
    }
}
