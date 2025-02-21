public static class Trees
{
    /// <summary>
    /// Given a sorted list (sorted_list), create a balanced BST.  
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree(); // Create an empty BST to start with
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// This function will attempt to insert the item in the middle of 'sortedNumbers' into
    /// the 'bst' tree. The middle is determined by using indices represented by 'first' and
    /// 'last'.
    /// </summary>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        if (first > last) return; // Base case: no elements to insert

        // Find the middle element
        int middle = first + (last - first) / 2;
        
        // Insert the middle element into the BST
        bst.Insert(sortedNumbers[middle]);

        // Recursively insert elements from the left and right halves
        InsertMiddle(sortedNumbers, first, middle - 1, bst); // Left half
        InsertMiddle(sortedNumbers, middle + 1, last, bst); // Right half
    }
}
