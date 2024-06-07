using Bulky.DataAccess.Repository.IRepository;
using BulkyWeb.DataAccess.Data;

namespace Bulky.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public ICategoryRepository Category { get; private set; }
        public IProduitRepository Produit { get; private set; }
        public IEntrepriseRepository Entreprise { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Produit = new ProduitRepository(_db);
            Entreprise = new EntrepriseRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}