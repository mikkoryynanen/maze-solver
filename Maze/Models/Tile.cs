namespace Maze.Models;

public struct Tile
{
    public readonly int posX;
    public readonly int posY;
    public readonly char character;

    public bool visited = false;

    public Tile(char _character, int _x, int _y)
    {
        posX = _x;
        posY = _y;
        character = _character;
    }
}