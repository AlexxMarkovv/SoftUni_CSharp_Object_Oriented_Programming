namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string command;
            while((command = Console.ReadLine()) != "END")
            {
                string[] cmndArrgs = command
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                string commandType = cmndArrgs[0];

                try
                {
                    switch (commandType)
                    {
                        case "Team":
                            AddTeam(cmndArrgs[1], teams);
                            break;
                        case "Add":
                            AddPlayer(
                                cmndArrgs[1],
                                cmndArrgs[2],
                                int.Parse(cmndArrgs[3]),
                                int.Parse(cmndArrgs[4]),
                                int.Parse(cmndArrgs[5]),
                                int.Parse(cmndArrgs[6]),
                                int.Parse(cmndArrgs[7]),
                                teams);
                            break;
                        case "Remove":
                            RemovePlayer(cmndArrgs[1], cmndArrgs[2], teams);
                            break;
                        case "Rating":
                            PrintRating(cmndArrgs[1], teams);
                            break;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void AddTeam(string name, List<Team> teams)
        {
            teams.Add(new Team(name));
        }

        static void AddPlayer(
            string teamName,
            string name,
            int endurance,
            int sprint,
            int dribble,
            int passing,
            int shooting,
            List <Team> teams)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            Player player = new (name, endurance, sprint, dribble, passing, shooting);
            team.AddPlayer(player);
        }

        static void RemovePlayer(string teamName, string playerName, List<Team> teams)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            team.RemovePlayer(playerName);
        }

        static void PrintRating(string teamName, List<Team> teams)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            Console.WriteLine($"{teamName} - {team.Rating:f0}");
        }
    }
}