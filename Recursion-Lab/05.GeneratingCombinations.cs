using System;
using System.Linq;

class GeneratingCombinations
{
    static void Main()
    {
        int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int count = int.Parse(Console.ReadLine());
        int[] vector = new int[count];

        PrintCombinations(nums, vector, 0, 0);
    }

    private static void PrintCombinations(int[] nums, int[] vector, int maxCount, int index)
    {
        if (index >= vector.Length)
        {
            Console.WriteLine(string.Join(" ", vector));
            return;
        }

        for (int i = maxCount; i < nums.Length; i++)
        {
            vector[index] = nums[i];
            PrintCombinations(nums, vector, i + 1, index + 1);
        }
    }
}

