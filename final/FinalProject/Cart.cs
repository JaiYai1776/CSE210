using System;
using System.Collections.Generic;

public class Cart
{
    private List<CartItem> items = new List<CartItem>();

    // Method to clear the cart
    public void Clear()
    {
        items.Clear();
    }

    // Method to get the items (books) in the cart
    public List<CartItem> GetItems()
    {
        return items;
    }
    // Method to add a book to the cart
    public void AddBook(Book book, int quantity)
    {
        // Check if the book is already in the cart
        CartItem existingItem = items.Find(item => item.Book.Id == book.Id);
        if (existingItem != null)
        {
            // If the book is already in the cart, increase the quantity
            existingItem.Quantity += quantity;
        }
        else
        {
            // If the book is not in the cart, add it as a new item
            items.Add(new CartItem(book, quantity));
        }
    }

    // Method to remove a book from the cart
    public void RemoveBook(Book book)
    {
        // Find the item corresponding to the book and remove it from the cart
        CartItem itemToRemove = items.Find(item => item.Book.Id == book.Id);
        if (itemToRemove != null)
        {
            items.Remove(itemToRemove);
        }
    }

    // Method to display the contents of the cart
    public void DisplayCart()
    {
        Console.WriteLine("Your Cart:");
        if (items.Count == 0)
        {
            Console.WriteLine("Your cart is empty.");
        }
        else
        {
            foreach (var item in items)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Book ID: {item.Book.Id}, Title: {item.Book.Title}, Price: {item.Book.Price}, Quantity: {item.Quantity}");
            }
        }
    }

public void DisplayCartTitles()
    {
        Console.WriteLine("Your Cart:");
        if (items.Count == 0)
        {
            Console.WriteLine("Your cart is empty.");
        }
        else
        {
            foreach (var item in items)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Title: {item.Book.Title}, Price: {item.Book.Price}, Quantity: {item.Quantity}");
            }
        }
    }
    // Method to calculate the total price of the items in the cart
    public decimal CalculateTotalPrice()
    {
        decimal totalPrice = 0;
        foreach (var item in items)
        {
            totalPrice += item.Book.Price * item.Quantity;
        }
        return totalPrice;
    }

    // Method to calculate the total number of items in the cart
    public int TotalItems()
    {
        int totalItems = 0;
        foreach (var item in items)
        {
            totalItems += item.Quantity;
        }
        return totalItems;
    }
}
