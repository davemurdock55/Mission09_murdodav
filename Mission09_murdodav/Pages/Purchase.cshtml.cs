using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_murdodav.Infrastructure;
using Mission09_murdodav.Models;

namespace Mission09_murdodav.Pages
{
    public class PurchaseModel : PageModel
    {
        // creating a private instance of our Water Project Repository called "repo"
        private IBookStoreRepository repo { get; set; }

        // making a public instance of the Cart class called "cart"
        public Cart cart { get; set; }

        // declaring a ReturnUrl string
        public string ReturnUrl { get; set; }


        // Constructor (passing a temporary repo to assign to our actual "repo" variable (declared above)
        public PurchaseModel(IBookStoreRepository temp_repo, Cart temp_cart)
        {
            repo = temp_repo;
            cart = temp_cart;
        }



        // - On a GET request to this Razor page (passing the returnUrl string)
        public void OnGet(string returnUrl)
        {
            // set the DonateModel's ReturnUrl string equal to the passed returnUrl string
            // if it's null, however, just set the ReturnUrl to the index route ("/")
            ReturnUrl = returnUrl ?? "/";

        }


        // - On a POST request to this Razor page

        // We're receiving a "@Model.ProjectId" through the asp-for of the hidden input in our
        // "Donate" button form on the ProjectSummary.cshtml page
        // so we are receiving an "int" that we'll call "projectID"
        public IActionResult OnPost(int BookId, string returnUrl)
        {
            // Making an object of type Project called "p" that we are setting equal to 
            // the project we (hopefully) receive when we go to the repo and look for the first project where
            // that project's ProjectId is equal to the projectID we're receiving in this OnPost() method
            Book b = repo.Books.FirstOrDefault(x => x.BookId == BookId); // Getting the information for that project

            // adding 1 quantity's worth of the project ("p") we just found to our Cart object ("cart") we instantiated just above
            cart.AddItem(b, 1);

            // redirecting the user to the OnGet method above, and passing a new ReturnUrl string that is
            // equal to the returnUrl string this OnPost() method is being passed
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            cart.RemoveItem(cart.CartItems.First(x => x.Book.BookId == bookId).Book);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }


}
