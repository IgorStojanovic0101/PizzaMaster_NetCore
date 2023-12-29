using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Domain.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual NameRelationDictionary? NameRelationDictionary { get; set; }
        public virtual Dictionary? Dictionary { get; set; }


    }
}
