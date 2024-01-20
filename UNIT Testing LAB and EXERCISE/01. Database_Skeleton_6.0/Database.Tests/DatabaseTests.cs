namespace Database.Tests
{
    using Newtonsoft.Json.Converters;
    using NUnit.Framework;
    using System;
    using System.Runtime.CompilerServices;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database(1, 2);
        }

        [Test]
        public void CreatingDatabaseCountShouldBeCorrect()
        {
            // Arrange 
            int expectedResult = 2;

            //Act
            //Database database = new Database(1,2);
            int actualResult = database.Count;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void CreatingDatabaseShouldAddElementsCorrecty(int[] data)
        {
            Database database = new(data);

            int[] actualResult = database.Fetch();

            Assert.AreEqual(data, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 })]
        public void CreatingDatabaseShouldThrowExceptionWhenCountIsMoreThan16(int[] data)
        {
            Assert.Throws<InvalidOperationException>(()
                => database = new Database(data), "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void DatabaseCountShouldWorkCorrectly()
        {
            int expectedResult = 2;

            int actuallResult = database.Count;

            Assert.AreEqual(expectedResult, actuallResult);
        }

        [TestCase(-10)]
        [TestCase(3)]
        public void DatabaseAddMethodShouldIncreaseCount(int number)
        {
            int exprectedResult = 3;

            database.Add(number);

            Assert.AreEqual(exprectedResult, database.Count);
        }

        [TestCase(new int[] {1, 2, 3, 4, 5})]
        public void DatabaseAddMethodShouldAddElementsCorrectly(int[] data)
        {
            database = new Database();

            foreach (int number in data)
            {
                database.Add(number);
            }

            int[] actualResult = database.Fetch();

            Assert.AreEqual(actualResult, actualResult);
        }

        [Test]
        public void DatabaseAddMethodShouldThrowEcseptionWhenCountIsMoreThan16()
        {
            for (int i = 0; i < 14; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(()
                => database.Add(3), "Array's capacity must be exactly 16 integers!");   
        }

        [Test]
        public void DatabaseRemoveMethodShouldDecreaseCount()
        {
            int expectedResult = 1;

            database.Remove();

            Assert.AreEqual(expectedResult, database.Count);
        }

        [Test]
        public void DatabaseRemoveMethodShouldRemoveElementsCorrectly()
        {
            int[] expectedResult = Array.Empty<int>();

            database.Remove();
            database.Remove();

            int[] actualrResult = database.Fetch();

            Assert.AreEqual(expectedResult, actualrResult);
        }

        [Test]
        public void DatabaseRemoveMethodShouldThrowExceptionIfDatabaseIsEmpty()
        {
            database = new Database();

            Assert.Throws<InvalidOperationException>(() 
                => database.Remove(), "The collection is empty!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void DatabaseFetchMethodShouldReturnDataCorrectly(int[] data)
        {
            database = new Database(data);

            int[] actualResult = database.Fetch();

            Assert.AreEqual(actualResult, actualResult);
        }
    }
}
