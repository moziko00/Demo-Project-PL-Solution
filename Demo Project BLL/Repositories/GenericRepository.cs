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
    public class GenericRepository<T> :IGenericRepository<T> where T : class
    {
        private readonly MVCAppDemoProjectDbContext _dbContext;
        public GenericRepository(MVCAppDemoProjectDbContext context)
        {
            _dbContext = context;
        }

        public int Add(T item)
        {
            _dbContext.Set<T>().Add(item);
            return _dbContext.SaveChanges();
        }

        public int Delete(T item)
        {
            _dbContext.Set<T>().Remove(item);
            return _dbContext.SaveChanges();
        }

        public T Get(int id)
            //=> _dbContext.Set<T>().Where(D => D.Id == id).FirstOrDefault();
            => _dbContext.Set<T>().Find(id);

        public IEnumerable<T> GetAll()
            => _dbContext.Set<T>().ToList();

        public int Update(T item)
        {
            _dbContext.Update(item);
            return _dbContext.SaveChanges();
        }
    }
}
