namespace Aufgabe3;

public class Program
{
    static void Main(string[] args)
    {
        // --- Binary Search Tree ---
        Console.WriteLine("--- Binary Search Tree ---");
        var bst = new Bst();

        foreach (var n in new[] { 55, 40, 60, 28, 95, 10, 30, 88, 99, 68, 90, 63, 84, 98 })
        {
            bst.Insert(n);
        }

        bst.Print(bst.Root);

        Console.WriteLine("Search 30: " + bst.Search(30).ToString());        
        Console.WriteLine("Minimum: " + bst.Minimum().ToString());
        Console.WriteLine("Maximum: " + bst.Maximum().ToString());
        Console.WriteLine("Successor 98: " + bst.Successor(98).ToString());
        Console.WriteLine("Predecessor 30: " + bst.Predecessor(30).ToString());

        bst.Remove(55);
        bst.Print(bst.Root);

        var result = bst.Traverse();
        result.ForEach(n => Console.WriteLine(n.Value));
        Console.WriteLine("\n");

        // --- AVL Tree ---
        Console.WriteLine("--- AVL Tree ---");
        var avl = new Avl();

        foreach (var n in new[] { 55, 40, 60, 28, 95, 10, 30, 88, 99, 68, 90, 63, 84, 98 })
        {
            avl.Insert(n);
        }

        avl.Print(avl.Root);

        Console.WriteLine("--- Insert 5 (triggert Rotation) ---");
        avl.Insert(5);
        avl.Print(avl.Root);

        // --- Binary Heap ---
        Console.WriteLine("--- Binary Heap ---");
        var heap = new BinaryHeap(20);

        foreach (var n in new[] { 5, 3, 8, 1, 4, 9, 2 })
        {
            heap.Insert(n);
        }

        heap.Print();

        Console.WriteLine(heap.ExtractMin());

        heap.Print();
    }
}
