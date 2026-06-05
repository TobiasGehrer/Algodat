namespace Aufgabe6;

public class Program
{
    static void Main(string[] args)
    {
        var graph = new Graph();

        var a = new Node("A");
        var b = new Node("B");
        var c = new Node("C");
        var d = new Node("D");
        var e = new Node("E");

        graph.AddNode(a);
        graph.AddNode(b);
        graph.AddNode(c);
        graph.AddNode(d);
        graph.AddNode(e);

        graph.AddEdge(a, b, 4);
        graph.AddEdge(a, c, 2);
        graph.AddEdge(b, c, 1);
        graph.AddEdge(b, d, 5);
        graph.AddEdge(c, d, 8);
        graph.AddEdge(c, e, 10);
        graph.AddEdge(d, e, 2);

        Console.WriteLine("Dijkstra:");
        graph.Dijkstra(a);

        Console.WriteLine("\nPrim:");
        graph.Prim(a);
    }
}
