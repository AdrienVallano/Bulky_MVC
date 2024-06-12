namespace Bulky.Models.ViewModels
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCart> PanierListeAchat { get; set; }
        public double OrderTotal { get; set; }

    }
}
