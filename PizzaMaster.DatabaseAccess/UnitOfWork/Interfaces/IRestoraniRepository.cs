using PizzaMaster.Models.Models;

namespace WebAPI
{
    public interface IRestoraniRepository : IRepository<RestoranModel>
    {
        Task<bool> UpdateRestoran(string email);

        List<RestoranModel> GetAllRestorans();
    }
}
