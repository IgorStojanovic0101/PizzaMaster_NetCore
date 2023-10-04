using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PizzaMaster.Models.Models
{
    public class RestoranModel
    {
        [Key]
        public int Id { get; set; }

       
        [Required]
        public string RestoranIme { get; set; }
    }
}
