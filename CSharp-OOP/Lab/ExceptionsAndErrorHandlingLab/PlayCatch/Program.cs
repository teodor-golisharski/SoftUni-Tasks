using System;
using System.Linq;


namespace PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 0;

            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            while (true)
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string operation = cmdArgs[0];

                switch (operation)
                {
                    case "Replace":
                        string index = cmdArgs[1];
                        
                        string element = cmdArgs[2];
                        
                        count = Replace(array, index, element, count);
                        break;

                    case "Print":
                        string startIndex = cmdArgs[1];
                        
                        string endIndex = cmdArgs[2];

                        count = Print(array, startIndex, endIndex, count);
                        break;

                    case "Show":
                        string showIndex = cmdArgs[1];
                        
                        count = Show(array, showIndex, count);
                        break;
                }
                if (count == 3)
                {
                    break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", array));
        }

        static int Show(int[] array, string index, int count)
        {
            bool flag = false;

            try
            {
                flag = ValidateData(index);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                count++;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                count++;
            }

            if (flag)
            {
                try
                {
                    if (ValidateIndex(array, int.Parse(index)))
                    {
                        Console.WriteLine(array[int.Parse(index)]);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    count++;
                }
            }
            return count;
        }

        static int Replace(int[] array, string index, string element, int count)
        {
            bool validationIndex = false;

            bool validationElement = false;

            try
            {
                validationIndex = ValidateData(index);

                validationElement = ValidateData(element);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                count++;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                count++;
            }

            if (validationElement && validationIndex)
            {
                try
                {
                    if (ValidateIndex(array, int.Parse(index)))
                    {
                        array[int.Parse(index)] = int.Parse(element);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    count++;
                }
            }
            return count;
        }

        static int Print(int[] array, string startIndex, string endIndex, int count)
        {
            bool validationIndexStart = false;

            bool validationIndexEnd = false;

            try
            {
                validationIndexStart = ValidateData(startIndex);

                validationIndexEnd = ValidateData(endIndex);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                count++;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                count++;
            }

            if (validationIndexStart && validationIndexEnd)
            {
                try
                {
                    if (ValidateIndex(array, int.Parse(startIndex)) && ValidateIndex(array, int.Parse(endIndex))&& int.Parse(startIndex) <= int.Parse(endIndex))
                    {
                        for (int i = int.Parse(startIndex); i < int.Parse(endIndex); i++)
                        {
                            Console.Write(array[i] + ", ");
                        }
                        Console.Write(array[int.Parse(endIndex)]);
                        Console.WriteLine();
                    }
                    else if(int.Parse(startIndex) > int.Parse(endIndex))
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    count++;
                }
            }
            return count;
        }


        static bool ValidateIndex(int[] array, int index)
        {
            bool flag;

            if (index < 0 || index >= array.Length)
            {
                throw new ArgumentOutOfRangeException("The index does not exist!");
            }

            flag = true;

            return flag;
        }

        static bool ValidateData(string element)
        {
            bool flag;

            long number;

            if (!long.TryParse(element, out number))
            {
                throw new FormatException($"The variable is not in the correct format!");
            }
            try
            {
                number = Convert.ToInt32(number);
            }
            catch (OverflowException)
            {
                throw new OverflowException($"The variable is not in the correct format!");
            }

            flag = true;

            return flag;
        }
    }
}
