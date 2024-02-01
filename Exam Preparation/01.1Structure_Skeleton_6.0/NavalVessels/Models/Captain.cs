using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private readonly List<IVessel> vessels;
        public Captain(string fullName)
        {
            FullName = fullName;
            CombatExperience = 0;

            vessels = new List<IVessel>();
        }

        private string fullName;

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                fullName = value;
            }
        }


        private int combatExperience;

        public int CombatExperience
        {
            get { return combatExperience; }
            private set { combatExperience = value; }
        }


        public ICollection<IVessel> Vessels
        {
            get => vessels;
            private set
            {

            }
        }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }

            Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{FullName} has {CombatExperience} combat experience" +
                $" and commands {vessels.Count} vessels.");

            if (Vessels.Any())
            {
                foreach (var vessel in Vessels)
                {
                    if (vessel.GetType().Name == "Battleship")
                    {
                        sb.AppendLine(vessel.ToString());
                    }
                    else if (vessel.GetType().Name == "Submarine")
                    {
                        sb.AppendLine(vessel.ToString());
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
