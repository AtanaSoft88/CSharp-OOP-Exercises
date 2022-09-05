namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;

        [Test]
        [TestCase("Nasko",100,100)]        

        public void Does_Constructor_Set_Proper_Data_Positive_Case(string properName, int dmg, int hp)
        {
            Warrior warrior = new Warrior("Nasko",100,100);

            Assert.That(properName, Is.EqualTo(warrior.Name));
            Assert.That(dmg, Is.EqualTo(warrior.Damage));
            Assert.That(hp, Is.EqualTo(warrior.HP));
        }


        [Test]
        [TestCase("", 100, 100)]    // empty string
        [TestCase(" ", 100, 100)]   // white space
        [TestCase("  ", 100, 100)]   // white space
        [TestCase("   ", 100, 100)]   // white space
        [TestCase("    ", 100, 100)]   // white space
        [TestCase("     ", 100, 100)]   // white space
        [TestCase("      ", 100, 100)]   // white space
        [TestCase("       ", 100, 100)]   // white space
        [TestCase(null, 100, 100)]  // null
        public void Does_Constructor_Throws_Exception_At_Invalid_Name(string properName, int dmg, int hp)
        {
            Warrior warrior = default;
            Assert.Throws<ArgumentException>(() => warrior = new Warrior(properName, dmg, hp), "Name should not be empty or whitespace!");
        }

        [Test]
        [TestCase("Nasko", 0, 100)]    // dmg == 0
        [TestCase("Gosho", -5, 100)]   // dmg < 0
        [TestCase("Gosho", int.MinValue, 100)]   // dmg < 0
        public void Does_Constructor_Throws_Exception_At_Invalid_Dmg(string properName, int dmg, int hp)
        {
            Warrior warrior = default;
            Assert.Throws<ArgumentException>(() => warrior = new Warrior(properName, dmg, hp), "Damage value should be positive!");
        }

        [Test]        
        [TestCase("Gosho", 100, -5)]   // dmg < 0
        [TestCase("Drago", 100, int.MinValue)]   // dmg < 0
        public void Does_Constructor_Throws_Exception_At_Invalid_Hp(string properName, int dmg, int hp)
        {
            Warrior warrior = default;
            Assert.Throws<ArgumentException>(() => warrior = new Warrior(properName, dmg, hp), "HP should not be negative!");
        }

        [Test]
        [TestCase("Attacker", 100, 10, "Defender", 100, 100)]    // min dmg > 30      Attacker // min dmg > 30      Attacker   
        [TestCase("Attacker", 100, 30, "Defender", 100, 100)]    // min dmg > 30      Attacker           
        [TestCase("Attacker", 100, 0, "Defender", 100, 100)]    // min dmg > 30      Attacker                                                                      
        public void When_WarriorAttacks_With_HP_LessOrEqual_Than_30(string attackerName, int dmgA, int hpA , string defenderName, int dmgD, int hpD)
        {
            Warrior attackingWarrior = new Warrior(attackerName, dmgA, hpA);
            Warrior defendingWarrior = new Warrior(defenderName, dmgD, hpD);
            Assert.Throws<InvalidOperationException>(() =>attackingWarrior.Attack(defendingWarrior) ,"Your HP is too low in order to attack other warriors!");
        }

        [Test]
        [TestCase("Attacker", 100, 100, "Defender", 100, 10)]    // min dmg > 30      Defender 
        [TestCase("Attacker", 100, 100, "Defender", 100, 30)]    // min dmg > 30      Defender 
        [TestCase("Attacker", 100, 100, "Defender", 100, 0)]    // min dmg > 30      Defender 
        public void When_EnemyAttacks_With_HP_LessOrEqual_Than_30(string attackerName, int dmgA, int hpA, string defenderName, int dmgD, int hpD)
        {
            Warrior attackingWarrior = new Warrior(attackerName, dmgA, hpA);
            Warrior defendingWarrior = new Warrior(defenderName, dmgD, hpD);
            Assert.Throws<InvalidOperationException>(() => defendingWarrior.Attack(attackingWarrior), $"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
        }

        [Test]
        [TestCase("Attacker", 100, 60, "Defender", 100, 100)]    // attacker hp < defender dmg
        
        public void When_AttackerAttacks_With_HP_LessThan_Enemy_Dmg(string attackerName, int dmgA, int hpA, string defenderName, int dmgD, int hpD)
        {
            Warrior attackingWarrior = new Warrior(attackerName, dmgA, hpA);
            Warrior defendingWarrior = new Warrior(defenderName, dmgD, hpD);
            Assert.Throws<InvalidOperationException>(() => attackingWarrior.Attack(defendingWarrior), $"You are trying to attack too strong enemy");
        }


        // att hp > 30 , def hp > 30 , atthp >= def hp => att hp -= def dmg  if------> att dmg > def hp => def hp = 0  ,else def hp -= att dmg
        [Test]              //dmg , hp            //dmg , hp
        [TestCase("Attacker", 100, 100, "Defender", 100, 80)]    //atthp > def hp
        [TestCase("Attacker", 100, 80, "Defender", 60, 110)]    //attdmg > def dmg && att hp < def hp

        public void When_Attacking_Without_Exception_Attacker(string attackerName, int dmgA, int hpA, string defenderName, int dmgD, int hpD)
        {
            Warrior attackingWarrior = new Warrior(attackerName, dmgA, hpA);
            Warrior defendingWarrior = new Warrior(defenderName, dmgD, hpD);

            attackingWarrior.Attack(defendingWarrior);
            Assert.That(hpA -= dmgD, Is.EqualTo(attackingWarrior.HP));
        }

        [Test]              //dmg , hp            //dmg , hp
        [TestCase("Attacker", 100, 80, "Defender", 100, 100)]    //atthp > def hp
        [TestCase("Attacker", 60, 110, "Defender", 100, 80)]    //attdmg > def dmg && att hp < def hp

        public void When_Attacking_Without_Exception_Defender(string attackerName, int dmgA, int hpA, string defenderName, int dmgD, int hpD)
        {
            Warrior defendingWarrior = new Warrior(defenderName, dmgD, hpD);
            Warrior attackingWarrior = new Warrior(attackerName, dmgA, hpA);
            

            defendingWarrior.Attack(attackingWarrior);
            Assert.That(hpD -= dmgA, Is.EqualTo(defendingWarrior.HP));



        }


    }
}