using Microsoft.AspNetCore.Mvc;
using Mission09_murdodav.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_murdodav.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        // bringing in a repository called "repo"
        private IBookStoreRepository repo { get; set; }

        public CategoriesViewComponent(IBookStoreRepository temp_repo)
        {
            repo = temp_repo;
        }

        public IViewComponentResult Invoke()
        {
            // making a ViewBag entry called "Selectedtype" and setting that to the value of "bookCategory" IF it's in the Route (can be nullable)
            ViewBag.SelectedType = RouteData?.Values["bookCategory"];

            var bookCategories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                // OrderBy x means that we're ordering by the default field
                .OrderBy(x => x);

            return View(bookCategories);
        }
    }
}
