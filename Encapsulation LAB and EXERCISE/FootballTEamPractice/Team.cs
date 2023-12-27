using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTEamPractice
{
    public class Team
    {
        private string name;
        private readonly List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }

        }
        public double Rating
        {
            get
            {
                if (players.Any())
                {
                    return players.Average(x => x.Stats);
                }

                return 0;
            }
        }

        public void AddPlayer(Player player) => players.Add(player);

        public void RemovePlayer(string playerToRemove)
        {
            Player player = players.FirstOrDefault(x => x.Name == playerToRemove);

            if (player == null)
            {
                throw new ArgumentException
                    (string.Format($"Player [{0}] is not in [{1}] team.", playerToRemove, Name));
            }

            players.Remove(player);
        }
    }
}
