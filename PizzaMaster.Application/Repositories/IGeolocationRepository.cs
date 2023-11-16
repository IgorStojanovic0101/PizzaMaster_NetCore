using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Application.Repositories
{
    public interface IGeolocationRepository
    {
        string GetGeolocation(double longitude, double latitude);
    }
}
