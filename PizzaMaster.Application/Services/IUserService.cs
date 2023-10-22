using PizzaMaster.Shared.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Application.Services
{
    public interface IUserService
    {
        List<UserRegisterResponseDTO> GetAllUsers();
        UserLoginResponseDTO Login(UserLoginRequestDTO creationDto);

        List<string> LoginValidationErrors(UserLoginRequestDTO creationDto);

       List<string> RegisterValidationErrors(UserRegisterRequestDTO creationDto);

        UserLoginResponseDTO Register(UserRegisterRequestDTO creationDto);

    }
}
