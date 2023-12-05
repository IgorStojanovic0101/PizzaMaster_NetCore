using AutoMapper;
using PizzaMaster.Application;
using PizzaMaster.Application.Services;
using PizzaMaster.Domain.Entities;
using PizzaMaster.Infrastructure.System;
using PizzaMaster.Shared.DTOs.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.BussinessLogic.Services
{
    public class DropdownService : IDropdownService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DropdownService( IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper ) {
            this._mapper = mapper;
            this._unitOfWork = unitOfWorkFactory.Create();
        }
        public IEnumerable<Dropdown_ResponseDTO> GetAllHeaderDropdowns()
        {
            var models = this._unitOfWork.DropdownRepository.GetAll(IncludeEnities.Dropdown.Entities);
            var dtos = _mapper.Map<IEnumerable<Dropdown_ResponseDTO>>( models );

            return dtos;

        }
    }
}
