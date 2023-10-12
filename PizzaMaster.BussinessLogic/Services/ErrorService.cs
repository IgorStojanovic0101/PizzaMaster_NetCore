using Microsoft.Extensions.Logging;
using PizzaMaster.Application;
using PizzaMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Application.Services
{
    public class ErrorService : IErrorService
    {
        private readonly ILogger<ErrorService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ErrorService(ILogger<ErrorService> logger, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _logger = logger;
            _unitOfWork = unitOfWorkFactory.Create();
        }

        public void AddErrorRecord(string message, Exception exception)
        {
            var entity = new ErrorEntity { Naziv = message, Opis = exception.Message, Detaljnije = exception.InnerException?.Message, VremeGreske = DateTime.Now, User = "Igor" };
            _unitOfWork.ErrorRepository.Add(entity);
            _unitOfWork.SaveChanges();
        }
    }
}
