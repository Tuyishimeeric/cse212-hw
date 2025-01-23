using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>();
        var result = new List<string>();

        foreach (var word in words)
        {
            var reversed = new string(word.Reverse().ToArray());

            if (wordSet.Contains(reversed) && word != reversed)
            {
                result.Add($"{reversed} & {word}");
            }

            wordSet.Add(word);
        }

        return result.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            
            if (fields.Length < 4) continue;

            var degree = fields[3].Trim();

            if (!string.IsNullOrEmpty(degree))
            {
                if (degrees.ContainsKey(degree))
                    degrees[degree]++;
                else
                    degrees[degree] = 1;
            }
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length) return false;

        var letterCount = new Dictionary<char, int>();

        foreach (var ch in word1)
        {
            if (letterCount.ContainsKey(ch))
                letterCount[ch]++;
            else
                letterCount[ch] = 1;
        }

        foreach (var ch in word2)
        {
            if (!letterCount.ContainsKey(ch)) return false;
            letterCount[ch]--;
        }

        return letterCount.Values.All(count => count == 0);
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        try
        {
            using var client = new HttpClient();
            using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
            using var reader = new StreamReader(jsonStream);

            var json = reader.ReadToEnd();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

            var result = featureCollection.Features
                .Where(f => f.Properties.Place != null && f.Properties.Mag >= 0)
                .Select(f => $"{f.Properties.Place} - Magnitude: {f.Properties.Mag}")
                .ToArray();

            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching earthquake data: {ex.Message}");
            return Array.Empty<string>();  // Return an empty array if an error occurs
        }
    }
}