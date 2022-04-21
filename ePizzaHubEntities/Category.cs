
using System.Collections.Generic;


namespace ePizzaHubEntities
{
   public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<Item> Items  { get; set; }
    }
}
