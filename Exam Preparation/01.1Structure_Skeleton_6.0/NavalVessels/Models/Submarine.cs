using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double InitialArmourThickness = 200;

        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, InitialArmourThickness)
        {
            SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public void ToggleSubmergeMode()
        {
            if (SubmergeMode == false)
            {
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 4;
            }

            SubmergeMode = !SubmergeMode;
        }

        public override void RepairVessel()
        {
            ArmorThickness = InitialArmourThickness;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string targetsOutput = !Targets.Any() ? "None" : string.Join(", ", Targets);

            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {Speed} knots");
            sb.AppendLine($" *Targets: {targetsOutput}");
            sb.AppendLine($" *Submerge mode: {(SubmergeMode ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}
