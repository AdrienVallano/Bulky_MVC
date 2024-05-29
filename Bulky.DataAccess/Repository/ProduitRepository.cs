using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using BulkyWeb.DataAccess.Data;

namespace Bulky.DataAccess.Repository
{
    public class ProduitRepository : Repository<Produit>, IProduitRepository
    {
        private ApplicationDbContext _db;

        public ProduitRepository(ApplicationDbContext context) : base(context)
        {
            _db = context;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Produit obj)
        {
            _db.Update(obj);
        }
    }
}