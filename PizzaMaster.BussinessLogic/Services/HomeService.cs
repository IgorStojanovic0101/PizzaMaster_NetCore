using AutoMapper;
using PizzaMaster.Application;
using PizzaMaster.Application.Services;
using PizzaMaster.Infrastructure.System;
using PizzaMaster.Shared.DTOs.Home.HomeDescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.BussinessLogic.Services
{
    public class HomeService : IHomeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HomeService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper)
        {
            this._unitOfWork = unitOfWorkFactory.Create();
            this._mapper = mapper;
        }

        public List<HomeDescription_ResponseDTO> GetHomeDescription()
        {
            var entities = _unitOfWork.HomeDescRepository.GetAll(IncludeEnities.HomeDescription.All);

            var dtos = new List<HomeDescription_ResponseDTO>();

            foreach (var entity in entities)
            {
                var dto = _mapper.Map<HomeDescription_ResponseDTO>(entity);
                string extension = GetFileExtensionFromUrl(entity.Image.Url);

                // Read the image from the path
                if (!string.IsNullOrEmpty(entity.Image?.Url))
                {
                    byte[] imageBytes = File.ReadAllBytes(entity.Image.Url);

                    // Convert the byte array to a base64 string
                    string base64Image = Convert.ToBase64String(imageBytes);

                    // Assign the base64 string to your DTO
                    dto.imageContent = $"data:image/{extension};base64,{base64Image}";
                }

                dtos.Add(dto);
            }

            return dtos;

        }

        public static string GetFileExtensionFromUrl(string url)
        {
            
                // Use Path.GetExtension to get the file extension from the URL
            string extension = Path.GetExtension(url);

            if (!string.IsNullOrEmpty(extension))
            {
                // Remove the leading dot (.) from the extension
                return extension.Substring(1);
            }
            

            return string.Empty; // Return an empty string if no extension is found
        }

    }
}
