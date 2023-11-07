using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Shared.Results
{
    public class ServiceResponse<T>
    {
        public T Payload { get; set; }
        public bool Validation { get; set; } = false;
        public List<string> Errors { get; set; } = new();
      
    }
}
