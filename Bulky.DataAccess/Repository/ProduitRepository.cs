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
            //_db.Update(obj);
            var objFromDb = _db.Produits.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Titre = obj.Titre;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Auteur = obj.Auteur;
                objFromDb.ListePrix = obj.ListePrix;
                objFromDb.Prix = obj.Prix;
                objFromDb.Prix50 = obj.Prix50;
                objFromDb.Prix100 = obj.Prix100;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Description = obj.Description;
                if(obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }




            }
        }
    }
}