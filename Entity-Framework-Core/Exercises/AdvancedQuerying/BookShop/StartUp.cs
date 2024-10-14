namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Text;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //string input = Console.ReadLine()!;
            //int year = int.Parse(Console.ReadLine()!);
            //int input = int.Parse(Console.ReadLine()!);

            Console.WriteLine(GetMostRecentBooks(db));
        }

        //Task 2 - Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var titles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return string.Join(Environment.NewLine, titles);
        }

        //Task 3 - Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var editionType = Enum.Parse<EditionType>("gold", true);

            var books = context.Books
                .Where(b => b.EditionType == editionType && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //Task 4 - Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} - ${b.Price:f2}")
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //Task 5 - Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate!.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //Task 6 - Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.ToLower())
                    .ToArray();

            var books = context.Books
                .Where(b => b.BookCategories
                    .Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //Task 7 - Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var dateData = date.Split('-').Select(int.Parse).ToArray();
            int day = dateData[0];
            int month = dateData[1];
            int year = dateData[2];

            var dt = new DateTime(year, month, day);

            var books = context.Books
                .Where(b => DateTime.Compare(b.ReleaseDate!.Value, dt) < 0)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}")
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //Task 8 - Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToList();

            return string.Join(Environment.NewLine, authors);
        }

        //Task 9 - Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //Task 10 - Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //Task 11 - Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return books;
        }

        //Task 12 - Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .OrderByDescending(a => a.Books.Select(b => b.Copies).Sum())
                .Select(a => $"{a.FirstName} {a.LastName} - {a.Books.Select(b => b.Copies).Sum()}")
                .ToList();

            return string.Join(Environment.NewLine, authors);
        }

        //Task 13 - Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryBooks.Sum(x => x.Book.Price * x.Book.Copies))
                .Select(c => $"{c.Name} ${c.CategoryBooks.Sum(x => x.Book.Price * x.Book.Copies):F2}")
                .ToList();

            return string.Join(Environment.NewLine, categories);
        }

        //Task 14 - Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                .OrderBy(x => x.Name)
                .Select(x => $"--{x.Name}{Environment.NewLine}" +
                    string.Join(Environment.NewLine, x.CategoryBooks
                        .OrderByDescending(x => x.Book.ReleaseDate)
                        .Select(x => $"{x.Book.Title} ({x.Book.ReleaseDate!.Value.Year})")
                        .Take(3)))
                .ToList();

            return string.Join(Environment.NewLine, categories);
        }

        //Task 15 - Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate!.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //Task 16 - Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();
            
            context.RemoveRange(books);
            
            context.SaveChanges(); 
            
            return books.Count;
        }
    }
}


