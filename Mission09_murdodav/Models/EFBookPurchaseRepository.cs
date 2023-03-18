using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_murdodav.Models
{
    public class EFBookPurchaseRepository : IBookPurchaseRepository
    {
        private BookstoreContext context;
        public EFBookPurchaseRepository(BookstoreContext temp_context)
        {
            context = temp_context;
        }

        public IQueryable<BookPurchase> BookPurchases => context.BookPurchases.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SavePurchase(BookPurchase purchase)
        {
            // get project associated with that particular line
            context.AttachRange(purchase.Lines.Select(x => x.Book));

            if (purchase.PurchaseId == 0)
            {
                context.BookPurchases.Add(purchase);
            }
            context.SaveChanges();
        }
    }
}
