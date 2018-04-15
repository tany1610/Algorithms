using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class DistanceBetweenVerticles
{
    static List<Vertex> graph;

    static void Main()
    {
        int verticesCount = int.Parse(Console.ReadLine());
        int pairsCount = int.Parse(Console.ReadLine());
        List<Vertex> vertices = new List<Vertex>();
        Dictionary<int,List<int>> nodes = new Dictionary<int, List<int>>();
        graph = new List<Vertex>();
        StringBuilder result = new StringBuilder();

        //reading edges
        for (int i = 0; i < verticesCount; i++)
        {
            string[] info = Console.ReadLine().Split(':').Where(s => s.Length > 0).ToArray();
            int label = int.Parse(info[0]);

            nodes.Add(label, new List<int>());

            if (info.Length > 1)
            {
                List<int> connections = info[1].Split().Select(int.Parse).ToList();
                nodes[label] = connections;
            }
        }

        //making connections
        foreach (var node in nodes)
        {
            Vertex vertex = new Vertex(node.Key);
            graph.Add(vertex);
        }

        foreach (var node in nodes)
        {
            List<Vertex> others = new List<Vertex>();

            foreach (var vertex in node.Value)
            {
                Vertex current = graph.First(n => n.Label == vertex);
                current.Parents.Add(graph.First(n => n.Label == node.Key));
                others.Add(current);
            }

            graph[graph.IndexOf(graph.First(n => n.Label == node.Key))].AddNeighbour(others);
        }

        //finding pairs
        for (int i = 0; i < pairsCount; i++)
        {
            int[] pair = Console.ReadLine().Split('-').Select(int.Parse).ToArray();
            int startLabel = pair[0];
            int endLabel = pair[1];

            Vertex node = graph.First(v => v.Label == startLabel);

            //BFS
            int steps = BFS(node, endLabel);
            string current = "{" + $"{startLabel}, {endLabel}" + "}" + $" -> {steps}\n";
            result.Append(current);
        }

        //print result
        Console.Write(result);
    }

    private static int BFS(Vertex node, int target)
    {
        Queue<Vertex> queue = new Queue<Vertex>();
        List<Vertex> visited = new List<Vertex>();
        int nodeLabel = node.Label;

        queue.Enqueue(node);
        visited.Add(node);

        while(queue.Count != 0)
        {
            node = queue.Dequeue();
            visited.Add(node);

            foreach (Vertex child in node.Connections)
            {
                if (!visited.Contains(child))
                {
                    queue.Enqueue(child);
                    visited.Add(child);
                }              
            }

            if (node.Label == target)
            {
                int counter = 0;

                while (true)
                {
                    foreach (Vertex parent in node.Parents)
                    {
                        if (visited.Contains(parent))
                        {
                            counter++;
                            node = parent;
                            visited.Remove(parent);
                            break;
                        }
                    }

                    if (node.Label == nodeLabel)
                    {
                        return counter;
                    }
                }
            }
        }

        return -1;
    }
}

class Vertex
{
    public int Label;

    public HashSet<Vertex> Parents = new HashSet<Vertex>();

    public List<Vertex> Connections = new List<Vertex>();

    public void AddNeighbour(List<Vertex> other)
    {
        Connections.AddRange(other);
    }

    public Vertex(int label)
    {
        Label = label;
    }
}