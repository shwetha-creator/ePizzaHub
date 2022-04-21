namespace ePizzaHubEntities
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public string ImageUrl { get; set; }

        //Forign key for CategoryId
        public int CategoryId { get; set; }
        //Navigationproperty
        public virtual Category Category { get; set; }

        //Forign key for ItemTypeId
        public int ItemTypeId { get; set; }
        //Navigationproperty
        public  virtual ItemType ItemType { get; set; }
    }
}