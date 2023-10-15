using PizzaMaster.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Application.Services
{
    public interface IRestoranService
    {
        List<string> ValidationErrors();
        public RestoranDTO ReturnResult();

        public List<RestoranDTO> VratiRestorane();


    }
}
