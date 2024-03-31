using System;
using System.Collections.Generic;

class Program
    {
        static void Main(string[] args)
        {
            // Using List<> to store shapes
            List<Shape> shapes = new List<Shape>();

            // Adding different shapes to the list
            shapes.Add(new Square("Red", 3));
            shapes.Add(new Rectangle("Blue", 4, 5));
            shapes.Add(new Circle("Green", 6));

            // Iterating over shapes and displaying their color and area
            foreach (Shape shape in shapes)
            {
                string color = shape.Color;
                double area = shape.GetArea();
                Console.WriteLine($"The {color} shape has an area of {area}.");
            }
        }
    }