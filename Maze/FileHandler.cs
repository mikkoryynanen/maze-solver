using System;
using Maze.Models;

public class FileHandler
{
    /// <summary>
    /// Loads lines from given .txt file
    /// </summary>
    /// <param name="filePath">Path to file</param>
    /// <returns>Loaded lines from file</returns>
    public static async Task<string[]> LoadLinesAsync(string filePath)
    {
        try
        {
            // TODO Find a better place to load files from
            // This assumes that the file in present in bin folder
            return await File.ReadAllLinesAsync(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not load file in {filePath}");
            return Array.Empty<string>();
        }
    }

    /// <summary>
    /// Writes all lines to file
    /// </summary>
    /// <param name="lines">Lines to save</param>
    /// <param name="filePath">Path to file</param>
    public static async Task SaveLinesAsync(string[] lines, string filePath)
    {
        try
        {
            await File.WriteAllLinesAsync(filePath, lines);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to save lines to file in path {filePath}");
        }
    }
}