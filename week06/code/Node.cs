public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // If the value is equal to the node's data, do nothing to prevent duplicates.
        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // If the value matches the current node's data, we found it.
        if (value == Data)
        {
            return true;
        }
        // If the value is less, search the left subtree.
        else if (value < Data)
        {
            // If the left child exists, call Contains on it. Otherwise, it's not in the tree.
            if (Left is not null)
            {
                return Left.Contains(value);
            }
            else
            {
                return false;
            }
        }
        // If the value is greater, search the right subtree.
        else
        {
            // If the right child exists, call Contains on it. Otherwise, it's not in the tree.
            if (Right is not null)
            {
                return Right.Contains(value);
            }
            else
            {
                return false;
            }
        }
    }
    public int GetHeight()
    {
        int leftHeight = (Left is null) ? 0 : Left.GetHeight();
        int rightHeight = (Right is null) ? 0 : Right.GetHeight();
        
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}