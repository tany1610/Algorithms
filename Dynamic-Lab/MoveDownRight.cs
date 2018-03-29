using System;
using System.Collections.Generic;
using System.Linq;

class MoveDownRight
{
    private static int rows = int.Parse(Console.ReadLine());
    private static int cols = int.Parse(Console.ReadLine());
    private static int[][] matrix = new int[rows][];
    private static int[][] sums = new int[rows][];
    static List<KeyValuePair<int,int>> path = new List<KeyValuePair<int, int>>();

    static void Main()
    {
        FillMatrix();
        BuildSumsMatrix();

        //fill sums matrix
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (i != 0 || j != 0)
                {
                    sums[i][j] = CalsBestSum(i, j);
                }
            }
        }

        //construct path
        int currRow = rows - 1;
        int currCol = cols - 1;
        path.Add(new KeyValuePair<int, int>(rows - 1, cols - 1));

        while (true)
        {
            int upSum = 0;
            int leftSum = 0;

            if (currRow - 1 >= 0)
            {
                upSum = sums[currRow - 1][currCol];
            }

            if (currCol - 1 >= 0)
            {
                leftSum = sums[currRow][currCol - 1];
            }

            if (upSum > leftSum)
            {
                path.Add(new KeyValuePair<int, int>(currRow - 1, currCol));
                currRow--;
            }

            else
            {
                path.Add(new KeyValuePair<int, int>(currRow, currCol - 1));
                currCol--;
            }


            if (currRow == 0 && currCol == 0)
            {
                break;
            }
        }

        path.Reverse();

        Console.WriteLine(string.Join(" ", path));
    }

    private static int CalsBestSum(int row, int col)
    {
        int result;
        int fromRigth = 0;
        int fromUp = 0;

        if (col - 1 >= 0)
        {
            fromRigth = matrix[row][col - 1] + matrix[row][col];
        }

        if (row - 1 >= 0)
        {
            fromUp = matrix[row - 1][col] + matrix[row][col];
        }

        if (fromUp == 0 && fromRigth == 0)
        {
            result = matrix[row][col];
        }

        else if (fromUp > fromRigth)
        {
            result = fromUp;
        }

        else
        {
            result = fromRigth;
        }

        return result;
    }

    private static void BuildSumsMatrix()
    {
        for (int i = 0; i < rows; i++)
        {
            sums[i] = new int[cols];
        }

        sums[0][0] = matrix[0][0];
    }

    private static void FillMatrix()
    {
        for (int i = 0; i < rows; i++)
        {
            matrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
        }
    }
}