using System;
using System.Collections.Generic;
using System.Linq;

class CombinationsWithRepetitionam
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        int[] arr = new int[k];

        GenerateCombinationsWithRepetition(arr, 0, 1, n);
    }

    private static void GenerateCombinationsWithRepetition(int[] arr, int index, int start, int end)
    {
        if (index > arr.Length - 1)
        {
            Console.WriteLine(string.Join(" ", arr));
            return;
        }

        for (int i = start; i <= end; i++)
        {
            arr[index] = i;
            GenerateCombinationsWithRepetition(arr, index + 1, start + 1, end);
            start++;
        }
    }
}