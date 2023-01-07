using Maze.Models;

namespace Maze.Solvers;

public class RecursiveSolver : IMazeSolver
{
    private static Maze.Models.Maze maze;
    private static Tile[,] foundPath;
    static int moves = 0;

    readonly int maxMoves = 0;

    public RecursiveSolver(Maze.Models.Maze _maze, int _maxMoves)
    {
        maze = _maze;
        maxMoves = _maxMoves;

        foundPath = new Tile[maze.width, maze.height];
    }

    public string[] Solve(string[] lines)
    {
        var solved = RecursiveSolve(maze.exitTile, maze.startingTile.posX, maze.startingTile.posY) && moves < maxMoves;
        if (!solved)
        {
            return Array.Empty<string>();
        }
        else
        {
            List<string> newLines = new List<string>();
            for (int y = 0; y < lines.Length; y++)
            {
                string line = lines[y];
                string newLine = string.Empty;
                for (int x = 0; x < line.Length; x++)
                {
                    if (maze.tiles[x, y].Equals(foundPath[x, y]) && foundPath[x, y].character != Constants.ExitChar)
                    {
                        newLine += Constants.SolvedPathChar;
                    }
                    else
                    {
                        newLine += line[x];
                    }
                }

                newLines.Add(newLine);
            }

            return newLines.ToArray();
        }
    }

    static bool RecursiveSolve(Tile targetTile, int x, int y)
    {
        if (x == targetTile.posX && y == targetTile.posY) return true;
        if (maze.tiles[x, y].visited) return false;

        // Check for walls
        if (maze.tiles[x, y].character == Constants.WallChar) return false;

        maze.tiles[x, y].visited = true;

        // Check if not on left edge
        if (x != 0)
        {
            if (RecursiveSolve(targetTile, x - 1, y))
            {
                foundPath[x - 1, y] = maze.tiles[x - 1, y];
                moves++;
                return true;
            }
        }

        // Check if not on right edge
        if (x != maze.width - 1)
        {
            if (RecursiveSolve(targetTile, x + 1, y))
            {
                foundPath[x + 1, y] = maze.tiles[x + 1, y];
                moves++;
                return true;
            }
        }

        // Chekcs if not on top edge
        if (y != 0)
        {
            if (RecursiveSolve(targetTile, x, y - 1))
            {
                foundPath[x, y - 1] = maze.tiles[x, y - 1];
                moves++;
                return true;
            }
        }

        // Checks if not on bottom edge
        if (y != maze.height - 1)
        {
            if (RecursiveSolve(targetTile, x, y + 1))
            {
                foundPath[x, y + 1] = maze.tiles[x, y + 1];
                moves++;
                return true;
            }
        }

        return false;
    }
}