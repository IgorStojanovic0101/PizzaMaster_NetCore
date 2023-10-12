using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Domain.Entities
{
    public class User
    {
        public int Id { set; get; }
        public int RestoranId { set; get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        
        public Restoran Restoran { get; set; }

    }
}
