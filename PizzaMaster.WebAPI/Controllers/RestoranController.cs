using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaMaster.BussinessLogic.Services;
using PizzaMaster.Shared.DTOs.User;
using PizzaMaster.Shared.DTOs;
using PizzaMaster.Shared.Results;
using PizzaMaster.Application.Services;
using PizzaMaster.Infrastructure.System;
using System.Security.Claims;

namespace PizzaMaster.WebAPI.Controllers
{
    //[Authorize]
    public class RestoranController : ControllerBase
    {
        private readonly IRestoranService _service;

        public RestoranController(IRestoranService service) => _service = service;
  

        [HttpPost]
        public ActionResult<ServiceResponse<RestoranDTO>> TestDTO()
        {
            ServiceResponse<RestoranDTO> response = new();
            var roles = User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();
            var id =  User.FindAll("UserId").Select(c => c.Value).ToList();


            response.Errors = _service.ValidationErrors();


            if (response.Errors.Count > 0)
            {
                response.Validation = true;
                return Ok(response); //break
            }

            response.Payload = _service.ReturnResult();

            return Ok(response);

        }

        [HttpGet]
        public ActionResult<ServiceResponse<List<RestoranDTO>>> ListaRestorana()
        {
           ServiceResponse<List<RestoranDTO>> response = new();

            

            if (response.Errors.Count > 0)
            {
                response.Validation = true;
                return Ok(response);
            }

            response.Payload = _service.VratiRestorane();

            return Ok(response);

        }


        [HttpPost]
        public ActionResult<ServiceResponse<RestoranDTO>> AddRestoran(RestoranDTO request)
        {
            ServiceResponse<RestoranDTO> response = new();

            request.DateFrom = DateTime.Now;

            response.Payload = _service.AddRestoran(request);

            return Ok(response);

        }

        [HttpPost]
        public ActionResult<ServiceResponse<RestoranDTO>> UpdateRestoran(RestoranDTO request)
        {
            ServiceResponse<RestoranDTO> response = new();

            request.DateTo = DateTime.Now;

            response.Payload = _service.UpdateRestoran(request);

            return Ok(response);

        }

    }
}
