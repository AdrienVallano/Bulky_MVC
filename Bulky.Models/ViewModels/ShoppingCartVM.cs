namespace Bulky.Models.ViewModels
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCart> PanierListeAchat { get; set; }
        public EnteteCommande EnteteCommande { get; set; }

    }
}
