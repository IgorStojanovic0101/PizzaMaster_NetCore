using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Domain.Entities
{
    public partial class HomeDesc
    {
        public int Id { get; set; }

        public int ImageId { get; set; }

        public string Text { get; set; } = null!;

        public virtual Image Image { get; set; }
    }
}
