using System;
using System.Linq;

class ReverseArray
{
    static void Main()
    {
        int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Reverse(array, array.Length - 1);
    }

    static void Reverse(int[] array, int index)
    {
        if (index == 0)
        {
            Console.Write($"{array[index]} ");
            return;
        }

        Console.Write($"{array[index]} ");
        Reverse(array, index - 1);
    }
}
