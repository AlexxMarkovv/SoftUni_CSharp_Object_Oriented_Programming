using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;

            targets = new List<string>();
        }

        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                name = value;
            }
        }

        private ICaptain captain;

        public ICaptain Captain
        {
            get { return captain; }
            set 
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }
                captain = value;
            }
        }

        private double armorThickness;

        public double ArmorThickness
        {
            get { return armorThickness; }
            set { armorThickness = value; }
        }

        private double mainWeaponCaliber;

        public double MainWeaponCaliber
        {
            get { return mainWeaponCaliber; }
            protected set { mainWeaponCaliber = value; }
        }

        private double speed;

        public double Speed
        {
            get { return speed; }
            protected set { speed = value; }
        }

        private List<string> targets;
        public ICollection<string> Targets => targets;

        public void Attack(IVessel target)
        {
            if (targets == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= MainWeaponCaliber;

            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }

            targets.Add(target.Name);

            this.Captain.IncreaseCombatExperience();
            target.Captain.IncreaseCombatExperience();
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string targetsOutput = !Targets.Any() ? "none" : string.Join(", ", Targets);

            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {Speed} knots");
            sb.AppendLine($" *Targets: {targetsOutput}");

            return sb.ToString().TrimEnd();
        }
    }
}
