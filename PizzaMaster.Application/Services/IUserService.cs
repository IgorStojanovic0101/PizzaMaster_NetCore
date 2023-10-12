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
        List<UserDTO> GetAllUsers();
        UserLoginResponseDTO Login(UserLoginDTO creationDto);

        List<string> LoginValidationErrors(UserLoginDTO creationDto);

       List<string> RegisterValidationErrors(UserCreationDTO creationDto);

        UserLoginResponseDTO Register(UserCreationDTO creationDto);

    }
}
