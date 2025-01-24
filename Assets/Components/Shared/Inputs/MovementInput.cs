using UnityEngine;

public class MovementInput : MonoBehaviour{
    public Vector3 InputDirection{get => inputDirection; set => inputDirection = value;}
    private Vector3 inputDirection;

    private void Update() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        inputDirection = new Vector3(horizontal, 0, vertical).normalized;
    }
}