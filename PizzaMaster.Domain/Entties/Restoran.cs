using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PizzaMaster.Domain.Entities
{
    public class Restoran
    {
       
        public int Id { set; get; } 
        public string RestoranIme { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
