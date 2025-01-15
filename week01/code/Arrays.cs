public static class Arrays
{
 public static double[] MultiplesOf(double startingNumber, int numberOfMultiples)
    {
        // Step 1: Validate inputs
        if (numberOfMultiples <= 0)
        {
            throw new ArgumentException("Number of multiples must be greater than 0.");
        }

        // Step 2: Initialize the result array
        double[] multiples = new double[numberOfMultiples];

        // Step 3: Calculate each multiple
        for (int i = 0; i < numberOfMultiples; i++)
        {
            // The ith multiple is startingNumber * (i + 1)
            multiples[i] = startingNumber * (i + 1);
        }
        //step4: return the result array
        return multiples;
    }
}

public class Lists
{
    // Function to rotate a list to the right by a specified amount
    public static List<int> RotateListRight(List<int> data, int amount)
    {
        // Step 1: Validate inputs
        // Check if the list is null or empty. If so, no rotation is possible.
        if (data == null || data.Count == 0)
        {
            throw new ArgumentException("Data list cannot be null or empty.");
        }

        // Step 2: Normalize the rotation amount
        // If the rotation amount is greater than the size of the list, use modulo to avoid unnecessary rotations.
        amount = amount % data.Count;

        // If the rotation amount is 0, return a new copy of the list since no rotation is needed.
        if (amount == 0)
        {
            return new List<int>(data); // Copy the list to avoid modifying the original.
        }

        // Step 3: Split the list into two parts
        // The first part will be the last `amount` elements from the list (this will come to the front).
        List<int> rotatedPart = data.GetRange(data.Count - amount, amount);

        // The second part will be the remaining elements (everything except the last `amount`).
        List<int> remainingPart = data.GetRange(0, data.Count - amount);

        // Step 4: Combine the two parts
        // Append the remaining part after the rotated part to get the rotated list.
        rotatedPart.AddRange(remainingPart);

        // Step 5: Return the rotated list
        return rotatedPart;
    }
}
