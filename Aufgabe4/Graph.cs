using System.ComponentModel.Design;

namespace Aufgabe4;

public class Graph
{
    public List<Node> Nodes { get; set; } = new List<Node>();

    public void AddNode(Node node)
    {
        Nodes.Add(node);
    }

    public void AddEdge(Node a, Node b)
    {
        a.Neighbours.Add(b);
        b.Neighbours.Add(a);
    }

    public void Print()
    {
        foreach (var node in Nodes)
        {
            Console.Write(node.Value + " -> ");
            Console.WriteLine(string.Join(", ", node.Neighbours.Select(n => n.Value)));
        }
    }

    public bool HasEulerPath()
    {
        int oddCount = GetOddCount();
        return oddCount == 0 || oddCount == 2;
    }

    public bool HasEulerCircuit()
    {
        int oddCount = GetOddCount();
        return oddCount == 0;
    } 

    public List<Node> FindEulerPath()
    {
        if (!HasEulerPath())
        {
            return null;
        }

        Node start = Nodes.FirstOrDefault(n => n.Neighbours.Count % 2 != 0) ?? Nodes[0];

        var visitedEdges = new HashSet<(string, string)>();
        var path = new List<Node>();

        DFS(start, visitedEdges, path);

        return path;
    }

    private int GetOddCount()
    {
        int oddCount = 0;

        foreach (var node in Nodes)
        {
            if (node.Neighbours.Count % 2 != 0)
            {
                oddCount++;
            }
        }

        return oddCount;
    }

    private void DFS(Node current, HashSet<(string, string)> visitedEdges, List<Node> path)
    {
        foreach (var neighbour in current.Neighbours)
        {
            var edge = string.Compare(current.Value, neighbour.Value) < 0
                ? (current.Value, neighbour.Value)
                : (neighbour.Value, current.Value);

            if (!visitedEdges.Contains(edge))
            {
                visitedEdges.Add(edge);
                DFS(neighbour, visitedEdges, path);
            }
        }

        path.Insert(0, current);
    }
}
