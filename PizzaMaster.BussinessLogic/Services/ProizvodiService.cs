using AutoMapper;
using PizzaMaster.Application;
using PizzaMaster.Application.Services;
using PizzaMaster.Domain.Entities;
using PizzaMaster.Infrastructure.System;
using PizzaMaster.Infrastructure.Utilities;
using PizzaMaster.Shared.DTOs.Proizvod;
using PizzaMaster.Shared.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.BussinessLogic.Services
{
    public class ProizvodiService : IProizvodiService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly FileService _fileUploadService;
        public ProizvodiService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper, FileService fileUploadService)
        {
            this._unitOfWork = unitOfWorkFactory.Create();
            this._mapper = mapper;
            this._fileUploadService = fileUploadService;
        }

        public List<PastaType_ResponseDTO> GetPastaTypes()
        {
            var entities = _unitOfWork.PastaTypeRepository.Find(x => x.ImageId != null, IncludeEnities<PastaType>.All);

            var dtos = new List<PastaType_ResponseDTO>();

            foreach (var entity in entities)
            {
                var dto = _mapper.Map<PastaType_ResponseDTO>(entity);

                // Read the image from the path
                dto.imageContent = _fileUploadService.ConvertImageToBase64(entity.Image);

                dtos.Add(dto);

                if (dtos.Count >= 3)
                {
                    break;
                }
            }

            return dtos;
        }

        public List<PizzaType_ResponseDTO> GetPizzaTypes()
        {
            var entities = _unitOfWork.PizzaTypeRepository.Find(x => x.ImageId != null, IncludeEnities<PizzaType>.All);

            var dtos = new List<PizzaType_ResponseDTO>();

            foreach (var entity in entities)
            {
                var dto = _mapper.Map<PizzaType_ResponseDTO>(entity);

                // Read the image from the path
                dto.imageContent = _fileUploadService.ConvertImageToBase64(entity.Image);

                dtos.Add(dto);

                if (dtos.Count >= 3)
                {
                    break;
                }
            }

            return dtos;
        }
    }
}
