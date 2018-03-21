using System;

class IterativePermutationsWithoutRepetitions
{
    static string[] input = Console.ReadLine().Split();

    static void Main()
    {
        GenComb(0);
    }

    private static void GenComb(int index)
    {
        if (index == input.Length - 1)
        {
            Console.WriteLine(string.Join(" ", input));
            return;
        }

        for (int i = index; i < input.Length; i++)
        {
            Swap(index, i);
            GenComb(index + 1);
            Swap(index, i);
        }
    }

    private static void Swap(int index, int i)
    {
        string temp = input[index];
        input[index] = input[i];
        input[i] = temp;
    }
}