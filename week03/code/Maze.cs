public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        if (mazeMap == null || !mazeMap.Any())
        {
            throw new ArgumentException("Maze map cannot be null or empty.");
        }

        foreach (var entry in mazeMap)
        {
            if (entry.Value.Length != 4)
            {
                throw new ArgumentException("Each entry in the maze map must have 4 boolean values (left, right, up, down).");
            }
        }

        _mazeMap = mazeMap;
    }

    private void ValidateCurrentPosition()
    {
        if (!_mazeMap.ContainsKey((_currX, _currY)))
        {
            throw new InvalidOperationException("Invalid position in the maze.");
        }
    }

    public void MoveLeft()
    {
        ValidateCurrentPosition();
        if (!_mazeMap[(_currX, _currY)][0])
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        _currX -= 1; // Move left
    }

    public void MoveRight()
    {
        ValidateCurrentPosition();
        if (!_mazeMap[(_currX, _currY)][1])
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        _currX += 1; // Move right
    }

    public void MoveUp()
    {
        ValidateCurrentPosition();
        if (!_mazeMap[(_currX, _currY)][2])
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        _currY -= 1; // Move up
    }

    public void MoveDown()
    {
        ValidateCurrentPosition();
        if (!_mazeMap[(_currX, _currY)][3])
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        _currY += 1; // Move down
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
