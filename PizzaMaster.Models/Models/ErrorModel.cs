using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Models.Models
{
    public class ErrorModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Naziv")]
        [Required]    
        public string Naziv { get; set; }
    }
}
