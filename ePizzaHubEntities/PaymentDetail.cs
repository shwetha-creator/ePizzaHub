using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace ePizzaHubEntities
{
    public class PaymentDetail
    {

        public string Id { get; set; }
        public string TransactionId { get; set; }
        public decimal Tax { get; set; }
        public string Currency { get; set; }
        public decimal Total { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public Guid CartId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public decimal GrandTotal { get; set; }
        public virtual User User { get; set; }
    }
}
