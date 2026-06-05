namespace Aufgabe3;

public class BstNode
{
    public int Value { get; set; }
    public BstNode Left { get; set; }
    public BstNode Right { get; set; }
    public BstNode Parent { get; set; }

    public BstNode(int value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return $"Value: {Value} | Left: {Left?.Value} | Right: {Right?.Value} | Parent: {Parent?.Value}";
    }
}
