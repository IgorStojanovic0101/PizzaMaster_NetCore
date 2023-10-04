
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI;

namespace BusinessLogic.Repositories
{
    public class ErrorsLogic
    {
        private readonly ILogger<ErrorsLogic> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ErrorsLogic(ILogger<ErrorsLogic> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public void AddError(string message, Exception exception)
        {



            _unitOfWork.ErrorsRepository.Add(new Models.Models.ErrorModel { Naziv = message});
            _logger.LogError(message, exception);
        }
    }
}
