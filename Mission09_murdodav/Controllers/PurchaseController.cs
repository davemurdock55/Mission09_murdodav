using Microsoft.AspNetCore.Mvc;
using Mission09_murdodav.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_murdodav.Controllers
{
    public class PurchaseController : Controller
    {
        private IBookPurchaseRepository repo { get; set; }
        private Cart cart { get; set; }

        public PurchaseController(IBookPurchaseRepository temp_repo, Cart temp_cart)
        {
            repo = temp_repo;
            cart = temp_cart;

        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new BookPurchase());
        }

        [HttpPost]
        public IActionResult Checkout(BookPurchase purchase)
        {
            // if cart is empty
            if (cart.CartItems.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }


            if (ModelState.IsValid)
            {
                // from the purchase object passed in, go add lines from the items 
                purchase.Lines = cart.CartItems.ToArray();
                repo.SavePurchase(purchase);

                cart.ClearCart();

                return RedirectToPage("/PurchaseConfirmation");
            }
            else
            {
                return View();
            }
        }

    }
}
