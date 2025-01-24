using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IEntity
{
    [SerializeField] private float movementSpeed = 100;
    [SerializeField] private int health = 0;
    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
    public int Health { get => health; set => health = Math.Clamp(value, 0, 100); }
}