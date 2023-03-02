using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_murdodav.Models.ViewModels
{
    // A class with a bunch of info about each pagination page for displaying the books
    public class PageInfo
    {
        // creating a variable to hold the total number of books in the repo
        public int TotalBooksCount { get; set; }
        
        // creating a variable to hold the total number of books per pagination page
        public int BooksPerPage { get; set; }

        // creating a variable to hold the number of what pagination page we're on
        public int CurrentPage { get; set; }

        // Calculating the total number of pagination pages we'll need
        // to do this, we convert the TotalBooksCount to a double so the rounding is correct
        // and then divide that by the number of books we want to display per pagination page
        // and then we round UP (Ceiling) so we get enough pages and convert that to an integer (only whole #'s for pages)
        public int TotalPages => (int)Math.Ceiling((double)TotalBooksCount / BooksPerPage);
        // this is because if you had 1 project in the datbase and were supposed to show 2 projects per page, the result would be 0 (nothing at all would show on the page)
        // we add Math.Ceiling so that it will round UP always (meaning we always get that extra page we need (e.g. if we were left needing 4.25 pages, we want to get 5 instead of 4)

    }
}
