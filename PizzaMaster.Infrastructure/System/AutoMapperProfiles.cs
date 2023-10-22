using AutoMapper;
using PizzaMaster.Domain.Entities;
using PizzaMaster.Shared.DTOs;
using PizzaMaster.Shared.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Infrastructure.System
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() { 

            CreateMap<RestoranDTO,Restoran>().ReverseMap();
            CreateMap<UserRegisterResponseDTO, User>().ReverseMap();

            CreateMap<RestoranCreationDTO, Restoran>();
            CreateMap<UserRegisterRequestDTO, User>();


        }
    }
}
