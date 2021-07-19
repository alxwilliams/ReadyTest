using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GameSettings
{
    public const float DRAG_TOWARDS_SPEED = 14f;
    public const float GO_BACK_TIME = 0.2f;
    public const float GO_IN_SLOT_TIME = 0.05f;
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
