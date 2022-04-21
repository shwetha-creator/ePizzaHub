using System;
using System.Text.Json.Serialization;

namespace ePizzaHubEntities
{
    public class CartItem
    {
        public int Id { get; set; }
        public Guid CartId { get; set; }
        public int ItemId { get;  set; }
        public decimal UnitPrice { get;  set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public  virtual Cart Cart { get; set; }
        public CartItem()
        {
            //Required by EF
        }
        public CartItem(int itemid, int quantity, decimal unitprice )
        {
            ItemId = itemid;
            UnitPrice = unitprice;
            Quantity = quantity;
        }
      
    }
}