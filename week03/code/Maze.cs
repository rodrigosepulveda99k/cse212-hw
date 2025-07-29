using System; // Required for InvalidOperationException
using System.Collections.Generic;

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
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    // The maze representation: key is (x,y) coordinate, value is a bool array representing
    // [left, right, up, down] validity.
    // Index mapping: 0=left, 1=right, 2=up, 3=down
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX; // Initialized to 1, but could be set via a constructor if needed
    private int _currY; // Initialized to 1

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
        // Optionally, you might want to set initial _currX and _currY
        // based on a starting point in the mazeMap, or pass it as a parameter
        // For this problem, we'll stick with the default 1,1.
        _currX = 1;
        _currY = 1;

        // Ensure the starting position exists in the maze map
        if (!_mazeMap.ContainsKey((_currX, _currY)))
        {
            throw new ArgumentException("Initial position (1,1) not found in maze map.");
        }
    }

    // Public properties to expose current position for checking
    public int CurrentX => _currX;
    public int CurrentY => _currY;


    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        var currentPosition = (_currX, _currY);
        if (_mazeMap.TryGetValue(currentPosition, out var movements))
        {
            // Index 0 for left
            if (movements[0])
            {
                _currX--;
            }
            else
            {
                throw new InvalidOperationException("Can't go that way!");
            }
        }
        else
        {
            // This case implies we are at a position not defined in the maze,
            // which shouldn't happen if the maze is well-formed and current position is always valid.
            // For robustness, we could also throw here or log an error.
            throw new InvalidOperationException("Current position not defined in maze map!");
        }
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        var currentPosition = (_currX, _currY);
        if (_mazeMap.TryGetValue(currentPosition, out var movements))
        {
            // Index 1 for right
            if (movements[1])
            {
                _currX++;
            }
            else
            {
                throw new InvalidOperationException("Can't go that way!");
            }
        }
        else
        {
            throw new InvalidOperationException("Current position not defined in maze map!");
        }
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        var currentPosition = (_currX, _currY);
        if (_mazeMap.TryGetValue(currentPosition, out var movements))
        {
            // Index 2 for up
            if (movements[2])
            {
                _currY++;
            }
            else
            {
                throw new InvalidOperationException("Can't go that way!");
            }
        }
        else
        {
            throw new InvalidOperationException("Current position not defined in maze map!");
        }
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        var currentPosition = (_currX, _currY);
        if (_mazeMap.TryGetValue(currentPosition, out var movements))
        {
            // Index 3 for down
            if (movements[3])
            {
                _currY--;
            }
            else
            {
                throw new InvalidOperationException("Can't go that way!");
            }
        }
        else
        {
            throw new InvalidOperationException("Current position not defined in maze map!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}

// Example Usage 
/*
public class MazeTest
{
    public static void Main(string[] args)
    {
        // Define a sample maze based on the new bool[] structure: [left, right, up, down]
        var sampleMazeMap = new Dictionary<ValueTuple<int, int>, bool[]>
        {
            // (x,y) : [left, right, up, down]
            { (1, 1), new bool[] { false, true, true, false } }, // From (1,1): Can go Right, Up
            { (2, 1), new bool[] { true, false, true, false } }, // From (2,1): Can go Left, Up
            { (1, 2), new bool[] { false, true, false, true } }, // From (1,2): Can go Right, Down
            { (2, 2), new bool[] { true, false, false, true } }  // From (2,2): Can go Left, Down
        };

        var maze = new Maze(sampleMazeMap);
        Console.WriteLine(maze.GetStatus()); // Expected: Current location (x=1, y=1)

        try
        {
            maze.MoveLeft(); // Try to move left from (1,1) - should throw
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine($"Error: {e.Message}"); // Expected: Error: Can't go that way!
        }
        Console.WriteLine(maze.GetStatus()); // Expected: Current location (x=1, y=1)

        try
        {
            maze.MoveRight(); // Move right from (1,1) to (2,1)
            Console.WriteLine(maze.GetStatus()); // Expected: Current location (x=2, y=1)

            maze.MoveUp(); // Move up from (2,1) to (2,2)
            Console.WriteLine(maze.GetStatus()); // Expected: Current location (x=2, y=2)

            maze.MoveLeft(); // Move left from (2,2) to (1,2)
            Console.WriteLine(maze.GetStatus()); // Expected: Current location (x=1, y=2)

            maze.MoveDown(); // Move down from (1,2) to (1,1)
            Console.WriteLine(maze.GetStatus()); // Expected: Current location (x=1, y=1)

            maze.MoveUp(); // Move up from (1,1) to (1,2)
            Console.WriteLine(maze.GetStatus()); // Expected: Current location (x=1, y=2)

            maze.MoveRight(); // Move right from (1,2) to (2,2)
            Console.WriteLine(maze.GetStatus()); // Expected: Current location (x=2, y=2)

            maze.MoveUp(); // Try to move up from (2,2) - should throw
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine($"Error: {e.Message}"); // Expected: Error: Can't go that way!
        }
        Console.WriteLine(maze.GetStatus()); // Expected: Current location (x=2, y=2)
    }
}
*/