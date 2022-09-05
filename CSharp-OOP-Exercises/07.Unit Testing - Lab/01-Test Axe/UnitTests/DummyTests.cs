using NUnit.Framework;
using System;
using System.Reflection;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        // private fields as Classes gives us access to be used below
       private Axe axe = null;
       private Dummy dummy = null;
        //SetUp gives way to make an instance of classes so we wont be neededing to repeat(code) instanceing them anymore.
        [SetUp]
        public void Initializer()
        {
            axe = new Axe(10,100);
            dummy = new Dummy(20, 500);
        }
        [Test]
        public void If_Dummy_Loses_Health_After_Being_Attacked()
        {
            axe.Attack(dummy);
            //Assert.That(49 == dummy.Health,"After getting attacked ,health should be reduced by the dmg points");
            //Assert.IsTrue(49 is dummy.Health, "After getting attacked ,health should be reduced by the dmg points");
            Assert.AreEqual(10, dummy.Health, "After getting attacked ,health should be reduced by the dmg points");

        }
        [Test]
        public void If_Dummy_Health_Goes_Equal_Or_Below_Zero_Throws_Exception()
        {            
            axe.Attack(dummy);
            axe.Attack(dummy);
            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
            //Assert.Throws<InvalidOperationException>(() =>
            //{
            //    dummy.TakeAttack(500);
            //}, "Dummy is dead.");

        }

        [Test]
        public void Dead_Dummy_Can_Give_XP()
        {
            axe.Attack(dummy);            
            axe.Attack(dummy);
            Assert.AreEqual(500, dummy.GiveExperience());
            //Type dummyFieldSearch = typeof(Dummy);
            //FieldInfo privateField = dummyFieldSearch.GetField("experience", BindingFlags.NonPublic | BindingFlags.Instance);
            //object objInstance = Activator.CreateInstance(dummyFieldSearch, 10, 10);
            //Assert.AreEqual(500, privateField.GetValue(dummy));

        }
        [Test]
        public void Alive_Dummy_Can_Not_Give_XP()
        {           
            
            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
            //Assert.Throws<InvalidOperationException>(() =>
            //{
            //    dummy.GiveExperience();
            //},"Target is not dead.");


        }
    }
}