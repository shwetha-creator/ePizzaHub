using System.ComponentModel.DataAnnotations.Schema;

namespace ePizzaHubEntities
{
   public  class UserRole
    {
        // In "User" entity , primary key is "Id" but in third entity (UserRole) foreign key is "UserId"
        // Therefore to  match the keys we need to add ForeignKey Attribute and Navigation property
        // of that class is defined in that attribute 

        [ForeignKey("User")]
        public int UserId { get; set; }
        // to define foreign key , we need navigation of that class type 
        public virtual User User { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        // to define foreign key , we need navigation of that class type 
        public virtual Role Role { get; set; }

    }
}
