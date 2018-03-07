using System;

class NestedLoopsToRecursion
{
    static void Main()
    {
        int maxNum = int.Parse(Console.ReadLine());
        int[] vector = new int[maxNum];
        PrintCombinations(maxNum, vector, 0);
    }

    private static void PrintCombinations(int maxNum, int[] vector, int index)
    {
        if (index >= maxNum)
        {
            Console.WriteLine(string.Join(" ", vector));
            return;
        }

        for (int i = 1; i <= maxNum; i++)
        {
            vector[index] = i;
            PrintCombinations(maxNum, vector, index + 1);
        }
    }
}