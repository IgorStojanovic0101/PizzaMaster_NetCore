using BusinessLogic.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Results;
using PizzaMaster.Models.DTOs;
using WebAPI;

namespace PizzaMaster.WebAPI.Controllers
{
    public class RestoraniController : ControllerBase
    {
        private readonly RetoraniLogic _repo;

        public RestoraniController(RetoraniLogic repo) => _repo = repo;


        [HttpGet]
        public RestoranDTO PostSomething() => _repo.ReturnResult();

        [HttpPost]
        public ActionResult<ServiceResponse<RestoranDTO>> TestDTO(int id)
        {
            ServiceResponse<RestoranDTO> response = new();

            // Token validation
            if (id == 0)
                return Unauthorized(response);


            //Validations
            response.Errors =  _repo.ValidationErrors(id);


            if (response.Errors.Count > 0)
            {
                response.Validation = true;
                return Ok(response); //break
            }

            response.Payload = _repo.ReturnResult();

            return Ok(response);

        }

    }
}
