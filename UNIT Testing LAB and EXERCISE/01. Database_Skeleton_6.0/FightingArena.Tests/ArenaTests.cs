namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void ArenaConstructorShouldWorkCorreclty()
        {
            Assert.IsNotNull(arena);
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void ArenaCountShouldWorkProperly()
        {
            int expectedCount = 1;

            Warrior warrior = new("Gogo", 5, 50);

            arena.Enroll(warrior);

            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(expectedCount, arena.Count);
        }

        [Test]
        public void ArenaEnrollShouldWorkProperly()
        {
            Warrior warrior = new("Gogo", 5, 50);

            arena.Enroll(warrior);

            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(warrior, arena.Warriors.Single());
        }

        [Test]
        public void ArenaEnrollMethodShouldThrowExceptionIfWarriorIsAlreadyEnrolled()
        {
            Warrior warrior = new("Gogo", 5, 50);

            arena.Enroll(warrior);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => arena.Enroll(warrior));

            Assert.AreEqual("Warrior is already enrolled for the fights!", ex.Message);
        }

        [Test]
        public void ArenaFightMethodShouldWorkProperly()
        {
            Warrior attacker = new("Gogo", 65, 100);
            Warrior deffender = new("Franky", 5, 100);

            arena.Enroll(attacker); 
            arena.Enroll(deffender);

            arena.Fight(attacker.Name, deffender.Name);

            int expectedAttackerHp = 95;
            int expectedDeffenderHp = 35;

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDeffenderHp, deffender.HP);
        }

        [Test]
        public void ArenaFightMethodShouldThrowExceptionIfAttackerIsNotFound()
        {
            Warrior attacker = new("Gogo", 65, 100);
            Warrior deffender = new("Franky", 5, 100);

            arena.Enroll(deffender);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => arena.Fight(attacker.Name, deffender.Name));

            Assert.AreEqual($"There is no fighter with name {attacker.Name} enrolled for the fights!", ex.Message);
        }

        [Test]
        public void ArenaFightMethodShouldThrowExceptionIfDefenderIsNotFound()
        {
            Warrior attacker = new("Gogo", 65, 100);
            Warrior deffender = new("Franky", 5, 100);

            arena.Enroll(attacker);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => arena.Fight(attacker.Name, deffender.Name));

            Assert.AreEqual($"There is no fighter with name {deffender.Name} enrolled for the fights!", ex.Message);
        }
    }
}
