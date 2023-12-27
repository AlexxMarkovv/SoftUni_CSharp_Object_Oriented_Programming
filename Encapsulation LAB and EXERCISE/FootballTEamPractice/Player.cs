namespace FootballTEamPractice
{
    public class Player 
    {
        private const int StatMinValue = 0;
        private const int StatMaxValue = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(
            string name,
            int endurance,
            int sprint,
            int dribble,
            int passing,
            int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
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

        public int Endurance
        {
            get => endurance;
            set
            {
                if (CheckStatValue(value))
                {
                    throw new ArgumentException
                        (string.Format($"[{0}] should be between 0 and 100.", nameof(Endurance)));
                }

                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;
            set
            {
                if (CheckStatValue(value))
                {
                    throw new ArgumentException
                        (string.Format($"[{0}] should be between 0 and 100.", nameof(Sprint)));
                }

                sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;
            set
            {
                if (CheckStatValue(value))
                {
                    throw new ArgumentException
                        (string.Format($"[{0}] should be between 0 and 100.", nameof(Dribble)));
                }

                dribble = value;
            }
        }

        public int Passing
        {
            get => Passing;
            set
            {
                if (CheckStatValue(value))
                {
                    throw new ArgumentException
                        (string.Format($"[{0}] should be between 0 and 100.", nameof(Passing)));
                }

                passing = value;
            }
        }

        public int Shooting
        {
            get => Shooting;
            set
            {
                if (CheckStatValue(value))
                {
                    throw new ArgumentException
                        (string.Format($"[{0}] should be between 0 and 100.", nameof(Shooting)));
                }

                shooting = value;
            }
        }

        public double Stats => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;

        public bool CheckStatValue(int statValue)
        {
            return statValue < StatMinValue || statValue > StatMaxValue;
        }
    }
}