using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                Article article = new Article(input[0], input[1], input[2]);
                articles.Add(article);
            }
            string order = Console.ReadLine();
            switch (order)
            {
                case "title":
                    articles = articles.OrderBy(X => X.Title).ToList();
                    break;
                case "content":
                    articles = articles.OrderBy(X => X.Content).ToList();
                    break;
                case "author":
                    articles = articles.OrderBy(X => X.Author).ToList();
                    break;
            }
            foreach (var item in articles)
            {
                Console.WriteLine(item);
            }
        }
    }
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public override string ToString() => $"{Title} - {Content}: {Author}";
    }
}
