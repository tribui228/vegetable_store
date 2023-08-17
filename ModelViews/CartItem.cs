using Web_market.Models;

namespace Web_market.ModelViews
{
    public class CartItem
    {
        public Product product { get; set; }
        public int amount { get; set; }
        public double TotalMoney => (double)(amount * product.Price);
    }
}
