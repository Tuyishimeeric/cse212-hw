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

        return multiples;
    }
}

   
   public class Lists
{
    public static List<int> RotateListRight(List<int> data, int amount)
    {
        if (data == null || data.Count == 0)
        {
            throw new ArgumentException("Data list cannot be null or empty.");
        }

        if (amount < 1 || amount > data.Count)
        {
            throw new ArgumentException("Amount must be between 1 and the size of the list.");
        }

        amount = amount % data.Count;
        List<int> rotatedPart = data.GetRange(data.Count - amount, amount);
        List<int> remainingPart = data.GetRange(0, data.Count - amount);
        rotatedPart.AddRange(remainingPart);
        return rotatedPart;
    }
}