using Bulky.Models;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IProduitRepository : IRepository<Produit>
    {
        void Update(Produit obj);
    }
}