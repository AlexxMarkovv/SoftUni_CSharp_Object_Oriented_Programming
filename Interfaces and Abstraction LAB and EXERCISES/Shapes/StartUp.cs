namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IDrawable> figures = new List<IDrawable>();

            IDrawable circle = new Circle(5);

            IDrawable rect = new Rectangle(10, 20);

            figures.Add(circle);
            figures.Add(rect);

            circle.Draw();
            rect.Draw();
        }
    }
}