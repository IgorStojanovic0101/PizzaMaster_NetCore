using PizzaMaster.Shared.DTOs.Home.HomeDescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Shared.DTOs.Proizvod
{
    public class TopProducts_ResponseDTO
    {
       public List<PizzaType_ResponseDTO> pizzaTypes { get; set; }
        
        public HomeDescription_ResponseDTO homeDescription { get; set; }

    }
}
