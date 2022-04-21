using ePizzaHubEntities;
using ePizzaHubModels;
using ePizzaHubRepositories.Interfaces;
using ePizzaHubServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHubServices.Implementations
{
    public class ItemService : IItemService
    {
        private readonly IRepository<Item> _itemRepo;
        private readonly IRepository<ItemType> _itemTypeRepo;
        private readonly IRepository<Category> _categoryRepo;


        public ItemService(IRepository<Item> itemRepo, IRepository<ItemType> itemTypeRepo , IRepository<Category> categoryRepo)
        {
            _itemRepo = itemRepo;
            _itemTypeRepo = itemTypeRepo;
            _categoryRepo = categoryRepo;
        }

        public void AddItem(Item entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Item GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
           return  _itemRepo.GetAll();
        }

        public IEnumerable<ItemType> GetItemTypes()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item entity)
        {
            throw new NotImplementedException();
        }
    }
}
