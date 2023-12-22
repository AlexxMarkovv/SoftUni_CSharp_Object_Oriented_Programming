namespace CustomStack;

public class StartUp
{
    static void Main(string[] args)
    {
        StackOfStrings stack = new();

        Console.WriteLine(stack.IsEmpty());

        stack.AddRange(new List<string> { "Alex", "Gosho", "Marto" });

        Console.WriteLine(string.Join(" ", stack));

        Console.WriteLine(stack.Pop());
    }
}