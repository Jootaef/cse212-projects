using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}. Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array to hold the multiples.
        double[] multiples = new double[length];

        // Step 2: Use a loop to calculate each multiple.
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1); // Calculate the multiple based on the index.
        }

        // Step 3: Return the array of multiples.
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'. For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}. The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Determine the effective rotation amount using modulo to handle wrapping.
        int rotation = amount % data.Count;

        // Step 2: Slice the list into two parts using GetRange.
        List<int> lastPart = data.GetRange(data.Count - rotation, rotation); // Last 'rotation' elements.
        List<int> firstPart = data.GetRange(0, data.Count - rotation);       // Remaining elements.

        // Step 3: Clear the original list and rebuild it in rotated order.
        data.Clear();
        data.AddRange(lastPart); // Add the last part first.
        data.AddRange(firstPart); // Add the first part after.
    }
}
