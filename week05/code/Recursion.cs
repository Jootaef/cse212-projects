using System;
using System.Collections.Generic;

public static class Recursion
{
    // Problem 1: Recursive Squares Sum
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0) return 0;
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    // Problem 2: Permutations Choose
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }
        
        foreach (char letter in letters)
        {
            if (!word.Contains(letter))
            {
                PermutationsChoose(results, letters, size, word + letter);
            }
        }
    }

    // Problem 3: Climbing Stairs with Memoization
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null) remember = new Dictionary<int, decimal>();
        if (s < 0) return 0;
        if (s == 0) return 1;
        if (remember.ContainsKey(s)) return remember[s];
        
        remember[s] = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
        return remember[s];
    }

    // Problem 4: Wildcard Binary Patterns
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int wildcardPos = pattern.IndexOf('*');
        if (wildcardPos == -1)
        {
            results.Add(pattern);
            return;
        }

        WildcardBinary(pattern.Substring(0, wildcardPos) + "0" + pattern.Substring(wildcardPos + 1), results);
        WildcardBinary(pattern.Substring(0, wildcardPos) + "1" + pattern.Substring(wildcardPos + 1), results);
    }

    // Problem 5: Solve Maze
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<(int, int)>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<(int, int)>();

        if (!maze.IsValidMove(currPath, x, y)) return;

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add("<List>{" + string.Join(", ", currPath) + "}");
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        List<(int, int)> newPath = new List<(int, int)>(currPath);

        SolveMaze(results, maze, x + 1, y, new List<(int, int)>(newPath)); // Move Right
        SolveMaze(results, maze, x, y + 1, new List<(int, int)>(newPath)); // Move Down
        SolveMaze(results, maze, x - 1, y, new List<(int, int)>(newPath)); // Move Left
        SolveMaze(results, maze, x, y - 1, new List<(int, int)>(newPath)); // Move Up

        currPath.RemoveAt(currPath.Count - 1);
    }
}