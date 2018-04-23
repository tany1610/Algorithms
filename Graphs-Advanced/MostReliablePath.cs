using System;
using System.Collections.Generic;
using System.Linq;

class MostReliablePath
{
    static void Main()
    {
        //reading the input
        int nodesCount = int.Parse(Console.ReadLine()
            .Split(':', ' ')
            .Where(s => s.Length > 0)
            .ToArray()[1]);

        int[] pathInfo = Console.ReadLine()
            .Split(':', ' ', '-')
            .Where(s => s.Length > 0)
            .Skip(1)
            .Select(int.Parse)
            .ToArray();

        int edgesCount = int.Parse(Console.ReadLine()
            .Split(':', ' ')
            .Where(s => s.Length > 0)
            .ToArray()[1]);

        List<Node> graph = new List<Node>();

        //adding nodes
        for (int i = 0; i < nodesCount; i++)
        {
            graph.Add(new Node(i));
        }

        //making connections
        for (int i = 0; i < edgesCount; i++)
        {
            int[] info = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstLabel = info[0];
            int secondLabel = info[1];
            double edgeWeight = info[2];

            Node first = graph.Find(n => n.Label == firstLabel);
            Node second = graph.Find(n => n.Label == secondLabel);

            Edge edge = new Edge(first, second, edgeWeight);

            first.Edges.Add(edge);
            second.Edges.Add(edge);
        }

        List<double> percetages = new List<double>();
        List<int> path = new List<int>();

        //constructing path
        Node start = graph.Find(n => n.Label == pathInfo[0]);
        Node end = graph.Find(n => n.Label == pathInfo[1]);

        Node current = start;

        while (true)
        {
            current.Edges = current.Edges
                .Where(e => !e.IsUsed)
                .OrderByDescending(e => e.Weight)
                .ToList();

            Edge edgeToUse = current.Edges.First();
            
            edgeToUse.IsUsed = true;
            path.Add(current.Label);

            if (current.Label == end.Label)
            {
                break;
            }

            percetages.Add(edgeToUse.Weight / 100.0);

            current = current.Label == edgeToUse.FirstNode.Label ?
                edgeToUse.SecondNode : edgeToUse.FirstNode;
        }

        double percetage = percetages.First();

        for (int i = 1; i < percetages.Count; i++)
        {
            percetage *= percetages[i];
        }

        //printing result
        Console.WriteLine($"Most reliable path reliability: {percetage * 100:f2}%");
        Console.WriteLine(string.Join(" -> ", path));
    }
}

class Node
{
    public int Label;

    public List<Edge> Edges = new List<Edge>();

    public Node(int label)
    {
        Label = label;
    }
}

class Edge
{
    public Node FirstNode;

    public Node SecondNode;

    public double Weight;

    public bool IsUsed;

    public Edge(Node first, Node second, double weight)
    {
        FirstNode = first;
        SecondNode = second;
        Weight = weight;
    }
}