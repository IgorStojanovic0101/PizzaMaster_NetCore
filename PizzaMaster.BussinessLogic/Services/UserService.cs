﻿using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PizzaMaster.Application;
using PizzaMaster.Application.Services;
using PizzaMaster.Domain.Entities;
using PizzaMaster.Infrastructure.System;
using PizzaMaster.Infrastructure.Utilities;
using PizzaMaster.Shared.DTOs.Home.HomeDescription;
using PizzaMaster.Shared.DTOs.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
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
        private readonly FileService _fileUploadService;
        private readonly ILogger<UserService> _logger;

        public UserService(ILogger<UserService> logger, IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper, IConfiguration config, FileService fileUploadService)
        {

            _unitOfWork = unitOfWorkFactory.Create();
            _mapper = mapper;
            _config = config;
            _fileUploadService = fileUploadService;
            _logger = logger;


        }

        public List<string> ValidationErrors()
        {
            var errorList = new List<string>();



            // _unitOfWork.ErrorsRepository.Add(error);
            // _unitOfWork.SaveChanges();




            return errorList;
        }


      
   
        public UserLoginResponseDTO Login(UserLoginRequestDTO dto)
        {
            UserLoginResponseDTO response = new();


            var user = this._unitOfWork.UserRepository.TryNewSingleOrDefault(x =>x.Username == dto.Username && x.Password == dto.Password, IncludeEnities.User.Entities);
    

           this._unitOfWork.UserRepository.LogUser(dto.Username, dto.Password);

            var roles = user.UserRoles.Select(x => x.Role!.RoleName).AsEnumerable();

            response.Token = GenerateToken(user.Id.ToString(), user.Name, roles);

            return response;
        }

        public UserRegisterResponseDTO Register(UserRegisterRequestDTO dto)
        {
            UserRegisterResponseDTO response = new();

            var url = _fileUploadService.UploadFile(dto.File, @"Files\images\user\");

          
            var image = new Image() { Url = url };

            _unitOfWork.ImageRepository.Add(image);

            _unitOfWork.SaveChanges();


            var model = _mapper.Map<User>(dto);
            model.RestoranId = 1;
            model.ImageId = image.Id;

            _unitOfWork.UserRepository.Add(model);
            _unitOfWork.SaveChanges();

            response.Username = dto.Username;
            response.Token = GenerateToken(model.Id.ToString(), model.Name);

            return response;
        }

        public List<User_ResponseDTO> GetAllUsers()
        {
            var entities = _unitOfWork.UserRepository.GetAll();

            var dtos = new List<User_ResponseDTO>();

            _logger.LogInformation("123");

            foreach (var entity in entities)
            {
                var dto = _mapper.Map<User_ResponseDTO>(entity);

                // Read the image from the path
                dto.imageContent = _fileUploadService.ConvertImageToBase64(entity.Image);

                dtos.Add(dto);
            }

            return dtos;
        }

        public List<User_ResponseDTO> GetTopUsers()
        {
            var entities = _unitOfWork.UserRepository.Find(x=>x.ImageId != null,IncludeEnities.User.Entities);

            var dtos = new List<User_ResponseDTO>();

            foreach (var entity in entities)
            {
                var dto = _mapper.Map<User_ResponseDTO>(entity);

                // Read the image from the path
                dto.imageContent = _fileUploadService.ConvertImageToBase64(entity.Image);

                dtos.Add(dto);

                if (dtos.Count >= 4)
                {
                    break; 
                }
            }

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

       

        private string GenerateToken(string userId,string name, IEnumerable<string>? roles = null)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddHours(8);
            var claims = new List<Claim>
            {
                new Claim("UserId", userId),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(expires).ToUnixTimeSeconds().ToString()),
                new Claim(ClaimTypes.NameIdentifier,name)

            };

            // Add claims for each role
            if(roles != null)
                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role!)));

            var token = new JwtSecurityToken(null,null, claims, expires: expires, signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
