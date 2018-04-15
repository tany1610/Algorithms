using System;
using System.Collections.Generic;
using System.Linq;

class AreasInMatrix
{
    public static int size = int.Parse(Console.ReadLine());

    public static Cell[][] matrix = new Cell[size][];

    static void Main()
    {
        Dictionary<char, int> result = new Dictionary<char, int>();

        //reading the matrix
        for (int i = 0; i < size; i++)
        {
            char[] currentLine = Console.ReadLine().ToCharArray();
            matrix[i] = new Cell[currentLine.Length];

            for (int j = 0; j < currentLine.Length; j++)
            {
                char label = currentLine[j];

                matrix[i][j] = new Cell(label, new int[] {i, j});
            }
        }

        //adding neighbours
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                matrix[i][j].AddNeighbours();
            }
        }

        //finding areas
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                Cell current = matrix[i][j];

                if (!current.BelongsToArea)
                {
                    if (!result.ContainsKey(current.Label))
                    {
                        result.Add(current.Label, 1);
                    }

                    else
                    {
                        result[current.Label]++;
                    }

                    List<Cell> visited = new List<Cell>();
                    current.BelongsToArea = true;
                    DFS(current, visited);
                }
            }
        }

        //print result
        Console.WriteLine($"Areas: {result.Values.Sum()}");

        foreach (var pair in result.OrderBy(kvp => kvp.Key))
        {
            Console.WriteLine($"Letter \'{pair.Key}\' -> {pair.Value}");
        }
    }

    public static void DFS(Cell cell, List<Cell> visited)
    {
        if (!visited.Contains(cell))
        {
            visited.Add(cell);

            foreach (Cell child in cell.Neighbours)
            {
                if (child.Label == cell.Label && !child.BelongsToArea)
                {
                    child.BelongsToArea = true;
                    DFS(child, visited);
                }
            }
        }
    }
}

class Cell
{
    public char Label;

    public int[] Position;

    public bool BelongsToArea;

    public List<Cell> Neighbours = new List<Cell>();

    public Cell(char label, int[] position)
    {
        Label = label;
        Position = position;
    }

    public void AddNeighbours()
    {
        //add upper neighbour
        if (Position[0] - 1 >= 0)
        {
            Neighbours.Add(AreasInMatrix.matrix[Position[0] - 1][Position[1]]);
        }
        //add lower neighbour
        if (Position[0] + 1 < AreasInMatrix.size)
        {
            Neighbours.Add(AreasInMatrix.matrix[Position[0] + 1][Position[1]]);
        }
        //add left neighbour
        if (Position[1] + 1 < AreasInMatrix.matrix[Position[0]].Length)
        {
            Neighbours.Add(AreasInMatrix.matrix[Position[0]][Position[1] + 1]);
        }
        //add right neighbour
        if (Position[1] - 1 >= 0)
        {
            Neighbours.Add(AreasInMatrix.matrix[Position[0]][Position[1] - 1]);
        }
    }
}