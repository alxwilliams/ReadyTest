using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private GameSettings.Shapes _shape;
    [SerializeField] private GameSettings.Colors _color;
    private BoxCollider2D collider;

    public GameSettings.Colors Color => _color; 
    public GameSettings.Shapes Shape => _shape;
    public BoxCollider2D Collider => collider;

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }
}
