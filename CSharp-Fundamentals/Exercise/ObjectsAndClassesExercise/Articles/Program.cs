using System;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] current = Console.ReadLine().Split(", ");
            Article article = new Article(current[0], current[1], current[2]);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] lines = Console.ReadLine().Split(": ");
                string command = lines[0];
                string argument = lines[1];
                switch (command)
                {
                    case "Edit":
                        article.Edit(argument); break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(argument); break;
                    case "Rename":
                        article.Rename(argument); break;
                }
            }
            Console.WriteLine(article);
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

        public void Edit(string content) => Content = content;
        public void ChangeAuthor(string author) => Author = author;
        public void Rename(string title) => Title = title;

        public override string ToString() => $"{Title} - {Content}: {Author}";
    }
}
