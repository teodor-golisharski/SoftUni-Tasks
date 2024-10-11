using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            BladeKnight bladeKnight = new BladeKnight("choveche", 8);
            Console.WriteLine(bladeKnight);
        }
    }
}