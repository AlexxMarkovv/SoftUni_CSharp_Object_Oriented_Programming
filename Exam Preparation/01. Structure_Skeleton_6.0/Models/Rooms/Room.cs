using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        protected Room(int bedCapacity)
        {
            BedCapacity = bedCapacity;
        }

        private int bedCapacity;

        public int BedCapacity
        {
            get => bedCapacity;
            private set => bedCapacity = value;
        }

        private double pricePerNight = 0;

        public double PricePerNight
        {
            get => pricePerNight;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException(ExceptionMessages.PricePerNightNegative);
                }

                pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            PricePerNight = price;
        }
    }
}
