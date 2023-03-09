using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission09_murdodav.Models;
using Mission09_murdodav.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_murdodav.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // creating a variable to hold the "repo" object
        private IBookStoreRepository repo;

        // Constructor: passing the temporary repository variable to the constructor (along with the logger stuff)
        public HomeController(ILogger<HomeController> logger, IBookStoreRepository repo_temp)
        {
            // setting those temporary variables equal to their object attribute counterparts
            //(tying them to the instantiated objects)
            _logger = logger;
            repo = repo_temp;
        }

        // Index Controller (being passed the pageNum w/ the first page as the default
        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            // creating a variable called itemsPerPage, (at least initially) set to 5 items per page
            int itemsPerPage = 10;

            var AllViewInfo = new BooksViewModel
            {

                // getting the books using the repo's IQueryable "Books" object
                Books = repo.Books
                .Where(b => b.Category == bookCategory || bookCategory == null)
                // ordered by BookID
                .OrderBy(b => b.BookId)
                // Skip whatever page we're on minus 1 (so don't skip the page we're on, but skip all the pages before that) 
                // multiplied by the number of items (records) per page 
                .Skip((pageNum - 1) * itemsPerPage)
                // get the number of items per page from there on
                .Take(itemsPerPage),
                // (if we're on page 3 and we have 5 items per page, we will be skip all the records up to "page" 3
                // (grouped by "page") and then get the next 5 records


                PageInfo = new PageInfo
                {
                    TotalBooksCount = (bookCategory == null
                    ? repo.Books.Count()
                    : repo.Books.Where(x => x.Category == bookCategory).Count()),
                    BooksPerPage = itemsPerPage,
                    CurrentPage = pageNum
                }
            };

            IQueryable books = repo.Books
                    .OrderBy(b => b.Title)
                    .Skip(itemsPerPage * (pageNum - 1))
                    .Take(itemsPerPage);

            // returning the Index view and passing the "books" variable (which is an IQueryable of book records)
            return View(AllViewInfo);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

