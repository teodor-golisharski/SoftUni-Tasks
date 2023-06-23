using System;

namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            if (!Rule1(s))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!Rule2(s))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!Rule3(s))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (Rule1(s) && Rule2(s) && Rule3(s))
            {
                Console.WriteLine("Password is valid");
            }
        }
        static bool Rule1(string s)
        {
            return s.Length >= 6 && s.Length <= 10;
        }
        static bool Rule2(string s)
        {
            bool b = false;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if(((int)c>=48&&(int)c<=57)|| ((int)c >= 65 && (int)c <= 90)|| ((int)c >= 97 && (int)c <= 122))
                {
                    b = true;
                }
                else
                {
                    b = false;
                }
                if(b==false)
                {
                    return false;
                }
            }
            return true;
        }
        static bool Rule3(string s)
        {
            int sum = 0;
            foreach (char symbol in s)
            {
                if (char.IsDigit(symbol))
                {
                    sum++;
                }
            }
            return sum >= 2;
        }
    }
}

