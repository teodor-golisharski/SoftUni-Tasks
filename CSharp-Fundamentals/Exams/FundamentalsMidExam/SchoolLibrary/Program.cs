using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> books = Console.ReadLine().Split('&').ToList();
            string[] input = Console.ReadLine().Split(" | ");
            while (input[0] != "Done")
            {
                string command = input[0];
                switch (command)
                {
                    case "Add Book":
                        AddBook(books, input[1]);
                        break;
                    case "Take Book":
                        TakeBook(books, input[1]);
                        break;
                    case "Swap Books":
                        SwapBooks(books, input[1], input[2]);
                        break;
                    case "Insert Book":
                        InsertBook(books, input[1]);
                        break;
                    case "Check Book":
                        CheckBook(books, int.Parse(input[1]));
                        break;
                }
                input = Console.ReadLine().Split(" | ");
            }
            Console.WriteLine(string.Join(", ", books));
        }
        static List<string> AddBook(List<string> books, string bookName)
        {
            foreach (var item in books)
            {
                if (item == bookName)
                {
                    return books;
                }
            }
            books.Insert(0, bookName);
            return books;
        }
        static List<string> TakeBook(List<string> books, string bookName)
        {
            foreach (var item in books)
            {
                if (item == bookName)
                {
                    books.Remove(item);
                    return books;
                }
            }
            return books;
        }
        static List<string> SwapBooks(List<string> books, string book1, string book2)
        {
            bool flag1 = false;
            bool flag2 = false;
            foreach (var item in books)
            {
                if (item == book1)
                {
                    flag1 = true;
                }
                if (item == book2)
                {
                    flag2 = true;
                }
                if (flag1 && flag2) break;
            }
            if (!flag1 || !flag2)
            {
                return books;
            }
            int index1 = books.IndexOf(book1);
            int index2 = books.IndexOf(book2);
            string temp = books[index1];
            books[index1] = books[index2];
            books[index2] = temp;
            return books;
        }
        static List<string> InsertBook(List<string> books, string bookName)
        {
            foreach (var item in books)
            {
                if (item == bookName)
                {
                    return books;
                }
            }
            books.Add(bookName);
            return books;
        }
        static void CheckBook(List<string> books, int index)
        {
            if (index < 0 || index >= books.Count)
            {
                return;
            }
            else
            {
                string s = books[index];
                Console.WriteLine(s);
            }
        }
    }
}
