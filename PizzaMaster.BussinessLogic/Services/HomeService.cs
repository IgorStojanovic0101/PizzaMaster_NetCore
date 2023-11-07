using AutoMapper;
using PizzaMaster.Application;
using PizzaMaster.Application.Services;
using PizzaMaster.Domain.Entities;
using PizzaMaster.Infrastructure.System;
using PizzaMaster.Infrastructure.Utilities;
using PizzaMaster.Shared.DTOs.Home.HomeDescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.BussinessLogic.Services
{
    public class HomeService : IHomeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly FileService _fileUploadService;
        public HomeService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper, FileService fileUploadService)
        {
            this._unitOfWork = unitOfWorkFactory.Create();
            this._mapper = mapper;
            this._fileUploadService = fileUploadService;
        }

        public List<HomeDescription_ResponseDTO> GetHomeDescription()
        {
            var entities = _unitOfWork.HomeDescRepository.GetAll(IncludeEnities<HomeDesc>.All);

            var dtos = new List<HomeDescription_ResponseDTO>();

            foreach (var entity in entities)
            {
                var dto = _mapper.Map<HomeDescription_ResponseDTO>(entity);

                // Read the image from the path
                dto.imageContent = _fileUploadService.ConvertImageToBase64(entity.Image);

                dtos.Add(dto);
            }

            return dtos;

        }

        public string? getVideo()
        {
            return _fileUploadService.ConverVideoToBase64(@"Files\videos\49d2739d-5bdf-4201-9c4b-7bd96666b58e.mp4");

        }



    }
}
