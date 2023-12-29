using Amazon.Runtime.Internal.Util;
using AutoMapper;
using Microsoft.Extensions.Logging;
using PizzaMaster.Application;
using PizzaMaster.Application.Services;
using PizzaMaster.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.BussinessLogic.Services
{
    public class GeolocationService : IGeolocationService
    {
        private readonly IMongoUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GeolocationService> _logger;
        public GeolocationService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper, ILogger<GeolocationService> logger)
        {
            this._logger = logger;
            this._unitOfWork = unitOfWorkFactory.CreateMongo();
            this._mapper = mapper;
        }

        public string GetGeolocation(double lng,double lat) 
        {
            this._logger.LogInformation("Ovo je fixano");
          return this._unitOfWork.GeolocationRepository.GetGeolocation(lng, lat);
        }
    }
}
