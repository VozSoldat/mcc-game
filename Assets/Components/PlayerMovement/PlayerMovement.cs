using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    // private Vector3 inputDirection;
    private MovementInput movementInput;
    private Player playerStats;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerStats = GetComponent<Player>();
        movementInput = GetComponent<MovementInput>();
    }
    private void FixedUpdate()
    {
        Walk();
    }

    void Walk()
    {
        rb.velocity = movementInput.InputDirection * playerStats.MovementSpeed * Time.fixedDeltaTime;
    }
}