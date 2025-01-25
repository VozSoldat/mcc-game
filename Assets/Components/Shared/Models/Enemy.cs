using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IEntity
{
    // [SerializeField] private float movementSpeed = 100;
    // [SerializeField] private int health = 0;
    [SerializeField]
    private int acidity = 0;

    // public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
    public int Acidity
    {
        get => acidity;
        set => acidity = Math.Clamp(value, -7, 7);
    }
    // public int Health { get => health; set => health = Math.Clamp(value, 0, 100); }
}

