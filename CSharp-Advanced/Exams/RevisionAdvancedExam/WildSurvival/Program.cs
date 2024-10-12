namespace WildSurvival
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bees = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));
            Stack<int> beeEaters = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));


            while (beeEaters.Any() && bees.Any())
            {
                int currentBee = bees.Dequeue();
                int currentBeeEater = beeEaters.Pop();

                if (currentBee > currentBeeEater * 7)
                {
                    currentBee -= (currentBeeEater * 7);
                    bees.Enqueue(currentBee);
                }
                else if (currentBee < currentBeeEater * 7)
                {
                    currentBeeEater -= (currentBee / 7);

                    if (beeEaters.Any())
                    {
                        int nextGroup = beeEaters.Pop();
                        beeEaters.Push(nextGroup + currentBeeEater);
                    }
                    else
                    {
                        beeEaters.Push(currentBeeEater);
                    }
                }

            }
            Console.WriteLine("The final battle is over!");

            if (!beeEaters.Any() && !bees.Any())
            {
                Console.WriteLine("But no one made it out alive!");
            }
            else if (bees.Any())
            {
                Console.WriteLine($"Bee groups left: {string.Join(", ", bees)}");
            }
            else if (beeEaters.Any())
            {
                Console.WriteLine($"Bee-eater groups left: {string.Join(", ", beeEaters)}");
            }
        }
    }
}
