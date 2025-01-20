public static class Arrays
{
    public static double[] MultiplesOf(double number, int length)
    {
        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1); // (i+1) gives the correct multiple
        }

        return result;
    }

    public static void RotateListRight(List<int> data, int amount)
    {
        amount = amount % data.Count;

        List<int> rotatedPart = data.Skip(data.Count - amount).Take(amount).ToList();
        List<int> remainingPart = data.Take(data.Count - amount).ToList();

        data.Clear();
        data.AddRange(rotatedPart);
        data.AddRange(remainingPart);
    }
}
