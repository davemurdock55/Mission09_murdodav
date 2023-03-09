using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_murdodav.Models
{
    public class Cart
    {
        // declaring and initializing a List of CartItems called "Items" (which is a new CartItem list)
        // First part declares, second part instantiates
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        // the method to add an item
        public void AddItem(Book book, int qty)
        {
            // create a new instance of a CartItem called "ItemInCart" (to go see if an instance of that Book "line item" is already in the cart (Items list))
            CartItem ItemInCart = CartItems
                // Go look in the cart for a CartItem Book attribute (object) with a BookId that matches the BookId (called "book" that was passed to this method (AddItem)
                .Where(b => b.Book.BookId == book.BookId)
                // And get the first one, because there's hopefully only one that matches :)
                .FirstOrDefault();


            //and then add it to the list

            // IF... that Book "item" is NOT already in the cart (IOW if our variable "ItemInCart" is not holding anything
            // because the item was not already in our CartItems list
            if (ItemInCart == null)
            {
                // Then add to the CartItems list a new CartItem and pass it all the necessary info
                // that we recieve in this method (book, qty) inside a dictionary to the .Add() method of the CartItems list
                CartItems.Add(new CartItem
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else // OTHERWISE
            {
                // add the qty passed to this AddItem() method to the book in the cart's current quantity
                ItemInCart.Quantity += qty;
            }

        }


        // a method to get the total of the cart (all quantities multiplied by the amount in the cart, all added together)
        public double CalculateTotal()
        {
            // get the sum, which is a sum of all the quantities multiplied by the Book object's price attribute
            double sum = CartItems.Sum(x => x.Quantity * x.Book.Price);

            // returning the sum
            return sum;
        }
    }

    // Making a class for each item in the cart (because there will be multiple of these in the cart)
    public class CartItem
    {
        public int LineID { get; set; } // making an integer to hold a unique ID for the item in the cart (the ID of the Line Item)
        public Book Book { get; set; } // making an object of type Book called "Book" for the "book" part of the Line Item
        public int Quantity { get; set; } // making an integer to hold the current quantity for the item in the cart (the "quantity" part of the Line Item)
    }
}
