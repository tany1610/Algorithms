using System;

class Fibonacci
{
    private static int[] arr;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        arr = new int[n + 1];
        arr[0] = 0;
        arr[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            arr[i] = arr[i - 1] + arr[i - 2];
        }

        Console.WriteLine(arr[n]);
    }
}