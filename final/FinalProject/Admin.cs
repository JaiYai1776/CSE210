using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Threading;

public class Admin {
    private Inventory inventory = new Inventory();
    public bool IsLoggedIn { get; private set; }

    private const string AdminUsername = "admin";
    private const string AdminPassword = "admin123";

    private const string bookFilePath = "books.txt"; // Path to the file storing inventory information

    private string soldItemsFilePath = "sold_items.txt"; // Path to the file where sold items are stored

    private List<SoldItem> soldItemsList = new List<SoldItem>(); // List to store sold items


    // Method to handle admin login
    public bool Login() {
        Console.Clear();
        Console.WriteLine("Admin Login");

        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        if (username == AdminUsername && password == AdminPassword) {
            Console.WriteLine("Login successful!");
            Thread.Sleep(1000); // Simulating a delay for demonstration purposes
            IsLoggedIn = true;
            return true;
        } else {
            Console.WriteLine("Invalid username or password. Login failed.");
            Thread.Sleep(1000); // Simulating a delay for demonstration purposes
            return false;
        }
    }

   

    public void AddBookToInventory()
{
    Console.Clear();
    Console.WriteLine("Add Book to Inventory");

    Console.Write("Enter book title: ");
    string title = Console.ReadLine();

    Console.Write("Enter author: ");
    string author = Console.ReadLine();

    Console.Write("Enter genre: ");
    string genre = Console.ReadLine();

    Console.Write("Enter price: ");
    if (!decimal.TryParse(Console.ReadLine(), out decimal price))
    {
        Console.WriteLine("Invalid price format. Book not added to inventory.");
        Thread.Sleep(1000); // Simulating a delay for demonstration purposes
        return;
    }

    Console.Write("Enter quantity: ");
    if (!int.TryParse(Console.ReadLine(), out int quantity))
    {
        Console.WriteLine("Invalid quantity format. Book not added to inventory.");
        Thread.Sleep(1000); // Simulating a delay for demonstration purposes
        return;
    }

    Console.Write("Enter book ID: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Invalid ID format. Book not added to inventory.");
        Thread.Sleep(1000); // Simulating a delay for demonstration purposes
        return;
    }

    Console.Write("Enter cost: ");
    if (!decimal.TryParse(Console.ReadLine(), out decimal cost))
    {
        Console.WriteLine("Invalid cost format. Book not added to inventory.");
        Thread.Sleep(1000); // Simulating a delay for demonstration purposes
        return;
    }

    // Create a new Book object with the collected information
    Book newBook = new Book(id, title, author, quantity, genre, price, cost);

    // Add the new book to the inventory
    inventory.AddBook(newBook);

    Console.WriteLine("Book added to inventory successfully!");
    Thread.Sleep(1000); // Simulating a delay for demonstration purposes
    // Save the updated inventory to file
    SaveInventoryToFile();
}
   // Method to remove a book from inventory
    public void RemoveBook(string bookId) {
        // Find and remove the book from inventory based on the provided ID
        inventory.RemoveBook(bookId);
    }

    // Method to remove a book from inventory
