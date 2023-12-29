using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Domain.Entities
{
    public class Dictionary
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Value { get; set; }

        public int? LanguageId { get; set; }

        public virtual Language? Language { get; set; }

        public virtual ICollection<NameRelationDictionary> NameRelationDictionaries { get; set; }

        public Dictionary() 
        {
            NameRelationDictionaries = new HashSet<NameRelationDictionary>();
        }

    }
}
