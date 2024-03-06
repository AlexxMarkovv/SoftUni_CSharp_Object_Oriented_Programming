using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class User : IUser
    {
        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DrivingLicenseNumber = drivingLicenseNumber;
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FirstNameNull);
                }
                firstName = value;
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LastNameNull);
                }

                lastName = value;
            }
        }

        private double rating = 0;

        public double Rating
        {
            get { return rating; }
            private set { rating = value; }
        }

        private string drivingLicenseNumber;

        public string DrivingLicenseNumber
        {
            get { return drivingLicenseNumber; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DrivingLicenseRequired);
                }

                drivingLicenseNumber = value;
            }
        }

        private bool isBlocked = false;
        public bool IsBlocked
        {
            get => isBlocked;
            private set
            {
                isBlocked = value;
            }
        }

        public void DecreaseRating()
        {
            Rating -= 2;
            if (Rating < 0)
            {
                Rating = 0;
                IsBlocked = true;
            }
        }

        public void IncreaseRating()
        {
            Rating += 0.5;
            if (Rating > 10)
            {
                Rating = 10;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} Driving license:" +
                $" {drivingLicenseNumber} Rating: {rating}";
        }
    }
}
