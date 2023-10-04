﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Results
{
    public class ServiceResponse<T> where T : new()
    {
        public T Payload { get; set; } = new();
        public bool Validation { get; set; } = false;
        public List<string> Errors { get; set; } = new();
      
    }
}
