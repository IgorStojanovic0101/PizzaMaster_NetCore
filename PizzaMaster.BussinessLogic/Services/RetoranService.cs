using AutoMapper;
using Microsoft.Extensions.Logging;
using PizzaMaster.Application;
using PizzaMaster.Domain.Entities;
using PizzaMaster.Shared.DTOs.User;
using PizzaMaster.Shared.DTOs;
using PizzaMaster.Application.Services;
using PizzaMaster.Infrastructure.System;
using System.Data;
using System.Data.Common;
using Dapper;

namespace PizzaMaster.BussinessLogic.Services
{
    public class RetoranService : IRestoranService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RetoranService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper)
        {

            _unitOfWork = unitOfWorkFactory.Create();
            _mapper = mapper;
        }

        public List<string> ValidationErrors()
        {
            var errorList = new List<string>();


            return errorList;
        }


        public RestoranDTO ReturnResult()
        {


            var models = _unitOfWork.RestoranRepository.SingleOrDefault(x=>x.RestoranIme == "Vinyl");

           

            var dto = _mapper.Map<RestoranDTO>(models);
            

            return dto;
        }

        public List<RestoranDTO> VratiRestorane()
        {


            var modelsWithUsers = _unitOfWork.RestoranRepository.GetAll().ToList();

            var dto = _mapper.Map<List<RestoranDTO>>(modelsWithUsers);

            return dto;
        }

        public RestoranDTO AddRestoran(RestoranDTO restoran)
        {
            var entity = _mapper.Map<Restoran>(restoran);

            _unitOfWork.RestoranRepository.Add(entity);

            _unitOfWork.SaveChanges();
            return restoran;



        }
        public RestoranDTO UpdateRestoran(RestoranDTO restoran)
        {
            var entity = _mapper.Map<Restoran>(restoran);

            _unitOfWork.RestoranRepository.Update(entity);

            _unitOfWork.SaveChanges();
            return restoran;



        }

    }
}
