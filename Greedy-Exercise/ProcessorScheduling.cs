using System;
using System.Collections.Generic;
using System.Linq;

class ProcessorScheduling
{
    static void Main()
    {
        int tasksCount = int.Parse(Console.ReadLine().Split(':', ' ').Where(a => a.Length > 0).ToArray()[1]);
        List<Task> tasks = new List<Task>();
        List<Task> result = new List<Task>();
        int maxDeadline = 0;

        for (int i = 0; i < tasksCount; i++)
        {
            int[] taskInfo = Console.ReadLine().Split('-', '>').Where(a => a.Length > 0).Select(int.Parse).ToArray();
            int value = taskInfo[0];
            int deadline = taskInfo[1];

            if (deadline > maxDeadline)
            {
                maxDeadline = deadline;
            }

            tasks.Add(new Task(i + 1, value, deadline));
        }

        tasks.Sort();

        result = tasks.Take(maxDeadline).ToList();
        result = result.OrderBy(t => t.Deadline).ThenByDescending(t => t.Value).ToList();
        int totalValue = 0;

        Console.Write("Optimal schedule: ");

        for (int i = 0; i < result.Count; i++)
        {
            totalValue += result[i].Value;

            if (i == result.Count - 1)
            {
                Console.Write(result[i].Id);
            }
            else
            {
                Console.Write(result[i].Id + " -> ");
            }
        }

        Console.WriteLine();
        Console.WriteLine($"Total value: {totalValue}");
    }
}

class Task : IComparable<Task>
{
    public int Id;

    public int Value;

    public int Deadline;

    public Task(int id, int value, int deadline)
    {
        Id = id;
        Value = value;
        Deadline = deadline;
    }

    public int CompareTo(Task other)
    {
        return other.Value.CompareTo(Value);
    }
}