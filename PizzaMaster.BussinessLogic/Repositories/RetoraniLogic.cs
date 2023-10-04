using AutoMapper;
using Microsoft.Extensions.Logging;
using PizzaMaster.Models.DTOs;
using PizzaMaster.Models.Models;
using WebAPI;

namespace BusinessLogic.Repositories
{
    public class RetoraniLogic
    {
        private readonly ILogger<RetoraniLogic> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public RetoraniLogic(ILogger<RetoraniLogic> logger, IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper)
        {

            _unitOfWork = unitOfWorkFactory.Create();
            _mapper = mapper;
            _logger = logger;
        }

        public List<String> ValidationErrors(int id)
        {
            var errorList = new List<String>();

            var error = new Models.Models.ErrorModel { Naziv = "Error2323" };

            _unitOfWork.ErrorsRepository.Add(error);
            _unitOfWork.SaveChanges();

              
               

            return errorList;
        }


        public RestoranDTO ReturnResult()
        {
          

            _logger.LogInformation("Igor");
            _logger.LogError("Igor");

           var models =  _unitOfWork.RestoraniRepository.GetAllRestorans();

            var el = models[0];

            var dto = _mapper.Map<RestoranDTO>(el);

            return dto;
        }

    }
}
