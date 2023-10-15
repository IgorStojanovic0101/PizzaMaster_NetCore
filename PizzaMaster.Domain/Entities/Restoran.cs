using System;
using System.Collections.Generic;

namespace PizzaMaster.Domain.Entities
{
    public partial class Restoran
    {
        public Restoran()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string RestoranIme { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
