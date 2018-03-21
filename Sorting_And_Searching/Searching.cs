using System;
using System.Linq;

class Searching
{
    static void Main()
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == number)
            {
                Console.WriteLine(i);
                return;
            }
        }

        Console.WriteLine(-1);
    }
}