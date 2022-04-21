using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHubModels
{
   public class CartModel
    {
        public CartModel()
        {
            Items = new List<ItemModel>();
        }
        public Guid Id { get; set; }

        public int UserId { get; set; }

        public decimal  Total { get; set; }

        public decimal Tax { get; set; }
        public decimal GrandTotal { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual List<ItemModel> Items { get; set; }
    }
}
