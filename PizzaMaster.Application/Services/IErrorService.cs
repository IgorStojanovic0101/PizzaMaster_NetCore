using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Application.Services
{
    public interface IErrorService
    {
        void AddErrorRecord(string message, Exception exception);
    }
}
