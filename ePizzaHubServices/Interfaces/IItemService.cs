using ePizzaHubEntities;
using ePizzaHubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHubServices.Interfaces
{
  public  interface IItemService 
    {
        IEnumerable<Category> GetCategories();

        IEnumerable<ItemType> GetItemTypes();
        // To get all the list
        IEnumerable<Item> GetItems();
        Item GetItem(int id);
        // to add the object
        void AddItem(Item entity);
        //To update the object
        void UpdateItem(Item entity);
        //  To delete the object of the given id
        void DeleteItem(int id);

        // SAve the changes in the DB
       
    }
}
