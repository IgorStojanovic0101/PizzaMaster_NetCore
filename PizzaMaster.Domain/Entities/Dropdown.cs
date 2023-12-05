using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Domain.Entities
{
    public partial class Dropdown
    {
        public int Id { get; set; }

        public string DropdownName { get; set; } = null!;
        public string DropdownImage { get; set; } = null!;

        public bool Header { get; set; }

        public bool NavigationBar { get; set; }

        public virtual ICollection<DropdownRelationItem> DropdownRelationItems { get; set; }

        public Dropdown() {
            DropdownRelationItems = new HashSet<DropdownRelationItem>();

        }

    }
}
