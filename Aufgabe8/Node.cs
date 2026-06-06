namespace Aufgabe8;

public abstract class Node
{
    public Node Parent { get; set; }
    public int Cost { get; set; }

    public abstract IEnumerable<Node> GetSuccessors();
    public abstract int Heuristic();
    public abstract bool IsGoal();
}
