using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PizzaMaster.Application.Services;
using PizzaMaster.Shared.DTOs.Admin;
using PizzaMaster.Shared.Results;

namespace PizzaMaster.WebAPI.Controllers
{
    [EnableCors]

    public class DropdownController
    {
        private IDropdownService _dropdownService;
        public DropdownController(IDropdownService dropdownService) {
            _dropdownService = dropdownService;
        }

        [HttpGet]
        public ActionResult<ServiceResponse<IEnumerable<Dropdown_ResponseDTO>>> GetAllDropdownData()
        {
            ServiceResponse<IEnumerable<Dropdown_ResponseDTO>> response = new();

            response.Payload = _dropdownService.GetAllHeaderDropdowns();

            return response;

        }

            

    }
}
