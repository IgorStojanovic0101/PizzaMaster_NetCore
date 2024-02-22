using System;
using System.Collections.Generic;

namespace PizzaMaster.Domain.Entities
{
    public partial class PasteType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? ImageId { get; set; } = null!;

        public virtual Image? Image { get; set; }
    }
}
