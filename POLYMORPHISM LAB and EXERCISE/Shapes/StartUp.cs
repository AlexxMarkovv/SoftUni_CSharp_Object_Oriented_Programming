namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape circle = new Circle(15);
            Shape rectangle = new Rectangle(5, 10);

            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(rectangle.CalculateArea());
        }
    }
}