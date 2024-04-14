// Purpose: This file contains the Customer class which is used to store information about a customer.
using System;

public class Customer {
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    // Constructor
    public Customer(string username, string password, string email, string address) {
        Username = username;
        Password = password;
        Email = email;
        Address = address;
    }
}