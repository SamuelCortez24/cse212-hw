using System;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    /// <summary>
    /// Problem 1: Insert unique values only.
    /// Insert value into the BST subtree rooted at this node.
    /// If value equals this.Data, do nothing (no duplicates).
    /// </summary>
    public void Insert(int value)
    {
        // Prevent duplicates: if equal, do nothing.
        if (value == Data)
            return;

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else // value > Data
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    /// <summary>
    /// Problem 2: Contains (recursive).
    /// Return true if value exists in subtree rooted at this node.
    /// </summary>
    public bool Contains(int value)
    {
        if (value == Data)
            return true;

        if (value < Data)
            return Left is not null && Left.Contains(value);

        // value > Data
        return Right is not null && Right.Contains(value);
    }

    /// <summary>
    /// Problem 4: GetHeight (recursive).
    /// Height of a node is 1 + max(height(left), height(right)).
    /// If node has no children, height = 1.
    /// </summary>
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
