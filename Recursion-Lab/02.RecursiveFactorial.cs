using System;

class RecursiveFactorial
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(Factorial(n, 1, 1));
    }

    private static int Factorial(int n, int num, int sum)
    {
        if (num == n)
        {
            return sum;
        }

        sum *= num + 1;
        return Factorial(n, num + 1, sum);
    }
}

