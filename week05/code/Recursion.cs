using System;
using System.Collections.Generic;

public static class Recursion
{
    /// <summary>
    /// Problem 1: Sum of squares recursively
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: Permutations of length size from letters
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }
        for (int i = 0; i < letters.Length; i++)
        {
            char c = letters[i];
            string remaining = letters.Substring(0, i) + letters.Substring(i + 1);
            PermutationsChoose(results, remaining, size, word + c);
        }
    }

    /// <summary>
    /// Problem 3: Count ways to climb s stairs with 1,2,3 steps, using memoization
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (remember.ContainsKey(s))
            return remember[s];

        decimal result;
        if (s <= 0)
        {
            result = 0;
        }
        else if (s == 1)
        {
            result = 1;
        }
        else if (s == 2)
        {
            result = 2;
        }
        else if (s == 3)
        {
            result = 4;
        }
        else
        {
            result = CountWaysToClimb(s - 1, remember)
                   + CountWaysToClimb(s - 2, remember)
                   + CountWaysToClimb(s - 3, remember);
        }
        remember[s] = result;
        return result;
    }

    /// <summary>
    /// Problem 4: Wildcard binary patterns
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int idx = pattern.IndexOf('*');
        if (idx < 0)
        {
            // No wildcard, just add the string (or empty)
            results.Add(pattern);
            return;
        }
        // Replace wildcard with '0'
        WildcardBinary(pattern.Substring(0, idx) + '0' + pattern.Substring(idx + 1), results);
        // Replace wildcard with '1'
        WildcardBinary(pattern.Substring(0, idx) + '1' + pattern.Substring(idx + 1), results);
    }

    /// <summary>
    /// Problem 5: Solve maze - find all paths
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<(int, int)>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<(int, int)>();

        if (!maze.IsValidMove(currPath, x, y))
            return;

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            SolveMaze(results, maze, x + 1, y, currPath);
            SolveMaze(results, maze, x, y + 1, currPath);
            SolveMaze(results, maze, x - 1, y, currPath);
            SolveMaze(results, maze, x, y - 1, currPath);
        }

        currPath.RemoveAt(currPath.Count - 1);
    }
}
