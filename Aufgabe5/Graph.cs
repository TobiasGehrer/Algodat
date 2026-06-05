namespace Aufgabe5;

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

    public void DFSRecursive(Node node, string searchValue)
    {
        SearchStats searchStats = new SearchStats();
        var closeList = new List<Node>();
        DFSRecursive(node, closeList, 0, searchStats, searchValue);

        Console.WriteLine($"Expandierte Knoten: {searchStats.ExpandedNodes}");
        Console.WriteLine($"Lösungstiefe: {searchStats.SolutionDepth}");
        Console.WriteLine($"Max. OpenList Größe: {searchStats.MaxOpenListSize}");
    }

    public void DFSIterative(Node startNode, string searchValue)
    {
        int expandedNodes = 0;
        int maxOpenListSize = 0;
        int solutionDepth = 0;

        var closedList = new List<Node>();
        var openList = new Stack<(Node node, int depth)>();

        openList.Push((startNode, 0));

        while (openList.Count > 0)
        {
            var current = openList.Pop();

            if (!closedList.Contains(current.node))
            {
                expandedNodes++;
                closedList.Add(current.node);
                Console.WriteLine(current.node.Value);

                if (current.node.Value.Equals(searchValue))
                {
                    solutionDepth = current.depth;
                    break;
                }

                foreach (var node in current.node.Neighbours)
                {
                    openList.Push((node, current.depth + 1));

                    if (maxOpenListSize < openList.Count)
                    {
                        maxOpenListSize = openList.Count;
                    }
                }
            }
        }

        Console.WriteLine($"Expandierte Knoten: {expandedNodes}");
        Console.WriteLine($"Lösungstiefe: {solutionDepth}");
        Console.WriteLine($"Max. OpenList Größe: {maxOpenListSize}");
    }

    public void BFSIterative(Node startNode, string searchValue)
    {
        int expandedNodes = 0;
        int maxOpenListSize = 0;
        int solutionDepth = 0;

        var closeList = new List<Node>();
        var openList = new Queue<(Node node, int depth)>();

        openList.Enqueue((startNode, 0));

        while (openList.Count > 0)
        {
            var current = openList.Dequeue();

            if (!closeList.Contains(current.node))
            {
                expandedNodes++;
                closeList.Add(current.node);
                Console.WriteLine(current.node.Value);

                if (current.node.Value.Equals(searchValue))
                {
                    solutionDepth = current.depth;
                    break;
                }

                foreach (var node in current.node.Neighbours)
                {
                    openList.Enqueue((node, current.depth + 1));

                    if (maxOpenListSize < openList.Count)
                    {
                        maxOpenListSize = openList.Count;
                    }
                }
            }
        }

        Console.WriteLine($"Expandierte Knoten: {expandedNodes}");
        Console.WriteLine($"Lösungstiefe: {solutionDepth}");
        Console.WriteLine($"Max. OpenList Größe: {maxOpenListSize}");
    }

    private bool DFSRecursive(Node node, List<Node> closeList, int depth, SearchStats searchStats, string searchValue)
    {
        if (closeList.Contains(node))
        {
            return false;
        }

        searchStats.ExpandedNodes++;
        closeList.Add(node);
        Console.WriteLine(node.Value);

        if (node.Value.Equals(searchValue))
        {
            searchStats.SolutionDepth = depth;
            return true;
        }

        foreach (var n in node.Neighbours)
        {
            if (DFSRecursive(n, closeList, depth + 1, searchStats, searchValue))
            {
                return true;
            }
        }

        return false;
    } 
}
