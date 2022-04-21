

namespace ePizzaHubEntities
{
   public class OrderItem
    {
        public int Id { get; set; }
        public int ItemId { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; set; }

        public decimal Total { get; set; }

        public string  OrderId { get; set; }

        public virtual Order Order { get; set; }


    }
}
