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
        if (data == null || data.Count == 0)
        {
            throw new ArgumentException("Data list cannot be null or empty.");
        }

        if (amount < 1 || amount > data.Count)
        {
            throw new ArgumentException("Amount must be between 1 and the size of the list.");
        }

        // Step 2: Normalize the rotation amount
        amount = amount % data.Count;

        // Step 3: Split the list
        // The rotated part (last `amount` elements) and the remaining part
        List<int> rotatedPart = data.GetRange(data.Count - amount, amount);
        List<int> remainingPart = data.GetRange(0, data.Count - amount);

        // Step 4: Combine the rotated part and the remaining part
        rotatedPart.AddRange(remainingPart);

        // Step 5: Return the result
        return rotatedPart;
    }
}