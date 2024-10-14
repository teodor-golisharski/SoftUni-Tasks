namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        private int[] validArrayEdge1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        private int[] validArrayEdge2 = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        private int[] invalidArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
        private int[] emptyArray = new int[0];

        [SetUp]
        public void Setup()
        {
            database = new Database();
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_ConstructorInitializationValid(int[] data)
        {
            Database db = new Database(data);

            int expectedCount = data.Length;
            int actualCount = db.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        public void Test_ConstructorInitializationInvalid(int[] data)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database db = new Database(data);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void Test_ArrayAddOperationValid()
        {
            Database db = new Database(new int[] { 1, 2, 3, 4, 5 });

            int element = 63;

            db.Add(element);

            Assert.That(db.Count, Is.EqualTo(6));
        }

        [Test]
        public void Test_ArrayAddOperationThrowingException()
        {
            Database db = new Database(validArrayEdge1);

            int element = 63;

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(element);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void Test_ArrayRemoveOperationEmptyCollection()
        {
            Database db = new Database(emptyArray);

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            }, "The collection is empty!");
        }

        [Test]
        public void Test_ArrayRemoveOperationValid()
        {
            Database db = new Database(validArrayEdge1);

            int originCount = db.Count;

            db.Remove();

            Assert.That(db.Count, Is.EqualTo(originCount - 1));
        }

        [Test]
        public void Test_FetchReturnTheElements()
        {
            Database db = new Database(validArrayEdge2);

            int[] actual = db.Fetch();

            Assert.AreEqual(validArrayEdge2, actual);
        }
    }
}
