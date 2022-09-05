using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        // private fields as Classes gives us access to be used below
        private Axe axe = null;
        private Dummy dummy = null;
        //SetUp gives way to make an instance of classes so we wont be neededing to repeat(code) instanceing them anymore.
        [SetUp]
        public void Initializer()
        {
            axe = new Axe(10, 20);
            dummy = new Dummy(100, 100);
        }
        [Test]
        public void If_Attack_Loses_Its_Durability_On_Attack()
        {
            Axe axe = new Axe(10,20);
            axe.Attack(new Dummy(100, 100));
            
                                                      // with that string we describe message after bug occurrance!
            Assert.AreEqual(19, axe.DurabilityPoints,"Axe Durability doesnt change after attack!");
        }

        [Test]
        public void If_Attack_With_Zero_Durability_Throws_Exception()
        {
            Axe axe = new Axe(10, 1);
            axe.Attack(new Dummy(100, 100));
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(new Dummy(100, 100));

            }, "Following exception should be thrown : Axe is broken.");
            

            
        }
        [Test]
        public void If_Attack_With_Negative_Durability_Throws_Exception()
        {
            Axe axe = new Axe(10, -10);
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(new Dummy(100, 100));
            },"When Attacking with durability below 0");



        }
    }
}