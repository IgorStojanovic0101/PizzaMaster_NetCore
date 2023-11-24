﻿using System;
using System.Collections.Generic;

namespace PizzaMaster.Domain.Entities
{
    public partial class PizzaType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? ImageId { get; set; }

        public virtual Image? Image { get; set; }
    }
}
