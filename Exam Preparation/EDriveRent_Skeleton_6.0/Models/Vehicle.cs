using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        public Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            MaxMileage = maxMileage;
            LicensePlateNumber = licensePlateNumber;
        }

        private string brand;
        public string Brand
        {
            get { return brand; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandNull);
                }

                brand = value;
            }
        }

        private string model;
        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }

                model = value;
            }
        }

        private double maxMileage;
        public double MaxMileage
        {
            get => maxMileage;
            private set => maxMileage = value;
        }

        private string licensePlateNumber;
        public string LicensePlateNumber
        {
            get { return licensePlateNumber; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }

                licensePlateNumber = value;
            }
        }

        private int batteryLevel = 100;
        public int BatteryLevel
        {
            get { return batteryLevel; }
            private set
            {
                batteryLevel = value;
            }
        }

        private bool isDamaged = false;
        public bool IsDamaged
        {
            get { return isDamaged; }
            private set { isDamaged = value; }
        }

        public void Drive(double mileage)
        {
            double percentage = 
                Math.Round(mileage / MaxMileage * 100, MidpointRounding.AwayFromZero);

            if (MaxMileage == 180)
            {
                percentage += 5;
            }

            BatteryLevel -= (int)percentage;
        }

        public void ChangeStatus()
        {
            if (IsDamaged == true)
            {
                IsDamaged = false;
            }
            else
            {
                IsDamaged = true;
            }
        }

        public void Recharge()
        {
            BatteryLevel = 100;
        }

        public override string ToString()
        {
            return $"{Brand} {Model} License plate: {LicensePlateNumber}" +
               $" Battery: {BatteryLevel}% Status: {(isDamaged ? "damaged" : "OK")}";
        }
    }
}
