using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// Problem 1: Encuentra pares simétricos en O(n) usando un HashSet.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var result = new List<string>();

        foreach (var w in words)
        {
            if (w.Length != 2 || w[0] == w[1]) 
                continue;

            // reverso de "ab" -> "ba"
            string rev = new string(new[] { w[1], w[0] });

            // si ya vimos "ba", guardamos "ba & ab"
            if (seen.Contains(rev))
                result.Add($"{rev} & {w}");

            seen.Add(w);
        }

        return result.ToArray();
    }

    /// <summary>
    /// Problem 2: Lee un archivo CSV sin cabecera y cuenta el campo de grado (columna 4, índice 3).
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');
            if (fields.Length < 4) 
                continue;

            string degree = fields[3].Trim();
            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    /// <summary>
    /// Problem 3: Determina si dos cadenas son anagramas (ignora espacios y mayúsculas).
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        Dictionary<char, int> CountLetters(string s)
        {
            var dict = new Dictionary<char, int>();
            foreach (char c in s.ToLower())
            {
                if (c == ' ') continue;
                if (dict.ContainsKey(c)) dict[c]++;
                else dict[c] = 1;
            }
            return dict;
        }

        var c1 = CountLetters(word1);
        var c2 = CountLetters(word2);

        if (c1.Count != c2.Count) 
            return false;

        foreach (var kv in c1)
        {
            if (!c2.TryGetValue(kv.Key, out int cnt) || cnt != kv.Value)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Problem 5: Descarga el JSON de sismos del día y retorna un arreglo de "Lugar - Mag X.Y".
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        using var response = client.Send(request);
        using var stream = response.Content.ReadAsStream();
        using var reader = new StreamReader(stream);
        string json = reader.ReadToEnd();

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var list = new List<string>();
        foreach (var feat in featureCollection.features)
        {
            list.Add($"{feat.properties.place} - Mag {feat.properties.mag}");
        }
        return list.ToArray();
    }
}
