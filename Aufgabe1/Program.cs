namespace Aufgabe2;

public class Program
{
    static void Main(string[] args)
    {
        int[] A = { 5, 1, 10, 2, 8, 3, 7, 4, 9, 6 };
        int[] B = { 5, 1, 10, 2, 8, 3, 7, 4, 9, 6 };
        int[] C = { 5, 1, 10, 2, 8, 3, 7, 4, 9, 6 };
        int[] D = { 5, 1, 10, 2, 8, 3, 7, 4, 9, 6 };

        ISortService sortService = new QuicksortService();
        sortService.Sort(A);

        Console.WriteLine("QUICKSORT");
        A.ToList().ForEach(a => Console.Write(a + " "));

        sortService = new BubbleSortService();
        sortService.Sort(B);

        Console.WriteLine();
        Console.WriteLine("BUBBLESORT");
        B.ToList().ForEach(b => Console.Write(b + " "));

        sortService = new InsertionSortService();
        sortService.Sort(C);

        Console.WriteLine();
        Console.WriteLine("INSERTIONSORT");
        C.ToList().ForEach(c => Console.Write(c + " "));

        sortService = new SelectionSortService();
        sortService.Sort(D);

        Console.WriteLine();
        Console.WriteLine("SELECTIONSORT");
        D.ToList().ForEach(d => Console.Write(d + " "));
    }
}
