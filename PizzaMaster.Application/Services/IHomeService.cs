using PizzaMaster.Shared.DTOs;
using PizzaMaster.Shared.DTOs.Home.HomeDescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Application.Services
{
    public interface IHomeService
    {
      
        List<HomeDescription_ResponseDTO> GetHomeDescription();

        string? getVideo();


    }
}
