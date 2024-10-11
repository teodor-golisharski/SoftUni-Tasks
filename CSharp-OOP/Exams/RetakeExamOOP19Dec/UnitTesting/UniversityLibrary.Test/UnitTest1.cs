namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Tests
    {
        private UniversityLibrary ul;
        private TextBook t;
        private TextBook t2;

        [SetUp]
        public void Setup()
        {
            t = new TextBook("Title123", "Dimitrichko", "Action");
            t2 = new TextBook("demo", "123", "Fiction");
        }

        [Test]
        public void Test_ConstructorShouldWork()
        {
            ul = new UniversityLibrary();

            Type type = ul.GetType();
            FieldInfo fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(x => x.Name == "textBooks");

            List<TextBook> list = (List<TextBook>)fields.GetValue(ul);

            Assert.That(list.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test_ConstructorShouldWork2()
        {
            ul = new UniversityLibrary();

            Assert.That(ul.Catalogue.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test_Catalogue()
        {
            ul = new UniversityLibrary();
            ul.AddTextBookToLibrary(t);
            ul.AddTextBookToLibrary(t2);

            Assert.That(ul.Catalogue.Count, Is.EqualTo(2));

        }

        [Test]
        public void Test_AddTextBookToLibraryShouldWork()
        {
            ul = new UniversityLibrary();

            

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Book: Title123 - 1");
            sb.AppendLine("Category: Action");
            sb.AppendLine($"Author: Dimitrichko");

            Assert.That(sb.ToString().TrimEnd(), Is.EqualTo(ul.AddTextBookToLibrary(t)));
            Assert.That(ul.Catalogue.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test_AddTextBookToLibraryDoesNotThrowException()
        {
            ul = new UniversityLibrary();

            Assert.DoesNotThrow(() =>
            {
                ul.AddTextBookToLibrary(t);
            });

            Assert.That(ul.Catalogue.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test_LoanTextBookFreeBook()
        {
            ul = new UniversityLibrary();
            ul.AddTextBookToLibrary(t);

            string text = ul.LoanTextBook(1, "Goshko");

            Assert.That(t.Holder, Is.EqualTo("Goshko"));

            Assert.That(text, Is.EqualTo($"{t.Title} loaned to Goshko."));
        }

        [Test]
        public void Test_LoanTextBookNotReturned()
        {
            ul = new UniversityLibrary();
            t.Holder = "Goshko";
            ul.AddTextBookToLibrary(t);

            Assert.That(ul.LoanTextBook(1, "Goshko"), Is.EqualTo($"{t.Holder} still hasn't returned {t.Title}!"));
        }

        [Test]
        public void Test_LoanTextBookThrows()
        {
            ul = new UniversityLibrary();
            ul.AddTextBookToLibrary(t);

            Assert.Throws<NullReferenceException>(() => { ul.LoanTextBook(2, "Goshko"); });   
        }

        [Test]
        public void Test_ReturnTextBookShouldWork()
        {
            ul = new UniversityLibrary();
            t.Holder = "Goshko";
            ul.AddTextBookToLibrary(t);

            ul.ReturnTextBook(1);
            Assert.That(t.Holder, Is.EqualTo(string.Empty));
            Assert.That(ul.ReturnTextBook(1), Is.EqualTo($"{t.Title} is returned to the library."));
        }

        [Test]
        public void Test_ReturnTextBookShouldThrow()
        {
            ul = new UniversityLibrary();
            ul.AddTextBookToLibrary(t);

            Assert.Throws<NullReferenceException>(() => { ul.ReturnTextBook(2); });
        }
    }
}