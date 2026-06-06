namespace Aufgabe7;

public class Program
{
    static void Main(string[] args)
    {        
        var initial = new GameState();
        var solver = new Solver();

        Console.WriteLine("--- BFS ---");
        var path = solver.BFS(initial);
        path.ForEach(s => Console.WriteLine(s));

        Console.WriteLine("--- DFS ---");
        path = solver.DFS(initial);
        path.ForEach(s => Console.WriteLine(s));
    }
}
