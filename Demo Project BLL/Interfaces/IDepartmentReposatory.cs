using Demo_Project_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Project_BLL.Interfaces
{
    public interface IDepartmentReposatory
    {
        IEnumerable<Department> GetAll();
        Department Get(int id);
        int Add(Department department);
        int Update(Department department);
        int Delete(Department department);


    }
}
