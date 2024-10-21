using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        private InfluencerRepository repo;
        private InfluencerRepository repo1;
        private Influencer inf1;
        private Influencer inf2;

        [SetUp]
        public void Setup()
        {
            inf1 = new Influencer("Dimitrichko", 100);
            inf2 = new Influencer("Delyan_Peevski", 1000);

            repo1 = new InfluencerRepository();
            repo1.RegisterInfluencer(inf2);
        }

        [Test]
        public void Test_Constructor()
        {
            repo = new InfluencerRepository();
            Assert.That(repo, Is.Not.Null);
            Assert.That(repo.Influencers.Count() == 0);
        }

        [Test]
        public void Test_RegisterInfluencer_NullInfluencer()
        {
            repo = new InfluencerRepository();
            Assert.Throws<ArgumentNullException>(() => repo.RegisterInfluencer(null));
        }

        [Test]
        public void Test_RegisterInfluencer_AlreadyExists()
        {
            repo = new InfluencerRepository();
            repo.RegisterInfluencer(inf1);
            Assert.Throws<InvalidOperationException>(() => repo.RegisterInfluencer(inf1));
        }

        [Test]
        public void Test_RegisterInfluencer_ShouldWork()
        {
            repo = new InfluencerRepository();

            Assert.AreEqual($"Successfully added influencer {inf1.Username} with {inf1.Followers}", repo.RegisterInfluencer(inf1));
            Assert.AreEqual(1, repo.Influencers.Count());

        }


        [Test]
        public void Test_RemoveInfluencer_Null()
        {
            Assert.Throws<ArgumentNullException>(() => repo1.RemoveInfluencer(null));
        }

        [Test]
        public void Test_RemoveInfluencer_WhiteSpace()
        {
            Assert.Throws<ArgumentNullException>(() => repo1.RemoveInfluencer(""));
        }

        [Test]
        public void Test_RemoveInfluencer_InvalidName()
        {
            Assert.AreEqual(false, repo1.RemoveInfluencer("unknown"));
            Assert.AreEqual(1, repo1.Influencers.Count);
        }

        [Test]
        public void Test_RemoveInfluencer_ShouldWork()
        {
            Assert.AreEqual(true, repo1.RemoveInfluencer("Delyan_Peevski"));
            Assert.AreEqual(0, repo1.Influencers.Count);
        }

        [Test]
        public void Test_GetInfluencerWithMostFollowers_EmptyRepo()
        {
            repo = new InfluencerRepository();
            Assert.Throws<IndexOutOfRangeException>(() => repo.GetInfluencerWithMostFollowers());
        }

        [Test]
        public void Test_GetInfluencerWithMostFollowers_ShouldWork()
        {
            repo.RegisterInfluencer(inf1);
            repo.RegisterInfluencer(inf2);
            Assert.AreEqual(inf2.Username, repo.GetInfluencerWithMostFollowers().Username);
        }

        [Test]
        public void Test_GetInfluencer_ShouldReturnNull()
        {
            Assert.AreEqual(null, repo.GetInfluencer("null"));
        }

        [Test]
        public void Test_GetInfluencer_ShouldWork()
        {
            Assert.AreEqual(inf2.Username, repo1.GetInfluencer("Delyan_Peevski").Username);
        }
    }
}