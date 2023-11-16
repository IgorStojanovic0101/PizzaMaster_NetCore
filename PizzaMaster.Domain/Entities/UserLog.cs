using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Domain.Entities
{
    public partial class UserLog
    {
        public int Id { get; set; }   
  
        public string Username { get; set; }

        public string Email { get; set; }

        public DateTime? LogDate { get; set; }


    }
}
