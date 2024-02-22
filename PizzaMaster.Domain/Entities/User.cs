using System;
using System.Collections.Generic;

namespace PizzaMaster.Domain.Entities
{
    public partial class User
    {
        public User() 
        {
            UserRoles = new HashSet<UserRole>();
        }
        public int Id { get; set; }
        public int? RestoranId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Username { get; set; } = null!;
        public int? ImageId { get; set; } = null!;

        public virtual Image? Image { get; set; }
        public virtual Restoran? Restoran { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }



    }
}
