using Microsoft.AspNetCore.Mvc;
using PizzaMaster.Application.Services;
using PizzaMaster.Shared.DTOs;
using PizzaMaster.Shared.DTOs.Admin;
using PizzaMaster.Shared.Results;
using static System.Net.Mime.MediaTypeNames;

namespace PizzaMaster.WebAPI.Controllers
{
    public class AdminController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IAdminService _adminService;
        public AdminController(IWebHostEnvironment hostEnvironment, IAdminService adminService)
        {
            _hostEnvironment = hostEnvironment;
            _adminService = adminService;
        }

        [HttpPost]
        public ActionResult<ServiceResponse<Admin_ResponseDTO>> SetAdminData([FromForm] Admin_RequestDTO request)
        {
            var url = string.Empty;
            ServiceResponse<Admin_ResponseDTO> response = new();
            if (request.ImageFile == null)
            {
                return BadRequest("No image provided");
            }

            string wwwRootPath = _hostEnvironment.ContentRootPath;
            if (request.ImageFile != null)
            {
                string filename = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"Files\images\admin");
                var extension = Path.GetExtension(request.ImageFile.FileName);

                if (string.IsNullOrEmpty(url))
                {
                    var oldImagePath = Path.Combine(wwwRootPath, url.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStreams = new FileStream(Path.Combine(uploads, filename + extension), FileMode.Create))
                {
                    request.ImageFile.CopyTo(fileStreams);
                }
                url = @"Files\images\admin\" + filename + extension;

                _adminService.AddAdminData(request.Text, url);
            }


            return response;


        }
    }
}
