/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>

   public void MoveLeft()
    {
        if (CanMove(0)) // Check if left (index 0) is valid
        {
            _currX--; // Move left
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    // Move Right
    public void MoveRight()
    {
        if (CanMove(1)) // Check if right (index 1) is valid
        {
            _currX++; // Move right
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    // Move Up
    public void MoveUp()
    {
        if (CanMove(2)) // Check if up (index 2) is valid
        {
            _currY--; // Move up
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    // Move Down
    public void MoveDown()
    {
        if (CanMove(3)) // Check if down (index 3) is valid
        {
            _currY++; // Move down
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    // Check if a move is valid in a given direction (index)
    private bool CanMove(int directionIndex)
    {
        bool canMove = false;

        // Check if current position is in the maze map
        if (_mazeMap.ContainsKey((_currX, _currY)))
        {
            // Check if the direction is valid (true means movement is allowed)
            canMove = _mazeMap[(_currX, _currY)][directionIndex];
        }

        return canMove;
    }

    // Return the current status of the position
    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}