using System;
using System.Linq;

class RecursiveArraySum
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine(Sum(arr, 0));
    }

    private static int Sum(int[] arr, int index)
    {
        if (index == arr.Length - 1)
        {
            return arr[0];
        }

        arr[0] += arr[index + 1];
        return Sum(arr, index + 1);
    }
}

