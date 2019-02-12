using System;
using System.Collections.Generic;
using System.Linq;


namespace ListPractice
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("List practice!");

            Practice();

            AnalizeRandomNumbers();

            Console.ReadKey();
        }

        static void Practice()
        {
            // Create:

            List<int> numbers = new List<int>() { 1, 2, 4 };
            PrintList(numbers, "Created:");

            // Add data:

            numbers.Add(5);
            PrintList(numbers, "Add:");

            numbers.Insert(2, 3);
            PrintList(numbers, "Insert:");

            List<int> listToAdd = new List<int>() { 8, 9 };
            numbers.AddRange(listToAdd);
            PrintList(numbers, "AddRange:");

            int[] arrayToInsert = { 6, 7 };
            numbers.InsertRange(4, arrayToInsert);
            PrintList(numbers, "InsertRange:");

            Console.WriteLine();
            // Loop data:

            Console.WriteLine("for test:");
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write(numbers[i] + "|");
            }
            Console.WriteLine();

            Console.WriteLine("foreach test:");
            foreach (int number in numbers)
            {
                Console.Write(number + "-");
            }
            Console.WriteLine();

            Console.WriteLine("ForEach() test:");
            numbers.ForEach(Console.Write);
            Console.WriteLine();

            Console.WriteLine();
            // Data info:

            Console.WriteLine("Count: " + numbers.Count);
            Console.WriteLine("Contains 5: " + numbers.Contains(5));
            Console.WriteLine("Contains 100: " + numbers.Contains(100));
            Console.WriteLine("IndexOf 5: " + numbers.IndexOf(5));
            Console.WriteLine("IndexOf 100: " + numbers.IndexOf(100));
            Console.WriteLine("Find even: " + numbers.Find(TestEvenNumbers));
            Console.WriteLine("Find Odd: " + numbers.Find(TestOddNumbers));
            Console.WriteLine("Find > 5: " + numbers.Find(TestMoreThen5));
            Console.WriteLine("Find > 50: " + numbers.Find(TestMoreThen80));
            Console.WriteLine("Exists even: " + numbers.Exists(TestEvenNumbers));
            Console.WriteLine("Exists Odd: " + numbers.Exists(TestOddNumbers));
            Console.WriteLine("Exists > 5: " + numbers.Exists(TestMoreThen5));
            Console.WriteLine("Exists > 50: " + numbers.Exists(TestMoreThen80));
            Console.WriteLine("TrueForAll even: " + numbers.TrueForAll(TestEvenNumbers));
            Console.WriteLine("TrueForAll Odd: " + numbers.TrueForAll(TestOddNumbers));
            Console.WriteLine("TrueForAll > 5: " + numbers.TrueForAll(TestMoreThen5));
            Console.WriteLine("TrueForAll < 10: " + numbers.TrueForAll(TestLessThen20));

            Console.WriteLine();

            Console.WriteLine("Sum: " + numbers.Sum());
            Console.WriteLine("Avarage: " + numbers.Average());
            Console.WriteLine("Min: " + numbers.Min());
            Console.WriteLine("Max: " + numbers.Max());
            Console.WriteLine("First: " + numbers.First());
            Console.WriteLine("Last: " + numbers.Last());

            Console.WriteLine();

            numbers.Reverse();
            PrintList(numbers, "Reversed:");

            Console.WriteLine();
            // Remove data:

            Console.WriteLine("Remove 5: " + numbers.Remove(5));
            Console.WriteLine("Remove 100: " + numbers.Remove(100));
            PrintList(numbers, "Remove 5:");

            numbers.RemoveAt(2);
            PrintList(numbers, "Remove at 2:");

            numbers.RemoveRange(2, 3);
            PrintList(numbers, "Remove 3 range from 2:");

            numbers.RemoveAll(TestEvenNumbers);
            PrintList(numbers, "Remove Even:");

            numbers.Clear();
            PrintList(numbers, "All clear:");
        }

        static void AnalizeRandomNumbers()
        {
            List<int> numbers = new List<int>();

            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                numbers.Add(rnd.Next(1, 100));
            }

            Console.WriteLine();
            PrintList(numbers, "Start:");

            numbers.RemoveAll(TestMoreThen80);

            Console.WriteLine();
            PrintList(numbers, "After remove:");
            Console.WriteLine("After remove count is: " + numbers.Count);
            Console.WriteLine();
            PrintList(numbers, "All even numbers:");
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    Console.Write(number + "  ");
                }
            }
            Console.WriteLine();

            List<int> searchResult = numbers.FindAll(TestLessThen20);

            Console.WriteLine();
            Console.WriteLine("Count of < 20 is: " + searchResult.Count);

            Console.WriteLine("Sum: " + numbers.Sum());
            Console.WriteLine("Avarage: " + numbers.Average());
            Console.WriteLine("Min: " + numbers.Min());
            Console.WriteLine("Max: " + numbers.Max());
            Console.WriteLine("First: " + numbers.First());
            Console.WriteLine("Last: " + numbers.Last());
        }

        static bool TestEvenNumbers(int item)
        {
            return item % 2 == 0;
        }

        static bool TestOddNumbers(int item)
        {
            return item % 2 == 1;
        }

        static bool TestMoreThen5(int item)
        {
            return item > 5;
        }

        static bool TestMoreThen80(int item)
        {
            return item > 80;
        }

        static bool TestLessThen20(int item)
        {
            return item < 20;
        }

        static void PrintList(List<int> data, string message)
        {
            Console.Write(message + " ");
            for (int i = 0; i < data.Count; i++)
            {
                Console.Write(data[i]);
                if (i < data.Count - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine();
        }
    }
}
