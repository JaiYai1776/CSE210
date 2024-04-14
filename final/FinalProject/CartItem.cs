using System;
using System.Collections.Generic;
using System.Linq;



public class CartItem {
    public Book Book { get; set; }
    public int Quantity { get; set; }

    public CartItem(Book book, int quantity) {
        Book = book;
        Quantity = quantity;
    }
}