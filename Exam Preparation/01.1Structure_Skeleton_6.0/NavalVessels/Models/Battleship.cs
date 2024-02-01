using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double InitialArmourThikness = 300; 
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, InitialArmourThikness)
        {
            SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            if (SonarMode == false)
            {
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 5;
            }

            //Flip Mode -> Toggle 
            SonarMode = !SonarMode;
        }

        public override void RepairVessel()
        {
            ArmorThickness = InitialArmourThikness;
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
            sb.AppendLine($" *Sonar mode: {(SonarMode ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}
