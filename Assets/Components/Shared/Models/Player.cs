using UnityEngine;

public class Player: MonoBehaviour{
    [SerializeField] private float movementSpeed = 100;
    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
}