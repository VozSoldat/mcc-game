using System;
using UnityEngine;

public class BubbleReactor : MonoBehaviour
{
    [SerializeField] private int acidity = 0;
    public int Acidity { get => acidity; set => acidity = Math.Clamp(value, -7, 7); }
}