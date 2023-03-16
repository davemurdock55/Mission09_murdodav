using Microsoft.AspNetCore.Mvc;
using Mission09_murdodav.Models;

namespace SportsStore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart temp_cart)
        {
            cart = temp_cart;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}