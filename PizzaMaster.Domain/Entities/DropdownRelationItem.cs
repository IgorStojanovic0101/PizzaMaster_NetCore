using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Domain.Entities
{
    public partial class DropdownRelationItem
    {
        public int Id { get; set; }
        public int? DropdownId { get; set; }
        public virtual Dropdown? Dropdown { get; set; }

        public int? DropItemId { get; set; }
        public virtual DropItem? DropItem { get; set; }
    }
}
