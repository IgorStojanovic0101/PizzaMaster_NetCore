using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PizzaMaster.Domain.Entities
{
    public class ErrorEntity
    {     
        public int Id { get; set; }
        public string? Naziv { get; set; }

        public string? Opis { get; set; }

        public string? Detaljnije { get; set; }

        public DateTime? VremeGreske { get; set; }

        public string? User { get; set; }
    }
}
