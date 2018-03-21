using System;
using System.Numerics;

class NChooseK
{
    static void Main()
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine());
        BigInteger k = BigInteger.Parse(Console.ReadLine());
        Console.WriteLine(Fac(n) / (Fac(n - k) * Fac(k)));    
    }

    private static BigInteger Fac(BigInteger n)
    {
        if (n == 1)
        {
            return n;
        }

        return n * Fac(n - 1);
    }
}