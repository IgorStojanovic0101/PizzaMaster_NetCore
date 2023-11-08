using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PizzaMaster.Application.Services;
using PizzaMaster.Shared.DTOs;
using PizzaMaster.Shared.DTOs.Proizvod;
using PizzaMaster.Shared.Results;

namespace PizzaMaster.WebAPI.Controllers
{

    [EnableCors]
    public class ProizvodiController : ControllerBase
    {

        private readonly IProizvodiService _service;

        public ProizvodiController(IProizvodiService service) { 
            
            _service = service;


        }

        [HttpGet]
        public ActionResult<ServiceResponse<List<PizzaType_ResponseDTO>>> GetPizzaTypes()
        {
            ServiceResponse<List<PizzaType_ResponseDTO>> response = new();


            response.Payload = _service.GetPizzaTypes();

            return Ok(response);

        }

        [HttpGet]
        public ActionResult<ServiceResponse<List<PastaType_ResponseDTO>>> GetPastaTypes()
        {
            ServiceResponse<List<PastaType_ResponseDTO>> response = new();


            response.Payload = _service.GetPastaTypes();

            return Ok(response);

        }

        [HttpGet]
        public ActionResult<ServiceResponse<TopProducts_ResponseDTO>> GetTopProducts()
        {
            ServiceResponse<TopProducts_ResponseDTO> response = new();


            response.Payload = _service.GetTopProduct();

            return Ok(response);

        }
    }
}
