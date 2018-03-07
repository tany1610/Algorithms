using System;
using System.Collections.Generic;
using System.Linq;

class CombinationsWithRepetition
{
    private static int n = int.Parse(Console.ReadLine());
    private static int counter = 0;
    public static Stack<int> source = new Stack<int>();
    public static Stack<int> destination = new Stack<int>();
    public static Stack<int> spare = new Stack<int>();

    static void Main()
    {
        FillSource();
        Console.WriteLine($"Source: {string.Join(", ", source.Reverse())}");
        Console.WriteLine($"Destination: {string.Join(", ", destination.Reverse())}");
        Console.WriteLine($"Spare: {string.Join(", ", spare.Reverse())}");
        Console.WriteLine();
        SolveProblem(n, source, destination, spare);
    }

    private static void FillSource()
    {
        for (int i = n; i >= 1; i--)
        {
            source.Push(i);
        }
    }

    private static void SolveProblem(int count, Stack<int> source, Stack<int> destination, Stack<int> spare)
    {
        if (count == 1)
        {
            counter++;
            destination.Push(source.Pop());
            Print();
            return;
        }

        SolveProblem(count - 1, source, spare, destination);
        counter++;
        destination.Push(source.Pop());
        Print();
        SolveProblem(count - 1, spare, destination, source);
    }

    private static void Print()
    {
        Console.WriteLine($"Step #{counter}: Moved disk");
        Console.WriteLine($"Source: {string.Join(", ", source.Reverse())}");
        Console.WriteLine($"Destination: {string.Join(", ", destination.Reverse())}");
        Console.WriteLine($"Spare: {string.Join(", ", spare.Reverse())}");
        Console.WriteLine();
    }
}