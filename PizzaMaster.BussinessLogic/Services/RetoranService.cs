using AutoMapper;
using Microsoft.Extensions.Logging;
using PizzaMaster.Application;
using PizzaMaster.Domain.Entities;
using PizzaMaster.Shared.DTOs.User;
using PizzaMaster.Shared.DTOs;

namespace PizzaMaster.BussinessLogic.Services
{
    public class RetoranService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public RetoranService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper)
        {

            _unitOfWork = unitOfWorkFactory.Create();
            _mapper = mapper;
        }

        public List<string> ValidationErrors(int id)
        {
            var errorList = new List<string>();


            return errorList;
        }


        public RestoranDTO ReturnResult()
        {


            var models = _unitOfWork.RestoranRepository.GetAllRestorans();

            var el = models[0];

            var dto = _mapper.Map<RestoranDTO>(el);
            

            return dto;
        }

        public List<RestoranDTO> VratiRestorane()
        {


            var models = _unitOfWork.RestoranRepository.GetAllRestorans();

            var dto = _mapper.Map<List<RestoranDTO>>(models);

            return dto;
        }

    }
}
