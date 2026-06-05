namespace Aufgabe5;

public class Node
{
    public string Value { get; set; }
    public List<Node> Neighbours { get; set; } = new List<Node>();

    public Node(string value)
    {
        Value = value;
    }
}
