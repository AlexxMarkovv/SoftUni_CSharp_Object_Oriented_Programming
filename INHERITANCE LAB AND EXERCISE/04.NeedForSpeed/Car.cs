using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double defaultFuelConsumption = 3;

        public Car(int horsePower, double fuel)
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
