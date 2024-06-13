using Bulky.Models;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IEnteteCommandeRepository : IRepository<EnteteCommande>
    {
        void Update(EnteteCommande obj);
    }
}