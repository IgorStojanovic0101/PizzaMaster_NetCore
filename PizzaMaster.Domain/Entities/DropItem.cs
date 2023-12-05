using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Domain.Entities
{
    public partial class DropItem
    {
        public int Id { get; set; }
        public string DropItemName { get; set; } = null!;

        public string DropItemImage { get; set; } = null!;

        public virtual ICollection<DropdownRelationItem> DropdownRelationItems { get; set; }

        public DropItem() 
        {
            DropdownRelationItems = new HashSet<DropdownRelationItem>();
        }


    }
}
