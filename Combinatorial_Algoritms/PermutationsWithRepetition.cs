using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.SqlServer.Server;

class PermutationsWithRepetition
{
    static char[] input = Console.ReadLine().Split().Select(char.Parse).ToArray();

    static void Main()
    {
        GenComb(0);
    }

    private static void GenComb(int index)
    {
        if (index == input.Length - 1)
        {
            Console.WriteLine(string.Join(" ", input));
            return;
        }

        HashSet<char> used = new HashSet<char>();

        for (int i = index; i < input.Length; i++)
        {
            if (!used.Contains(input[i]))
            {
                used.Add(input[i]);
                Swap(index, i);
                GenComb(index + 1);
                Swap(index, i);
            }            
        }
    }

    private static void Swap(int index, int i)
    {
        char temp = input[index];
        input[index] = input[i];
        input[i] = temp;
    }
}