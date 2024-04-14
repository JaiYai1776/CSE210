using System;
using System.Collections.Generic;
using System.IO;

public class Book
{
    // Properties
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }
    public decimal Cost { get; set; }
    public int Quantity { get; set; }

    // Constructor
    public Book(int id, string title, string author, int quantity, string genre, decimal price, decimal cost)
    {
        Id = id; // Assign id directly to Id property (no need for ToString())
        Title = title;
        Author = author;
        Genre = genre;
        Price = price;
        Cost = cost;
        Quantity = quantity;
    }
}