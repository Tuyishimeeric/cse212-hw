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
            // Make the HTTP request and retrieve the JSON string
            using var client = new HttpClient();
            var json = client.GetStringAsync(uri).Result;

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

            // Filter and format the earthquake data
            var result = featureCollection.Features
                .Where(f => f.Properties.Place != null && f.Properties.Mag.HasValue)
                .Select(f => $"{f.Properties.Place} - Mag {f.Properties.Mag}")
                .ToArray();

            // Debugging: Log the result length and first few results for validation
            Console.WriteLine($"Total earthquakes found: {result.Length}");
            for (int i = 0; i < Math.Min(result.Length, 5); i++)
            {
                Console.WriteLine($"Earthquake {i + 1}: {result[i]}");
            }

            // Ensure there are at least 5 results
            if (result.Length < 5)
            {
                throw new InvalidOperationException("Not enough earthquakes returned.");
            }

            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching earthquake data: {ex.Message}");
            return Array.Empty<string>();  // Return an empty array if an error occurs
        }
    }

    // Classes for deserializing the JSON response
    public class FeatureCollection
    {
        public Feature[] Features { get; set; }
    }

    public class Feature
    {
        public FeatureProperties Properties { get; set; }
    }

    public class FeatureProperties
    {
        public string Place { get; set; }
        public double? Mag { get; set; }
    }
}