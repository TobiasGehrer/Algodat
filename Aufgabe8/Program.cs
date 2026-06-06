namespace Aufgabe8;

public class Program
{
    static void Main(string[] args)
    {
        var start = new PuzzleState();

        Console.WriteLine("Startzustand:");
        Console.WriteLine(start);

        Console.WriteLine("--- Greedy ---");
        var greedy = new GreedySearch();
        var greedyPath = greedy.Search(start);
        greedyPath?.ForEach(n => Console.WriteLine(n));

        Console.WriteLine("--- A* ---");
        var aStar = new AStarSearch();
        var aStarPath = aStar.Search(start);
        aStarPath?.ForEach(n => Console.WriteLine(n));
    }
}
