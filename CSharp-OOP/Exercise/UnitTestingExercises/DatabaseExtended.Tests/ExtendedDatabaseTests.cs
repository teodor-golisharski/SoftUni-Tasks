namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using Newtonsoft.Json.Converters;
    using NUnit.Framework;
    using System;
    using System.Xml.Linq;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database db;
        private Person person1 = new Person(1, "A");
        private Person person2 = new Person(2, "B");
        private Person person3 = new Person(3, "C");
        private Person person4 = new Person(4, "D");
        private Person person5 = new Person(5, "E");
        private Person person6 = new Person(6, "F");
        private Person person7 = new Person(7, "G");
        private Person person8 = new Person(8, "H");
        private Person person9 = new Person(9, "I");
        private Person person10 = new Person(10, "J");
        private Person person11 = new Person(11, "K");
        private Person person12 = new Person(12, "L");
        private Person person13 = new Person(13, "M");
        private Person person14 = new Person(14, "N");
        private Person person15 = new Person(15, "O");
        private Person person16 = new Person(16, "P");

        private Person[] peopleInvalidAbove16;
        private Person[] peopleValid;
        
        [SetUp]
        public void Setup()
        {
            db = new Database();
            peopleInvalidAbove16 = new Person[] { person1, person2, person3,
                person4, person5, person6,
                person7, person8, person9,
                person9, person10, person11,
                person12, person13, person14,
                person15, person16 };

            peopleValid = new Person[] { person1, person2, person3,
                person4, person5, person6,
                person7, person8, person9,
                person10, person11, person12 };

            
        }
        [Test]
        public void ConstructorShoudInitializeCollection()
        {
            var expected = new Person[] {person1, person2, person3,
                person4, person5, person6,
                person7, person8, person9,
                person10, person11, person12 };

            var db = new Database(expected);

            var actual = expected;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_ConstructorInitializationValid()
        {
            db = new Database(peopleValid);

            int expectedCount = peopleValid.Length;
            int actualCount = db.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Test_ConstructorInitializationInvalid()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                db = new Database(peopleInvalidAbove16);
            }, "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void Test_AddPersonWithExistingUsername()
        {
            db = new Database(peopleValid);
            Person person = new Person(63, "A");

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(person);
            }, "There is already user with this username!");
        }

        [Test]
        public void Test_AddPersonWithExistingId()
        {
            db = new Database(peopleValid);
            Person person = new Person(1, "Dimitrichko");

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(person);
            }, "There is already user with this Id!");
        }

        [Test]
        public void Test_AddValidPerson()
        {
            db = new Database(peopleValid);

            int count = db.Count;

            Person person = new Person(63, "Dimitrichko");

            db.Add(person);

            Assert.AreEqual(db.Count, count + 1);
        }

        [Test]
        public void Test_RemoveFunctionalityInvalid()
        {
            Database db = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            });
        }

        [Test]
        public void FindByUsernameNullOrEmpty()
        {
            db = new Database(peopleValid);

            string name = string.Empty;

            Assert.Throws<ArgumentNullException>(() =>
            {
                db.FindByUsername(name);
            }, "Username parameter is null!");
        }

        [Test]
        public void FindByUsernameNoMatch()
        {
            db = new Database(peopleValid);

            string name = "Example";

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindByUsername(name);
            }, "No user is present by this username!");
        }

        [Test]
        public void FindByUsernameHasMatch()
        {
            db = new Database(peopleValid);

            string name = "C";

            Person match = db.FindByUsername(name);

            Assert.That(match, Is.Not.Null);                  
        }

        [Test]
        public void FindByIdNegativeException()
        {
            db = new Database(peopleValid);

            long id = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                db.FindById(id);
            }, "Id should be a positive number!");
        }

        [Test]
        public void FindByIdNoMatch()
        {
            db = new Database(peopleValid);

            long id = 63;

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindById(id);
            }, "No user is present by this ID!");
        }

        [Test]
        public void FindByIdHasMatch()
        {
            db = new Database(peopleValid);

            long id = 4;

            Person match = db.FindById(id); 

            Assert.That(match, Is.Not.Null);
        }
    }
}