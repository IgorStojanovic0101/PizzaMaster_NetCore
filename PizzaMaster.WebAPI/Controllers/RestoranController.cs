using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaMaster.BussinessLogic.Services;
using PizzaMaster.Shared.DTOs.User;
using PizzaMaster.Shared.DTOs;
using PizzaMaster.Shared.Results;

namespace PizzaMaster.WebAPI.Controllers
{
    [Authorize]
    public class RestoranController : ControllerBase
    {
        private readonly RetoranService _service;

        public RestoranController(RetoranService service) => _service = service;
  

        [HttpPost]
        public ActionResult<ServiceResponse<RestoranDTO>> TestDTO(int id)
        {
            ServiceResponse<RestoranDTO> response = new();


            //Validations
            response.Errors = _service.ValidationErrors();


            if (response.Errors.Count > 0)
            {
                response.Validation = true;
                return Ok(response); //break
            }

            response.Payload = _service.ReturnResult();

            return Ok(response);

        }

        [HttpPost]
        public ActionResult<ServiceResponse<List<RestoranDTO>>> ListaRestorana()
        {
            ServiceResponse<List<RestoranDTO>> response = new();


            if (response.Errors.Count > 0)
            {
                response.Validation = true;
                return Ok(response); //break
            }

            response.Payload = _service.VratiRestorane();

            return Ok(response);

        }

    }
}
