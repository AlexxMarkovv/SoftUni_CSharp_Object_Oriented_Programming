using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;
using BorderControl.Models;

List <ICelebratable> birthdateMembers = new List <ICelebratable>();

string command;
while ((command = Console.ReadLine()) != "End")
{
    string[] cmndArrgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (cmndArrgs[0] == "Citizen")
    {
        Citizen citizen = new Citizen(cmndArrgs[1], int.Parse(cmndArrgs[2]), cmndArrgs[3], cmndArrgs[4]);
        birthdateMembers.Add(citizen);
    }
    else if (cmndArrgs[0] == "Pet")
    {
        Pet pet = new Pet(cmndArrgs[1], cmndArrgs[2]);
        birthdateMembers.Add(pet);
    }
}

string year = Console.ReadLine();

foreach (var member in birthdateMembers)
{
    if (member.Birthdate.EndsWith(year))
    {
        Console.WriteLine(member.Birthdate);
    }
}