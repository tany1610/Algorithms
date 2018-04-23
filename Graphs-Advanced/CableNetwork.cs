using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

class CableNetwork
{
    static void Main()
    {
        int budget = int.Parse(Console.ReadLine()
            .Split(':', ' ')
            .Where(s => s.Length > 0)
            .ToArray()[1]);
        int nodes = int.Parse(Console.ReadLine()
            .Split(':', ' ')
            .Where(s => s.Length > 0)
            .ToArray()[1]);
        int edges = int.Parse(Console.ReadLine()
            .Split(':', ' ')
            .Where(s => s.Length > 0)
            .ToArray()[1]);

        List<Node> graph = new List<Node>();

        //creating nodes
        for (int i = 0; i < nodes; i++)
        {
            graph.Add(new Node(i));
        }

        //making connections and adding weights
        for (int i = 0; i < edges; i++)
        {
            string[] info = Console.ReadLine().Split();
            int firstLabel = int.Parse(info[0]);
            int secondLabel = int.Parse(info[1]);
            int weight = int.Parse(info[2]);
            bool areConnected = info.Length > 3;

            Node first = graph.Find(n => n.Label == firstLabel);
            Node second = graph.Find(n => n.Label == secondLabel);

            Edge edge = new Edge(first, second, weight, areConnected);

            first.Edges.Add(edge);
            second.Edges.Add(edge);
        }

        //finding non-connected nodes
        List<Node> nonConnected = new List<Node>();
        foreach (Node node in graph)
        {
            if (!node.IsConnected)
            {
                nonConnected.Add(node);
            }
        }

        nonConnected = nonConnected.OrderBy(n => n.Edges.Min(e => e.Weight)).ToList();
        int sum = 0;

        foreach (Node node in nonConnected)
        {
            int currWeight = node.Edges.Min(e => e.Weight);

            if (sum + currWeight <= budget)
            {
                sum += currWeight;
            }

            else
            {
                break;
            }
        }

        Console.WriteLine($"Budget used: {sum}");

    }
}

class Node
{
    public int Label;

    public bool IsConnected
    {
        get { return Edges.Any(e => e.IsInUse); }
    }

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

    public int Weight;

    public bool IsInUse;

    public Edge(Node first, Node second, int weight, bool areConnected)
    {
        FirstNode = first;
        SecondNode = second;
        Weight = weight;
        IsInUse = areConnected;
    }
}