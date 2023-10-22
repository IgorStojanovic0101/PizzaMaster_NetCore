using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PizzaMaster.Application;
using PizzaMaster.Application.Services;
using PizzaMaster.Data;
using PizzaMaster.Domain.Entities;
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


        public UserService(ILogger<UserService> logger, IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper, IConfiguration config)
        {

            _unitOfWork = unitOfWorkFactory.Create();
            _mapper = mapper;
            _config = config;
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

            var model = _mapper.Map<User>(dto);
            model.RestoranId = 1;

            _unitOfWork.UserRepository.Add(model);
            _unitOfWork.SaveChanges();

            response.Username = dto.Username;
            response.Token = GenerateToken(dto.Username);

            return response;
        }

        public List<UserRegisterResponseDTO> GetAllUsers()
        {
            var entities = _unitOfWork.UserRepository.GetAllUsers();


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
