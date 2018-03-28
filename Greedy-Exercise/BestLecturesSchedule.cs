using System;
using System.Collections.Generic;
using System.Linq;

class BestLecturesSchedule
{
    static void Main()
    {
        int lecturesCount = int.Parse(Console.ReadLine().Split(':', ' ').Where(a => a.Length > 0).ToArray()[1]);
        List<Lecture> lectures = new List<Lecture>();
        List<Lecture> result = new List<Lecture>();

        for (int i = 0; i < lecturesCount; i++)
        {
            string[] lectureParams = Console.ReadLine().Split(':', ' ', '-').Where(a => a.Length > 0).ToArray();
            string name = lectureParams[0];
            int start = int.Parse(lectureParams[1]);
            int end = int.Parse(lectureParams[2]);
            
            lectures.Add(new Lecture(name, start, end));
        }

        lectures.Sort();

        while (lectures.Count > 0)
        {
            Lecture current = lectures.First();
            result.Add(current);
            lectures.RemoveAll(l => l.Start < current.End);
        }

        Console.WriteLine($"Lectures ({result.Count}):");
        foreach (Lecture lecture in result)
        {
            Console.WriteLine(lecture);
        }
    }
}

class Lecture : IComparable<Lecture>
{
    public string Name;

    public int Start;

    public int End;

    public int CompareTo(Lecture other)
    {
        return End.CompareTo(other.End);
    }

    public Lecture(string name, int start, int end)
    {
        Name = name;
        Start = start;
        End = end;
    }

    public override string ToString()
    {
        return $"{Start}-{End} -> {Name}";
    }
}