using System;
using System.Collections.Generic;

namespace PizzaMaster.Domain.Entities
{
    public partial class Error
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = null!;
        public string? Opis { get; set; }
        public string? Detaljnije { get; set; }
        public DateTime? VremeGreske { get; set; }
        public string? User { get; set; }
    }
}
