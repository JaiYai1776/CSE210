using System;
using System.Xml.Schema;

class Program
{
    static void Main(string[] args)
    {
        Fraction fract1 = new Fraction();
        Console.WriteLine("Fractional Representation: " + fract1.GetFractionalRepresentation());
        Console.WriteLine("Decimal Representation: " + fract1.GetDecimalRepresentation());

        Fraction fract2 = new Fraction(5);
        Console.WriteLine("Fractional Representation: " + fract2.GetFractionalRepresentation());
        Console.WriteLine("Decimal Representation: " + fract2.GetDecimalRepresentation());

        Fraction fract3 = new Fraction(3, 4);
        Console.WriteLine("Fractional Representation: " + fract3.GetFractionalRepresentation());
        Console.WriteLine("Decimal Representation: " + fract3.GetDecimalRepresentation());

        Fraction fract4 = new Fraction(1, 3);
        Console.WriteLine("Fractional Representation: " + fract4.GetFractionalRepresentation());
        Console.WriteLine("Decimal Representation: " + fract4.GetDecimalRepresentation());
    }
}