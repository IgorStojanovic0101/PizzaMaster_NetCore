using AutoMapper;
using PizzaMaster.Application;
using PizzaMaster.Application.Services;
using PizzaMaster.Infrastructure.Utilities;
using PizzaMaster.Shared.DTOs.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.BussinessLogic.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly FileService _fileUploadService;
        public AdminService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper, FileService fileUploadService) 
        {
            this._unitOfWork = unitOfWorkFactory.Create();
            this._mapper = mapper;
            this._fileUploadService = fileUploadService;
        }
        public void AddAdminData(Admin_RequestDTO dto)
        {
            string url = _fileUploadService.UploadFile(dto.File, @"Files\images\admin");

            var image = new Domain.Entities.Image() { Url = url };

            _unitOfWork.ImageRepository.Add(image);

            _unitOfWork.SaveChanges();

            var homeDesc = new Domain.Entities.HomeDesc() { Text = dto.Text, ImageId = image.Id };

            _unitOfWork.HomeDescRepository.Add(homeDesc);
            _unitOfWork.SaveChanges();

        }

        public void AddVideo(Admin_RequestDTO dto)
        {
            string url = _fileUploadService.UploadFile(dto.File, @"Files\videos");

        }
    }
}
