using System;
using System.Collections.Generic;
using System.Linq;

class ConnectedAreas
{
    private static int rows = int.Parse(Console.ReadLine());
    private static int cols = int.Parse(Console.ReadLine());
    private static char[][] matrix = new char[rows][];
    private static int maxSum;

    static List<Area> result = new List<Area>();

    static void Main()
    {
        ReadMatrix();

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                char current = matrix[row][col];

                if (current == ' ' || current == '-')
                {
                    maxSum = 0;

                    LoopArea(row, col);

                    Area currentArea = new Area
                    {
                        Pos = new[] { row, col },
                        Size = maxSum
                    };

                    result.Add(currentArea);
                }                   
            }
        }

        Console.WriteLine($"Total areas found: {result.Count}");

        result = result.OrderByDescending(a => a.Size).ThenBy(a => a.Pos[0]).ThenBy(a => a.Pos[1]).ToList();
        int counter = 1;

        foreach (Area area in result)
        {
            Console.WriteLine($"Area #{counter} at ({area.Pos[0]}, {area.Pos[1]}), size: {area.Size}");
            counter++;
        }
    }

    private static void LoopArea(int row, int col)
    {
        if (!IsInside(row, col) || matrix[row][col] == '*')
        {         
            return;
        }

        maxSum++;
        matrix[row][col] = '*';        
        LoopArea(row, col + 1);
        LoopArea(row, col - 1);
        LoopArea(row - 1, col);
        LoopArea(row + 1, col);
    }

    private static bool IsInside(int row, int col)
    {
        return row >= 0 && col >= 0 && row < rows && col < cols;
    }

    private static void ReadMatrix()
    {
        for (int i = 0; i < rows; i++)
        {
            matrix[i] = Console.ReadLine().ToCharArray();
        }
    }
}

class Area
{
    public int[] Pos;

    public int Size;
}