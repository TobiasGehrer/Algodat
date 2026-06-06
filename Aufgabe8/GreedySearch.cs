namespace Aufgabe8;

public class GreedySearch
{
    public List<Node> Search(Node start)
    {
        var openList = new PriorityQueue<Node, int>();
        var closeList = new HashSet<Node>();

        openList.Enqueue(start, start.Heuristic());

        while (openList.Count > 0)
        {
            var current = openList.Dequeue();

            if (closeList.Contains(current))
            {
                continue;
            }

            closeList.Add(current);

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

            foreach (var state in current.GetSuccessors())
            {
                state.Parent = current;
                openList.Enqueue(state, state.Heuristic());
            }
        }

        return null;
    }
}
