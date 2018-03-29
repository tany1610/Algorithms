using System;
using System.Collections.Generic;
using System.Linq;

class LIS
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] len = new int[arr.Length];
        int[] prev = new int[arr.Length];
        List<int> result = new List<int>();

        //set length to 1
        for (int i = 0; i < len.Length; i++)
        {
            len[i] = 1;
        }
        //set previos to -1
        for (int i = 0; i < prev.Length; i++)
        {
            prev[i] = -1;
        }

        for (int i = 0; i < arr.Length; i++)
        {
            int current = arr[i];

            for (int j = 0; j < i; j++)
            {
                int previous = arr[j];

                if (previous < current && len[j] >= len[i])
                {
                    len[i] = len[j] + 1;
                    prev[i] = j;
                }
            }
        }

        int index = Array.IndexOf(len, len.Max());

        while (index != -1)
        {
            result.Add(arr[index]);
            index = prev[index];
        }

        result.Reverse();

        Console.WriteLine(string.Join(" ", result));
    }
}