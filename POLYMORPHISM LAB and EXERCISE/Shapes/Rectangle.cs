
namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height
        {
            get { return height; }
            private set
            {
                height = value;
            }
        }
        public double Width
        {
            get { return width; }
            private set
            {
                width = value;
            }
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }

        public override double CalculatePerimeter()
        {
            return (Height * 2) + (Width * 2);
        }
    }
}
