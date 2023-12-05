using AutoMapper;
using PizzaMaster.Domain.Entities;
using PizzaMaster.Shared.DTOs;
using PizzaMaster.Shared.DTOs.Admin;
using PizzaMaster.Shared.DTOs.Dropdown;
using PizzaMaster.Shared.DTOs.Home.HomeDescription;
using PizzaMaster.Shared.DTOs.Proizvod;
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
        public AutoMapperProfiles()
        {

            CreateMap<RestoranDTO, Restoran>().ReverseMap();

            CreateMap<UserRegisterResponseDTO, User>().ReverseMap();
            CreateMap<User, User_ResponseDTO>().ReverseMap();


            CreateMap<RestoranCreationDTO, Restoran>();
            CreateMap<UserRegisterRequestDTO, User>();

            CreateMap<HomeDesc, HomeDescription_ResponseDTO>().ReverseMap();

            CreateMap<PizzaType, PizzaType_ResponseDTO>().ReverseMap();
            CreateMap<PasteType, PastaType_ResponseDTO>().ReverseMap();

            CreateMap<Dropdown, Dropdown_ResponseDTO>().ReverseMap();

            CreateMap<DropItem, DropItem_ResponseDTO>().ReverseMap();

            // Map Dropdown.Name to Dropdown_ResponseDTO.DisplayName

            CreateMap<Dropdown, Dropdown_ResponseDTO>()
             .ForMember(dest => dest.dropItem_ResponseDTOs, opt => opt.MapFrom(src => src.DropdownRelationItems.Select(x=>x.DropItem)))
            .ReverseMap();



        }
    }
}



//User
//i have relation N:M for my tables Dropdown and DropItem..there is DropdownRelationItem between them for realtions..

// public partial class DropdownRelationItem
//{
//    public int Id { get; set; }
//    public int? DropdownId { get; set; }
//    public virtual Dropdown? Dropdown { get; set; }

//    public int? DropItemId { get; set; }
//    public virtual DropItem? DropItem { get; set; }
//}
//|

//i need to automap now my Dropdown responseDTO

//public class Dropdown_ResponseDTO
//{
//    public int Id { get; set; }

//    public string DropdownName { get; set; }
//    public string DropdownImage { get; set; }

//    public bool Header { get; set; }

//    public bool NavigationBar { get; set; }

//    public IEnumerable<DropItem_ResponseDTO> dropItem_ResponseDTOs { get; set; }


//}

//I have problem with automaping dropItem_ResponseDTOs  

//i need to do this..

//CreateMap<Dropdown, Dropdown_ResponseDTO>()
//             .ForMember(dest => dest.dropItem_ResponseDTOs, opt => opt.MapFrom(src => src.DropdownRelationItems....DropItem))
//            .ReverseMap();