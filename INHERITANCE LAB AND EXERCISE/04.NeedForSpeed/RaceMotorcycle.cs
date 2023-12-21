using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double defaultFuelConsumption = 8;
        public RaceMotorcycle(int horsePower, double fuel)
           : base(horsePower, fuel)
        {

        }

        public override void Drive(double kilometers)
        {
            double fuelSum = defaultFuelConsumption * kilometers;

            Fuel -= fuelSum;
            if (Fuel < 0)
            {
                Fuel = 0;
            }
        }
    }
}
