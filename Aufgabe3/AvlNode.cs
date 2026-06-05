namespace Aufgabe3;

public class AvlNode
{
    public int Value { get; set; }
    public int Height { get; set; } = 1;
    public AvlNode Left { get; set; }
    public AvlNode Right { get; set; }
    public AvlNode Parent { get; set; }

    public AvlNode(int value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return $"Value: {Value} | Height: {Height}";
    }
}
