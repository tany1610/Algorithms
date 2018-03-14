using System;
using System.Collections.Generic;
using System.Linq;

class QueensPuzzle
{
    static HashSet<int> attackedRows = new HashSet<int>();
    static HashSet<int> attackedCols = new HashSet<int>();
    static HashSet<int> attackedLeftDiag = new HashSet<int>();
    static HashSet<int> attackedRightDiag = new HashSet<int>();
    static bool[,] board = new bool[8, 8];

    static void Main()
    {
        DrawQueens(0);
    }

    private static void DrawQueens(int row)
    {
        if (row >= 8)
        {
            PrintBoard();
            return;
        }

        for (int col = 0; col < 8; col++)
        {
            if (QueenCanBePlaced(row, col))
            {
                MarkPositions(row, col);
                DrawQueens(row + 1);
                UnmarkPositions(row, col);
            }
        }
    }

    private static void UnmarkPositions(int row, int col)
    {
        attackedRows.Remove(row);
        attackedCols.Remove(col);
        attackedLeftDiag.Remove(col - row);
        attackedRightDiag.Remove(row + col);
        board[row, col] = false;
    }

    private static void MarkPositions(int row, int col)
    {
        attackedRows.Add(row);
        attackedCols.Add(col);
        attackedLeftDiag.Add(col - row);
        attackedRightDiag.Add(row + col);
        board[row, col] = true;
    }

    private static bool QueenCanBePlaced(int row, int col)
    {
        bool cantBePlaced = attackedCols.Contains(col) 
                         || attackedRows.Contains(row)
                         || attackedLeftDiag.Contains(col - row) 
                         || attackedRightDiag.Contains(row + col);
        return !cantBePlaced;
    }

    private static void PrintBoard()
    {
        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (board[row, col])
                {
                    Console.Write("* ");
                }
                else
                {
                    Console.Write("- ");
                }                
            }

            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

