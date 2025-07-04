using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number'
    /// followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan for solving this problem:
        // 1. Create a new array of type double with size 'length'.
        // 2. Use a loop from i = 0 to length - 1.
        //    a. For each i, calculate number * (i + 1).
        //    b. Assign the result to the i-th index in the array.
        // 3. Return the filled array.

        double[] results = new double[length];
        for (int i = 0; i < length; i++)
        {
            results[i] = number * (i + 1);
        }
        return results;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is {1, 2, 3, 4, 5, 6, 7, 8, 9} and amount is 3, the result is:
    /// {7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// The list is modified in place.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan for solving this problem:
        // 1. Get the count of the list (n).
        // 2. Normalize the amount: amount = amount % n.
        // 3. Use GetRange to slice the last 'amount' elements as 'tail'.
        // 4. Use GetRange to slice the first 'n - amount' elements as 'head'.
        // 5. Clear the list.
        // 6. AddRange(tail) and then AddRange(head) to rebuild the list rotated.

        int n = data.Count;
        int r = amount % n;

        List<int> tail = data.GetRange(n - r, r);
        List<int> head = data.GetRange(0, n - r);

        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}
