namespace Aufgabe6;

public class Graph
{
    public List<Node> Nodes { get; set; } = new List<Node>();

    public void AddNode(Node node)
    {
        Nodes.Add(node);
    }

    public void AddEdge(Node a, Node b, int weight)
    {
        a.Edges.Add(new Edge(b, weight));
        b.Edges.Add(new Edge(a, weight));
    }

    public void Dijkstra(Node start)
    {
        var distance = new Dictionary<Node, int>();
        var previous = new Dictionary<Node, Node>();
        var visited = new HashSet<Node>();

        foreach (var node in Nodes)
        {
            distance[node] = int.MaxValue;
            previous[node] = null;
        }

        distance[start] = 0;

        while (visited.Count < Nodes.Count)
        {
            var current = GetUnvisitedMinDistance(distance, visited);

            if (current is null)
            {
                break;
            }

            visited.Add(current);

            foreach (var edge in current.Edges)
            {
                if (!visited.Contains(edge.Target))
                {
                    int newDistance = distance[current] + edge.Weight;

                    if (newDistance < distance[edge.Target])
                    {
                        distance[edge.Target] = newDistance;
                        previous[edge.Target] = current;
                    }
                }
            }
        }

        foreach (var node in Nodes)
        {
            Console.Write($"{node.Value}: Distanz={distance[node]}, Pfad=");
            var path = new List<string>();
            var current = node;

            while (current != null)
            {
                path.Insert(0, current.Value);
                current = previous[current];
            }

            Console.WriteLine(string.Join(" -> ", path));
        }
    }

    public void Prim(Node start)
    {
        var distance = new Dictionary<Node, int>();
        var previous = new Dictionary<Node, Node>();
        var visited = new HashSet<Node>();

        foreach (var node in Nodes)
        {
            distance[node] = int.MaxValue;
            previous[node] = null;
        }

        distance[start] = 0;

        while (visited.Count < Nodes.Count)
        {
            var current = GetUnvisitedMinDistance(distance, visited);

            if (current is null)
            {
                break;
            }

            visited.Add(current);

            foreach (var edge in current.Edges)
            {
                if (!visited.Contains(edge.Target))
                {
                    int newDistance = edge.Weight;

                    if (newDistance < distance[edge.Target])
                    {
                        distance[edge.Target] = newDistance;
                        previous[edge.Target] = current;
                    }
                }
            }
        }

        foreach (var node in Nodes)
        {
            if (previous[node] != null)
            { 
                Console.WriteLine($"{previous[node].Value} -- {distance[node]} --> {node.Value}"); 
            }           
        }
    }

    private Node GetUnvisitedMinDistance(Dictionary<Node, int> distance, HashSet<Node> visited)
    {
        Node minNode = null;
        int minDistance = int.MaxValue;

        foreach (var node in Nodes) 
        {
            if (!visited.Contains(node) && distance[node] < minDistance)
            {
                minDistance = distance[node];
                minNode = node;
            }
        }

        return minNode;
    }
}
