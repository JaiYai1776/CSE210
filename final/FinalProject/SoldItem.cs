using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Threading;

public class SoldItem
{
    public int BookId { get; }
    public int Quantity { get; }

    public SoldItem(int bookId, int quantity)
    {
        BookId = bookId;
        Quantity = quantity;
    }
}
