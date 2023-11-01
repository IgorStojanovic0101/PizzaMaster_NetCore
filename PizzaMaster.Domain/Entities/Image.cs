using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Domain.Entities
{
    public partial class Image
    {
        public int Id { get; set; }

        public string Url { get; set; } = null!;

        public virtual HomeDesc HomeDesc { get; set; }

        public virtual User? User { get; set; }


    }
}
