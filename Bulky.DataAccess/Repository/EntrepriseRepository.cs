using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using BulkyWeb.DataAccess.Data;

namespace Bulky.DataAccess.Repository
{
    public class EntrepriseRepository : Repository<Entreprise>, IEntrepriseRepository
    {
        private ApplicationDbContext _db;

        public EntrepriseRepository(ApplicationDbContext context) : base(context)
        {
            _db = context;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Entreprise obj)
        {
            //_db.Update(obj);
            var objFromDb = _db.Entreprises.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Nom = obj.Nom;
                objFromDb.Adresse = obj.Adresse;
                objFromDb.Ville = obj.Ville;
                objFromDb.Code = obj.Code;
                objFromDb.PhoneNumber = obj.PhoneNumber;
            }
        }

    }
}