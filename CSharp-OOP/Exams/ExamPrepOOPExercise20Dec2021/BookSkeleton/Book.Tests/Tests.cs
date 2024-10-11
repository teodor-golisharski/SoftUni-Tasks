namespace Book.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;
    using static System.Net.Mime.MediaTypeNames;

    public class Tests
    {
        private Book book;
        private string validBookName = "Dimitrichko";
        private string invalidBookName = "";
        private string validAuthor = "Mitko";
        private string invalidAuthor = null;


        [Test]
        public void Test_ConstructorValid()
        {
            book = new Book(validBookName, validAuthor);
            Assert.That(book.BookName, Is.EqualTo(validBookName));
            Assert.That(book.Author, Is.EqualTo(validAuthor));
            Assert.That(book.FootnoteCount, Is.EqualTo(0));
        }

        [Test]
        public void Test_ConstructorInvalidBookName()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                book = new Book(invalidBookName, validAuthor);
            }, $"Invalid {nameof(book.BookName)}!");
        }

        [Test]
        public void Test_ConstructorInvalidAuthor()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                book = new Book(validBookName, invalidAuthor);
            }, $"Invalid {nameof(book.Author)}!");
        }

        [Test]
        public void Test_AddFootnoteShouldThrowInvalidOperationException()
        {
            book = new Book(validBookName, validAuthor);
            book.AddFootnote(1, "text");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(1, "otherText");
            }, "Footnote already exists!");
        }

        [Test]
        public void Test_AddFootnoteShouldWork()
        {
            book = new Book(validBookName, validAuthor);
            book.AddFootnote(1, "text");
            book.AddFootnote(2, "otherText");

            Assert.DoesNotThrow(() =>
            {
                book.AddFootnote(3, "third text");
            });
            Assert.That(book.FootnoteCount, Is.EqualTo(3));
        }

        [Test]
        public void Test_FindFootnoteShouldThrowInvalidOperationException()
        {
            book = new Book(validBookName, validAuthor);
            book.AddFootnote(1, "text");
            book.AddFootnote(2, "otherText");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(3);
            }, "Footnote doesn't exists!");
        }

        [Test]
        public void Test_FindFootnoteShouldWork()
        {
            book = new Book(validBookName, validAuthor);
            book.AddFootnote(1, "text");
            book.AddFootnote(2, "otherText");

            Assert.DoesNotThrow(() => book.FindFootnote(2));
            Assert.That(book.FindFootnote(2), Is.EqualTo($"Footnote #2: otherText")); 
        }

        [Test]
        public void Test_AlterFootnoteShouldThrowInvalidOperationException()
        {
            book = new Book(validBookName, validAuthor);
            book.AddFootnote(1, "text");
            book.AddFootnote(2, "otherText");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(3, "new text");
            }, "Footnote doesn't exists!");
        }

        [Test]
        public void Test_AlterFootnoteShouldWork()
        {
            book = new Book(validBookName, validAuthor);
            book.AddFootnote(1, "text");
            book.AddFootnote(2, "otherText");

            string newText = "new text";

            Assert.DoesNotThrow(() => book.AlterFootnote(2, newText));
            Type bookType = this.book.GetType();
            FieldInfo fields = bookType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(x => x.Name == "footnote");

            Dictionary<int, string> fieldValue = (Dictionary<int, string>)fields.GetValue(this.book);

            string text = fieldValue[2];
            Assert.AreEqual(text, "new text");
            
        }
    }
}