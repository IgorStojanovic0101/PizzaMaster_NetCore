using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PizzaMaster.Application;
using PizzaMaster.Application.Services;
using PizzaMaster.Data;
using PizzaMaster.Domain.Entities;
using PizzaMaster.Infrastructure.System;
using PizzaMaster.Shared.DTOs.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.BussinessLogic.Services
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _hostEnvironment;


        public UserService(ILogger<UserService> logger, IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper, IConfiguration config, IWebHostEnvironment webHostEnvironment)
        {

            _unitOfWork = unitOfWorkFactory.Create();
            _mapper = mapper;
            _config = config;
            this._hostEnvironment = webHostEnvironment;
        }

        public List<string> ValidationErrors()
        {
            var errorList = new List<string>();



            // _unitOfWork.ErrorsRepository.Add(error);
            // _unitOfWork.SaveChanges();




            return errorList;
        }


        public UserRegisterResponseDTO ReturnUser()
        {


            var models = _unitOfWork.UserRepository.GetAllUsers();

            var el = models[0];

            var dto = _mapper.Map<UserRegisterResponseDTO>(el);

            return dto;
        }

    

        public UserLoginResponseDTO Login(UserLoginRequestDTO dto)
        {
            UserLoginResponseDTO response = new();

            response.Username = dto.Username;
            response.Token = GenerateToken(dto.Username);

            return response;
        }

        public UserLoginResponseDTO Register(UserRegisterRequestDTO dto)
        {
            UserLoginResponseDTO response = new();
            var url = string.Empty;

            string wwwRootPath = _hostEnvironment.ContentRootPath;
            if (dto.File != null)
            {
                string filename = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"Files\images\user");
                var extension = Path.GetExtension(dto.File.FileName);

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
                    dto.File.CopyTo(fileStreams);
                }
                url = @"Files\images\user\" + filename + extension;
            }
            var image = new Domain.Entities.Image() { Url = url };

            _unitOfWork.ImageRepository.Add(image);

            _unitOfWork.SaveChanges();


            var model = _mapper.Map<User>(dto);
            model.RestoranId = 1;
            model.ImageId = image.Id;

            _unitOfWork.UserRepository.Add(model);
            _unitOfWork.SaveChanges();

            response.Username = dto.Username;
            response.Token = GenerateToken(dto.Username);

            return response;
        }

        public List<UserRegisterResponseDTO> GetAllUsers()
        {
            var entities = _unitOfWork.UserRepository.GetAll(IncludeEnities.User.All);


            var dtos = _mapper.Map<List<UserRegisterResponseDTO>>(entities);

            return dtos;
        }

        public List<string> LoginValidationErrors(UserLoginRequestDTO dto)
        {
            List<string> errors = new();
            if (!_unitOfWork.UserRepository.Any(x => x.Username.Equals(dto.Username) && x.Password.Equals(dto.Password)))
                errors.Add("Ne postoji ovaj user");
                
             return errors;

        }

        public List<string> RegisterValidationErrors(UserRegisterRequestDTO dto)
        {
            List<string> errors = new();
            if (_unitOfWork.UserRepository.Any(x => x.Username.Equals(dto.Username)))
                errors.Add("Postoji ovaj user");

            return errors;

        }

       

        private string GenerateToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, username),  
            };
            var token = new JwtSecurityToken(null,null, claims, expires: DateTime.Now.AddHours(8),signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
