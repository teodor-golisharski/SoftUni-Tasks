using System;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");
            foreach (var item in usernames)
            {
                if(Validation(item))
                {
                    Console.WriteLine(item);
                }
            }
        }
        static bool Validation(string username)
        {
            bool status = false;
            if(username.Length>=3 && username.Length<=16)
            {
                for (int i = 0; i < username.Length; i++)
                {
                    char symbol = username[i];
                    if(char.IsLetter(symbol))
                    {
                        status = true;
                    }
                    else if(char.IsDigit(symbol))
                    {
                        status = true;
                    }
                    else if(symbol=='_'||symbol=='-')
                    {
                        status = true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return status;
        }
    }
}
