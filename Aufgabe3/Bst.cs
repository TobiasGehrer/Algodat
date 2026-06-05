namespace Aufgabe3;

public class Bst
{
    public BstNode Root { get; set;  }

    public void Print(BstNode node, int indent = 0)
    {
        if (node is null)
        {
            return;
        }

        Print(node.Right, indent + 4);
        Console.WriteLine(new string(' ', indent) + node.Value);
        Print(node.Left, indent + 4);
    }

    public void Insert(int newValue)
    {
        Root = Insert(Root, newValue);
    }

    public BstNode Search(int value)
    {
        return Search(Root, value);
    }

    public BstNode Minimum()
    {
        return Minimum(Root);
    }

    public BstNode Maximum()
    {
        return Maximum(Root);
    }

    public BstNode Successor(int value)
    {
        return Successor(Search(Root, value));
    }

    public BstNode Predecessor(int value)
    {
        return Predecessor(Search(Root, value));
    }

    public void Remove(int value)
    {
        Remove(Root, Search(Root, value));
    }

    public List<BstNode> Traverse()
    {
        var result = new List<BstNode>();
        InOrderTraversal(Root, result);
        return result;
    }

    private BstNode Insert(BstNode node, int newValue)
    {
        if (node is null)
        {
            return new BstNode(newValue);
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
        
        return node;
    }

    private BstNode Search(BstNode node, int value)
    {
        if (node.Value == value)
        {
            return node;
        }

        if (value < node.Value)
        {
            if (node.Left is null)
            {
                return null;
            }
            else
            {
                return Search(node.Left, value);
            }
        }
        else
        {
            if (node.Right is null)
            {
                return null;
            }
            else
            {
                return Search(node.Right, value);
            }
        }       
    }

    private BstNode Minimum(BstNode node)
    {
        if (node.Left is null)
        {
            return node;
        }
        else
        {
            return Minimum(node.Left);
        }
    }

    private BstNode Maximum(BstNode node)
    {
        if (node.Right is null)
        {
            return node;
        }
        else
        {
            return Maximum(node.Right);
        }
    }

    private BstNode Successor(BstNode node)
    {
        // Fall 1: rechtes Kind vorhanden
        if (node.Right is not null)
        {
            return Minimum(node.Right);
        }
        // Fall 2: Pfad zur Wurzel
        else
        {
            BstNode parent = node.Parent;

            while (parent is not null && parent.Right == node)
            {
                node = parent;
                parent = node.Parent;
            }

            return parent;
        }
    }

    private BstNode Predecessor(BstNode node)
    {
        // Fall 1: linkes Kind vorhanden
        if (node.Left is not null)
        {
            return Maximum(node.Left);
        }
        // Fall 2: Pfad zur Wurzel
        else
        {
            BstNode parent = node.Parent;

            while (parent is not null && parent.Left == node)
            {
                node = parent;
                parent = node.Parent;
            }

            return parent;
        }
    }

    private void Remove(BstNode root, BstNode node)
    {
        // Fall 1: kein Kind
        if (node.Left is null && node.Right is null)
        {
            if (node.Parent.Right == node)
            {
                node.Parent.Right = null;
            }
            else
            {
                node.Parent.Left = null;
            }
        }
        // Fall 2a: nur rechtes Kind
        else if (node.Left is null)
        {
            if (node.Parent.Right == node)
            {
                node.Parent.Right = node.Right;
            }
            else
            {
                node.Parent.Left = node.Right;
            }
        }
        // Fall 2b: nur linkes Kind
        else if (node.Right is null)
        {
            if (node.Parent.Right == node)
            {
                node.Parent.Right = node.Left;
            }
            else
            {
                node.Parent.Left = node.Left;
            }
        }
        // Fall 3: zwei Kinder
        else
        {
            BstNode replaceNode = Successor(node);
            node.Value = replaceNode.Value;

            if (replaceNode.Parent == node)
            {
                replaceNode.Parent.Right = replaceNode.Right;
            }
            else
            {
                replaceNode.Parent.Left = replaceNode.Right;
            }
        }
    }

    private void InOrderTraversal(BstNode node, List<BstNode> result)
    {
        if (node is not null)
        {
            InOrderTraversal(node.Left, result);
            result.Add(node);
            InOrderTraversal(node.Right, result);
        }
    }
}
