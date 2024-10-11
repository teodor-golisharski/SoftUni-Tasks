using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private FootballPlayer player;
        private FootballTeam team;

        private FootballPlayer p1 = new FootballPlayer("A", 1, "Goalkeeper");
        private FootballPlayer p2 = new FootballPlayer("B", 2, "Midfielder");
        private FootballPlayer p3 = new FootballPlayer("C", 3, "Forward");
        private FootballPlayer p4 = new FootballPlayer("D", 4, "Goalkeeper");
        private FootballPlayer p5 = new FootballPlayer("E", 5, "Midfielder");
        private FootballPlayer p6 = new FootballPlayer("F", 6, "Forward");
        private FootballPlayer p7 = new FootballPlayer("G", 7, "Goalkeeper");
        private FootballPlayer p8 = new FootballPlayer("H", 8, "Midfielder");
        private FootballPlayer p9 = new FootballPlayer("I", 9, "Forward");

        private FootballTeam team1;

        [SetUp]
        public void Setup()
        {
            team1 = new FootballTeam("Team", 20);
            player = new FootballPlayer("Dimitrichko", 16, "Midfielder");
        }

        [Test]
        public void Test_FootballPlayerConstructorValidTest()
        {
            string name = "Dimitrichko";
            int number = 20;
            string pos = "Goalkeeper";
            player = new FootballPlayer(name, number, pos);
            Assert.That(player.Name, Is.EqualTo(name));
            Assert.That(player.PlayerNumber, Is.EqualTo(number));
            Assert.That(player.Position, Is.EqualTo(pos));

        }

        [Test]
        public void Test_FootballPLayerConstructorInvalidName()
        {
            string name = "";
            int number = 20;
            string pos = "Goalkeeper";
            Assert.Throws<ArgumentException>(() =>
            {
                player = new FootballPlayer(name, number, pos);
            }, "Name cannot be null or empty!");
        }

        [Test]
        public void Test_FootballPLayerConstructorInvalidNumber()
        {
            string name = "Dimitrichko";
            int number = 40;
            string pos = "Goalkeeper";
            Assert.Throws<ArgumentException>(() =>
            {
                player = new FootballPlayer(name, number, pos);
            }, "Player number must be in range [1,21]");
        }

        [Test]
        public void Test_FootballPLayerConstructorInvalidPosition()
        {
            string name = "Dimitrichko";
            int number = 20;
            string pos = "kuche";
            Assert.Throws<ArgumentException>(() =>
            {
                player = new FootballPlayer(name, number, pos);
            }, "Invalid Position");
        }

        //football team
        [Test]
        public void Test_FootballTeamConstructorValid()
        {
            string name = "Paris Saint-Germain";

            int capacity = 16;

            //players = new List<FootballPlayer>() { p1, p2, p3, p4, p5, p6, p7, p8, p9 };

            team = new FootballTeam(name, capacity);

            Assert.That(team.Name, Is.EqualTo(name));
            Assert.That(team.Capacity, Is.EqualTo(capacity));
            Assert.That(team.Players.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test_FootballTeamConstructorInvalidName()
        {
            string name = "";
            int capacity = 16;
            Assert.Throws<ArgumentException>(() =>
            {
                team = new FootballTeam(name, capacity);
            }, "Name cannot be null or empty!");
        }

        [Test]
        public void Test_FootballTeamConstructorInvalidCapacity()
        {
            string name = "Paris Saint-Germain";
            int capacity = 5;
            Assert.Throws<ArgumentException>(() =>
            {
                team = new FootballTeam(name, capacity);
            }, "Capacity min value = 15");
        }

        [Test]
        public void Test_AddNewPlayerValid()
        {
            int count = team1.Players.Count;

            team1.AddNewPlayer(player);
            Assert.That(team1.Players.Count, Is.EqualTo(count + 1));
            Assert.That($"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}", Is.EqualTo(team1.AddNewPlayer(player)));
        }

        [Test]
        public void Test_AddNewPlayerInvalid()
        {
            for (int i = 0; i < team1.Capacity; i++)
            {
                team1.AddNewPlayer(player);
            }
            int count = team1.Players.Count;
            
            team1.AddNewPlayer(player);

            Assert.That(team1.Capacity, Is.Not.EqualTo(count + 1));
            Assert.That(team1.AddNewPlayer(player), Is.EqualTo("No more positions available!"));
        }

        [Test]
        public void Test_PickPlayerShouldReturnNull()
        {
            team1.AddNewPlayer(p1);
            team1.AddNewPlayer(p2);
            team1.AddNewPlayer(p3);
            team1.AddNewPlayer(p4);
            
            Assert.That(team1.PickPlayer("E"), Is.EqualTo(null));
        }

        [Test]
        public void Test_PickPlayerShouldReturnPlayer()
        {
            team1.AddNewPlayer(p1);
            team1.AddNewPlayer(p2);
            team1.AddNewPlayer(p3);
            team1.AddNewPlayer(p4);

            Assert.That(team1.PickPlayer("D"), Is.EqualTo(p4));
        }

        [Test]
        public void Test_PlayerScoreShouldReturnNull()
        {
            team1.AddNewPlayer(p1);
            team1.AddNewPlayer(p2);
            team1.AddNewPlayer(p3);
            team1.AddNewPlayer(p4);

            Assert.Throws<NullReferenceException>(() =>
            {
                team1.PlayerScore(5);
            });
        }

        [Test]
        public void Test_PlayerScoreShouldReturnPlayer()
        {
            team1.AddNewPlayer(p1);
            team1.AddNewPlayer(p2);
            team1.AddNewPlayer(p3);
            team1.AddNewPlayer(p4);

            int count = p4.ScoredGoals;

            Assert.That(team1.PlayerScore(4), Is.EqualTo($"{p4.Name} scored and now has {p4.ScoredGoals} for this season!"));
            
            Assert.That(p4.ScoredGoals, Is.Not.EqualTo(count));
            
        }
    }
}
