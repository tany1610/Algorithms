using System;

class GeneratingVectors
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        int[] vector = new int[count];

        PrintVectors(vector, 0);
    }

    private static void PrintVectors(int[] vector, int index)
    {
        if (index == vector.Length)
        {
            Console.WriteLine(string.Join("", vector));
            return;
        }

        for (int i = 0; i <= 1; i++)
        {
            vector[index] = i;
            PrintVectors(vector, index + 1);
        }

    }
}

