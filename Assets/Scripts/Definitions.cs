using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GameSettings
{
    public const float DRAG_TOWARDS_SPEED = 7.5f;
    public const float GO_BACK_TIME = 0.2f;
    public enum Colors
    {
        Blue,
        Green,
        Purple,
        Yellow
    }
    
    public enum Shapes
    {
        Square,
        Circle,
        Pentagon,
        Triangle
    }
}
