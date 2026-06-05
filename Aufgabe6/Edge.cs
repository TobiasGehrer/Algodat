namespace Aufgabe6;

public class Edge
{
    public Node Target { get; set; }
    public int Weight { get; set; }

    public Edge (Node target, int weight)
    {
        Target = target;
        Weight = weight;
    }
}
