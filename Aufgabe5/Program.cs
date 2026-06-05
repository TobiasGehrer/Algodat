namespace Aufgabe5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();

            var n1 = new Node("A");
            var n2 = new Node("B");
            var n3 = new Node("C");
            var n4 = new Node("D");
            var n5 = new Node("E");

            graph.AddNode(n1);
            graph.AddNode(n2);
            graph.AddNode(n3);
            graph.AddNode(n4);
            graph.AddNode(n5);

            graph.AddEdge(n1, n2);
            graph.AddEdge(n1, n3);
            graph.AddEdge(n2, n4);
            graph.AddEdge(n2, n5);
            graph.AddEdge(n3, n4);
            graph.AddEdge(n4, n5);

            Console.WriteLine("--- DFS Rekursiv ---");
            graph.DFSRecursive(n1, "D");

            Console.WriteLine("--- DFS Iterativ ---");
            graph.DFSIterative(n1, "D");

            Console.WriteLine("--- BFS Iterativ ---");
            graph.BFSIterative(n1, "D");
        }
    }
}
