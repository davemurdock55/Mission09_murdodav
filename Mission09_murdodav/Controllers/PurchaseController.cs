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
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new BookPurchase());
        }
    }
}
