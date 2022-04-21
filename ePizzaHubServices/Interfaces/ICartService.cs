using ePizzaHubEntities;
using ePizzaHubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHubServices.Interfaces
{
   public interface ICartService
    {
        int GetCartCount(Guid cartId);
        Cart GetCart(Guid CardId);

        Cart AddItem(int userid, Guid cartId, int itemId ,decimal unitprice,
            int Quantity);
        CartModel GetCartDetails(Guid CartId);
        int UpdateQuantity(Guid cartId, int itemId, int Quantity);
        int UpdateCart(Guid cartid, int userid);

        int DeleteItem(Guid cartid, int itemId);
    }
}
