using System;
using System.Collections.Generic;

namespace PizzaMaster.Domain.Entities
{
    public partial class HomeDesc
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public int ImageId { get; set; }

        public virtual Image Image { get; set; } = null!;
    }
}
