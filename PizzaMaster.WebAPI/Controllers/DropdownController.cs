using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PizzaMaster.Application.Services;
using PizzaMaster.Shared.DTOs.Admin;
using PizzaMaster.Shared.Results;
using System.Security.Claims;

namespace PizzaMaster.WebAPI.Controllers
{
    [EnableCors]
  //  [Authorize]
    public class DropdownController : ControllerBase
    {
        private IDropdownService _dropdownService;
        public DropdownController(IDropdownService dropdownService) {
            _dropdownService = dropdownService;
        }

        [HttpGet]
        public ActionResult<ServiceResponse<IEnumerable<Dropdown_ResponseDTO>>> GetAllDropdownData()
        {
            ServiceResponse<IEnumerable<Dropdown_ResponseDTO>> response = new();

            var roles = User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();

            response.Payload = _dropdownService.GetAllHeaderDropdowns(roles);

            return response;

        }

            

    }
}
