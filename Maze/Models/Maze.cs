namespace Maze.Models;

public sealed class Maze
{
    public readonly Tile[,] tiles;
    public readonly Tile startingTile;
    public readonly Tile exitTile;
    public readonly int width;
    public readonly int height;

    public Maze(string[] _lines)
    {
        width = _lines[0].Length;
        height = _lines.Length;
        Tile[,] maze = new Tile[width, height];

        for (int y = 0; y < _lines.Length; y++)
        {
            string line = _lines[y];
            for (int x = 0; x < line.Length; x++)
            {
                char currentChar = line[x];
                Tile tile = new Tile(currentChar, x, y);

                switch (currentChar)
                {
                    case Constants.StartingPositionChar:
                        startingTile = tile;
                        break;
                    case Constants.ExitChar:
                        exitTile = tile;
                        break;
                }

                maze[x, y] = tile;
            }
        }

        tiles = maze;
    }
}

