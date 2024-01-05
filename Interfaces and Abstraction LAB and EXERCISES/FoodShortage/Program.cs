using BorderControl.Models;
using FoodShortage.Models;
using FoodShortage.Models.Interfaces;

int n = int.Parse(Console.ReadLine());

List<IBuyer> buyersList = new();

for (int i = 0; i < n; i++)
{
    string[] buyerInfo = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (buyerInfo.Length == 4)
    {
        Citizen citizen = new(buyerInfo[0], int.Parse(buyerInfo[1]), buyerInfo[2], buyerInfo[3]);
        buyersList.Add(citizen);
    }
    else
    {
        Rebel rebel = new Rebel(buyerInfo[0], int.Parse(buyerInfo[1]), buyerInfo[2]);
        buyersList.Add(rebel);
    }
}

string input;
while ((input = Console.ReadLine()) != "End")
{
    buyersList.FirstOrDefault(b => b.Name == input)?.BuyFood();
}

Console.WriteLine(buyersList.Sum(b => b.Food));