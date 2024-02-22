using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PizzaMaster.Shared.DTOs.Language;
using PizzaMaster.Shared.Results;

namespace PizzaMaster.WebAPI.Controllers
{

  
    public class LanguageController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetLanguage(Language_RequestDTO dto)
        {
            var response = new ServiceResponse<Language_ResonseDTO>();
            response.Payload = new();
            if (dto.language == "eng")
            {

                response.Payload.title = "English Titlee";
            }
            if(dto.language == "srb")
            {
                response.Payload.title = "Srpski Titlee";
            }
            return Ok(response);
           // return response;
        }
    }
}
