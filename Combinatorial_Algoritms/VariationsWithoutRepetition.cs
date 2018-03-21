using System;
using System.Linq;

class VariationsWithoutRepetition
{
    private static bool[] used;

    static void Main()
    {
        char[] input = Console.ReadLine().Split().Select(char.Parse).ToArray();
        used = new bool [input.Length];
        int k = int.Parse(Console.ReadLine());
        char[] vec = new char[k];

        GenerateVariantions(vec, input, 0, k);
    }

    private static void GenerateVariantions(char[] vec, char[] input, int start, int end)
    {
        if (start == end)
        {
            Console.WriteLine(string.Join(" ", vec));
            return;
        }

        for (int i = 0; i < input.Length; i++)
        {
            if (!used[i])
            {
                used[i] = true;
                vec[start] = input[i];
                GenerateVariantions(vec, input, start + 1, end);
                used[i] = false;
            }            
        }
    }
}