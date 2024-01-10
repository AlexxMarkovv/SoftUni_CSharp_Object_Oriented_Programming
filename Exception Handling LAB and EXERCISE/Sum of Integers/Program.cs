string[] inputArrgs = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

int sum = 0;

foreach (string element in inputArrgs)
{
	try
	{
		int number = int.Parse(element);

		sum += number;
	}
	catch (FormatException ex)
	{
		Console.WriteLine($"The element '{element}' is in wrong format!");
	}
	catch (OverflowException ex)
	{
		Console.WriteLine($"The element '{element}' is out of range!");
	}
	finally
	{
        Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
    }
}

Console.WriteLine($"The total sum of all integers is: {sum}");