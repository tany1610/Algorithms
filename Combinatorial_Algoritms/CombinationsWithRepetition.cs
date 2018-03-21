using System;
using System.Collections.Generic;
using System.Linq;

class CombinationsWithoutRepetition
{
    static char[] input = Console.ReadLine().Split().Select(char.Parse).ToArray();
    static int k = int.Parse(Console.ReadLine());
    static char[] arr = new char[k];
    static void Main()
    {        
        Comb(0, 0);
    }

    private static void Comb(int index, int start)
    {
        if (index >= k)
        {
            Console.WriteLine(string.Join(" ", arr));
            return;
        }

        for (int i = start; i < input.Length; i++)
        {
            arr[index] = input[i];
            Comb(index + 1, i);
        }
    }
}