using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        public Dummy Dummy { get; set; }
        [SetUp]
        public void Setup()
        {
            Dummy = new Dummy(10, 15);
        }

        [Test]
        public void DummyLosesHealthWhenAttacked()
        {
            Dummy.TakeAttack(2);
            Assert.That(Dummy.Health, Is.EqualTo(8));
        }

        [Test]
        public void DeadDummyException()
        {
            Dummy = new Dummy(0, 10);
            
            Assert.Catch<InvalidOperationException>(() =>
            {
                Dummy.TakeAttack(10);
            });
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            int experience = 15;
            Dummy = new Dummy(0, experience);

            Assert.AreEqual(experience, Dummy.GiveExperience());
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            Assert.Catch<InvalidOperationException>(() =>
            {
                Dummy.GiveExperience();
            });
        }
    }
}