using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.books = books.ToList();
        }
        private List<Book> books = new List<Book>();

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        

        class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int currentIndex;

            public LibraryIterator(List<Book> books)
            {
                this.books = books;
                this.books.Sort(new BookComparator());
                this.currentIndex = -1;
            }

            public Book Current
            {
                get { return books[currentIndex]; }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                return ++currentIndex < books.Count;
            }

            public void Reset()
            {
            }
        }
    }
}
