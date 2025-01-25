using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorTube : MonoBehaviour
{
    [SerializeField] private int health = 0;
    public int Health { get => health; set => health = Math.Clamp(value, 0, 100); } 
}
