namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new(204, 55);

            car.Drive(35);

            Console.WriteLine(car.Fuel);
        }
    }
}