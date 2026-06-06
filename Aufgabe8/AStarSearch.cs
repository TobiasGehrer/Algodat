namespace Aufgabe8;

public class AStarSearch
{
    public List<Node> Search(Node start)
    {
        var openList = new PriorityQueue<Node, int>();
        var closeList = new List<Node>();

        openList.Enqueue(start, start.Cost + start.Heuristic());

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
                state.Cost = current.Cost + 1;
                openList.Enqueue(state, state.Cost + state.Heuristic());
            }
        }

        return null;
    }
}
