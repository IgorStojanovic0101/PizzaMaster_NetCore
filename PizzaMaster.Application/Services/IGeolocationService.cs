﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Application.Services
{
    public interface IGeolocationService
    {
        string GetGeolocation(double lng, double lat);

    }
}
