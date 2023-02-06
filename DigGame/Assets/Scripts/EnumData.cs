using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TileType
{
    Null = 0,
    Sand = 50,
    Ground = 100,
    DarkGound = 200,
    Gravel = 300,
    Obstacle = 400,
}

public enum Direction
{
    Null = 0,
    Left = 100,
    Right = 200,
    Up = 300,
    Down = 400,
}

public enum ItemType
{ 
    Null = 0,
    Time = 100, 
    food = 200, 
    DigSpeed = 300, 
    RunSpeed = 400, 
    Bomb = 500,
}