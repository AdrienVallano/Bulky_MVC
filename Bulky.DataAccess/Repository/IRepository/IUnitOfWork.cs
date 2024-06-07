namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProduitRepository Produit { get; }
        IEntrepriseRepository Entreprise { get; }

        void Save();
    }
}