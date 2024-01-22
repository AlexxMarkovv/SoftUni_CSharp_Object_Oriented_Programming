namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {

        [Test]
        public void WarriorConstructorShouldWorkProperly()
        {
            string expectedName = "Gogo";
            int expectedDamage = 15;
            int expectedHP = 100;

            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHP);

            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHP, warrior.HP);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("     ")]
        public void WarriorConstructorShouldThrowExceptionIfNameIsNullOrWhiteSpace(string name)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Warrior(name, 10, 50));

            Assert.AreEqual("Name should not be empty or whitespace!", exception.Message);
        }

        [TestCase(-1)]
        [TestCase(-45)]
        [TestCase(-80)]
        public void WarriorConstructorShouldThrowExceptionIfDamageIsNotPositive(int damage)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(()
                => new Warrior("Gogo", damage, 50));

            Assert.AreEqual("Damage value should be positive!", ex.Message);
        }

        [TestCase(-1)]
        [TestCase(-45)]
        [TestCase(-80)]
        public void WarriorConstructorShouldThrowExceptionIfHPPointsAreNegative(int hpPoints)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(()
                => new Warrior("Gogo", 10, hpPoints));

            Assert.AreEqual("HP should not be negative!", ex.Message);
        }

        [Test]
        public void WarriorAttackMethodShouldWorkCorrectly()
        {
            int expectedAttackerHP = 95;
            int expectedDeffHP = 80;

            Warrior attacker = new("Gogo", 10, 115);
            Warrior defender = new("Franky", 20, 90);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDeffHP, defender.HP);
        }

        [TestCase(30)]
        [TestCase(10)]
        public void WarriorShouldNotAttackIfHPAreEqualOrLessThan30(int hp)
        {

            Warrior attacker = new("Gogo", 10, hp);
            Warrior defender = new("Franky", 20, 90);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(defender));

            Assert.AreEqual("Your HP is too low in order to attack other warriors!", ex.Message);
        }

        [TestCase(30)]
        [TestCase(10)]
        public void WarriorShouldNotAttackEnemyWith30HPorLess(int hp)
        {

            Warrior attacker = new("Gogo", 10, 90);
            Warrior defender = new("Franky", 5, hp);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(defender));

            Assert.AreEqual($"Enemy HP must be greater than 30 in order to attack him!", ex.Message);
        }

        [TestCase]
        public void WarriorShouldNotAttackEnemyWithMoreDamagePointsThanHisHP()
        {
            Warrior attacker = new("Gogo", 10, 35);
            Warrior defender = new("Franky", 45, 100);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(defender));

            Assert.AreEqual($"You are trying to attack too strong enemy", ex.Message);
        }

        [Test]
        public void EnemyHpShouldBeSetToZeroIfWarriorDamageIsGreaterThanHisHp()
        {
            Warrior attacker = new("Gogo", 50, 100);
            Warrior defender = new("Franky", 45, 40);

            attacker.Attack(defender);

            int expectedAttackerHp = 55;
            int expectedDeffernder = 0;

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDeffernder, defender.HP);
        }
    }
}