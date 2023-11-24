using System;
using System.Collections.Generic;

namespace PizzaMaster.Domain.Entities
{
    public partial class Image
    {
        public int Id { get; set; }
        public string Url { get; set; } = null!;

        public virtual HomeDesc? HomeDesc { get; set; }
        public virtual PasteType? PasteType { get; set; }
        public virtual PizzaType? PizzaType { get; set; }
        public virtual User? User { get; set; }
    }
}
