using PizzaMaster.Domain.Entities;
using PizzaMaster.Shared.DTOs.Proizvod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Application.Services
{
    public interface IProizvodiService
    {
        List<PizzaType_ResponseDTO> GetPizzaTypes();

        List<PastaType_ResponseDTO> GetPastaTypes();

        TopProducts_ResponseDTO GetTopProduct();
    }
}
