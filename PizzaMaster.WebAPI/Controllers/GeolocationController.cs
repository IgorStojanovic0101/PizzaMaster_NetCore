using Microsoft.AspNetCore.Mvc;
using PizzaMaster.Application.Services;
using PizzaMaster.Shared.DTOs.Proizvod;
using PizzaMaster.Shared.Results;

namespace PizzaMaster.WebAPI.Controllers
{
    public class GeolocationController : ControllerBase
    {
        private readonly IGeolocationService _service;

        public GeolocationController(IGeolocationService service) => _service = service;

        [HttpGet]
        public ActionResult<ServiceResponse<string>> GetGeoLocation()
        {
            ServiceResponse<string> response = new();


            response.Payload = _service.GetGeolocation(1.1,2.2);

            return Ok(response);

        }
    }
}
