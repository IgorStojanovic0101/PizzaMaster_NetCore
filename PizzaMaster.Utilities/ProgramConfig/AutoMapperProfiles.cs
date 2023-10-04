using AutoMapper;
using PizzaMaster.Models.DTOs;
using PizzaMaster.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Utilities.ProgramConfig
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() { 

            CreateMap<RestoranDTO,RestoranModel>().ReverseMap();
            CreateMap<RestoranCreationDTO, RestoranModel>();

        }
    }
}
