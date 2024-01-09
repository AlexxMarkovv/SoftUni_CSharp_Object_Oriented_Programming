
string[] inputArrgs = Console.ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries);

Dictionary<double, double> accounts = new Dictionary<double, double>();

for (int i = 0; i < inputArrgs.Length; i++)
{
    double[] accInfo = inputArrgs[i].Split("-")
        .Select(double.Parse)
        .ToArray();

    double accountNumber = accInfo[0];
    double balance = accInfo[1];

    if (!accounts.ContainsKey(accountNumber))
    {
        accounts.Add(accountNumber, balance);
    }
}

string command;
while ((command = Console.ReadLine()) != "End")
{
    string[] cmndArrgs = command.Split();

    string cmndType = cmndArrgs[0];
    int accNumber = int.Parse(cmndArrgs[1]);
    double sum = double.Parse(cmndArrgs[2]);

    try
    {
        if (cmndType != "Deposit" &&  cmndType != "Withdraw")
        {
            throw new InvalidCommand();
        }

        if (!accounts.ContainsKey(accNumber))
        {
            throw new InvalidAccount();
        }

        if (cmndType == "Withdraw")
        {
            accounts[accNumber] -= sum;

            if (accounts[accNumber] < 0)
            {
                accounts[accNumber] += sum;
                throw new InsufficientBalance();
            }
            else
            {
                Console.WriteLine($"Account {accNumber} has new balance: {accounts[accNumber]:f2}");
            }
        }
        else
        {
            accounts[accNumber] += sum;

            Console.WriteLine($"Account {accNumber} has new balance: {accounts[accNumber]:f2}");
        }
    }
    catch (InvalidCommand ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (InvalidAccount ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (InsufficientBalance ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        Console.WriteLine("Enter another command");
    }
}

public class InvalidCommand : Exception
{
    public InvalidCommand()
        : base("Invalid command!")
    {
    }
}

public class InvalidAccount : Exception
{
    public InvalidAccount()
        : base("Invalid account!")
    {
    }
}

public class InsufficientBalance : Exception
{
    public InsufficientBalance()
        : base("Insufficient balance!")
    {
    }
}