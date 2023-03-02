using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_murdodav.Models
{
    public class EFBookStoreRepository : IBookStoreRepository
    {
        // creating a DBContext variable (BookstoreContext) to hold our database context called "context"
        private BookstoreContext context { get; set; }

        // The constructor of the Repository (passing a temporary context object so that
        // our context variable gets filled with our actual database context upon creation of the object
        public EFBookStoreRepository(BookstoreContext temp_context)
        {
            // setting the context 
            context = temp_context;
        }

        // getting an IQueryable object of type book called "Books" from the context variable's Books (which receives its DbContext value above)
        public IQueryable<Book> Books => context.Books;
    }
}
