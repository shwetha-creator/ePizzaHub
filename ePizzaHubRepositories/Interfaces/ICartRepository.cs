using ePizzaHubEntities;
using ePizzaHubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHubRepositories.Interfaces
{
   public  interface ICartRepository : IRepository<Cart>
    {
        Cart GetCart(Guid CardId);

        CartModel GetCartDetails(Guid CartId);
        int UpdateQuantity(Guid cartId, int itemId, int Quantity);
        int UpdateCart(Guid cartid, int userid);

        int DeleteItem(Guid cartid, int itemId);
    }
}
