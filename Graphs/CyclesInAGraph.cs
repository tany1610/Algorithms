using System;
using System.Collections.Generic;
using System.Linq;

class CyclesInAGraph
{
    static void Main()
    {
        List<KeyValuePair<char, char>> connections= new List<KeyValuePair< char, char>>();

        bool acyclic = true;
        string input = Console.ReadLine();

        while (!string.IsNullOrEmpty(input))
        {
            connections.Add(new KeyValuePair<char,char>(input[0], input[2]));

            if (connections.Any(kvp => kvp.Key == input[2]))
            {
                acyclic = false;
            }

            input = Console.ReadLine();
        }

        if (acyclic)
        {
            Console.WriteLine("Acyclic: Yes");
            return;
        }

        Console.WriteLine("Acyclic: No");
    }
}