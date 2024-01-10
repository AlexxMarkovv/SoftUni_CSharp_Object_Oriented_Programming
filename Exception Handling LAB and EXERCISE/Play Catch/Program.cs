int[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int exCount = 3;

while (exCount > 0)
{
    string[] cmndArrgs = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string cmndType = cmndArrgs[0];

	try
	{
		if (cmndType == "Replace")
		{
			int index = int.Parse(cmndArrgs[1]);
			int element = int.Parse(cmndArrgs[2]);

			if (index >= 0 && index < numbers.Length)
			{
				numbers[index] = element;
			}
			else
			{
				throw new ArgumentOutOfRangeException("", "The index does not exist!");
			}
		}
		else if (cmndType == "Print")
		{
            int index = int.Parse(cmndArrgs[1]);
            int index2 = int.Parse(cmndArrgs[2]);

			if (index >= 0 && index < numbers.Length
				&& index2 >= 0 && index2 < numbers.Length)
			{
				int[] numsToPrint = numbers.Take(index + index2).ToArray();
				numsToPrint = numsToPrint.Skip(index).ToArray();

                Console.WriteLine(string.Join(", ", numsToPrint));
            }
			else
			{
                throw new ArgumentOutOfRangeException("", "The index does not exist!");
            }
        }
		else if (cmndType == "Show")
		{
			int index = int.Parse(cmndArrgs[1]);

			if ( index >= 0 && index < numbers.Length)
			{
                Console.WriteLine(numbers[index]);
            }
			else
			{
                throw new ArgumentOutOfRangeException("", "The index does not exist!");
            }
        }
	}
	catch (ArgumentOutOfRangeException ex)
	{
		exCount--;
        Console.WriteLine(ex.Message);
    }
	catch (FormatException)
	{
        exCount--;
        Console.WriteLine("The variable is not in the correct format!");
    }
}

Console.WriteLine(string.Join(", ", numbers));