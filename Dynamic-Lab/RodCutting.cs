using System;
using System.Collections.Generic;
using System.Linq;

class RodCutting
{
    static Dictionary<string, int> result = new Dictionary<string, int>();
    static int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
    static int rodSize = int.Parse(Console.ReadLine());
    static int[] rod = input.Take(rodSize + 1).ToArray();
    private static int[] helper = new int[rodSize + 1];

    static void Main()
    {        
        GenerateVariations(1);
        KeyValuePair<string, int> best = result.OrderByDescending(kvp => kvp.Value).First();

        Console.WriteLine($"{best.Value}\n{best.Key}");
    }

    private static void GenerateVariations(int index)
    {
        if (helper.Sum() >= rodSize)
        {
            if (helper.Sum() == rodSize)
            {
                int sum = 0;

                for (int i = 0; i < helper.Length; i++)
                {
                    sum += rod[helper[i]];
                }

                result.Add(string.Join(" ", helper.Where(a => a != 0)), sum);
            }
            
            return;
        }

        for (int i = 1; i < rod.Length; i++)
        {
            if (helper.Sum() < rodSize)
            {
                helper[index] = i;
                GenerateVariations(index + 1);
                helper[index] = 0;
            }
        }
    }
}