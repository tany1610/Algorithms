using System;
using System.Collections.Generic;
using System.Linq;

class EgyptianFractions
{
    static void Main()
    {
        int[] number = Console.ReadLine().Split('/').Select(int.Parse).ToArray();
        int firstDigit = number[0];
        int seconddoigit = number[1];

        if (firstDigit / seconddoigit >= 1)
        {
            Console.WriteLine("Error (fraction is equal to or greater than 1)");
            return;
        }

        double result = Math.Round((double)firstDigit / seconddoigit, 5);
        List<string> output = new List<string>();
        double currentSum = 0;
        int q = 2;

        while (true)
        {
            double current = Math.Round((double) 1 / q, 5);

            if (currentSum + current <= result)
            {
                currentSum += current;
                output.Add($"1/{q}");

                if (currentSum == result)
                {
                    break;
                }
            }

            q++;
        }

        Console.WriteLine($"{firstDigit}/{seconddoigit} = " + string.Join(" + ", output));
    }
}