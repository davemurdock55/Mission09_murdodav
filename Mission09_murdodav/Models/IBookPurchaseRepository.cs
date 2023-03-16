using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_murdodav.Models
{
    public interface IBookPurchaseRepository
    {
        IQueryable<BookPurchase> BookPurchases { get; }

        void SaveDonation(BookPurchase purchase);

    }
}
