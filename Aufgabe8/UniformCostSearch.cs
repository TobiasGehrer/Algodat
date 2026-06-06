namespace Aufgabe8;

public class UniformCostSearch
{
    public List<Node> Search(Node startNode)
    {
        var openList = new PriorityQueue<Node, double>();
        var closedList = new List<Node>();

        openList.Enqueue(startNode, startNode.Cost);

        while (openList.Count > 0)
        {
            var current = openList.Dequeue();

            if (!closedList.Contains(current))
            {
                closedList.Add(current);

                if (current.IsGoal())
                {
                    var path = new List<Node>();
                    var parent = current.Parent;

                    while (parent is not null)
                    {                        
                        path.Add(current);
                        current = parent;
                        parent = current.Parent;
                    }

                    path.Add(current);
                    path.Reverse();
                    return path;
                }

                foreach (var successor in current.GetSuccessors())
                {
                    successor.Parent = current;
                    successor.Cost = current.Cost + successor.Cost;
                    openList.Enqueue(successor, successor.Cost);
                }
            }
        }

        return null;
    }
}
