namespace SquareRoot
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int num = int.Parse(Console.ReadLine());

                if (num < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(num), "Invalid number.");
                }

                Console.WriteLine(Math.Sqrt(num));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number.");
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}