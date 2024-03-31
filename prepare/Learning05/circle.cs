public class Circle : Shape
    {
        private double _radius;

        public Circle(string color, double radius) : base(color)
        {
            _radius = radius;
        }

        // Override method to calculate area for Circle
        public override double GetArea()
        {
            return _radius * _radius * Math.PI;
        }
    }