using PizzaMaster.Shared.DTOs.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Application.Services
{
    public interface IDropdownService
    {
        IEnumerable<Dropdown_ResponseDTO> GetAllHeaderDropdowns(List<string> list);
    }
}
