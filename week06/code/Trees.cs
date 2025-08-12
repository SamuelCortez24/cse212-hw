public static class Trees
{
    /// <summary>
    /// Given a sorted list (sortedNumbers), create a balanced BST.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree(); // Create an empty BST to start with 
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// Problem 5: InsertMiddle recursively inserts the middle element of the
    /// subarray [first..last], then recurses on left and right halves.
    /// </summary>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        if (first > last)
            return;

        int mid = (first + last) / 2;
        bst.Insert(sortedNumbers[mid]);

        // Insert middle of left half
        InsertMiddle(sortedNumbers, first, mid - 1, bst);

        // Insert middle of right half
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}