public void RemoveBookFromInventory()
{
    Console.Clear();
    Console.WriteLine("Removing a Book from Inventory");
    Console.WriteLine();

    // Display inventory (ID and title only)
    Console.WriteLine("Inventory:");
    Console.WriteLine("ID\tTitle");
    foreach (var book in inventory.Books)
    {
        Console.WriteLine($"{book.Id}\t{book.Title}"); 
    }
    Console.WriteLine();

    // Ask the user for the ID of the book to remove
    Console.Write("Enter the ID of the book you want to remove: ");
    string bookId = Console.ReadLine();

    // Call the RemoveBook method to remove the book from the inventory
    if (!string.IsNullOrEmpty(bookId))
    {
        if (!int.TryParse(bookId, out int id))
        {
            Console.WriteLine("Invalid book ID format.");
            return;
        }
        
        // Remove the book without assigning the result to a variable
        RemoveBook(bookId);
        
        // Since the RemoveBook method doesn't return a book, there's no need to check if it's not null
        Console.WriteLine($"Book with ID '{bookId}' removed from inventory successfully!");

        // Update the books.txt file to reflect the removal
        SaveInventoryToFile();
    }
    else
    {
        Console.WriteLine("Please provide a valid book ID.");
    }

    Thread.Sleep(1000); // Simulating a delay for demonstration purposes
}


     // Method to save inventory to file
    public void SaveInventoryToFile() {
        using (StreamWriter writer = new StreamWriter(bookFilePath, true)) {
            foreach (Book book in inventory.Books) {
                writer.WriteLine($"{book.Id},{book.Title},{book.Author},{book.Quantity},{book.Genre},{book.Price},{book.Cost}");
            }
        }
        Console.WriteLine("Inventory saved to file successfully!");
    }


    // Method to view books sold
public void ViewBooksSold()
    {
        Console.WriteLine("Books Sold:");

        List<SoldItem> soldItems = GetSoldItems();

        foreach (SoldItem soldItem in soldItems)
        {
            Console.WriteLine($"Book ID: {soldItem.BookId}, Quantity Sold: {soldItem.Quantity}");
        }
    }

    private List<SoldItem> GetSoldItems()
    {
        List<SoldItem> soldItems = new List<SoldItem>();

        if (File.Exists(soldItemsFilePath))
        {
            string[] lines = File.ReadAllLines(soldItemsFilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[0], out int bookId) && int.TryParse(parts[1], out int quantity))
                {
                    soldItems.Add(new SoldItem(bookId, quantity));
                }
            }
        }

        return soldItems;
    }

     // Method to handle admin logout
    public void Logout()
    {
        IsLoggedIn = false;
        Console.WriteLine("Logged out successfully!");
        Thread.Sleep(1000); // Simulating a delay for demonstration purposes
    }
static void PlaceOrder(Customer customer, Cart cart, Inventory inventory)
{
    // Display the books in the cart with their titles
    Console.WriteLine("Books in Cart:");
    cart.DisplayCartTitles();

    // Calculate the total price of the items in the cart
    decimal totalPrice = cart.CalculateTotalPrice();

    // Calculate sales tax (4.255% Missouri Sales tax)
    decimal salesTaxRate = 0.04255M;
    decimal salesTax = totalPrice * salesTaxRate;

    // Calculate total including sales tax
    decimal total = totalPrice + salesTax;

    // Display the order details
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"Total number of items: {cart.TotalItems()}");
    Console.WriteLine($"Subtotal: {totalPrice:C}");
    Console.WriteLine($"Sales tax (4.255% Missouri Sales tax): {salesTax:C}");
    Console.WriteLine($"Total: {total:C}");

    // Ask the user if they wish to continue with the order
    Console.Write("Do you wish to continue with the order? (y/n): ");
    string input = Console.ReadLine();

    // If the user chooses to continue, process the order
    if (input.ToLower() == "y")
    {
        // Create an instance of the Admin class
        Admin admin = new Admin();

        // Subtract the quantity of each book in the cart from the inventory
        foreach (CartItem item in cart.GetItems())
        {
            inventory.SubtractFromInventory(item.Book.Id, item.Quantity);
        }

        // Save sold items to file
        admin.SaveSoldItemsToFile(cart.GetItems());

        // Clear the cart
        cart.Clear();
        Console.WriteLine("Order placed successfully!");
    }
    else
    {
        Console.WriteLine("Order canceled.");
    }
}
private void SaveSoldItemsToFile(List<CartItem> items)
{
    using (StreamWriter writer = new StreamWriter(soldItemsFilePath, true))
    {
        foreach (var item in items)
        {
            writer.WriteLine($"{item.Book.Id},{item.Quantity}");
        }
    }
    Console.WriteLine("Sold items saved to file successfully!");

}
}
