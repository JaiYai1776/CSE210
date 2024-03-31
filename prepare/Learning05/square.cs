public class Square : Shape
    {
        private double _side;

        public Square(string color, double side) : base(color)
        {
            _side = side;
        }

        // Override method to calculate area for Square
        public override double GetArea()
        {
            return _side * _side;
        }
    }