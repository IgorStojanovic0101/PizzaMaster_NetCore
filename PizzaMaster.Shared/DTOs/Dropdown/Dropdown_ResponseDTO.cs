using Microsoft.AspNetCore.Http;
using PizzaMaster.Shared.DTOs.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Shared.DTOs.Admin
{
    public class Dropdown_ResponseDTO
    {
        public int Id { get; set; }

        public string DropdownName { get; set; }
        public string DropdownImage { get; set; }

        public bool Header { get; set; }

        public bool NavigationBar { get; set; }

        public IEnumerable<DropItem_ResponseDTO> dropItem_ResponseDTOs { get; set; }

    }
}
