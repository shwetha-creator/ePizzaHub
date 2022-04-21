using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHubRepositories.Interfaces
{
   public  interface IRepository<TEntity> where TEntity : class
    {
       // To get the TEntity (class object) for the given id
        TEntity Find(object id);

        // To get all the list
        IEnumerable<TEntity> GetAll();

        // to add the object
        void Add(TEntity entity);
        //To update the object
        void Update(TEntity entity);
      //  To delete the object of the given id
        void Delete(object id);

        // SAve the changes in the DB
        int SaveChanges();

    }
}
