using System;

namespace HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            Console.WriteLine("<h1>");
            Console.WriteLine(title);
            Console.WriteLine("</h1>");
            
            string content = Console.ReadLine();
            Console.WriteLine("<article>");
            Console.WriteLine(content);
            Console.WriteLine("</article>");

            string input = Console.ReadLine();
            do
            {
                Console.WriteLine("<div>");
                Console.WriteLine(input);
                Console.WriteLine("</div>");

                input = Console.ReadLine();
            }
            while (input != "end of comments");
        }
    }
}
