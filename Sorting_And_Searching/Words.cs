using System;
using System.Collections.Generic;

class Words
{
    private static int counter;

    static void Main()
    {
        char[] input = Console.ReadLine().ToCharArray();

        bool hack = TryHack(input);

        if (!hack)
        {
            GeneratePermutations(input, 0);

            Console.WriteLine(counter);
        }       
    }

    private static bool TryHack(char[] input)
    {
        var chars = new HashSet<char>();

        foreach (var c in input)
        {
            chars.Add(c);
        }

        if (chars.Count == input.Length)
        {
            Console.WriteLine(Fact(input.Length));
            return true;
        }

        return false;
    }

    private static int Fact(int inputLength)
    {
        int n = 1;

        for (int i = 1; i <= inputLength; i++)
        {
            n *= i;
        }

        return n;
    }

    private static void GeneratePermutations(char[] input, int index)
    {
        if (index == input.Length)
        {
            bool addCount = true;

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    addCount = false;
                    break;
                }
            }

            if (addCount)
            {
                counter++;
            }

            return;
        }

        var swapped = new HashSet<char>();

        for (int i = index; i < input.Length; i++)
        {
            if (!swapped.Contains(input[i]))
            {
                char temp = input[index];
                input[index] = input[i];
                input[i] = temp;

                GeneratePermutations(input, index + 1);

                input[i] = input[index];
                input[index] = temp;
            }

            swapped.Add(input[i]);
        }
    }
}