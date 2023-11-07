using Microsoft.AspNetCore.Mvc;
using PizzaMaster.Application.Services;
using PizzaMaster.Shared.DTOs;
using PizzaMaster.Shared.DTOs.Home.HomeDescription;
using PizzaMaster.Shared.Results;

namespace PizzaMaster.WebAPI.Controllers
{
    public class HomeController : ControllerBase
    {

        private readonly IHomeService _service;

        public HomeController(IHomeService service) => _service = service;


        [HttpGet]
        public ActionResult<ServiceResponse<List<HomeDescription_ResponseDTO>>> GetHomeDescription()
        {
            ServiceResponse<List<HomeDescription_ResponseDTO>> response = new();

            response.Payload = this._service.GetHomeDescription();

            return response;

        }

        [HttpGet]
        public ActionResult<ServiceResponse<string>> GetVideo()
        {
            ServiceResponse<string> response = new();

            response.Payload = this._service.getVideo()!;

            return response;
        }
    }
}
