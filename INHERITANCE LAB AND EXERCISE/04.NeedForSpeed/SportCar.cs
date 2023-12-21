﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double DefaultFuelConsumption = 10;

        public SportCar (int horsePower, double fuel)
           : base(horsePower, fuel)
        {

        }

        public override void Drive(double kilometers)
        {
            double fuelSum = DefaultFuelConsumption * kilometers;

            Fuel -= fuelSum;
            if (Fuel < 0)
            {
                Fuel = 0;
            }
        }
    }
}
