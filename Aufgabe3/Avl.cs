namespace Aufgabe3;

public class Avl
{
    public AvlNode Root { get; set; }

    public void Print(AvlNode node, int indent = 0)
    {
        if (node is null)
        {
            return;
        }

        Print(node.Right, indent + 4);
        Console.WriteLine(new string(' ', indent) + node.Value);
        Print(node.Left, indent + 4);
    }

    public int GetHeight(AvlNode node)
    {
        return node is null ? 0 : node.Height;
    }

    public int GetBalanceFactor(AvlNode node)
    {
        if (node is null)
        {
            return 0;
        }

        return GetHeight(node.Right) - GetHeight(node.Left); 
    }

    public void Insert(int newValue)
    {
        Root = Insert(Root, newValue);
    }

    private AvlNode Insert(AvlNode node, int newValue)
    {
        if (node is null)
        {
            return new AvlNode(newValue);
        }

        if (newValue < node.Value)
        {
            node.Left = Insert(node.Left, newValue);

            if (node.Left is not null)
            {
                node.Left.Parent = node;
            }
        }
        else if (newValue > node.Value)
        {
            node.Right = Insert(node.Right, newValue);

            if (node.Right is not null)
            {
                node.Right.Parent = node;
            }
        }

        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

        int bf = GetBalanceFactor(node);

        // Fall 1.1: links-links -> Rechtsrotation
        if (bf == -2 && GetBalanceFactor(node.Left) <= 0)
        {
            return RotateRight(node);
        }

        // Fall 1.2: links-recht -> Doppelrotation
        if (bf == -2 && GetBalanceFactor(node.Left) == 1)
        {
            node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }

        // Fall 2.1 rechts-rechts -> Linksrotation
        if (bf == 2 && GetBalanceFactor(node.Right) >= 0)
        {
            return RotateLeft(node);
        }

        // Fall 2.2: rechts-links -> Doppelrotation
        if (bf == 2 && GetBalanceFactor(node.Right) == -1)
        {
            node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }

        return node;
    }

    private AvlNode RotateRight(AvlNode unbalancedNode)
    {
        AvlNode newRoot = unbalancedNode.Left;
        AvlNode relocatedSubtree = newRoot.Right;

        newRoot.Right = unbalancedNode;
        unbalancedNode.Left = relocatedSubtree;

        unbalancedNode.Height = 1 + Math.Max(GetHeight(unbalancedNode.Left), GetHeight(unbalancedNode.Right));
        newRoot.Height = 1 + Math.Max(GetHeight(newRoot.Left), GetHeight(newRoot.Right));

        return newRoot;
    }

    private AvlNode RotateLeft(AvlNode unbalancedNode)
    {
        AvlNode newRoot = unbalancedNode.Right;
        AvlNode relocatedSubtree = newRoot.Left;

        newRoot.Left = unbalancedNode;
        unbalancedNode.Right = relocatedSubtree;

        unbalancedNode.Height = 1 + Math.Max(GetHeight(unbalancedNode.Left), GetHeight(unbalancedNode.Right));
        newRoot.Height = 1 + Math.Max(GetHeight(newRoot.Left), GetHeight(newRoot.Right));

        return newRoot;
    }
}
