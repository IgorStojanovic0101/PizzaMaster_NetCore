using AutoMapper;
using PizzaMaster.Application;
using PizzaMaster.Application.Services;
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
        public AdminService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) 
        {
            this._unitOfWork = unitOfWorkFactory.Create();
            this._mapper = mapper;
        }
        public void AddAdminData(string text, string url)
        {
            var image = new Domain.Entities.Image() { Url = url };

            _unitOfWork.ImageRepository.Add(image);

            _unitOfWork.SaveChanges();

            var homeDesc = new Domain.Entities.HomeDesc() { Text = text, ImageId = image.Id };

            _unitOfWork.HomeDescRepository.Add(homeDesc);
            _unitOfWork.SaveChanges();

        }
    }
}
