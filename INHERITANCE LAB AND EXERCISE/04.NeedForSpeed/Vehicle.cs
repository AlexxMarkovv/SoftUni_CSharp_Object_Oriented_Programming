using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public abstract class Vehicle
    {
        private const double defaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public double DefaultFuelConsumption { get; set; }
        public virtual double FuelConsumption { get; set; }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }


        public virtual void Drive(double kilometers)
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
