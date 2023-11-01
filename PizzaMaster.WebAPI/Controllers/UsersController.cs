using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PizzaMaster.Application.Services;
using PizzaMaster.BussinessLogic.Services;
using PizzaMaster.Shared.DTOs.User;
using PizzaMaster.Shared.Results;

namespace PizzaMaster.WebAPI.Controllers
{
    [EnableCors]
    public class UsersController : ControllerBase
    {
  
        private readonly IUserService _service;


        public UsersController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<ServiceResponse<List<UserRegisterResponseDTO>>> GetAllUsers()
        {
            ServiceResponse<List<UserRegisterResponseDTO>> response = new(); 

            response.Payload = _service.GetAllUsers();

            return Ok(response);

        }

        [HttpPost]
        public ActionResult<ServiceResponse<UserLoginResponseDTO>> Login([FromForm] UserLoginRequestDTO dto)
        {
            ServiceResponse<UserLoginResponseDTO> response = new();

            //Validations
            response.Errors = _service.LoginValidationErrors(dto);


            if (response.Errors.Count > 0)
            {
                response.Validation = true;
                return Ok(response); //break
            }

            response.Payload = _service.Login(dto);

            return Ok(response);

        }

        [HttpPost]
        public ActionResult<ServiceResponse<UserLoginResponseDTO>> Register([FromForm] UserRegisterRequestDTO dto)
        {
            ServiceResponse<UserLoginResponseDTO> response = new();

            //Validations
            response.Errors = _service.RegisterValidationErrors(dto);


            if (response.Errors.Count > 0)
            {
                response.Validation = true;
                return Ok(response); //break
            }

            response.Payload = _service.Register(dto);

            return Ok(response);

        }
    }
}