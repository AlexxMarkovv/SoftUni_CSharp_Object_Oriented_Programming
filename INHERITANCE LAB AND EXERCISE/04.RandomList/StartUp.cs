namespace CustomRandomList;

public class StartUp
{
    static void Main(string[] args)
    {
        RandomList list = new RandomList()
        {
            { "One" },
            { "Two" },
            { "Three" },
            { "Four" },
        };

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine(list.RandomString());
    }
}