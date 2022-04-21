using System;
using System.Collections.Generic;


namespace ePizzaHubEntities
{
   public  class Cart
    {
        // Add items to cart 

        public Guid Id { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }

        public virtual List<CartItem> Items { get; set; }

        public Cart()
        {
            Items = new List<CartItem>();
            CreatedDate = DateTime.Now;
            IsActive = true;
        }
    }
}
