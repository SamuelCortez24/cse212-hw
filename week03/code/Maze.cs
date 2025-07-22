using System;
using System.Collections.Generic;

public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    public void MoveLeft()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out var dirs) || !dirs[0])
            throw new InvalidOperationException("Can't go that way!");
        _currX--;
    }

    public void MoveRight()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out var dirs) || !dirs[1])
            throw new InvalidOperationException("Can't go that way!");
        _currX++;
    }

    public void MoveUp()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out var dirs) || !dirs[2])
            throw new InvalidOperationException("Can't go that way!");
        _currY--;
    }

    public void MoveDown()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out var dirs) || !dirs[3])
            throw new InvalidOperationException("Can't go that way!");
        _currY++;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
