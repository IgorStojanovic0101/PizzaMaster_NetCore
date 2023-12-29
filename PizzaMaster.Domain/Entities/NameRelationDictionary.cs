using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Domain.Entities
{
    public class NameRelationDictionary
    {
        public int Id { get; set; }
        public int? DropdownId { get; set; }
        public virtual Dropdown? Dropdown { get; set; }

        public int? DictionaryId { get; set; }
        public virtual Dictionary? Dictionary { get; set; }

        public int? LanguageId { get; set; }

        public virtual Language? Language { get; set; }


    }
}
