using PizzaMaster.Shared.DTOs.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Application.Services
{
    public interface IAdminService
    {
        void AddAdminData(Admin_RequestDTO dto);
    }
}
