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
        public DateTime DateFrom { get; set; } 
        public DateTime? DateTo { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
