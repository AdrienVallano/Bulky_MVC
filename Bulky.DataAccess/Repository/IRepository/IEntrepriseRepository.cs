using Bulky.Models;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IEntrepriseRepository : IRepository<Entreprise>
    {
        void Update(Entreprise obj);
    }
}