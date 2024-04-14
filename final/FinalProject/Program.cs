using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Threading;

public partial class Program {
    static string customerFilePath = "customers.txt";
    static Inventory inventory = new Inventory();
    static Cart cart = new Cart();
    static Customer customer = null;
    static Admin admin = new Admin();
    static bool exit = false;

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
        // Subtract the quantity of each book in the cart from the inventory
        foreach (CartItem item in cart.GetItems())
        {
            inventory.SubtractFromInventory(item.Book.Id, item.Quantity);
        }
        // Clear the cart
        cart.Clear();
        Console.WriteLine("Order placed successfully!");
    }
    else
    {
        Console.WriteLine("Order canceled.");
    }
}


    static void Main(string[] args) {
        inventory.LoadBooksFromFile();
        if (!File.Exists(customerFilePath)) {
            File.Create(customerFilePath).Close();
        }

        while (!exit) {
            if (customer == null) {
                DisplayGuestMenu();
                int choice = GetMenuChoice(4);

                switch (choice) {
                    case 1:
                        customer = RegisterNewCustomer();
                        break;
                    case 2:
                        customer = LoginAsCustomer();
                        break;
                    case 3:
                        if (admin.Login()) {
                            AdminMenu();
                        }
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } else if (customer != null) {
                DisplayCustomerMenu();
                int choice = GetMenuChoice(7);

                switch (choice) {
                    case 1:
                        inventory.DisplayBooks();
                        break;
                    case 2:
                        AddBookToCart(customer, inventory, cart);
                        break;
                    case 3:
                        cart.DisplayCart();
                        break;
                    case 4:
                        // Calculate total price and total number of items
                        decimal totalPrice = cart.CalculateTotalPrice();
                        int totalItems = cart.TotalItems();
                        // Calculate sales tax (4.255% Missouri Sales tax)
                        decimal salesTaxRate = 0.04255M;
                        decimal salesTax = totalPrice * salesTaxRate;

                        // Calculate total including sales tax
                        decimal total = totalPrice + salesTax;

                        // Display the information
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Total number of items: {totalItems}");
                        Console.WriteLine($"Subtotal: {totalPrice:C}");
                        Console.WriteLine($"Sales tax (4.255% Missouri Sales tax): {salesTax:C}");
                        Console.WriteLine($"Total: {total:C}");
                        break;
                    case 5:
                        PlaceOrder(customer, cart, inventory);
                        break;
                    case 6:
                        customer = null;
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } else if (admin.IsLoggedIn) {
                AdminMenu();
            }
        }
    }

    static void AdminMenu() {
        while (admin.IsLoggedIn && !exit) {
            DisplayAdminMenu();
            int choice = GetMenuChoice(7);

            switch (choice) {
                case 1:
                    admin.AddBookToInventory();
                    break;
                case 2:
                    inventory.DisplayBooksForAdmins();
                    break;
                case 3:
                    admin.ViewBooksSold();
                    break;
                case 4:
                    admin.Logout();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }


    static void DisplayGuestMenu() {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Welcome to the Online Bookstore!");
        Console.WriteLine("1. Register as a new customer");
        Console.WriteLine("2. Log in as an existing customer");
        Console.WriteLine("3. Admin login");
        Console.WriteLine("4. Exit");
    }

    static void DisplayCustomerMenu() {
        //Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Welcome, " + customer.Username + "!");
        Console.WriteLine("Customer Menu");
        Console.WriteLine("1. View available books");
        Console.WriteLine("2. Add book to cart");
        Console.WriteLine("3. View cart");
        Console.WriteLine("4. Calculate total price");
        Console.WriteLine("5. Place order");
        Console.WriteLine("6. Log out");
        Console.WriteLine("7. Exit");
    }

    static void DisplayAdminMenu() {
        //Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Welcome, Admin!");
        Console.WriteLine("Admin Menu");
        Console.WriteLine("1. Add book to inventory");
        Console.WriteLine("2. View inventory");
        Console.WriteLine("3. View books sold");
        Console.WriteLine("4. Log out");
        Console.WriteLine("5. Exit");
    }

    static int GetMenuChoice(int maxChoice) {
        int choice;
        do {
            Console.Write("Enter your choice: ");
        } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > maxChoice);
        return choice;
    }

    static Customer RegisterNewCustomer() {
        Console.Clear();
        Console.WriteLine("Register as a new customer");

        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        Console.Write("Enter email address: ");
        string email = Console.ReadLine();

        Console.Write("Enter shipping address: ");
        string address = Console.ReadLine();

        // Create a new instance of Customer with the collected information
        Customer newCustomer = new Customer(username, password, email, address);

        // Save the new customer information to the file
        using (StreamWriter writer = File.AppendText(customerFilePath)) {
            writer.WriteLine($"{username},{password},{email},{address}");
        }

        Console.WriteLine("Registration successful!");
        Thread.Sleep(1000); // Simulating a delay for demonstration purposes
        return newCustomer;
    }

    static Customer LoginAsCustomer() {
        Console.Clear();
        Console.WriteLine("Customer Login");

        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        // Check if the credentials match any entry in the customers file
        string[] customers = File.ReadAllLines(customerFilePath);
        foreach (string customerInfo in customers) {
            string[] customerDetails = customerInfo.Split(',');
            if (customerDetails.Length == 4 && customerDetails[0] == username && customerDetails[1] == password) {
                Console.WriteLine("Login successful!");
                Thread.Sleep(1000); // Simulating a delay for demonstration purposes
                // Create a new Customer object with the retrieved details
                return new Customer(customerDetails[0], customerDetails[1], customerDetails[2], customerDetails[3]);
            }
        }

        Console.WriteLine("Invalid username or password. Login failed.");
        Thread.Sleep(1000); // Simulating a delay for demonstration purposes
        return null;
    }

static void AddBookToCart(Customer customer, Inventory inventory, Cart cart)
{
    // Display available books for the customer to choose from
    Console.WriteLine("Available Books:");
    inventory.DisplayBooks();

    // Ask the customer to enter the ID of the book they want to add to their cart
    Console.Write("Enter the ID of the book you want to add to your cart: ");
    int bookId;
    while (!int.TryParse(Console.ReadLine(), out bookId) || !inventory.BookExists(bookId))
    {
        Console.WriteLine("Invalid book ID. Please enter a valid ID.");
        Console.Write("Enter the ID of the book you want to add to your cart: ");
    }

    // Ask the customer to enter the quantity of the book they want to add to their cart
    Console.Write("Enter the quantity of the book you want to add to your cart: ");
    int quantity;
    while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 1)
    {
        Console.WriteLine("Invalid quantity. Please enter a valid quantity.");
        Console.Write("Enter the quantity of the book you want to add to your cart: ");
    }

    // Get the book object from the inventory using the provided ID
    Book selectedBook = inventory.GetBookById(bookId);

    // Add the selected book to the cart with the specified quantity
    cart.AddBook(selectedBook, quantity);

    Console.WriteLine($"Added {quantity} of {selectedBook.Title} to your cart.");
}


  public bool BookExists(int bookId)
    {
        // Check if the book exists in the inventory
        foreach (Book book in inventory.Books)
        {
            if (book.Id == bookId)
            {
                return true; // Book found, return true
            }
        }
        // If the loop completes without finding the book, return false
        return false;
    }
}
