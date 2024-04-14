using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

public class Inventory
{
    private List<Book> books;
    
 // Method to subtract a quantity of a book from the inventory
    public void SubtractFromInventory(int bookId, int quantity)
    {
        // Find the book in the inventory by its ID
        Book book = books.FirstOrDefault(b => b.Id == bookId);
        
        // If the book is found and the quantity is available, subtract the quantity
        if (book != null && book.Quantity >= quantity)
        {
            book.Quantity -= quantity;
            
            // Write the updated inventory to the file
            SaveBooksToFile();
        }
    }
    public List<Book> Books
    {
        get { return books; }
    }
    

    // Method to add a book to the inventory
    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public bool BookExists(int bookId)
    {
        return books.Exists(b => b.Id == bookId);
    }
 public void RemoveBook(string bookId)
    {
        if (!int.TryParse(bookId, out int id))
        {
            Console.WriteLine("Invalid book ID format.");
            return;
        }

        Book bookToRemove = books.Find(b => b.Id == id);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
        }
    }

public Book GetBookById(int bookId) {
    if (!int.TryParse(bookId.ToString(), out int id)) {
        Console.WriteLine("Invalid book ID format.");
        return null;
    }
    return books.Find(b => b.Id == id);
}

public Inventory()
    {
        books = new List<Book>();
        
    }
    // Method to load books from a file
public void LoadBooksFromFile()
{
    try
    {
        string[] lines = File.ReadAllLines("books.txt"); // Load from books.txt
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 7) // Assuming cost is included in the file
            {
                if (!int.TryParse(parts[0], out int id))
                {
                    Console.WriteLine("Invalid book ID format.");
                    continue;
                }
                string title = parts[1];
                string author = parts[2];
                int quantity = int.Parse(parts[3]);
                string genre = parts[4];
                decimal price = decimal.Parse(parts[5]);
                decimal bookCost = decimal.Parse(parts[6]);

                Book book = new Book(id, title, author, quantity, genre, price, bookCost);
                books.Add(book);
            }
        }
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("books.txt not found."); // Handle the exception accordingly
    }
    catch (IOException e)
    {
        Console.WriteLine($"Error reading file: {e.Message}");
    }
}

List<CartItem> items = new List<CartItem>(); // Declare and initialize the 'items' variable

public void DisplayCart() {
    foreach (CartItem item in items) {
        Console.WriteLine($"Title: {item.Book.Title}, Quantity: {item.Quantity}");
    }
}

public decimal CalculateTotalPrice() {
    decimal totalPrice = 0;
    foreach (CartItem item in items) {
        totalPrice += item.Book.Price * item.Quantity;
    }
    return totalPrice;
}

public void SaveBooksToFile()
{
    try
    {
        using (StreamWriter writer = File.CreateText("books.txt"))
        {
            foreach (var book in books)
            {
                // Write each book's details to the file
                writer.WriteLine($"{book.Id},{book.Title},{book.Author},{book.Quantity},{book.Genre},{book.Price},{book.Cost}");
            }
        }
    }
    catch (IOException e)
    {
        Console.WriteLine($"Error writing to file: {e.Message}");
    }
}

public void DisplayBooksForAdmins()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("ID\tTitle\t\t\t\t\t\t\tAuthor\t\t\tGenre\t\tCost\t\tPrice\tQuantity");
    foreach (var book in books)
    {
        Console.WriteLine($"{book.Id}\t{book.Title.PadRight(55)}{book.Author.PadRight(25)}{book.Genre.PadRight(20)}{book.Cost}\t{book.Price}\t{book.Quantity}");
    }
}

public void DisplayBooks()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("ID\tTitle\t\t\t\t\t\t\tAuthor\t\t\tGenre\t\tPrice");
    foreach (var book in books)
    {
        Console.WriteLine($"{book.Id}\t{book.Title.PadRight(55)}{book.Author.PadRight(25)}{book.Genre.PadRight(20)}{book.Price}");
    }
}


}


