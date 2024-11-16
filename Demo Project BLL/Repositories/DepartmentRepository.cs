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
    public class DepartmentRepository : IDepartmentReposatory
    {
        private readonly MVCAppDemoProjectDbContext _dbContext;
        public DepartmentRepository(MVCAppDemoProjectDbContext context )
        {
            _dbContext = context;
        }

        public int Add(Department department)
        {
            _dbContext.Departments.Add( department );
            return _dbContext.SaveChanges();
        }

        public int Delete(Department department)
        {
            _dbContext.Departments.Remove( department );
            return _dbContext.SaveChanges();
        }

        public Department Get(int id)
            => _dbContext.Departments.Where(D => D.Id == id).FirstOrDefault();

        public IEnumerable<Department> GetAll()
            => _dbContext.Departments.ToList();

        public int Update(Department department)
        {
            _dbContext.Update( department );
            return _dbContext.SaveChanges();
        }
    }
}
