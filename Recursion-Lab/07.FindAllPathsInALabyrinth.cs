using System;
using System.Collections.Generic;
using System.Linq;

class FindAllPathsInALabyrinth
{
    public static int rows = int.Parse(Console.ReadLine());
    public static int cols = int.Parse(Console.ReadLine());
    public static char[,] board = new char[rows,cols];
    public static List<string> paths = new List<string>();
    public static List<string> visited = new List<string>();

    static void Main()
    {
        ReadBoardFromConsole();
        FindAllPaths(0, 0, "S");
    }

    private static void FindAllPaths(int row, int col, string direction)
    {
        if (InvalidInput(row, col))
        {           
            return;
        }

        paths.Add(direction);

        if (board[row, col] == 'e')
        {
            PrintCurrentPath();
            return;
        }

        if (!IsVisited(row, col) && PlaceIsFree(row, col))
        {
            MarkPosoitions(row, col);
            FindAllPaths(row, col + 1, "R");
            FindAllPaths(row + 1, col, "D");
            FindAllPaths(row, col - 1, "L");
            FindAllPaths(row - 1, col, "U");
            UnmarkPositions(row, col);
        }

        paths.RemoveAt(paths.Count - 1);
    }

    private static void UnmarkPositions(int row, int col)
    {
        visited.Remove($"{row}{col}");
    }

    private static void MarkPosoitions(int row, int col)
    {
        visited.Add($"{row}{col}");
    }

    private static bool PlaceIsFree(int row, int col)
    {
        bool isFree = !InvalidInput(row, col) && board[row, col] != '*';
        return isFree;
    }

    private static bool IsVisited(int row, int col)
    {
        if (visited.Contains($"{row}{col}"))
            return true;
        return false;
    }

    private static void PrintCurrentPath()
    {
        Console.WriteLine(string.Join("", paths.Skip(1).ToList()));
    }

    private static bool InvalidInput(int row, int col)
    {
        bool isInavlid = row < 0 || col < 0 || row >= board.GetLength(0) || col >= board.GetLength(1);
        return isInavlid;
    }

    private static void ReadBoardFromConsole()
    {
        for (int row = 0; row < rows; row++)
        {
            char[] currentRow = Console.ReadLine().ToCharArray();
            for (int col = 0; col < cols; col++)
            {
                board[row, col] = currentRow[col];
            }
        }
    }
}

