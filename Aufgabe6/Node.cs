namespace Aufgabe6;

public class Node
{
    public string Value { get; set; }
    public List<Edge> Edges { get; set; } = new List<Edge>();

    public Node (string value)
    {
        Value = value;
    }    
}
