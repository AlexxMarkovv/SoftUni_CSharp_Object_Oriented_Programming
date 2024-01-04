using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> society = new List<IIdentifiable>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (data.Length == 3)
                {
                    Citizen citizen = new(data[0], int.Parse(data[1]), data[2]);
                    society.Add(citizen);
                }
                else
                {
                    Robot robot = new(data[0], data[1]);
                    society.Add(robot);
                }
            }

            string invalidSuffix = Console.ReadLine();

            foreach (var member in society)
            {
                if (member.Id.EndsWith(invalidSuffix))
                {
                    Console.WriteLine(member.Id);
                }
            }
        }
    }
}