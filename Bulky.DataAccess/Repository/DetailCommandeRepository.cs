using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using BulkyWeb.DataAccess.Data;

namespace Bulky.DataAccess.Repository
{
    public class DetailCommandeRepository : Repository<DetailCommande>, IDetailCommandeRepository
    {
        private ApplicationDbContext _db;

        public DetailCommandeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(DetailCommande obj)
        {
            _db.DetailCommandes.Update(obj);
        }
    }
}