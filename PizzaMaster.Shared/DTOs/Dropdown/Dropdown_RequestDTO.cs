using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Shared.DTOs.Admin
{
    public class Dropdown_RequestDTO
    {
        public IFormFile File { get; set; }
        public string DropdownName { get; set; } 

        public bool Header { get; set; }

        public bool NavigationBar { get; set; }

    }
}
