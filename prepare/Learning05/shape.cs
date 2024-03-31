public abstract class Shape
{
    // Using properties for color
    public string Color { get; set; }

    // Constructor to set color
    public Shape(string color)
    {
        Color = color;
    }

    // Abstract method for calculating area
    public abstract double GetArea();
}
