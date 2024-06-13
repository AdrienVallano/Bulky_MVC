using Bulky.Models;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IDetailCommandeRepository : IRepository<DetailCommande>
    {
        void Update(DetailCommande obj);
    }
}