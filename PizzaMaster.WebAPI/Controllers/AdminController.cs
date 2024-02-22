using Microsoft.AspNetCore.Mvc;
using PizzaMaster.Application.Services;
using PizzaMaster.Infrastructure.Utilities;
using PizzaMaster.Shared.DTOs;
using PizzaMaster.Shared.DTOs.Admin;
using PizzaMaster.Shared.Results;
using static System.Net.Mime.MediaTypeNames;

namespace PizzaMaster.WebAPI.Controllers
{
   
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        public ActionResult<ServiceResponse<Admin_ResponseDTO>> SetAdminData([FromForm] Admin_RequestDTO request)
        {
            ServiceResponse<Admin_ResponseDTO> response = new();
            if (request.File == null)
            {
                return BadRequest("No image provided");
            }
            _adminService.AddAdminData(request);

            return response;


        }

        [HttpPost]
        public ActionResult<ServiceResponse<Admin_ResponseDTO>> AddVideo([FromForm] Admin_RequestDTO request)
        {
            ServiceResponse<Admin_ResponseDTO> response = new();
            if (request.File == null)
            {
                return BadRequest("No image provided");
            }
            _adminService.AddVideo(request);

            return response;


        }
    }
}
