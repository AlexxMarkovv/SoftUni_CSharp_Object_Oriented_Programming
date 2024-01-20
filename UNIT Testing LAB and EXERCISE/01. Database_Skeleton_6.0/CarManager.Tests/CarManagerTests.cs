namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new("VW", "Passat", 10, 100);
        }

        [Test]
        public void CarShouldBeCreatedWithZeroFuelAmount()
        {
            //Assert
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void CarConstructorShouldSetsPropertiesCorrectly()
        {
            string expMake = "VW";
            string expModel = "Passat";
            double expectedFuelCons = 5;
            double expectedFuelCapacity = 65;

            Car car = new(expMake, expModel, expectedFuelCons, expectedFuelCapacity);

            Assert.AreEqual(expMake, car.Make);
            Assert.AreEqual(expModel, car.Model);
            Assert.AreEqual(expectedFuelCons, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarConstructorShouldThrowExceptionIfMakeIsNullOrWhiteSpace(string make)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car(make, "Passat", 10, 65));

            Assert.AreEqual("Make cannot be null or empty!", exception.Message);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarConstructorShouldThrowExceptionIfModelIsNullOrWhiteSpace(string model)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car("VW", model, 10, 65));

            Assert.AreEqual("Model cannot be null or empty!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void CarConstructorShouldThrowExceptionIfFuelConsIsZeroOrBelow(double fuelConsumption)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car("VW", "Passat", fuelConsumption, 65));

            Assert.AreEqual("Fuel consumption cannot be zero or negative!", exception.Message);
        }

        [Test]
        public void CarFuelAmountCannotBeNegative()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(()
            => car.Drive(1), "Fuel amount cannot be negative!");
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void CarConstructorShouldThrowExceptionIfFuelCapacityIsZeroOrNegative(double fuelCapacity)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car("VW", "Passat", 5, fuelCapacity));

            Assert.AreEqual("Fuel capacity cannot be zero or negative!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void CarMethodRefuelShouldThrowExcceptionIfFuelIsZerOrNegative(double fuel)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car("VW", "Passat", 5, 45).Refuel(fuel));

            Assert.AreEqual("Fuel amount cannot be zero or negative!", exception.Message);
        }

        [Test]
        public void CarFuelAmountShouldNotBeMoreThanFuelCapacity()
        {
            int expectedFuel = 100;

            car.Refuel(110);
            double actualResult = car.FuelAmount;

            Assert.AreEqual(expectedFuel, actualResult);
        }

        [Test]
        public void CarRefuelShouldWorkProperly()
        {
            int expectedFuel = 10;

            car.Refuel(10);

            Assert.AreEqual(expectedFuel, car.FuelAmount);
        }

        [TestCase(100)]
        [TestCase(900)]
        public void CarDriveMethodShouldWorkProperly(double distance)
        {
            //Assert
            double fuelNeeded = (distance / 100) * car.FuelConsumption;

            //Act
            car.Refuel(100);
            car.Drive(distance);

            //Assert
            Assert.AreEqual(car.FuelAmount, 100 - fuelNeeded);
        }

        [Test]
        public void CarDriveMethodShouldThrowExcceptionIfFuelAmountIsNotEnough()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => new Car("VW", "Passat", 5, 45).Drive(100));

            Assert.AreEqual("You don't have enough fuel to drive!", exception.Message);
        }
    }
}