using PizzaMaster.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Application
{
    public interface INeo4jUnitOfWork
    {

        IMLRepository MLRepository { get; }

    }
}
