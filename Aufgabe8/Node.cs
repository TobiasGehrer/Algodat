namespace Aufgabe8;

public abstract class Node
{
    public Node Parent { get; set; }
    public double Cost { get; set; }

    public abstract IEnumerable<Node> GetSuccessors();
    public abstract bool IsGoal();
}
