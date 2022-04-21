using ePizzaHubRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHubRepositories.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        // Creating the object for DbCOntext of EntityFramework to call the CRUD operations methods 
        protected DbContext _db;

        public Repository(DbContext db)
        {
            _db = db;
        }
        public void Add(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
        }

        public void Delete(object id)
        {
          TEntity entity =  _db.Set<TEntity>().Find(id);
            if(entity != null)
            {
                _db.Set<TEntity>().Remove(entity);
            }
        }
        public TEntity Find(object id)
        {
            return  _db.Set<TEntity>().Find(id);
             
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }
        // return how many rows its affected , so return type is int 
        public int SaveChanges()
        {
           return  _db.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
        }
    }
}
