using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ModifiedKruskalAlgorithm
{
    static void Main()
    {
        int nodes = int.Parse(Console.ReadLine()
            .Split(' ', ':')
            .Where(s => s.Length > 0)
            .ToArray()[1]);

        int edges = int.Parse(Console.ReadLine()
            .Split(' ', ':')
            .Where(s => s.Length > 0)
            .ToArray()[1]);

        List<Node> graph = new List<Node>();
        List<Edge> edgesList = new List<Edge>();

        //adding nodes
        for (int i = 0; i < nodes; i++)
        {
            graph.Add(new Node(i));
        }

        //adding edges
        for (int i = 0; i < edges; i++)
        {
            string[] info = Console.ReadLine()
                .Split()
                .ToArray();

            int firstLabel = int.Parse(info[0]);
            int secondLabel = int.Parse(info[1]);
            int edgeWeight = int.Parse(info[2]);

            Node first = graph.First(n => n.Label == firstLabel);
            Node second = graph.First(n => n.Label == secondLabel);

            Edge edge = new Edge(first, second, edgeWeight);
            edgesList.Add(edge);
            first.Edges.Add(edge);
            second.Edges.Add(edge);
        }

        edgesList = edgesList.OrderBy(e => e.Weight).ThenBy(e => e.First.Label + e.Second.Label).ToList();
        int totalWeight = 0;

        //finding minimum spannig tree
        foreach (Edge edge in edgesList)
        {
            Node first = edge.First;
            Node second = edge.Second;

            if (first.Nodes.Contains(second) || second.Nodes.Contains(first))
            {
                continue;
            }

            totalWeight += edge.Weight;
            first.Nodes.Add(second);
            second.Nodes.Add(first);
            first.Nodes.AddRange(second.Nodes);
            second.Nodes.AddRange(first.Nodes);
            first.AddNodesToNodes(second);
            second.AddNodesToNodes(first);
            first.Nodes = first.Nodes.Distinct().ToList();
            second.Nodes = second.Nodes.Distinct().ToList();

            //adding to result
            result.AppendLine(first.Label < second.Label ? 
                $"({first.Label} {second.Label}) -> {edge.Weight}" :
                $"({second.Label} {first.Label}) -> {edge.Weight}");
        }

        //printing result
        Console.WriteLine($"Minimum spanning forest weight: {totalWeight}");
    }
}

class Node
{
    public int Label;

    public List<Edge> Edges = new List<Edge>();

    public List<Node> Nodes = new List<Node>();

    public Node(int label)
    {
        Label = label;
    }

    public void AddNodesToNodes(Node other)
    {
        for (int i = 0; i < Nodes.Count; i++)
        {
            Node node = Nodes[i];
            node.Nodes.Add(other);
            node.Nodes.AddRange(other.Nodes);
            node.Nodes = node.Nodes.Distinct().ToList();
        }
    }
}

class Edge
{
    public Node First;

    public Node Second;

    public int Weight;

    public Edge(Node first, Node second, int weight)
    {
        First = first;
        Second = second;
        Weight = weight;
    }
}