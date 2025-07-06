public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        double[] multiples = new double[length]; // Step 1: Create an array of size 'length'

        for (int i = 0; i < length; i++) // Step 2: Traverse the array from 0 to length - 1
        {
            multiples[i] = number * (i + 1); // Step 3: At position i, enter the corresponding multiple:
// The first multiple is number * 1, the second number * 2, etc.
        }

        return multiples; // Step 4: Return the array with all the calculated multiples
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 
    /// then the list after the function runs should be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// This function modifies the existing list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        int listCount = data.Count; // Step 1: Get the number of elements in the list
        int rotation = amount % listCount;  // Step 2: Calculate the effective rotation (if amount == listCount, it's zero)

        if (rotation == 0) // Step 3: If the rotation is zero, do nothing, exit
        {
            return; 
        }

        // Step 4: Get the last rotation elements from the list
        List<int> tail = data.GetRange(listCount - rotation, rotation);

        // Step 5: Get the remaining elements (the first ones left)
        List<int> head = data.GetRange(0, listCount - rotation);

        // Step 6: Clear the original list to fill it with the rotated order
        data.Clear();
        // Step 7: Add the tail (last elements) to the head first
        data.AddRange(tail);
        // Step 8: Add the remaining head afterward
        data.AddRange(head);
    }
}
