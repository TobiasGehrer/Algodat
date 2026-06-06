namespace Aufgabe7;

public class Solver
{
    public List<GameState> BFS(GameState startState)
    {
        var openList = new Queue<GameState>();
        var closeList = new HashSet<GameState>();
        var previous = new Dictionary<GameState, GameState>();

        openList.Enqueue(startState);

        while (openList.Count > 0)
        {
            var current = openList.Dequeue();            

            if (closeList.Contains(current))
            {
                continue;
            }

            closeList.Add(current);

            if (current.IsTerminationState())
            {
                var path = new List<GameState>();
                var step = current;

                while (previous.ContainsKey(step))
                {
                    path.Insert(0, step);
                    step = previous[step];
                }

                path.Insert(0, startState);
                return path;
            }

            var neighbours = current.GetNeighbours();

            foreach (var neighbor in neighbours)
            {
                if (!previous.ContainsKey(neighbor) && !closeList.Contains(neighbor))
                {
                    previous[neighbor] = current;
                    openList.Enqueue(neighbor);
                }
            }
        }

        return new List<GameState>();
    }

    public List<GameState> DFS(GameState startState)
    {
        var openList = new Stack<GameState>();
        var closeList = new HashSet<GameState>();
        var previous = new Dictionary<GameState, GameState>();

        openList.Push(startState);

        while (openList.Count > 0)
        {
            var current = openList.Pop();

            if (closeList.Contains(current))
            {
                continue;
            }

            closeList.Add(current);

            if (current.IsTerminationState())
            {
                var path = new List<GameState>();
                var step = current;

                while (previous.ContainsKey(step))
                {
                    path.Insert(0, step);
                    step = previous[step];
                }

                path.Insert(0, startState);
                return path;
            }

            var neighbours = current.GetNeighbours();

            foreach (var neighbor in neighbours)
            {
                if (!previous.ContainsKey(neighbor) && !closeList.Contains(neighbor))
                {
                    previous[neighbor] = current;
                    openList.Push(neighbor);
                }
            }
        }

        return new List<GameState>();
    }
}
