using System;
using System.Collections.Generic;
using System.Linq;

class VariationsWithRepetition
{
    private static List<string> printed = new List<string>();

    static void Main()
    {
        char[] input = Console.ReadLine().Split().Select(char.Parse).ToArray();
        int k = int.Parse(Console.ReadLine());
        char[] vec = new char[k];

        GenerateVariantions(vec, input, 0, k);
    }

    private static void GenerateVariantions(char[] vec, char[] input, int start, int end)
    {
        if (start == end)
        {
            if (!printed.Contains(string.Join(" ", vec)))
            {
                Console.WriteLine(string.Join(" ", vec));
                printed.Add(string.Join(" ", vec));
            }
            return;
        }

        for (int i = 0; i < input.Length; i++)
        {
            vec[start] = input[i];
            GenerateVariantions(vec, input, start + 1, end);

        }
    }
}