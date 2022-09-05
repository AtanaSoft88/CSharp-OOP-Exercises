namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void Constructor_Collects_Warriors_With_Unique_Names()
        {
            Arena arena = new Arena();
            Warrior warriorOffence = new Warrior("Nasko", 102, 152);
            Warrior warriorOffence1 = new Warrior("Nasko1", 101, 151);
            Warrior warriorDefence = new Warrior("Gosho1", 103, 153);
            Warrior warriorDefence1 = new Warrior("Gosho2", 104, 154);
            Warrior warriorDefence2 = new Warrior("Gosho3", 105, 155);
            List<Warrior> warriors = new List<Warrior>() { warriorOffence, warriorOffence1, warriorDefence, warriorDefence1, warriorDefence2 };
            int n = warriors.Count;
            for (int i = 0; i < warriors.Count; i++)
            {
                arena.Enroll(warriors[i]);
            }

            Assert.That(arena.Count == n);
        }

        [Test]
        public void Constructor_Collects_Properly()
        {
            Arena arena = new Arena();           

            var list = new List<Warrior>();
            
            CollectionAssert.AreEqual(arena.Warriors,list);
        }
        [Test]
        public void Constructor_Collects_Properly_Enrolled_Correct_Count_Warriors()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("Gosho",10,100));
            
            List<Warrior> list = new List<Warrior>() { new Warrior("Pavlin", 11, 200) };
            
            Assert.AreEqual(arena.Count, list.Count);
        }

        [Test]
        public void When_Trying_To_Enrol_Same_Warrior_Name()
        {
            Arena arena = new Arena();
            Warrior warriorOffence = new Warrior("Nasko", 102, 150);
            arena.Enroll(warriorOffence);
            Warrior warriorOffence1 = new Warrior("Nasko", 101, 155);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warriorOffence1), "Warrior is already enrolled for the fights!");
        }
        [Test]
        public void When_Trying_To_Enrol_Unique_Warriors()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("Nasko", 102, 150);
            Warrior defender = new Warrior("Gosho", 101, 155);
            List<Warrior> warriors = new List<Warrior>() { attacker, defender };
            for (int i = 0; i < warriors.Count; i++)
            {
                arena.Enroll(warriors[i]);
            }

            Assert.That(arena.Count == warriors.Count);
        }

        [Test]
        [TestCase("Nasko", "InvalidName")]
        [TestCase("InvalidName", "Gosho")]
        
        public void When_Fight_Throw_Exception_When_A_Warrior_Doesnt_Exist(string nameAttacker, string nameDefender)
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior(nameAttacker, 102, 150);
            Warrior defender = new Warrior(nameDefender, 101, 155);
            arena.Enroll(attacker);
            arena.Enroll(defender);
            string attackerName = "Nasko";
            string deffenderName = "Gosho";
            string missing = string.Empty;
            if (attackerName == attacker.Name && deffenderName != defender.Name)
            {
                missing = defender.Name;
            }
            else
            {
                missing = attacker.Name;
            }

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, deffenderName), $"There is no fighter with name {missing} enrolled for the fights!");
        }
        [Test]
        [TestCase("Nasko", "Gosho")]

        public void When_Fight_Accepts_Valid_Fighters(string nameAttacker, string nameDefender)
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior(nameAttacker, 102, 150);
            Warrior defender = new Warrior(nameDefender, 100, 155);
            arena.Enroll(attacker);
            arena.Enroll(defender);
            string attackerName = "Nasko";
            string defenderName = "Gosho";

            arena.Fight(attackerName,defenderName);

            var expectedAttackerHp = attacker.HP;

            Assert.AreEqual(50, expectedAttackerHp);


        }
    }
}
