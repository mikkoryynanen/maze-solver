using Maze.Models;

namespace Maze.Solvers;

public interface IMazeSolver
{
    /// <summary>
    /// Solves the given lines in a Maze
    /// </summary>
    /// <param name="lines">Loaded lines from .txt file</param>
    /// <returns>New solved lines.</returns>
    string[] Solve(string[] lines);
}