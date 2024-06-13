namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProduitRepository Produit { get; }
        IEntrepriseRepository Entreprise { get; }
        IShoppingCartRepository ShoppingCart { get; }
        IApplicationuserRepository ApplicationUser { get; }
        IDetailCommandeRepository DetailCommande { get; }
        IEnteteCommandeRepository EnteteCommande { get; }

        void Save();
    }
}