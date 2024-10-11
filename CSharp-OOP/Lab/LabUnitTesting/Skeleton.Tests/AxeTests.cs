using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        public Axe Axe { get; set; }
        public Dummy Dummy { get; set; }

        [SetUp]
        public void SetUp()
        {
            Axe = new Axe(10, 10);
            Dummy = new Dummy(10, 10);
        }

        [Test]
        public void AxeDurabilityChanges()
        {
            Axe.Attack(Dummy);
            
            Assert.That(Axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void AttackingWithBrokenAxe()
        {
            Axe = new Axe(10, 0);
            
            Assert.Catch<InvalidOperationException>(() =>
            {
                Axe.Attack(Dummy);
            });
        }
    }
}