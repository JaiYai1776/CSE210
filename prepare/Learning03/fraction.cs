using System;

public class Fraction
{
    private int numerator;
    private int denominator;

    // Constructors
    public Fraction()
    {
        // Default to 1/1
        numerator = 1;
        denominator = 1;
    }

    public Fraction(int wholeNumber)
    {
        numerator = wholeNumber;
        denominator = 1;
    }
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Denominator cannot be zero.");
        
        this.numerator = numerator;
        this.denominator = denominator;
    }

    // Getter and setter for numerator
    public int Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }

    // Getter and setter for denominator
    public int Denominator
    {
        get { return denominator; }
        set
        {
            if (value == 0)
                throw new ArgumentException("Denominator cannot be zero.");
            
            denominator = value;
        }
    }

    // Method to return fractional representation
    public string GetFractionalRepresentation()
    {
        return $"{numerator}/{denominator}";
    }

    // Method to return decimal representation
    public double GetDecimalRepresentation()
    {
        return (double)numerator / denominator;
    }
}