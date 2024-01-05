﻿using BirthdayCelebrations.Models.Interfaces;
using BorderControl.Models.Interfaces;
using FoodShortage.Models.Interfaces;

namespace BorderControl.Models
{
    public class Citizen : IIdentifiable, ICelebratable, IBuyer, INamable
    {
        private const int DefaultFoodIncrement = 10;
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += DefaultFoodIncrement;
        }
    }
}