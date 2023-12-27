using System.Xml.Linq;

namespace FootballTEamPractice
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmndArrgs = input
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);
                string cmndType = cmndArrgs[0];
                string teamName = cmndArrgs[1];

                try
                {
                    switch (cmndType)
                    {
                        case "Team":
                            AddTeam(teamName, teams);
                            break;
                        case "Add":
                            AddPlayerToTeam(teamName, cmndArrgs[2],
                            int.Parse(cmndArrgs[3]),
                            int.Parse(cmndArrgs[4]),
                            int.Parse(cmndArrgs[5]),
                            int.Parse(cmndArrgs[6]),
                            int.Parse(cmndArrgs[7]),
                            teams);
                            break;
                        case "Remove":
                            RemovePlayer(teamName, cmndArrgs[2], teams);
                            break;
                        case "Rating": PrintRating(teams, teamName);
                            break;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
        }

        public static void AddTeam(string teamName, List<Team> teams)
        {
            teams.Add(new Team(teamName));
        }

        public static void AddPlayerToTeam(
            string teamName,
            string playerName,
            int endurance,
            int sprint,
            int dribble,
            int passing,
            int shooting,
            List<Team> teams)
        {
            Team team = teams.FirstOrDefault(x => x.Name == teamName);

            if (team == null)
            {
                throw new ArgumentException($"Team [{teamName}] does not exist.");
            }

            Player player = new(playerName, endurance, sprint, dribble, passing, shooting);
            team.AddPlayer(player);
        }

        public static void RemovePlayer(string teamName, string playerName, List<Team> teams)
        {
            Team team =  teams.FirstOrDefault(x => x.Name == teamName);

            if (team == null)
            {
                throw new ArgumentException($"Player[{playerName}] is not in [{teamName}] team.");
            }

            team.RemovePlayer(playerName);
        }

        public static void PrintRating(List<Team> teams, string teamName)
        {
            Team team = teams.FirstOrDefault(x => x.Name == teamName);

            if (team == null)
            {
                throw new ArgumentException($"Team [{teamName}] does not exist.");
            }

            Console.WriteLine($"{teamName} - {team.Rating:f2}");

        }
    }
}