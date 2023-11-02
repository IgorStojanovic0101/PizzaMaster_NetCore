using PizzaMaster.Shared.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Shared.DTOs
{
    public class RestoranDTO
    {
        public int Id { get; set; }
        public string RestoranIme { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public List<User_ResponseDTO> Users { get; set; }

    }
}
