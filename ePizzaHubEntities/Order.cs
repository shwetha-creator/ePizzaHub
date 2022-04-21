using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace ePizzaHubEntities
{
    public class Order
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public string PaymentId { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string CreatedDate { get; set; }
        public string Locality { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public virtual User User { get; set; }
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

    }
}