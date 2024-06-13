using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using BulkyWeb.DataAccess.Data;

namespace Bulky.DataAccess.Repository
{
    public class EnteteCommandeRepository : Repository<EnteteCommande>, IEnteteCommandeRepository
    {
        private ApplicationDbContext _db;

        public EnteteCommandeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(EnteteCommande obj)
        {
            _db.EntetesCommandes.Update(obj);
        }
    }
}