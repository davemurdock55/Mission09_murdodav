using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_murdodav.Models
{
    public interface IBookStoreRepository
    {
        // Every BookStoreRepository class needs an IQueryable object of type "Book"
        IQueryable<Book> Books { get; }

    }
}
