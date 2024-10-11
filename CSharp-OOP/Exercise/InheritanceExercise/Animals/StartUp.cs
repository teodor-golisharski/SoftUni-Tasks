using System;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            
            string type = Console.ReadLine();
            
            while(type != "Beast!")
            {
                string[] furtherInformation = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                
                string name = furtherInformation[0];
                int age = int.Parse(furtherInformation[1]);
                string gender = string.Empty;

                if(furtherInformation.Length > 2)
                {
                    gender = furtherInformation[2];
                }

                try
                {
                    switch (type)
                    {
                        case "Cat":
                            Cat cat = new Cat(name, age, gender);
                            sb.AppendLine(cat.ToString());
                            break;

                        case "Dog":
                            Dog dog = new Dog(name, age, gender);
                            sb.AppendLine(dog.ToString());
                            break;

                        case "Frog":
                            Frog frog = new Frog(name, age, gender);
                            sb.AppendLine(frog.ToString());
                            break;

                        case "Kitten":
                            Kitten kitten = new Kitten(name, age);
                            sb.AppendLine(kitten.ToString());
                            break;

                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(name, age);
                            sb.AppendLine(tomcat.ToString());
                            break;
                    }
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                type = Console.ReadLine();
            }
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
